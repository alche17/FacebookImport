using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// Accounts are a collection of Facebook Pages a User has a role on
    /// </summary>
    public class FacebookFeed
    {
        public ObservableCollection<FacebookPost> Data { get; set; }

        public Dictionary<string, Dictionary<string,string>> Paging { get; set; }
    }
}
