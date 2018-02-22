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

        public string GetUserData(string user_id, string access_token)
        {
            return FacebookAPICall(user_id, access_token, "id,name,address,age_range,gender,locale,location");
        }

        public string GetPageFeed(string page_id, string access_token)
        {
            return FacebookAPICall(page_id + "/feed", access_token, "id,message,from,likes,comments,place");
        }

        public string GetPages(string user_id, string access_token)
        {
            return FacebookAPICall(user_id + "/accounts", access_token);
        }

        public string GetPageData(string page_id, string access_token)
        {
            return FacebookAPICall(page_id, access_token, "id,name,category,fan_count");
        }

        public string GetPermissions(string user_id, string access_token)
        {
            return FacebookAPICall(user_id + "permissions", access_token);
        }

        public string GetPostData(string post_id, string access_token)
        {
            return FacebookAPICall(post_id, access_token, "message,id,from,place,likes,comments");
        }

        public string GetPostComments(string post_id, string access_token)
        {
            return FacebookAPICall(post_id + "/comments", access_token);
        }

        public string GetComment(string comment_id, string access_token)
        {
            return FacebookAPICall(comment_id, access_token);
        }
    }
}
