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

        public static ResponseModels ForgotPassword(ForgotPasswordModels models)
        {
            return   clsLoginDL.ForgotPassword (models);
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
        public static  int UpdatePayment (string FID,string PID)
        {
            return clsLoginDL.UpdatePayment(FID, PID);
        }
    }
}