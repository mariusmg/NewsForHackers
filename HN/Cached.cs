using System.Collections.Generic;
using System.Runtime.Serialization;

namespace voidsoft.HackerNews
{
    [DataContract]
    public class CachedNews
    {
        private List<News> news;

        public CachedNews()
        {
            news = new List<News>();
        }

        [DataMember]
        public List<News> News
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
            }
        }

        [DataMember]
        public string NextId
        {
            get;
            set;
        }
    }


    public static class Cached
    {
        private static CachedNews loadedAskHNItems = new CachedNews();

        private static CachedNews loadedNewItems = new CachedNews();

        private static CachedNews loadedNews = new CachedNews();

        private static List<Comment> myComments = new List<Comment>();

        public static CachedNews LoadedAskHnItems
        {
            get
            {
                return loadedAskHNItems;
            }
            set
            {
                loadedAskHNItems = value;
            }
        }

        public static CachedNews LoadedNewItems
        {
            get
            {
                return loadedNewItems;
            }
            set
            {
                loadedNewItems = value;
            }
        }

        public static CachedNews LoadedNews
        {
            get
            {
                return loadedNews;
            }
            set
            {
                loadedNews = value;
            }
        }

        public static List<Comment> MyComments
        {
            get
            {
                return myComments;
            }
            set
            {
                myComments = value;
            }
        }
    }
}