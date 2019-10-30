using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AISET.Models;
using AISET.Repository.BL;
namespace AISET.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            StudentModels models = new StudentModels();
            models = clsLoginBL.BindStudentDetailsByID(Convert.ToInt32(Session[SessionVariable.UserID].ToString()));


            return View(models);
        }
        [HttpPost]
        public ActionResult Index(StudentModels models)
        {

            if (ModelState.IsValid)
            {

                ResponseModels rsp = clsLoginBL.UpdateStudentDetails(models);
                if (rsp.Response == MethodResponse.Success)
                {
                    ViewBag.Message = "The Record has been Updated Successfully.";
                }
                else
                {
                    ViewBag.Message = "Something went wrong please try again.";
                }
            }


            return View(models);
        }


        public ActionResult ExamResults()
        {
            return View();
        }
        public ActionResult AdmitCard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {



            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel models)
        {

            if (ModelState.IsValid)

            {
                if (models.OldPassword == Session[SessionVariable.Password].ToString())
                {
                    ModelState.AddModelError("", "The current Password does not match.");
                    return View(models);
                }
                ViewBag.Message = "The Password changed successfully.";
                models.UserID = Convert.ToInt32(Session[SessionVariable.UserID].ToString());
                clsLoginBL.ChangePassword(models);
            }
            else

            {
                ModelState.AddModelError("", "Something went wrong please try again");
            }

            return View(models);
        }
    }
}