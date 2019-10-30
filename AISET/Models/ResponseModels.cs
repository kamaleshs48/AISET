using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace AISET.Models
{


    public class EditUpdateDateModels
    {
        [Required(ErrorMessage = "Please enter Date")]
        public string LastEditDate { get; set; }
    }
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
        public const string Password = "Password";

    }
}