
namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// Location node used with other objects in the Graph API
    /// </summary>
    public class Location
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
