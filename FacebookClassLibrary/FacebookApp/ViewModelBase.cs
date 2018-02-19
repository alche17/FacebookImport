
namespace FacebookApp
{
    public class ViewModelBase
    {
        public RelayCommand Command { get; set; }

        public string AccessToken { get; set; }

        public string AppID { get; set; }

        public ViewModelBase()
        {
            Command = new RelayCommand(this);
        }

        public void OnCommand()
        {
            FacebookAuthenticationWindow dialog = new FacebookAuthenticationWindow() { AppID = "191439638113408" };
            if (dialog.ShowDialog() == true)
            {
                string accessToken = dialog.AccessToken;
            }
        }
    }
}
