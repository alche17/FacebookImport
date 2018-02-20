using System.Collections.ObjectModel;

namespace FacebookClassLibrary.Models.Page
{
    class Posts
    {
        public Posts()
        {
        }

        public ObservableCollection<string> Data { get; set; }

        public ObservableCollection<string> Paging { get; set; }

    }
}
