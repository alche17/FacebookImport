using System.Windows;
using System;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string AccessToken { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            AccessToken = "Nothing yet";
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            FacebookAuthenticationWindow dialog = new FacebookAuthenticationWindow() { AppID = "191439638113408" };
            if (dialog.ShowDialog() == true)
            {
                AccessToken = dialog.AccessToken;
            }
        }
    }
}
