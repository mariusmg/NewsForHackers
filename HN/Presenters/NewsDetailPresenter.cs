using System.Collections.Generic;
using System.Linq;
using System.Windows;
using voidsoft.HackerNews.Views;

namespace voidsoft.HackerNews.Presenters
{
    public class NewsDetailPresenter : IPageContext
    {
        private List<Comment> sortedComments;

        private NewsDetail view;

        public NewsDetailPresenter(NewsDetail page)
        {
            view = page;
        }


        public void SetPageContext()
        {
            view.title.Text = view.model.Title;


            GetComments();
        }


        private void GetComments()
        {
            (new HackerAdapter()).GetNews
                    (view.model.Id,
                     (message, list) =>
                         {
                             if (!string.IsNullOrEmpty(message))
                             {
                                 view.Dispatcher.BeginInvoke
                                         (() =>
                                              {
                                                  MessageBox.Show(" Cannot load comments. " + message);
                                              });
                                 return;
                             }


                             view.Dispatcher.BeginInvoke
                                     (() =>
                                          {
                                              if (list.NewsComments.Count() == 0)
                                              {
                                              }
                                              else
                                              {
                                                  view.listComments.Source = list.NewsComments;
                                              }
                                          });
                         });
        }


        private void SortComments(List<Comment> comments)
        {
            //  comments.Sort((comment, comment1) => );

            (from c in comments
             where c.ParentId == -1 || c.ParentId == 0
             orderby c.Points descending
             select c).ToArray();
        }
    }
}