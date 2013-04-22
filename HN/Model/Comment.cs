using System.Net;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class Comment
    {
        private string text;

        [DataMember]
        [JsonProperty("id")]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty("parentID")]
        [DataMember]
        public long ParentId
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
        [JsonProperty("comment")]
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = HttpUtility.HtmlDecode(Utils.StripHTML(value));
            }
        }
    }
}