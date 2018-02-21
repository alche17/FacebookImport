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
                _mvm.SetUser();
            }
        }
        
        private void GetUserDataClick(object sender, RoutedEventArgs e)
        {
            _mvm.SetUser();
            _mvm.SetPages();
        }
    }
}
