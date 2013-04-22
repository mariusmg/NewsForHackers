namespace voidsoft.HackerNews.Context
{
    public static class ApplicationContext
    {
        private static UserSettings mySettings = new UserSettings();

        public static UserSettings UsersSettings
        {
            get
            {
                return mySettings;
            }
            set
            {
                mySettings = value;
            }
        }
    }
}