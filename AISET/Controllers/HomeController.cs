﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AISET.Models;
using AISET.Repository.BL;
using Microsoft.AspNet.Identity;
using AISET.Controllers;
using AISET.Repository.DL;

namespace AISET.Controllers
{
    public class HomeController : BaseController
    {
        ResponseModels res = new ResponseModels();


        public ActionResult ForgotRegistrationNo()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Step1()
        {

            RegisterModels models = new RegisterModels();

            if (Session["ModelValue"] != null)
            {
                models = (RegisterModels)Session["ModelValue"];
            }


            return View(models);
        }

        [HttpGet]
        public ActionResult Step2()
        {

            RegisterModels models = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                models = (RegisterModels)Session["ModelValue"];
            }
            return View(models);
        }

        [HttpGet]
        public ActionResult Step3()
        {

            RegisterModels models = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                models = (RegisterModels)Session["ModelValue"];
            }

            if (!string.IsNullOrEmpty(models.ExamChoice) && models.ExamChoice == "1")
            {
                models.PaybalAmount = (1800 * 100).ToString();
            }
            else
            {

                models.PaybalAmount = (999 * 100).ToString();
            }
            return View(models);
        }

        [HttpGet]
        public ActionResult Step4()
        {

            RegisterModels models = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                models = (RegisterModels)Session["ModelValue"];
            }
            return View(models);
        }

        [HttpGet]
        public ActionResult Step5()
        {

            RegisterModels models = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                models = (RegisterModels)Session["ModelValue"];
            }
            return View(models);
        }

        [HttpPost]
        public ActionResult Step1(string ID, string Commond, RegisterModels models)
        {

            RegisterModels OldModels = new RegisterModels();
            ResponseModels res = new ResponseModels();

            if (Session["ModelValue"] != null)
            {
                OldModels = (RegisterModels)Session["ModelValue"];
                res = clsLoginBL.Step1(models);
            }
            else
            {

                res = clsLoginBL.Register(models);
                OldModels.FormID = res.UserID.ToString();
            }
            OldModels.Applaying = models.Applaying;
            OldModels.DOB = models.DOB;
            OldModels.Gender = models.Gender;
            OldModels.FirstName = models.FirstName;
            OldModels.MiddleName = models.MiddleName;
            OldModels.LastName = models.LastName;
            OldModels.MobileNo = models.MobileNo;
            OldModels.Email = models.Email;


            Session["ModelValue"] = OldModels;







            return RedirectToAction("Step2", models);


        }
        [HttpPost]
        public ActionResult Step2(string ID, string Commond, RegisterModels models)
        {

            RegisterModels OldModels = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                OldModels = (RegisterModels)Session["ModelValue"];
                res = clsLoginBL.Step2(models);
            }



            OldModels.ExamChoice = models.ExamChoice;
            OldModels.StateName = models.StateName;
            OldModels.City = models.City;
            OldModels.IDCardType = models.IDCardType;
            OldModels.IDCardNumber = models.IDCardNumber;
            OldModels.ExaminationMedium = models.ExaminationMedium;
            OldModels.ExaminationPrefrence1 = models.ExaminationPrefrence1;
            OldModels.ExaminationPrefrence2 = models.ExaminationPrefrence2;
            OldModels.ExaminationPrefrence3 = models.ExaminationPrefrence3;
            OldModels.ExaminationPrefrence4 = models.ExaminationPrefrence4;





            Session["ModelValue"] = OldModels;


            if (Commond == "Next")
            {
                return RedirectToAction("Step3");
            }
            else
            {
                return RedirectToAction("Step1");
            }



        }
        [HttpPost]
        public ActionResult Step3(string ID, string Commond, RegisterModels models)
        {

            RegisterModels OldModels = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                OldModels = (RegisterModels)Session["ModelValue"];
                res = clsLoginBL.Step3(models);
            }
            Session["ModelValue"] = OldModels;



            return RedirectToAction("Step4", models);

        }
        [HttpPost]
        public ActionResult Step4(string ID, string Commond, RegisterModels models)
        {
            RegisterModels OldModels = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                OldModels = (RegisterModels)Session["ModelValue"];
                res = clsLoginBL.Step4(models);
            }


            OldModels._10PassingYear = models._10PassingYear;
            OldModels._10PassingBoard = models._10PassingBoard;
            OldModels._10PassingPercentag = models._10PassingPercentag;

            OldModels._12PassingYear = models._12PassingYear;
            OldModels._12PassingBoard = models._12PassingBoard;
            OldModels._12PassingPercentag = models._12PassingPercentag;

            OldModels.GraduationPassingYear = models.GraduationPassingYear;
            OldModels.GraduationPassingBoard = models.GraduationPassingBoard;
            OldModels.GraduationPassingPercentag = models.GraduationPassingPercentag;

            OldModels.Post_GraduationPassingYear = models.Post_GraduationPassingYear;
            OldModels.Post_GraduationPassingBoard = models.Post_GraduationPassingBoard;
            OldModels.Post_GraduationPassingPercentag = models.Post_GraduationPassingPercentag;

            OldModels.AnyOther_PassingYear = models.AnyOther_PassingYear;
            OldModels.AnyOther_PassingBoard = models.AnyOther_PassingBoard;
            OldModels.AnyOther_PassingPercentag = models.AnyOther_PassingPercentag;




            Session["ModelValue"] = OldModels;
            if (Commond == "Next")
            {
                return RedirectToAction("Step5", models);
            }
            else
            {
                return RedirectToAction("Step3", models);
            }
        }
        [HttpPost]
        public ActionResult Step5(string ID, string Commond, RegisterModels models,
                HttpPostedFileBase Photograph,
                HttpPostedFileBase Signature,
                HttpPostedFileBase Marksheet10,
                HttpPostedFileBase Marksheet12,
                HttpPostedFileBase Any_Other)
        {
            RegisterModels OldModels = new RegisterModels();
            if (Session["ModelValue"] != null)
            {
                OldModels = (RegisterModels)Session["ModelValue"];
                res = clsLoginBL.Step5(models);
            }

            OldModels.Photograph = models.Photograph;
            OldModels.Signature = models.Signature;
            OldModels.Marksheet10 = models.Marksheet10;
            OldModels.Marksheet12 = models.Marksheet12;
            OldModels.Any_Other = models.Any_Other;


            TempData["RID"] = "AISET-" + DateTime.Now.ToString("ddMMyyyy") + models.FormID.ToString();

            Session["ModelValue"] = OldModels;

            return RedirectToAction("Confirmation", models);

        }

        public ActionResult MemberProfile()
        {
            return View();
        }

        public ActionResult Confirmation()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModels models)
        {
            if (models.EmailID == "admin@gmail.com" && models.Password == "abc@123456")
            {
                Session[SessionVariable.UserID] = "1";

                Session["FirstName"] = "Admin";
                return RedirectToAction("Index", "Admin");
            }
            ResponseModels respModels = new ResponseModels();
            respModels = clsLoginBL.Login(models);

            if (respModels.Response == MethodResponse.Success)
            {
                Session[SessionVariable.LoginUserDetails] = respModels;
                Session[SessionVariable.UserID] = respModels.UserID;
                Session[SessionVariable.Password] = models.Password;
                Session["FirstName"] = respModels.FirstName;
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(models);
            }


        }

        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Center()
        {
            return View();
        }

        public ActionResult UPayment(string FID, string PID)
        {

            clsLoginBL.UpdatePayment(FID, PID);
            return Json("Success", JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModels models)
        {
            if (ModelState.IsValid)
            {

                res = clsLoginBL.ForgotPassword(models);
                if (res.Response == MethodResponse.Success)
                {




                    string mailBody = "Dear <b>" + res.FirstName + "</b>,<br /><br/>";
                    mailBody += "Your password on the " + AppSettingModel.ApplicationName + "." + "<br /><br />";
                    mailBody += "Your details are as below:<br />";
                    mailBody += "<b>Full name:</b> " + res.FirstName + " " + res.LastName + "<br />";
                    mailBody += "<b>Email:</b> " + res.Email + "<br />";
                    mailBody += "<b>Password:</b> " + res.Password + "<br /><br />";
                    mailBody += "Please login to the service using this password. You will have to change your password when you first login. <br />";
                    mailBody += "If you did not request to reset your password, please notify IGspectrum Support Team immediately.<br /><br />";
                    mailBody += "Please <a href='" + this.HostName + "'>click here</a> to login into the " + AppSettingModel.ApplicationName + "." + "<br/><br/>";

                    IdentityMessage Message = new IdentityMessage();
                    Message.Subject = "Temporary password for the " + AppSettingModel.ApplicationName + "";
                    Message.Body = mailBody + CommanFunction.GetEmailFooter();
                    Message.Destination = res.Email;

                    CommanFunction.SendEmailAsync(Message);
                    ViewBag.JavascriptToRun = "ShowErrorPopup()";
                    ViewBag.Error = "Password has been reset and sent to your email.";

                }
                else

                {
                    ViewBag.JavascriptToRun = "ShowErrorPopup()";
                    ViewBag.Error = "Email ID does not exist.";

                }


            }
            return View(models);
        }



        [HttpGet]
        public JsonResult GetCenterList(string StateName)
        {

            List<SelectListItem> _List = new List<SelectListItem>();

            _List.Add(new SelectListItem { Text = "A", Value = "A" });
            _List.Add(new SelectListItem { Text = "B", Value = "B" });


            return Json(_List, JsonRequestBehavior.AllowGet);
        }

    }
}