﻿
namespace FacebookClassLibrary.Models
{
    /// <summary>
    ///  A user represents a person on Facebook. The /{user-id} node returns a single user
    /// </summary>
    public class FacebookUser : FacebookProfile
    {
        public FacebookUser()
        {
        }

        #region Fields
        public Location Address { get; set; }
        
        public AgeRange AgeRange { get; set; }

        public string Gender { get; set; }

        public string Locale { get; set; }
        #endregion

        #region Edges
        public FacebookAccounts Accounts { get; set; }
        #endregion
    }
}
