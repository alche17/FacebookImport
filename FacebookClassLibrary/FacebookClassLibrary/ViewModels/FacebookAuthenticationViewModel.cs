
using FacebookClassLibrary.Models;

namespace FacebookClassLibrary.ViewModels
{
    public class FacebookAuthenticationViewModel
    {
        private FacebookAuthenticator _fba;

        public FacebookAuthenticationViewModel()
        {
            _fba = new FacebookAuthenticator();
        }

        public FacebookAuthenticator Fba
        {
            get { return _fba; }
            set { _fba = value; }
        }

        public string AccessToken
        {
            get { return Fba.UserAccessToken; }
            set { Fba.UserAccessToken = value; }
        }

        public string AppID
        {
            get { return Fba.AppID; }
            set { Fba.AppID = value; }
        }
    }
}
