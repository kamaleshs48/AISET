using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AISET.Models
{
    public static class ApplicationModels
    {
        private static string _CompanyName = "E-Exam";
        private static string _CopyRight = "E-Exam";
        private static string _ApplicationTitle = "Welcome to E Exam |Student Panel";


        public static string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        public static string CopyRight
        {

            get { return _CopyRight; }
            set { _CopyRight = value; }
        }
        public static string ApplicationTitle
        {
            get { return _ApplicationTitle; }
            set {_ApplicationTitle=value; }
        }

        public static string CompanyLogo { get; set; }
    }
}