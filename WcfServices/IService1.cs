//Author: Ahmed Almoshawer
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // --- A3 operations ---

        // Removes HTML/XML tags and common stop words; returns the cleaned text.
        [OperationContract]
        string WordFilter(string str);

        // Downloads a page, filters + stems words, counts, and returns the top 10 content words.
        [OperationContract]
        string[] Top10ContentWords(string url);

        // Elective: WordCount — return JSON { "word": count, ... }
        [OperationContract]
        string WordCountFromUrl(string url);

        [OperationContract]
        string WordCountText(string text);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}