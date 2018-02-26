﻿using FacebookClassLibrary.Models;
using FacebookClassLibrary;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Jitbit.Utils;
using FacebookClassLibrary.Models.Metadata;
using System;
using System.IO;
using System.Collections.Generic;

namespace FacebookApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private FacebookUser _fbUser;
        private FacebookPage _fbPage;
        private FacebookPost _fbPost;
        private FacebookGroup _fbGroup;
        private FacebookComment _fbComment;
        private FacebookPlugin _fbPlugin;
        private FacebookAuthenticator _fbAuth;
        private ObservableCollection<FacebookPage> _pages;
        private ObservableCollection<FacebookPost> _pagePosts;
        private ObservableCollection<FacebookComment> _comments;
        private ObservableCollection<Reaction> _reactions;
        private ObservableCollection<FacebookGroup> _groups;
        private ObservableCollection<FacebookPost> _groupPosts;
        private ObservableCollection<FacebookUser> _members;

        public MainViewModel()
        {
            FBPlugin = new FacebookPlugin();
            FBPage = new FacebookPage();
            FBPost = new FacebookPost();
            FBUser = new FacebookUser();
            FBGroup = new FacebookGroup();
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
            GroupID = "test string";
        }

        public void ExportToCSV()
        {
            // Mock up some dummy data to fill .csv file
            FacebookPage testPage = JsonConvert.DeserializeObject<FacebookPage>(FBPlugin.GetPageData("CityOfKingston", FBAuth.UserAccessToken));
            testPage.Posts = JsonConvert.DeserializeObject<FacebookFeed>(FBPlugin.GetPageFeed("CityOfKingston", FBAuth.PageAccessToken));
            ObservableCollection<FacebookPost> testPagePosts = testPage.Posts.Data;
            FacebookPost testPost = JsonConvert.DeserializeObject<FacebookPost>(FBPlugin.GetPostData("144064188977112_1813323618717819", FBAuth.PageAccessToken));
            testPost.Comments = JsonConvert.DeserializeObject<FacebookComments>(FBPlugin.GetPostComments("144064188977112_1813323618717819", FBAuth.PageAccessToken));
            ObservableCollection<FacebookComment> testComments = testPost.Comments.Data;
            

            // Question: Post, Responses: Comments
            var export = new CsvExport();
            foreach (FacebookComment comment in testComments)
            {
                export.AddRow();
                export[testPost.Message] = comment.Message;
            }

            File.WriteAllBytes(@"C:\Users\acheevers\Documents\survey1.csv", export.ExportToBytes());

            // Question: Post, Response: Reactions
            testPost = JsonConvert.DeserializeObject<FacebookPost>(FBPlugin.GetPostData("226889444550986_226890444550886", FBAuth.PageAccessToken));
            testPost.Reactions = JsonConvert.DeserializeObject<FacebookReactions>(FBPlugin.GetPostReactions("226889444550986_226890444550886", FBAuth.PageAccessToken));
            ObservableCollection<Reaction> testReactions = testPost.Reactions.Data;
            export = new CsvExport();
            foreach (Reaction reaction in testReactions)
            {
                export.AddRow();
                export[testPost.Message] = reaction.Type;
            }

            File.WriteAllBytes(@"C:\Users\acheevers\Documents\survey2.csv", export.ExportToBytes());
        }

        public void SetUser()
        {
            FBUser = JsonConvert.DeserializeObject<FacebookUser>(FBPlugin.GetUserData(UserID, FBAuth.UserAccessToken));
            FBUser.Accounts = JsonConvert.DeserializeObject<FacebookAccounts>(FBPlugin.GetPages(UserID, FBAuth.UserAccessToken));
            Pages = FBUser.Accounts.Data;
            FBUser.Groups = JsonConvert.DeserializeObject<FacebookGroups>(FBPlugin.GetGroups(UserID, FBAuth.UserAccessToken));
            Groups = FBUser.Groups.Data;
        }

        public void SetUserPage()
        {
            FBPage = JsonConvert.DeserializeObject<FacebookPage>(FBPlugin.GetPageData(PageID, FBAuth.PageAccessToken));
            FBPage.Posts = JsonConvert.DeserializeObject<FacebookFeed>(FBPlugin.GetPageFeed(PageID, FBAuth.PageAccessToken));
            PagePosts = FBPage.Posts.Data;
        }

        public void SetUserGroup()
        {
            FBGroup = JsonConvert.DeserializeObject<FacebookGroup>(FBPlugin.GetGroupData(GroupID, FBAuth.UserAccessToken));
            FBGroup.Members = JsonConvert.DeserializeObject<FacebookMembers>(FBPlugin.GetGroupMembers(GroupID, FBAuth.UserAccessToken));
            Members = FBGroup.Members.Data;
            FBGroup.Posts = JsonConvert.DeserializeObject<FacebookFeed>(FBPlugin.GetGroupFeed(GroupID, FBAuth.UserAccessToken));
            GroupPosts = FBGroup.Posts.Data;
        }

        public void SetPublicPage()
        {
            FBPage = JsonConvert.DeserializeObject<FacebookPage>(FBPlugin.GetPublicPageData(PageID, FBAuth.UserAccessToken));
        }

        public void SetPost()
        {
            FBPost = JsonConvert.DeserializeObject<FacebookPost>(FBPlugin.GetPostData(PostID, FBAuth.PageAccessToken));
            FBPost.Comments = JsonConvert.DeserializeObject<FacebookComments>(FBPlugin.GetPostComments(PostID, FBAuth.PageAccessToken));
            Comments = FBPost.Comments.Data;
            FBPost.Likes = JsonConvert.DeserializeObject<FacebookProfiles>(FBPlugin.GetPostLikes(PostID, FBAuth.PageAccessToken));
            FBPost.Reactions = JsonConvert.DeserializeObject<FacebookReactions>(FBPlugin.GetPostReactions(PostID, FBAuth.PageAccessToken));
            Reactions = FBPost.Reactions.Data;
        }

        public void SetComment()
        {
            FBComment = JsonConvert.DeserializeObject<FacebookComment>(FBPlugin.GetComment(CommentID, FBAuth.PageAccessToken));
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

        public FacebookGroup FBGroup
        {
            get { return _fbGroup; }
            set
            {
                if (_fbGroup != value)
                {
                    _fbGroup = value;
                    RaisePropertyChanged("FBGroup");
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

        public string GroupID
        {
            get { return FBGroup.ID; }
            set
            {
                if (FBGroup.ID != value)
                {
                    FBGroup.ID = value;
                    RaisePropertyChanged("GroupID");
                }
            }
        }

        public ObservableCollection<FacebookPost> PagePosts
        {
            get { return _pagePosts; }
            set
            {
                if (_pagePosts != value)
                {
                    _pagePosts = value;
                    RaisePropertyChanged("PagePosts");
                }
            }
        }

        public ObservableCollection<FacebookPost> GroupPosts
        {
            get { return _groupPosts; }
            set
            {
                if (_groupPosts != value)
                {
                    _groupPosts = value;
                    RaisePropertyChanged("GroupPosts");
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

        public ObservableCollection<Reaction> Reactions
        {
            get { return _reactions; }
            set
            {
                if (_reactions != value)
                {
                    _reactions = value;
                    RaisePropertyChanged("Reactions");
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

        public ObservableCollection<FacebookGroup> Groups
        {
            get { return _groups; }
            set
            {
                if (_groups != value)
                {
                    _groups = value;
                    RaisePropertyChanged("Groups");
                }
            }
        }

        public ObservableCollection<FacebookUser> Members
        {
            get { return _members; }
            set
            {
                if (_members != value)
                {
                    _members = value;
                    RaisePropertyChanged("Members");
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
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
