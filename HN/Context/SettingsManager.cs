using System.IO.IsolatedStorage;

namespace voidsoft.HackerNews.Context
{
    public class SettingsManager
    {
        public static void LoadSettings()
        {
            ApplicationContext.UsersSettings = (UserSettings) IsolatedStorageSettings.ApplicationSettings["settings"];
        }

        public static void SaveSettings()
        {
            IsolatedStorageSettings.ApplicationSettings["settings"] = ApplicationContext.UsersSettings;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }
}