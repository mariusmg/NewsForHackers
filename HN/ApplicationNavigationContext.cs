using System.Runtime.Serialization;

namespace voidsoft.HackerNews
{
    [DataContract]
    public class NavigationContextData
    {
        //add here data need to contextual navigation
        [DataMember]
        public string BrowserUrl
        {
            get;
            set;
        }

        [DataMember]
        public News DetailNews
        {
            get;
            set;
        }
    }


    public class ApplicationNavigationContext
    {
        private static NavigationContextData context = new NavigationContextData();

        public static NavigationContextData Context
        {
            get
            {
                return context;
            }

            set
            {
                context = value;
            }
        }
    }
}