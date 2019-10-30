using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AISET.Models;
using Student.Repository.DL;
namespace AISET.Repository.BL
{
    public class clsLoginBL
    {
        public static ResponseModels Login(LoginModels models)
        {
            return clsLoginDL.Login(models);
        }


        public static ResponseModels ChangePassword(ChangePasswordViewModel models)
        {
            return clsLoginDL.ChangePassword(models);
        }

        public static string UpdateLastDateForEdit(string LastDate)
        {
            return clsLoginDL.UpdateLastDateForEdit(LastDate);
        }

        public static string GetLastDateForEdit()
        {
            return clsLoginDL.GetLastDateForEdit();
        }

        public static ResponseModels ForgotPassword(ForgotPasswordModels models)
        {
            return clsLoginDL.ForgotPassword(models);
        }

        public static ResponseModels Register(RegisterModels models)
        {
            return clsLoginDL.Register(models);
        }

        public static ResponseModels Step1(RegisterModels models)
        {
            return clsLoginDL.Step1(models);
        }
        public static ResponseModels Step2(RegisterModels models)
        {
            return clsLoginDL.Step2(models);
        }
        public static ResponseModels Step3(RegisterModels models)
        {
            return clsLoginDL.Step3(models);
        }
        public static ResponseModels Step4(RegisterModels models)
        {
            return clsLoginDL.Step4(models);
        }
        public static ResponseModels Step5(RegisterModels models)
        {
            return clsLoginDL.Step5(models);
        }
        public static int UpdatePayment(string FID, string PID)
        {
            return clsLoginDL.UpdatePayment(FID, PID);
        }

        public static List<RegisterModels> GetAllStudentList()
        {
            return clsLoginDL.GetAllStudentList();
        }


        public static StudentModels BindStudentDetailsByID(int studentID)
        {
            return clsLoginDL.BindStudentDetailsByID(studentID);
        }
        public static int UpdateStudentDetails(RegisterModels models)
        {
            return clsLoginDL.UpdateStudentDetails(models);
        }

        public static ResponseModels UpdateStudentDetails(StudentModels models)
        {
            return clsLoginDL.UpdateStudentDetails(models);
        }

    }

}