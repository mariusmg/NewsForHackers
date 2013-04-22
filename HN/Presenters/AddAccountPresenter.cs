using System.Windows;
using voidsoft.HackerNews.Context;
using voidsoft.HackerNews.Views;

namespace voidsoft.HackerNews.Presenters
{
    public class AddAccountPresenter
    {
        private AddAccount view;


        public AddAccountPresenter(AddAccount view)
        {
            this.view = view;
        }


        public void AddAccount()
        {
            string name = view.textBoxUserName.Text;
            string password = view.textBoxPassword.Password;


            (new HackerAdapter()).AddAccount
                    (name,
                     password,
                     (message, s) =>
                         {
                             if (!string.IsNullOrEmpty(message))
                             {
                                 view.Dispatcher.BeginInvoke
                                         (() =>
                                              {
                                                  MessageBox.Show("Failed to authentificate. Make sure you entered data correctly ");

                                                  view.header.ShowLoading = false;
                                              });


                                 return;
                             }


                             //just keep the token
                             ApplicationContext.UsersSettings.UserToken = s.Token;
                             ApplicationContext.UsersSettings.Name = name;


                             //redirect back to main page

                             (new NavigationHelper(view)).NavigateToMainPage();
                         });
        }

        public void SetPageContext()
        {
        }
    }
}