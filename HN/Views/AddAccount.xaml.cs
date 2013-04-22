using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using voidsoft.HackerNews.Presenters;

namespace voidsoft.HackerNews.Views
{
    public partial class AddAccount : PhoneApplicationPage
    {
        private AddAccountPresenter presenter;


        public AddAccount()
        {
            InitializeComponent();

            presenter = new AddAccountPresenter(this);
        }


        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUserName.Text.Length == 0)
            {
                MessageBox.Show("Please enter your user name ");
                return;
            }


            if (textBoxPassword.Password.Length == 0)
            {
                MessageBox.Show("Please enter your password ");
                return;
            }


            header.ShowLoading = true;

            presenter.AddAccount();
        }

        private void textBoxUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            State["userName"] = textBoxUserName.Text;
        }
    }
}