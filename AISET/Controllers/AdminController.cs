using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AISET.Models;

using AISET.Repository.BL;
namespace AISET.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            RegisterModels models = new RegisterModels();

            models._StudentList = clsLoginBL.GetAllStudentList();








            return View(models);
        }



        public ActionResult GenerateAdmitCard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateEditDate()
        {
            EditUpdateDateModels models = new EditUpdateDateModels();
            models.LastEditDate = clsLoginBL.GetLastDateForEdit();
            return View(models);
        }

        [HttpPost]
        public ActionResult UpdateEditDate(EditUpdateDateModels models)
        {
            if (ModelState.IsValid)
            {
                clsLoginBL.UpdateLastDateForEdit(models.LastEditDate.ToString());
                ViewBag.Message = "Record Updated Sucessfully";
            }
            return View(models);
        }

    }
}