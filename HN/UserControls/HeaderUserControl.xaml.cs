using System.Windows;
using System.Windows.Controls;

namespace voidsoft.HackerNews.UserControls
{
    public partial class HeaderUserControl : UserControl
    {
        private bool showLoading;


        public HeaderUserControl()
        {
            InitializeComponent();

            progressBar.Visibility = Visibility.Collapsed;
        }


        public bool ShowLoading
        {
            get
            {
                return showLoading;
            }
            set
            {
                showLoading = value;

                if (value)
                {
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.IsIndeterminate = true;
                }
                else
                {
                    progressBar.Visibility = Visibility.Collapsed;
                    progressBar.IsIndeterminate = false;
                }
            }
        }

        public string Text
        {
            get
            {
                return textLoggedUser.Text;
            }

            set
            {
                textLoggedUser.Text = value;
            }
        }
    }
}