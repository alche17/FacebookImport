using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// A facebook group
    /// The /{group-id} node returns a single group
    /// </summary>
    public class FacebookGroup : FacebookProfile
    {
        #region fields
        public string Privacy { get; set; }
        #endregion

        #region edges
        public FacebookFeed Posts { get; set; }

        public FacebookMembers Members { get; set; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
