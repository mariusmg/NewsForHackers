using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews
{
    public class NavigationHelper
    {
        private PhoneApplicationPage page;

        public NavigationHelper(PhoneApplicationPage page)
        {
            this.page = page;
        }


        public void NavigateToAboutPage()
        {
            page.NavigationService.Navigate(new Uri("/Views/About.xaml", UriKind.RelativeOrAbsolute));
        }

        public void NavigateToAddAccount()
        {
            page.NavigationService.Navigate(new Uri("/Views/AddAccount.xaml", UriKind.RelativeOrAbsolute));
        }

        public void NavigateToBrowser(string url)
        {
            if (ApplicationContext.UsersSettings.OpenLinksInExternalBrowser)
            {
                var task = new WebBrowserTask();
                task.URL = url;
                task.Show();
            }
            else
            {
                //page.NavigationService.Navigate(new Uri("/Browser.xaml?url=" + HttpUtility.UrlEncode(url), UriKind.RelativeOrAbsolute));
                ApplicationNavigationContext.Context.BrowserUrl = url;
                page.NavigationService.Navigate(new Uri("/Browser.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        public void NavigateToMainPage()
        {
            page.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public void NavigateToNewsDetails(News news)
        {
            ApplicationNavigationContext.Context.DetailNews = news;

            page.NavigationService.Navigate(new Uri("/Views/NewsDetail.xaml", UriKind.RelativeOrAbsolute));
        }

        public void NavigateToSettings()
        {
            page.NavigationService.Navigate(new Uri("/Views/Settings.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}