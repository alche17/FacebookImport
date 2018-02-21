using RestSharp;

namespace FacebookClassLibrary
{
    public class FacebookPlugin
    {
        private readonly RestClient _client;

        public FacebookPlugin()
        {
            _client = new RestClient("https://graph.facebook.com");
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
            IRestResponse response = _client.Execute(request);
            return response.Content;
        }

        public string GetUserData(string user_access_token)
        {
            return FacebookAPICall("me", user_access_token, "['id','name','address','age_range','gender','locale','location']");
        }

        public string GetPageFeed(string page_access_token)
        {
            return FacebookAPICall("me/accounts", page_access_token);
        }

        public string GetPages(string user_access_token)
        {
            return FacebookAPICall("me/accounts", user_access_token);
        }

        public string GetPageData(string page_access_token, string user_access_token)
        {
            return FacebookAPICall(page_access_token, user_access_token, "['id','name','category','fan_count']");
        }

        public string GetPermissions(string user_access_token)
        {
            return FacebookAPICall("me/permissions", user_access_token);
        }
    }
}
