using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using FacebookClassLibrary.ViewModels;
using FacebookClassLibrary;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for FacebookAuthenticationWindow.xaml
    /// </summary>
    public partial class FacebookAuthenticationWindow : Window
    {
        public FacebookAuthenticationViewModel Fbvm;
        public FacebookPlugin FbPlugin;

        public FacebookAuthenticationWindow()
        {
            InitializeComponent();

            Fbvm = new FacebookAuthenticationViewModel();
            FbPlugin = new FacebookPlugin();
            DataContext = Fbvm;

            Loaded += (object sender, RoutedEventArgs e) =>
            {
                DeleteFacebookCookie();

                var destinationURL = String.Format("https://www.facebook.com/v2.12/dialog/oauth?" +
                    "client_id=191439638113408" +
                    "&display=popup" +
                    "&response_type=token" +
                    "&redirect_uri=https://www.facebook.com/connect/login_success.html" +
                    "&scope=manage_pages,read_insights");
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
                FbPlugin.SetUserAccessToken(urlParams["access_token"]);
                DialogResult = true;
                Close();
            }
        }

        public Dictionary<string, string> GetParams(string uri)
        {
            var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
            var keyValues = new Dictionary<string, string>(matches.Count);
            foreach (Match m in matches)
                keyValues.Add(Uri.UnescapeDataString(m.Groups[2].Value), Uri.UnescapeDataString(m.Groups[3].Value));

            return keyValues;
        }
    }
}
