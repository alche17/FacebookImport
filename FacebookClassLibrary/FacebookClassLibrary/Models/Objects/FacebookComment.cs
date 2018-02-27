
namespace FacebookClassLibrary.Models
{
    /// <summary>
    /// A comment can be made on various types of content on Facebook
    /// They can be retrieved using the /comments edge in the Graph API
    /// The /{comment-id} node returns a single comment
    /// </summary>
    public class FacebookComment
    {
        public string ID { get; set; }

        public FacebookProfile From { get; set; }

        public int Like_Count { get; set; }

        public string Message { get; set; }

        public FacebookComments Comments { get; set; }

        public FacebookReactions Reactions { get; set; }

        public FacebookProfiles Likes { get; set; }
    }
}
