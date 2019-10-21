using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AISET.Repository.DL;

namespace AISET.Models
{
    public class RegisterModels
    {
        public string FormID { get; set; }
        public string IPAddress { get; set; }
        [Required(ErrorMessage = "Please Select Applying For")]
        public string Applaying { get; set; }

        public List<SelectListItem> ApplayingList = new List<SelectListItem>()
        {

                 new SelectListItem { Text="PCM",Value="PCM" },
                 new SelectListItem { Text="PCB",Value="PCB" },
        };
        [Required(ErrorMessage = "Please Date Of Birth")]
       
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
        public List<SelectListItem> GenderList = new List<SelectListItem>()
        {

                new SelectListItem { Text="Male",Value="Male" },
                 new SelectListItem { Text="Female",Value="Female" },

            };
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile No")]
        public string MobileNo { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select Exam Choice")]
        public string ExamChoice { get; set; }
        public List<SelectListItem> ExamChoiceList = new List<SelectListItem>()
               {

                new SelectListItem {Text="Open book",Value="1" },
                new SelectListItem {Text="Target",Value="2" }
            };

        public string ExamCenter { get; set; }
        public string City { get; set; }
        public List<SelectListItem> CityList = new List<SelectListItem>();
        [Required(ErrorMessage = "Please Select State Name")]
        public string StateName { get; set; }

        public List<SelectListItem> StateList { get { return CommanFunction.GetStateList(); } }
        public string PostCode { get; set; }
        [Required(ErrorMessage = "Please Select Applying For")]
        public string IDCardType { get; set; }
        public List<SelectListItem> IDCardTypeList = new List<SelectListItem>()
        {

                new SelectListItem { Text="Voter Card",Value="Voter Card" },
                 new SelectListItem { Text="Aadhar Card",Value="Aadhar Card" },
                  new SelectListItem { Text="Pan Card",Value="Pan Card" },
        };
        public string IDCardNumber { get; set; }
        public string ExaminationMedium { get; set; }
        public List<SelectListItem> ExaminationMediumList = new List<SelectListItem>()
        {
            new SelectListItem {Text="English",Value="English" },
             new SelectListItem {Text="Hindi",Value="Hindi" }
        };


        public string ExaminationPrefrence1 { get; set; }
        public string ExaminationPrefrence2 { get; set; }
        public string ExaminationPrefrence3 { get; set; }
        public string ExaminationPrefrence4 { get; set; }


        [Required]
        public string _10PassingYear { get; set; }
        [Required]
        public string _10PassingBoard { get; set; }
        [Required]
        public string _10PassingPercentag { get; set; }
        [Required]
        public string _12PassingYear { get; set; }
        [Required]
        public string _12PassingBoard { get; set; }
        [Required]
        public string _12PassingPercentag { get; set; }


        public string GraduationPassingYear { get; set; }
        public string GraduationPassingBoard { get; set; }
        public string GraduationPassingPercentag { get; set; }
        public string Post_GraduationPassingYear { get; set; }
        public string Post_GraduationPassingBoard { get; set; }
        public string Post_GraduationPassingPercentag { get; set; }

        public string AnyOther_PassingYear { get; set; }
        public string AnyOther_PassingBoard { get; set; }
        public string AnyOther_PassingPercentag { get; set; }

        [Required]
        public string Photograph { get; set; }
        [Required]
        public string Signature { get; set; }
        [Required]
        public string Marksheet10 { get; set; }
        [Required]
        public string Marksheet12 { get; set; }
        public string Any_Other { get; set; }
        public string PaybalAmount { get; set; }

    }
    public class LoginModels
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

    }
}
