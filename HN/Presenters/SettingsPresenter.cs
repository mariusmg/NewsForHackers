using System.Windows;
using voidsoft.HackerNews;
using voidsoft.HackerNews.Context;
using voidsoft.HackerNews.Presenters;

namespace HN.Presenters
{
    public class SettingsPresenter : IPageContext
    {
        private Settings view;

        public SettingsPresenter(Settings v)
        {
            view = v;
        }


        public void SetPageContext()
        {
            view.checkBoxOpenBrowser.IsChecked = ApplicationContext.UsersSettings.OpenLinksInExternalBrowser;

            switch (ApplicationContext.UsersSettings.TextTemplate)
            {
                case "small":
                    view.radioButtonTextSizeSmall.IsChecked = true;
                    break;

                case "medium":
                    view.radioButtonTextSizeMedium.IsChecked = true;
                    break;

                case "big":
                    view.radioButtonTextSizeBig.IsChecked = true;
                    break;
            }


            if (!string.IsNullOrEmpty(ApplicationContext.UsersSettings.UserToken))
            {
                // view.buttonAccount.Content = "Remove account";
            }
        }

        public void DoAccountAction()
        {
            //has account?

            if (! string.IsNullOrEmpty(ApplicationContext.UsersSettings.UserToken))
            {
                //remove

                if (MessageBox.Show("Remove account ?", "HackerNews", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            else
            {
                //add account
                (new NavigationHelper(view)).NavigateToAddAccount();
            }
        }
    }
}