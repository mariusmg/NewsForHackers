using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace voidsoft.HackerNews
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class News
    {
        [JsonProperty("commentCount")]
        [DataMember]
        public int Comments
        {
            get;
            set;
        }


        [DataMember]
        [JsonProperty("id")]
        public long Id
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("comments")]
        public Comment[] NewsComments
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("points")]
        public int Points
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("postedAgo")]
        public string PostedAgo
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("postedBy")]
        public string PostedBy
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }
    }
}