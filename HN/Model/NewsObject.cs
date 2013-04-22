using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace voidsoft.HackerNews
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class NewsObject
    {
        [JsonProperty("items")]
        public News[] IncludedNews
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("nextid")]
        public string NextId
        {
            get;
            set;
        }

        [JsonProperty("version")]
        public string Version
        {
            get;
            set;
        }
    }
}