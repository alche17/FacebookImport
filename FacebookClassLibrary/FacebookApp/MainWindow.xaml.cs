using System.Windows;
using FacebookApp.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;

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

        private void ExportToCSVClick(object sender, RoutedEventArgs e)
        {
            _mvm.ExportToCSV();
        }
        
        private void GetUserInfoClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUser();
        }

        private void GetPageClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUserPage();
        }

        private void GetGroupClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUserGroup();
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
            _mvm.SetComment();
        }

        private void GetKCCPageClick(object sender, RoutedEventArgs e)
        {
            _mvm.PageID = "CityOfKingston";
            _mvm.SetPublicPage();
        }

        private void GetKCCSamplePostClick(object sender, RoutedEventArgs e)
        {
            _mvm.PageID = "CityOfKingston";
            _mvm.PostID = "144064188977112_1815243248525856";
            _mvm.SetPost();
        }
    }
}
