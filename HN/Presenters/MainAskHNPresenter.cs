using System;
using System.Windows;
using Microsoft.Phone.Shell;

namespace voidsoft.HackerNews.Presenters
{
    public class MainAskHNPresenter : IPageContext
    {
        private IApplicationBar bar;

        private MainPage view;


        public MainAskHNPresenter(MainPage view)
        {
            this.view = view;
        }


        private void ButtonNewsLoadMore_OnClick(object sender, EventArgs e)
        {
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
        }

        public void SetPageContext()
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

        public void GetAskHN()
        {
            (new HackerAdapter()).GetAskHackerNews
                    ((message, o) =>
                         {
                             if (!string.IsNullOrEmpty(message))
                             {
                                 view.Dispatcher.BeginInvoke
                                         (() =>
                                              {
                                                  MessageBox.Show(" Couldn't load ask HN items. " + message);
                                                  return;
                                              });
                                 return;
                             }


                             foreach (var item in o.IncludedNews)
                             {
                                 Cached.LoadedAskHnItems.News.Add(item);
                             }

                             Cached.LoadedAskHnItems.NextId = o.NextId;

                             view.Dispatcher.BeginInvoke
                                     (() =>
                                          {
                                              view.listAskHN.Source = Cached.LoadedAskHnItems.News;
                                          });
                         });
        }
    }
}