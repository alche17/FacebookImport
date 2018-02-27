using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using FacebookClassLibrary.ViewModels;
using FacebookClassLibrary;
using FacebookApp.ViewModels;

namespace FacebookApp
{
    /// <summary>
    /// Interaction logic for FacebookAuthenticationWindow.xaml
    /// </summary>
    public partial class FacebookAuthenticationWindow : Window
    {
        public FacebookPlugin FbPlugin;
        public ViewModels.MainViewModel Fbvm;

        public FacebookAuthenticationWindow(ViewModels.MainViewModel viewModel)
        {
            InitializeComponent();

            Fbvm = viewModel;
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
                    "&scope=manage_pages,read_insights,user_location,user_birthday,user_managed_groups");
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

                Properties.Settings.Default.UserAccessToken = urlParams["access_token"];
                Properties.Settings.Default.Save();
                Fbvm.FBAuth.UserAccessToken = Properties.Settings.Default.UserAccessToken;
                Fbvm.IsLoggedIn();
                Fbvm.SetUser();
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
