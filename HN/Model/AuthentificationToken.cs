using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace voidsoft.HackerNews
{
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public class AuthentificationToken
    {
        [JsonProperty("token")]
        [DataMember]
        public string Token
        {
            get;
            set;
        }
    }
}