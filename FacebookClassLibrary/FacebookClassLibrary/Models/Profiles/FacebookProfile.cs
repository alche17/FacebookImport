
namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// A profile can be a User, Page, Group, Event, or Application
    /// The /{profile-id} node returns a single profile
    /// </summary>
    public class FacebookProfile
    {
        public string ID { get; set; }

        public string Name { get; set; }
    }
}
