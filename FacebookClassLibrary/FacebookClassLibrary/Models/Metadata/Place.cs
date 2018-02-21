
namespace FacebookClassLibrary.Models
{
    public class Place
    {
        public Place()
        {
        }

        public string ID { get; set; }

        public Location Location { get; set; }

        public string Name { get; set; }

        public float Overall_Rating { get; set; }
    }
}
