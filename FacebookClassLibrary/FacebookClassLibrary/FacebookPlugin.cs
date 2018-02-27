using RestSharp;

namespace FacebookClassLibrary
{
    public class FacebookPlugin
    {
        readonly RestClient Client;

        public FacebookPlugin()
        {
            Client = new RestClient("https://graph.facebook.com");
        }

        public string FacebookAPICall(string resource, string access_token, string fields = "")
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = resource
            };

            request.AddParameter("access_token", access_token);
            if (fields != "")
            {
                request.AddParameter("fields", fields);
            }
            IRestResponse response = Client.Execute(request);
            return response.Content;
        }

        public string FacebookAPIDelete(string resource, string access_token)
        {
            var request = new RestRequest(Method.DELETE)
            {
                Resource = resource
            };

            request.AddParameter("access_token", access_token);
            IRestResponse response = Client.Execute(request);
            return response.Content;
        }

        public string DeleteUserLogin(string user_id, string access_token)
        {
            return FacebookAPIDelete(user_id + "/permissions", access_token);
        }

        #region Users
        public string GetUserData(string user_id, string access_token)
        {
            return FacebookAPICall(user_id, access_token, "id,name,address,age_range,gender,locale,location");
        }
        #endregion

        #region Pages
        public string GetPageFeed(string page_id, string access_token)
        {
            return FacebookAPICall(page_id + "/feed", access_token, "id,message,from,place");
        }

        public string GetPageData(string page_id, string access_token)
        {
            return FacebookAPICall(page_id, access_token, "access_token,category,name,id,fan_count");
        }

        public string GetPublicPageData(string page_id, string access_token)
        {
            return FacebookAPICall(page_id, access_token, "access_token,category,name,id,fan_count");
        }

        public string GetPages(string user_id, string access_token)
        {
            return FacebookAPICall(user_id + "/accounts", access_token, "access_token,category,name,id,perms,fan_count");
        }
        #endregion

        #region Groups
        public string GetGroups(string user_id, string access_token)
        {
            return FacebookAPICall(user_id + "/groups", access_token);
        }

        public string GetGroupFeed(string group_id, string access_token)
        {
            return FacebookAPICall(group_id + "/feed", access_token, "id,message,from,place");
        }

        public string GetGroupData(string group_id, string access_token)
        {
            return FacebookAPICall(group_id, access_token);
        }

        public string GetGroupMembers(string group_id, string access_token)
        {
            return FacebookAPICall(group_id + "/members", access_token);
        }
        #endregion

        #region Posts
        public string GetPostData(string post_id, string access_token)
        {
            return FacebookAPICall(post_id, access_token, "message,id,from,place,likes,comments");
        }

        public string GetPostComments(string post_id, string access_token)
        {
            return FacebookAPICall(post_id + "/comments", access_token);
        }

        public string GetPostLikes(string post_id, string access_token)
        {
            return FacebookAPICall(post_id + "/likes", access_token);
        }

        public string GetPostReactions(string post_id, string access_token)
        {
            return FacebookAPICall(post_id + "/reactions", access_token);
        }
        #endregion

        #region Comments
        public string GetComment(string comment_id, string access_token)
        {
            return FacebookAPICall(comment_id, access_token, "id,from,message,like_count");
        }
        #endregion
    }
}
