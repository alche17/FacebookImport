using FacebookClassLibrary.Models.Metadata;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models
{
    public class FacebookReactions
    {
        public ObservableCollection<Reaction> Data { get; set; }

        public Dictionary<string, Dictionary<string, string>> Paging { get; set; }
    }
}
