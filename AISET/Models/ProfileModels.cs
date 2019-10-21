using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace AISET.Models
{
    public class ProfileModels
    {

        public int UserID { get; set; }
        public string Summary { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public string Courses { get; set; }
        public string Batch { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skyup { get; set; }
        public string EmergencyConcatNo { get; set; }

    }
    public class TestModels
    {
        public string TestName { get; set; }
        public string TestDateTime { get; set; }
        public bool Completed { get; set; }
        public int TimeInMinut { get; set; }
        public int TotalQuestion { get; set; }
        public int TotalMarks { get; set; }
        public List<TestModels> TestList = new List<TestModels>();


    }


    public class TestPaperModels
    {
        public string EncodedStudentID { get; set; }
        public int PaperID { get; set; }
        public string  EncodedPaperID { get; set; }
        public string PaperTitle { get; set; }
        public string PaperDate { get; set; }
        public string PaperStartTime { get; set; }
        public string PaperEndTime { get; set; }
        public int TotalQuestion { get; set; }
        public string TimeDuration { get; set; }
        public int PassingMarks { get; set; }
        public DateTime _PaperDate { get; set; }

        public int TestStatus { get; set; }

        public List<TestPaperModels> PaperList = new List<TestPaperModels>();

    }

        public class ScheduleClassModels
    {

        private List<SelectListItem> _TimeList = new List<SelectListItem>()
        {
new SelectListItem{ Text="01",Value="01"},
new SelectListItem{ Text="02",Value="02"},
new SelectListItem{ Text="03",Value="03"},
new SelectListItem{ Text="04",Value="04"},
new SelectListItem{ Text="05",Value="05"},
new SelectListItem{ Text="06",Value="06"},
new SelectListItem{ Text="07",Value="07"},
new SelectListItem{ Text="08",Value="08"},
new SelectListItem{ Text="09",Value="09"},
new SelectListItem{ Text="10",Value="10"},
new SelectListItem{ Text="11",Value="11"},
new SelectListItem{ Text="12",Value="12"},

        };
        private List<SelectListItem> _AMPMList = new List<SelectListItem>()
        {
new SelectListItem{ Text="AM",Value="AM"},
new SelectListItem{ Text="PM",Value="PM"},

        };


        public string ClassDate { get; set; }
        public string StartTime { get; set; }
        public string StartTimeAMPM { get; set; }
        public string EndTime { get; set; }
        public string EndTimeAMPM { get; set; }
        public string LessionName { get; set; }
        public int ClassID { get; set; }
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public int UserID { get; set; }
        public DateTime SessionDateTime { get; set; }
        public List<SelectListItem> TimeList { get { return _TimeList; } }
        public List<SelectListItem> AMPMList { get { return _AMPMList; } }

        public List<ScheduleClassModels> ScheduleClassList = new List<ScheduleClassModels>();

    }
    public class ForgotPasswordModels
    {
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}