using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace voidsoft.HackerNews
{
    public partial class Browser : PhoneApplicationPage
    {
        public Browser()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!NavigationContext.QueryString.ContainsKey("url"))
            //{
            //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            //    return;
            //}

            //try
            //{
            //    webBrowser.Navigate(new Uri(HttpUtility.UrlDecode(NavigationContext.QueryString["url"])));
            //}
            //catch (Exception ex)
            //{
            //}


            if (string.IsNullOrEmpty(ApplicationNavigationContext.Context.BrowserUrl))
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
                return;
            }

            try
            {
                webBrowser.Navigate(new Uri(ApplicationNavigationContext.Context.BrowserUrl));
            }
            catch (Exception ex)
            {
                string g;
            }
        }
    }
}