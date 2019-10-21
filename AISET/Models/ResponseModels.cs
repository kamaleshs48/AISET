using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AISET.Models
{
    public class ResponseModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int OrgID { get; set; }
        public MethodResponse Response { get; set; }

    }
    public enum MethodResponse
    {
        Success,
        Invalid_Email_And_Password,
        SomthingWorng,

    }
    public static class SessionVariable
    {
        public const string LoginUserDetails = "LoginUserDetails";
        public const string UserID = "UserID";
        
    }
}