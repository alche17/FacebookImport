using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models
{
    public class FacebookMembers
    {
        public ObservableCollection<FacebookUser> Data { get; set; }

        public Dictionary<string, Dictionary<string, string>> Paging { get; set; }
    }
}
