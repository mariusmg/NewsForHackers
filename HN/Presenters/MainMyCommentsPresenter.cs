using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews.Presenters
{
    public class MainMyCommentsPresenter
    {
        private MainPage view;

        public MainMyCommentsPresenter(MainPage view)
        {
            this.view = view;
        }


        public void GetMyComments()
        {
            (new HackerAdapter()).GetCommentThreadsForUser
                    (ApplicationContext.UsersSettings.UserToken,
                     (message, list) =>
                         {
                             if (!string.IsNullOrEmpty(message))
                             {
                                 return;
                             }


                             view.Dispatcher.BeginInvoke
                                     (() =>
                                          {
                                              // view.listMyComments.Source = list;
                                          });
                         });
        }
    }
}