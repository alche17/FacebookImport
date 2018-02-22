using FacebookClassLibrary.Models;
using FacebookClassLibrary;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Jitbit.Utils;

namespace FacebookApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FacebookUser _fbUser;
        private FacebookPage _fbPage;
        private FacebookPost _fbPost;
        private FacebookComment _fbComment;
        private FacebookPlugin _fbPlugin;
        private FacebookAuthenticator _fbAuth;
        private ObservableCollection<FacebookPage> _pages;
        private ObservableCollection<FacebookPost> _posts;
        private ObservableCollection<FacebookComment> _comments;

        public MainViewModel()
        {
            FBPlugin = new FacebookPlugin();
            FBPage = new FacebookPage();
            FBPost = new FacebookPost();
            FBUser = new FacebookUser();
            FBComment = new FacebookComment();
            FBAuth = new FacebookAuthenticator
            {
                UserAccessToken = "EAACuHQOgLIABAGyLF625fLgkB2NFCUjF71zXDcHduaeAuaQwX6bZBhYIi24Q9dzgZBj8gv6gcMNcgwXD2CXzp48D1XX5VtT69BCUWUgsyHYBW" +
                "Bo788GKp4jwlYeyH3atpKUsUe85Que9xpU3gwwqUTVNnaKqk1IVoYUltLzQZDZD",
                PageAccessToken = "EAACuHQOgLIABABZBnhGEZBushr4VWGWaZCeFh1PBTmMDEghZCKoqesNUfAtJ18R8VZCZANAwZA39NRcej0BjZBcyCHxOvnZAlVS7JSPuiAiRZ" +
                "BQKcDzwPca4pnk9zY8Q8jVO8nQJYtAUKWnTOXsZAoORQP7ukyPHxY1klQmc81026lw1QZDZD",
                AppAccessToken = "191439638113408|Zg-Ci3Qt-HGaPmrdse9yZTfT_VE"
            };
            UserID = PostID = CommentID = PageID = "";
        }

        public void ExportToCSV()
        {
            var export = new CsvExport();
            // need logic here
        }

        public void SetUser()
        {
            FBUser = JsonConvert.DeserializeObject<FacebookUser>(FBPlugin.GetUserData(UserID, FBAuth.UserAccessToken));
        }

        public void SetUserPages()
        {
            FBUser.Accounts = JsonConvert.DeserializeObject<FacebookAccounts>(FBPlugin.GetPages(UserID, FBAuth.UserAccessToken));
            Pages = FBUser.Accounts.Data;
        }

        public void SetUserPage()
        {
            FBPage = JsonConvert.DeserializeObject<FacebookPage>(FBPlugin.GetPageData(PageID, FBAuth.PageAccessToken));
            FBPage.Posts = JsonConvert.DeserializeObject<FacebookFeed>(FBPlugin.GetPageFeed(FBPage.ID, FBAuth.PageAccessToken));
            Posts = FBPage.Posts.Data;
        }

        public void SetPublicPage()
        {
            FBPage = JsonConvert.DeserializeObject<FacebookPage>(FBPlugin.GetPageData(PageID, FBAuth.UserAccessToken));
        }

        public void SetFeed()
        {
            FacebookFeed feedResponse = JsonConvert.DeserializeObject<FacebookFeed>(FBPlugin.GetPageFeed(PageID, FBAuth.UserAccessToken));
            Posts = feedResponse.Data;
        }

        public void SetPost()
        {
            FBPost = JsonConvert.DeserializeObject<FacebookPost>(FBPlugin.GetPostData(PostID, FBAuth.UserAccessToken));
        }

        public void SetComment()
        {
            FBComment = JsonConvert.DeserializeObject<FacebookComment>(FBPlugin.GetComment(CommentID, FBAuth.UserAccessToken));
        }

        #region Members
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

        public FacebookComment FBComment
        {
            get { return _fbComment; }
            set
            {
                if (_fbComment != value)
                {
                    _fbComment = value;
                    RaisePropertyChanged("FBComment");
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

        public FacebookPost FBPost
        {
            get { return _fbPost; }
            set
            {
                if (_fbPost != value)
                {
                    _fbPost = value;
                    RaisePropertyChanged("FBPost");
                }
            }
        }

        public FacebookPage FBPage
        {
            get { return _fbPage; }
            set
            {
                if (_fbPage != value)
                {
                    _fbPage = value;
                    RaisePropertyChanged("FBPage");
                }
            }
        }

        public string CommentID
        {
            get { return FBComment.ID; }
            set
            {
                if (FBComment.ID != value)
                {
                    FBComment.ID = value;
                    RaisePropertyChanged("CommentID");
                }
            }
        }

        public string PostID
        {
            get { return FBPost.ID; }
            set
            {
                if (FBPost.ID != value)
                {
                    FBPost.ID = value;
                    RaisePropertyChanged("PostID");
                }
            }
        }

        public string UserID
        {
            get { return FBUser.ID; }
            set
            {
                if (FBUser.ID != value)
                {
                    FBUser.ID = value;
                    RaisePropertyChanged("UserID");
                }
            }
        }

        public string PageID
        {
            get { return FBPage.ID; }
            set
            {
                if (FBPage.ID != value)
                {
                    FBPage.ID = value;
                    RaisePropertyChanged("PageID");
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
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
