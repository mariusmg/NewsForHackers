using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using voidsoft.HackerNews.Presenters;

namespace voidsoft.HackerNews.Views
{
    public partial class NewsDetail : PhoneApplicationPage
    {
        private const string CURRENT_MODEL = "CurrentModel";

        public News model;

        private NewsDetailPresenter presenter;

        public NewsDetail()
        {
            InitializeComponent();

            presenter = new NewsDetailPresenter(this);

            listComments.CurrentTemplate = (DataTemplate) Application.Current.Resources["templateComments"];
        }


        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            model = ApplicationNavigationContext.Context.DetailNews;

            presenter.SetPageContext();
        }

        private void title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (new NavigationHelper(this)).NavigateToBrowser(model.Url);
        }


        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedTo(e);

        //    if(this.State[CURRENT_MODEL] != null)
        //    {
        //        this.model = 
        //    }
        //}

        //protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        //{
        //    if (model != null)
        //    {
        //        State[CURRENT_MODEL] = model;
        //    }
        //}
    }
}