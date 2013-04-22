using System;
using System.Collections.Generic;
using Hammock;
using Hammock.Web;
using Newtonsoft.Json;
using voidsoft.HackerNews.Context;

namespace voidsoft.HackerNews
{
    public class HackerAdapter
    {
        private const string HN_BASE_URL_FOR_NEWS = "http://news.ycombinator.com/item?id=";

        public void AddAccount(string name, string password, ActionCallback<AuthentificationToken> callback)
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Post;


            req.Path = "http://api.ihackernews.com/login";

            var client = new RestClient();

            client.HasElevatedPermissions = true;

            client.AddParameter("username", name);
            client.AddParameter("password", password);


            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<AuthentificationToken>(response.Content);


                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }

        public void GetAskHackerNews(ActionCallback<NewsObject> callback, string pageId = "")
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Get;

            if (!string.IsNullOrEmpty(pageId))
            {
                req.Path = "http://api.ihackernews.com/ask/" + pageId;
            }
            else
            {
                req.Path = "http://api.ihackernews.com/ask";
            }

            var client = new RestClient();

            client.HasElevatedPermissions = true;

            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<NewsObject>(response.Content);


                                 //fix the urls
                                 foreach (var n in instance.IncludedNews)
                                 {
                                     n.Url = HN_BASE_URL_FOR_NEWS + n.Url.Substring(n.Url.LastIndexOf("/") + 1);
                                 }

                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }

        public void GetCommentThreadsForUser(string userName, ActionCallback<List<Comment>> callback)
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Get;

            req.Path = "http://api.ihackernews.com/threads/" + userName;

            var client = new RestClient();

            client.HasElevatedPermissions = true;


            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<List<Comment>>(response.Content);


                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }

        public void GetNewItems(ActionCallback<NewsObject> callback, string pageId = "")
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Get;

            if (!string.IsNullOrEmpty(pageId))
            {
                req.Path = "http://api.ihackernews.com/new/" + pageId;
            }
            else
            {
                req.Path = "http://api.ihackernews.com/new";
            }

            var client = new RestClient();

            client.HasElevatedPermissions = true;

            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<NewsObject>(response.Content);


                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }

        public void GetNews(long id, ActionCallback<News> callback)
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Get;

            req.Path = "http://api.ihackernews.com/post/" + id;

            var client = new RestClient();

            client.HasElevatedPermissions = true;

            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<News>(response.Content);

                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }

        public void GetNewsObject(ActionCallback<NewsObject> callback, string pageId = "")
        {
            RestRequest req = new RestRequest();

            req.Method = WebMethod.Get;

            if (!string.IsNullOrEmpty(pageId))
            {
                req.Path = "http://api.ihackernews.com/page/" + pageId;
            }
            else
            {
                req.Path = "http://api.ihackernews.com/page";
            }

            var client = new RestClient();

            client.HasElevatedPermissions = true;

            client.BeginRequest
                    (req,
                     (request, response, state) =>
                         {
                             if (response.InnerException != null)
                             {
                                 callback(response.InnerException.Message, null);
                                 return;
                             }

                             try
                             {
                                 var instance = JsonConvert.DeserializeObject<NewsObject>(response.Content);


                                 callback(string.Empty, instance);
                             }
                             catch (Exception ex)
                             {
                                 callback(ex.Message, null);
                             }
                         });
        }
    }
}