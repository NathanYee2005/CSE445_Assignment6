//Author: Ahmed Almoshawer
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace WcfServices
{
    public class Service1 : IService1
    {
        // ===== Template methods (keep) =====
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null) throw new ArgumentNullException("composite");
            if (composite.BoolValue) composite.StringValue += "Suffix";
            return composite;
        }

        // ===== A3: Required/Elective services =====

        // Stop word set (extended with common page chrome tokens)
        private static readonly HashSet<string> StopWords =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "a","an","the","is","are","am","in","on","of","for","to","and","or","but","be","been","being",
            "by","with","as","at","from","that","this","these","those","it","its","into","about","over",
            "under","up","down","out","off","so","than","then","too","very","can","cannot","could","should",
            "would","will","shall","do","does","did","done","have","has","had","i","you","he","she","we","they",
            "was","were","not","no","yes","if","else","when","while","where","which","who","whom","what","why","how",
            "http","https","url","json","null","true","false","width","height","typename","paragraphblock",
            "nyt","wsjtheme","com"
        };

        // Removes script/style blocks, URLs, tags; filters stop words; normalizes tokens.
        public string WordFilter(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return string.Empty;

            // 0) decode HTML entities
            string text = WebUtility.HtmlDecode(str);

            // 1) strip <script> and <style> blocks (they contain JSON/CSS noise)
            text = Regex.Replace(text, "<script.*?</script>", " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            text = Regex.Replace(text, "<style.*?</style>", " ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            // 2) unescape \uXXXX sequences from inline JSON
            text = Regex.Replace(text, @"\\u([0-9A-Fa-f]{4})",
                m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());

            // 3) remove URLs and bare domains
            text = Regex.Replace(text, @"https?://\S+", " ", RegexOptions.IgnoreCase);
            text = Regex.Replace(text, @"\b\w+\.(com|net|org|io|gov|edu)\b", " ",
                RegexOptions.IgnoreCase);

            // 4) remove remaining tags
            text = Regex.Replace(text, "<.*?>", " ");

            // 5) keep word-like tokens (letters/apostrophes only)
            var tokens = Regex.Matches(text, @"[A-Za-z']+")
                              .Cast<Match>()
                              .Select(m => m.Value);

            // 6) filter out junk: length >= 4, must contain a vowel, and not a stop word
            var filtered = tokens
                .Where(w => w.Length >= 4 &&
                            Regex.IsMatch(w, "[aeiouyAEIOUY]") &&
                            !StopWords.Contains(w))
                .ToArray();

            return string.Join(" ", filtered);
        }

        // Downloads the page, filters text, applies light stemming, counts, and returns top 10 words.
        public string[] Top10ContentWords(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return new string[0];

            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                url = "https://" + url;

            string html;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                html = wc.DownloadString(url);
            }

            var filtered = WordFilter(html);

            // Tokenize, stem, count
            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var w in filtered.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var stem = Stem(w);
                if (string.IsNullOrWhiteSpace(stem) || stem.Length < 2) continue;

                counts[stem] = counts.TryGetValue(stem, out var c) ? c + 1 : 1;
            }

            return counts
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .Take(10)
                .Select(kv => kv.Key)
                .ToArray();
        }

        // ===== Elective: WordCount =====

        public string WordCountFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return "{}";
            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                url = "https://" + url;

            string content;
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                content = wc.DownloadString(url);
            }

            // Strip tags and count all words (no stop-word removal here)
            return CountWordsToJson(content, stripTags: true);
        }

        public string WordCountText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "{}";
            return CountWordsToJson(text, stripTags: false);
        }

        // ===== Helpers =====

        // Minimal stemming
        private static string Stem(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;
            var w = word.ToLowerInvariant();

            if (w.EndsWith("ies") && w.Length > 4)
                return w.Substring(0, w.Length - 3) + "y";

            if (w.EndsWith("ing") && w.Length > 5)
                return w.Substring(0, w.Length - 3);

            if (w.EndsWith("ed") && w.Length > 4)
                return w.Substring(0, w.Length - 2);

            if (w.EndsWith("es") && w.Length > 4)
                return w.Substring(0, w.Length - 2);

            if (w.EndsWith("s") && w.Length > 3 && !w.EndsWith("ss"))
                return w.Substring(0, w.Length - 1);

            return w;
        }

        private static string CountWordsToJson(string text, bool stripTags)
        {
            if (stripTags)
            {
                text = WebUtility.HtmlDecode(text ?? "");
                text = Regex.Replace(text, "<.*?>", " ");
            }

            var matches = Regex.Matches(text ?? "", @"[A-Za-z0-9']+");

            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (Match m in matches)
            {
                var token = m.Value.ToLowerInvariant();
                if (string.IsNullOrWhiteSpace(token)) continue;

                counts[token] = counts.TryGetValue(token, out var c) ? c + 1 : 1;
            }

            var sb = new StringBuilder();
            sb.Append('{');
            bool first = true;

            foreach (var kv in counts.OrderByDescending(k => k.Value).ThenBy(k => k.Key))
            {
                if (!first) sb.Append(',');
                first = false;
                sb.Append('"').Append(JsonEscape(kv.Key)).Append('"').Append(':').Append(kv.Value);
            }
            sb.Append('}');
            return sb.ToString();
        }

        private static string JsonEscape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }
}