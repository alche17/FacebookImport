using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FacebookClassLibrary.Models
{
    public class FacebookPage : FacebookProfile
    {
        public FacebookPage()
        {
        }

        #region fields
        public string Access_Token { get; set; }

        public string Category { get; set; }

        public string Fan_Count { get; set; }

        public ObservableCollection<string> Perms { get; set; }
        #endregion

        #region edges
        public ObservableCollection<FacebookPost> Posts { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
