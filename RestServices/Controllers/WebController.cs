using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestServices.Controllers
{
    [RoutePrefix("api/web")]
    public class WebController : ApiController
    {
        // GET api/web/download?url=https://example.com
        [HttpGet, Route("download")]
        public async Task<IHttpActionResult> Download(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("Missing 'url'.");

            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri) ||
                (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                return BadRequest("Only http/https URLs are allowed.");

            try
            {
                using (var http = new HttpClient())
                {
                    // Many sites require a User-Agent
                    http.DefaultRequestHeaders.UserAgent.ParseAdd(
                        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) A3-Downloader/1.0");

                    // Avoid huge responses (simple safety cap)
                    http.Timeout = TimeSpan.FromSeconds(20);

                    var resp = await http.GetAsync(uri);
                    var body = await resp.Content.ReadAsStringAsync();

                    // Return the body as text; let the browser show it as plain text
                    return Content(resp.StatusCode, body, new System.Net.Http.Formatting.JsonMediaTypeFormatter(), "text/plain");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Fetch failed: " + ex.Message));
            }
        }
    }
}