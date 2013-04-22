using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace voidsoft.HackerNews.UserControls
{
    public partial class ListBoxWithProgressBar : UserControl
    {
        private DataTemplate currentTemplate;

        private IEnumerable source;

        public ListBoxWithProgressBar()
        {
            InitializeComponent();

            listBoxResults.Loaded += (sender, args) =>
                                         {
                                             listBoxResults.SelectedIndex = -1;
                                         };

            SetControlsVisibility();
        }


        public DataTemplate CurrentTemplate
        {
            get
            {
                return currentTemplate;
            }
            set
            {
                currentTemplate = value;

                listBoxResults.ItemTemplate = currentTemplate;
            }
        }

        public string LoaderMessage
        {
            get;
            set;
        }

        public IEnumerable Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;

                listBoxResults.ItemsSource = null;
                listBoxResults.ItemsSource = source;

                SetControlsVisibility();

                if (listBoxResults.Items.Count == 0)
                {
                    ShowNoResults();
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoaderMessage))
            {
                loaderMessage.Text = LoaderMessage;
            }
        }

        public void SetControlsVisibility()
        {
            if (source == null)
            {
                regularView.Visibility = Visibility.Collapsed;

                progressBar.Visibility = Visibility.Visible;
                initialLoader.Visibility = Visibility.Visible;
            }
            else
            {
                regularView.Visibility = Visibility.Visible;
                listBoxResults.Visibility = Visibility.Visible;
                initialLoader.Visibility = Visibility.Collapsed;
            }
        }


        public void ShowNoResults()
        {
            SetControlsVisibility();
            progressBar.Visibility = Visibility.Collapsed;
            loaderMessage.Text = "no results";
        }
    }
}