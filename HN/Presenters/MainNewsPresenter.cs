using System;
using System.Windows;
using Microsoft.Phone.Shell;
using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews.Presenters
{
    public class MainNewsPresenter : IPageContext
    {
        private ApplicationBar bar;

        private MainPage view;

        public MainNewsPresenter(MainPage view)
        {
            this.view = view;


            SetPageContext();
        }

        private void ButtonNewsLoadMore_OnClick(object sender, EventArgs eventArgs)
        {
            GetNews(Cached.LoadedNews.NextId);
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            (new NavigationHelper(view)).NavigateToSettings();
        }

        public void SetPageContext()
        {
            if (!string.IsNullOrEmpty(ApplicationContext.UsersSettings.UserToken))
            {
                view.header.Text = "HACKER NEWS" + " - " + ApplicationContext.UsersSettings.Name;
            }

            //CreateApplicationBar();
        }

        public void CreateApplicationBar()
        {
            if (bar != null)
            {
                view.ApplicationBar = bar;
                return;
            }


            bar = new ApplicationBar();

            ApplicationBarIconButton buttonNewsLoadMore = new ApplicationBarIconButton(new Uri("/Resources/baricons/loadmore.png", UriKind.RelativeOrAbsolute));
            buttonNewsLoadMore.Text = "more";
            buttonNewsLoadMore.Click += ButtonNewsLoadMore_OnClick;


            bar.Buttons.Add(buttonNewsLoadMore);


            ApplicationBarMenuItem menuItemSettings = new ApplicationBarMenuItem("settings");
            menuItemSettings.Click += menuItemSettings_Click;

            bar.MenuItems.Add(menuItemSettings);

            view.ApplicationBar = bar;
        }


        public void GetNew()
        {
            (new HackerAdapter()).GetNewItems
                    ((message, o) =>
                         {
                             if (!string.IsNullOrEmpty(message))
                             {
                                 view.Dispatcher.BeginInvoke
                                         (() =>
                                              {
                                                  MessageBox.Show(" Couldn't load news. " + message);
                                                  return;
                                              });
                                 return;
                             }


                             foreach (var item in o.IncludedNews)
                             {
                                 Cached.LoadedNewItems.News.Add(item);
                             }

                             Cached.LoadedNewItems.NextId = o.NextId;

                             view.Dispatcher.BeginInvoke
                                     (() =>
                                          {
                                              view.listNewItems.Source = Cached.LoadedNewItems.News;
                                          });
                         });
        }

        public void GetNews(string pageId = "")
        {
            var adapter = new HackerAdapter();


            if (string.IsNullOrEmpty(pageId))
            {
                adapter.GetNewsObject(GetNewsCallback);
            }
            else
            {
                ShowLoadingProgress(true);

                adapter.GetNewsObject(GetNewsCallback, pageId);
            }
        }

        private void GetNewsCallback(string errorMessage, NewsObject newsObject)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                view.Dispatcher.BeginInvoke
                        (() =>
                             {
                                 ShowLoadingProgress(false);

                                 MessageBox.Show(" Couldn't load new news. " + errorMessage);
                                 return;
                             });
                return;
            }


            foreach (var item in newsObject.IncludedNews)
            {
                Cached.LoadedNews.News.Add(item);
            }

            Cached.LoadedNews.NextId = newsObject.NextId;

            view.Dispatcher.BeginInvoke
                    (() =>
                         {
                             ShowLoadingProgress(false);

                             view.listNews.Source = Cached.LoadedNews.News;
                         });
        }

        private void ShowLoadingProgress(bool showLoading)
        {
            view.header.ShowLoading = showLoading;
        }
    }
}