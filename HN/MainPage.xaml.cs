using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using voidsoft.HackerNews.Context;
using voidsoft.HackerNews.Presenters;

namespace voidsoft.HackerNews
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainAskHNPresenter presenterAsk;

        private MainMyCommentsPresenter presenterMyComments;

        private MainNewsPresenter presenterNews;

        public MainPage()
        {
            InitializeComponent();

            presenterNews = new MainNewsPresenter(this);

            presenterAsk = new MainAskHNPresenter(this);

            presenterMyComments = new MainMyCommentsPresenter(this);

//            presenterMyComments.AddMyCommentsPivot();


            //does user have account

            //if (string.IsNullOrEmpty(ApplicationContext.UsersSettings.UserToken))
            //{
            //    pivotMyComments.Visibility = Visibility.Collapsed;
            //}


            if (ApplicationContext.UsersSettings.TextTemplate == Constants.BIG)
            {
                listNews.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsBig"];
                listNewItems.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsBig"];
                listAskHN.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsBig"];
            }
            else if (ApplicationContext.UsersSettings.TextTemplate == Constants.MEDIUM)
            {
                listNews.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsMedium"];
                listNewItems.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsMedium"];
                listAskHN.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsMedium"];
            }
            else
            {
                listNews.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsSmall"];
                listNewItems.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsSmall"];
                listAskHN.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateNewsSmall"];
            }

            //listMyComments.TemplateForData = (DataTemplate) Application.Current.Resources["templateComments"];
            //listMyComments.listBoxResults.SelectionChanged += listBoxResults_SelectionChanged;

            listNews.listBoxResults.SelectionChanged += listBoxResultsNews_SelectionChanged;
            listNewItems.listBoxResults.SelectionChanged += listBoxResultsNewItems_SelectionChanged;
            listAskHN.listBoxResults.SelectionChanged += listBoxResultsAskHN_SelectionChanged;

            pivot.SelectedIndex = 0;
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (pivot.SelectedIndex)
            {
                case 0:
                    if (listNews.listBoxResults.Items.Count == 0)
                    {
                        presenterNews.GetNews();
                    }
                    break;

                case 1:
                    if (listNewItems.listBoxResults.Items.Count == 0)
                    {
                        presenterNews.GetNew();
                    }
                    break;

                case 2:
                    if (listAskHN.listBoxResults.Items.Count == 0)
                    {
                        presenterAsk.GetAskHN();
                    }
                    break;

                    //case 3:
                    //    if (listMyComments.listBoxResults.Items.Count == 0)
                    //    {
                    //        presenterMyComments.GetMyComments();
                    //    }
                    //    break;
            }
        }

        private void listBoxResultsAskHN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            (new NavigationHelper(this)).NavigateToNewsDetails(((News) e.AddedItems[0]));
        }

        private void listBoxResultsNewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }

            (new NavigationHelper(this)).NavigateToNewsDetails(((News) e.AddedItems[0]));
        }

        private void listBoxResultsNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }


            (new NavigationHelper(this)).NavigateToNewsDetails(((News) e.AddedItems[0]));
        }


    }
}