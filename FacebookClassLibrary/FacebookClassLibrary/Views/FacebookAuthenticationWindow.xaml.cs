using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for FacebookAuthenticationWindow.xaml
    /// </summary>
    public partial class FacebookAuthenticationWindow : Window
    {
        public string AppID { get; set; }

        public string AccessToken { get; set; }

        public FacebookAuthenticationWindow()
        {
            InitializeComponent();
            this.Loaded += (object sender, RoutedEventArgs e) =>
            {
                wbSample.MessageHook += wbSample_MessageHook;

                DeleteFacebookCookie();

                var destinationURL = String.Format("https://www.facebook.com/v2.12/dialog/oauth?" +
                    "client_id=191439638113408" +
                    "&display=popup" +
                    "&response_type=token" +
                    "&redirect_uri=https://www.facebook.com/connect/login_success.html");
                wbSample.Navigate(destinationURL);
            };
        }

        private void DeleteFacebookCookie()
        {
            string cookie = string.Format("c_user=; expires={0:R}; path=/; domain=.facebook.com", DateTime.UtcNow.AddDays(-1).ToString("R"));
            Application.SetCookie(new Uri("https://www.facebook.com"), cookie);
        }

        private void wbSample_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var url = e.Uri.Fragment;
            if (url.Contains("access_token") && url.Contains("#"))
            {
                url = (new Regex("#")).Replace(url, "?", 1);
                Dictionary<string, string> urlParams = GetParams(url);
                AccessToken = urlParams["access_token"];
                DialogResult = true;
                this.Close();
            }
        }

        private void wbSample_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.Uri.LocalPath == "/r.php")
            {
                MessageBox.Show("To create a new account go to www.facebook.com", "Could Not Create Account", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Cancel = true;
            }
        }

        IntPtr wbSample_MessageHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 130)
            {
                this.Close();
            }
            return IntPtr.Zero;
        }

        static Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var keyValues = new Dictionary<string, string>(matches.Count);
            foreach (Match m in matches)
                keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));

            return keyValues;
        }
    }
}
