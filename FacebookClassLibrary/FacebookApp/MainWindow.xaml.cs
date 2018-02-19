using System.Windows;
using System;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FacebookAuthenticationWindow dialog = new FacebookAuthenticationWindow() { AppID = "191439638113408" };
            if (dialog.ShowDialog() == true)
            {
                string accessToken = dialog.AccessToken;
            }
        }
    }
}
