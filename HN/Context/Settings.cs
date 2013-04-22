using System.Runtime.Serialization;

namespace voidsoft.HackerNews.Context
{
    [DataContract]
    public class UserSettings
    {
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public bool OpenLinksInExternalBrowser
        {
            get;
            set;
        }

        [DataMember]
        public string TextTemplate
        {
            get;
            set;
        }

        [DataMember]
        public string UserToken
        {
            get;
            set;
        }
    }
}