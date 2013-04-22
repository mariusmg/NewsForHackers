using System;
using System.Windows;
using HN.Presenters;
using Microsoft.Phone.Controls;
using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews
{
    public partial class Settings : PhoneApplicationPage
    {
        private SettingsPresenter presenter;

        public Settings()
        {
            InitializeComponent();

            presenter = new SettingsPresenter(this);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            presenter.SetPageContext();
        }

        private void appBarButtonCancel_Click(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                (new NavigationHelper(this)).NavigateToMainPage();
            }
        }

        private void appBarButtonOK_Click(object sender, EventArgs e)
        {
            ApplicationContext.UsersSettings.OpenLinksInExternalBrowser = (bool) checkBoxOpenBrowser.IsChecked;

            if ((bool) radioButtonTextSizeBig.IsChecked)
            {
                ApplicationContext.UsersSettings.TextTemplate = "big";
            }
            else if ((bool) radioButtonTextSizeMedium.IsChecked)
            {
                ApplicationContext.UsersSettings.TextTemplate = "medium";
            }
            else
            {
                ApplicationContext.UsersSettings.TextTemplate = "small";
            }

            SettingsManager.SaveSettings();

            (new NavigationHelper(this)).NavigateToMainPage();
        }

        private void buttonAbout_Click(object sender, RoutedEventArgs e)
        {
            (new NavigationHelper(this)).NavigateToAboutPage();
        }

        private void buttonAccount_Click(object sender, RoutedEventArgs e)
        {
            presenter.DoAccountAction();
        }
    }
}