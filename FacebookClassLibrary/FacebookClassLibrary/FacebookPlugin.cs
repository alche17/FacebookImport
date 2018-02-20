using FacebookClassLibrary.Models;
using RestSharp;

namespace FacebookClassLibrary
{
    public class FacebookPlugin
    {
        private readonly RestClient _client;
        private FacebookAuthenticator _fbAuthenticator;

        public FacebookPlugin()
        {
            _client = new RestClient("https://graph.facebook.com");
            _fbAuthenticator = new FacebookAuthenticator();
        }

        public bool IsLoggedIn()
        {
            // need to add logic
            // need to check this before user clicks buttons on UI to do GET requests
            return true;
        }

        public void SetUserAccessToken(string accessToken)
        {
            _fbAuthenticator.UserAccessToken = accessToken;
        }

        public void GetPageAccessToken()
        {
            var request = new RestRequest(Method.GET)
            {
                // resource = {edge-id} which in this case is a page-id
                Resource = "me/accounts"
            };

            request.AddParameter("access_token", _fbAuthenticator.UserAccessToken);

            IRestResponse response = _client.Execute(request);

        }

        public string GetPageData()
        {
            var request = new RestRequest(Method.GET)
            {
                // resource = {edge-id} which in this case is a page-id
                Resource = _fbAuthenticator.PageAccessToken
            };

            request.AddParameter("access_token", _fbAuthenticator.UserAccessToken);
            request.AddParameter("fields", "['id','name','category','fan_count']");

            IRestResponse response = _client.Execute(request);
            return response.Content;
        }

        public string GetPermissions()
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "me/permissions"
            };

            request.AddParameter("access_token", _fbAuthenticator.UserAccessToken);

            IRestResponse response = _client.Execute(request);
            return response.Content;
        }
    }
}
