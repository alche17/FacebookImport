using FacebookClassLibrary.Models;
using FacebookClassLibrary;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FacebookApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FacebookUser _fbUser;
        private FacebookPlugin _fbPlugin;
        private FacebookAuthenticator _fbAuth;
        private ObservableCollection<FacebookPage> _pages;
        private ObservableCollection<FacebookPost> _posts;
        private ObservableCollection<FacebookComment> _comments;
        private string _postID;

        public MainViewModel()
        {
            FBUser = new FacebookUser();
            FBPlugin = new FacebookPlugin();
            FBAuth = new FacebookAuthenticator
            {
                UserAccessToken = "EAACuHQOgLIABAGyLF625fLgkB2NFCUjF71zXDcHduaeAuaQwX6bZBhYIi24Q9dzgZBj8gv6gcMNcgwXD2CXzp48D1XX5VtT69BCUWUgsyHYBW" +
                "Bo788GKp4jwlYeyH3atpKUsUe85Que9xpU3gwwqUTVNnaKqk1IVoYUltLzQZDZD"
            };
            PostID = "226889444550986_226890444550886";
        }

        public void SetUser()
        {
            FBUser = JsonConvert.DeserializeObject<FacebookUser>(FBPlugin.GetUserData(FBAuth.UserAccessToken));
        }

        public void SetPages()
        {
            FBUser.Accounts = JsonConvert.DeserializeObject<FacebookAccounts>(FBPlugin.GetPages(FBAuth.UserAccessToken));
            Pages = FBUser.Accounts.Data;
        }

        public FacebookAuthenticator FBAuth
        {
            get { return _fbAuth; }
            set
            {
                if (_fbAuth != value)
                {
                    _fbAuth = value;
                    RaisePropertyChanged("FBAuth");
                }
            }
        }

        public string PostID
        {
            get { return _postID; }
            set
            {
                if (_postID != value)
                {
                    _postID = value;
                    RaisePropertyChanged("PostID");
                }
            }
        }

        public ObservableCollection<FacebookPost> Posts
        {
            get { return _posts; }
            set
            {
                if (_posts != value)
                {
                    _posts = value;
                    RaisePropertyChanged("Posts");
                }
            }
        }

        public ObservableCollection<FacebookComment> Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments = value;
                    RaisePropertyChanged("Comments");
                }
            }
        }

        public FacebookUser FBUser
        {
            get { return _fbUser; }
            set
            {
                if (_fbUser != value)
                {
                    _fbUser = value;
                    RaisePropertyChanged("FBUser");
                }
            }
        }

        public FacebookPlugin FBPlugin
        {
            get { return _fbPlugin; }
            set
            {
                if (_fbPlugin != value)
                {
                    _fbPlugin = value;
                    RaisePropertyChanged("FBPlugin");
                }
            }
        }

        public ObservableCollection<FacebookPage> Pages
        {
            get { return _pages; }
            set
            {
                if (_pages != value)
                {
                    _pages = value;
                    RaisePropertyChanged("Pages");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
