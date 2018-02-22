using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FacebookClassLibrary.Models
{
    public class FacebookPage : FacebookProfile
    {
        #region fields
        public string Access_Token { get; set; }

        public string Category { get; set; }

        public string Fan_Count { get; set; }

        public ObservableCollection<string> Perms { get; set; }
        #endregion

        #region edges
        public  FacebookFeed Posts { get; set; }
        #endregion
    }
}
