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
        FacebookPlugin _fb;

        public MainWindow()
        {
            InitializeComponent();

            _fb = new FacebookPlugin();
            _mvm = new MainViewModel();
            DataContext = _mvm;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            FacebookAuthenticationWindow dialog = new FacebookAuthenticationWindow();
            if (dialog.ShowDialog() == true)
            {
                // need to set access token somewhere
                //_mvm.AccessToken = dialog.Fbvm.AccessToken;
            }
        }
        
        private void GetPageDataClick(object sender, RoutedEventArgs e)
        {
            var data = _fb.GetPageData();
            _mvm.SetFacebookPageData(data);
        }
    }
}
