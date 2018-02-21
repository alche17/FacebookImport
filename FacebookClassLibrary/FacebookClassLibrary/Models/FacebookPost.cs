
using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// An individual entry in a profile's feed. The profile could be a User, Page, or Group
    /// </summary>
    public class FacebookPost
    {
        #region fields
        public string ID { get; set; }
        
        public FacebookProfile From { get; set; }

        public string Message { get; set; }
        
        public Place Place { get; set; }
        #endregion

        #region edges
        public int Likes { get; set; }

        public ObservableCollection<FacebookComment> Comments { get; set; }
        #endregion
    }
}
