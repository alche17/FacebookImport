using System.Windows;
using FacebookApp.ViewModels;
using FacebookClassLibrary;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _mvm;

        public MainWindow()
        {
            InitializeComponent();
            
            _mvm = new MainViewModel();
            DataContext = _mvm;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            FacebookAuthenticationWindow dialog = new FacebookAuthenticationWindow();
            if (dialog.ShowDialog() == true)
            {
            }
        }
        
        private void GetUserInfoClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUser();
        }

        private void GetUserPagesClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUserPages();
        }

        private void GetPageClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUserPage();
        }

        private void GetPublicPageClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetPublicPage();
        }

        private void GetPostClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetPost();
        }

        private void GetCommentClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void GetKCCPageClick(object sender, RoutedEventArgs e)
        {
            _mvm.PageID = "CityOfKingston";
            _mvm.SetUserPage();
        }

        private void GetKCCFeedClick(object sender, RoutedEventArgs e)
        {
            _mvm.PageID = "CityOfKingston";
            _mvm.SetFeed();
        }

        private void GetKCCSamplePostClick(object sender, RoutedEventArgs e)
        {
            _mvm.PageID = "CityOfKingston";
            _mvm.PostID = "144064188977112_1813323618717819";
            _mvm.SetPost();
        }
    }
}
