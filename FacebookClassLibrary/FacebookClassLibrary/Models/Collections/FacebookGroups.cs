using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models
{
    public class FacebookGroups
    {
        public ObservableCollection<FacebookGroup> Data { get; set; }

        public Dictionary<string, Dictionary<string, string>> Paging { get; set; }
    }
}
