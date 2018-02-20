using FacebookClassLibrary.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace FacebookApp.ViewModels
{
    public class MainViewModel
    {
        private ObservableCollection<FacebookPage> _pages;

        public MainViewModel()
        {
            _pages = new ObservableCollection<FacebookPage>();
        }

        public ObservableCollection<FacebookPage> Pages
        {
            get { return _pages; }
            set { _pages = value; }
        }

        public void SetFacebookPageData(string data)
        {
            Pages.Clear();
            Pages.Add(JsonConvert.DeserializeObject<FacebookPage>(data));
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void RaisePropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
