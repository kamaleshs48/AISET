using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AISET.Models;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
namespace Student.Repository.DL
{
    public class clsLoginDL
    {
        public static ResponseModels Login(LoginModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@Email",models.EmailID),
            new SqlParameter("@Password",models.Password),
            new SqlParameter("@Mode","StudentLogin")

            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_Login", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                result.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;

        }

        internal static ResponseModels ChangePassword(ChangePasswordViewModel models)
        {
            ResponseModels _Resp = new ResponseModels();
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, "UPDATE tbl_StudentMaster Set Password= '" + models.NewPassword + "' Where ID=" + models.UserID);

                _Resp.Response = MethodResponse.Success;
            }
            catch (Exception ex)
            {
                _Resp.Response = MethodResponse.SomthingWorng;
                _Resp.Email = ex.Message;
            }
            return _Resp;
        }

        internal static string GetLastDateForEdit()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, "Select CONVERT(VARCHAR,LastDate,103) from tbl_StudentEditDate");

            return ds.Tables[0].Rows[0][0].ToString();


        }

        internal static ResponseModels UpdateStudentDetails(StudentModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@FirstName",models.FirstName),
            new SqlParameter("@LastName",models.LastName),
            new SqlParameter("@MobileNo",models.MobileNo),
          
            new SqlParameter("@DOB",models.DOB),
            new SqlParameter("@StudentID",models.StudentID),

            new SqlParameter("@Mode","UpdateStudentDetails")
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                result.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                result.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                result.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                // result.OrgID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORGID"].ToString());
                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }

        internal static string UpdateLastDateForEdit(string lastDate)
        {

            SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, "UPDATE tbl_StudentEditDate Set  LastDate ='" + DateTime.ParseExact(lastDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) + "'");
            return "";

        }

        public static ResponseModels ForgotPassword(ForgotPasswordModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@Email",models.Email),

            new SqlParameter("@Mode","ForgotPassword")
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_Login", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                result.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                result.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                result.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                // result.OrgID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORGID"].ToString());
                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }

        internal static int UpdateStudentDetails(RegisterModels models)
        {
            SqlParameter[] pr = new SqlParameter[]
           {
            new SqlParameter("@Email",models.Email),

            new SqlParameter("@Mode","ForgotPassword")
           };
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_Login", pr);

        }

        internal static StudentModels BindStudentDetailsByID(int studentID)
        {


            StudentModels _models = new StudentModels();
            string _Qry = "Select * from tbl_StudentMaster Where ID=" + studentID;


            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, _Qry);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                _models.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                _models.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                _models.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                _models.MobileNo = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                _models.DOB = ds.Tables[0].Rows[0]["DOB"].ToString();
                _models.StudentID = studentID.ToString();

            }



            return _models;
        }
        

        public static ResponseModels Register(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@ApplyingFor",models.Applaying),
            new SqlParameter("@DOB",models.DOB),
            new SqlParameter("@Gender",models.Gender),
            new SqlParameter("@FirstName",models.FirstName),
            new SqlParameter("@MiddleName",models.MiddleName),
            new SqlParameter("@LastName",models.LastName),
            new SqlParameter("@MobileNo",models.MobileNo),
            new SqlParameter("@Email",models.Email),
            new SqlParameter("@Password",models.Password),
             new SqlParameter("@Mode","REGISTER"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }
        public static ResponseModels Step1(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@ApplyingFor",models.Applaying),
            new SqlParameter("@DOB",models.DOB),
            new SqlParameter("@Gender",models.Gender),
            new SqlParameter("@FirstName",models.FirstName),
            new SqlParameter("@MiddleName",models.MiddleName),
            new SqlParameter("@LastName",models.LastName),
            new SqlParameter("@MobileNo",models.MobileNo),
            new SqlParameter("@Email",models.Email),
             new SqlParameter("@StudentID",models.FormID),
             new SqlParameter("@Mode","STEP1"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }
        public static ResponseModels Step2(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@ExamChoice",models.ExamChoice),
            new SqlParameter("@State",models.StateName),
            new SqlParameter("@City",models.City),
            new SqlParameter("@IDCardType",models.IDCardType),
            new SqlParameter("@IDCardNumber",models.IDCardNumber),
            new SqlParameter("@ExaminationMedium",models.ExaminationMedium),
            new SqlParameter("@CityPreference1",models.ExaminationPrefrence1),
            new SqlParameter("@CityPreference2",models.ExaminationPrefrence2),
            new SqlParameter("@CityPreference3",models.ExaminationPrefrence3),
            new SqlParameter("@CityPreference4",models.ExaminationPrefrence4),
              new SqlParameter("@StudentID",models.FormID),
             new SqlParameter("@Mode","STEP2"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }
        public static ResponseModels Step3(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@ApplyingFor",models.Applaying),
            new SqlParameter("@DOB",models.DOB),
            new SqlParameter("@Gender",models.Gender),
            new SqlParameter("@FirstName",models.FirstName),
            new SqlParameter("@MiddleName",models.MiddleName),
            new SqlParameter("@LastName",models.LastName),
            new SqlParameter("@MobileNo",models.MobileNo),
            new SqlParameter("@Email",models.Email),
             new SqlParameter("@StudentID",models.FormID),
             new SqlParameter("@Mode","STEP3"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }
        public static ResponseModels Step4(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@_10thPassingYear",models._10PassingYear),
            new SqlParameter("@_10thPassingBoard",models._10PassingBoard),
            new SqlParameter("@_10thPassingPercentag",models._10PassingPercentag),
             new SqlParameter("@_12thPassingYear",models._12PassingYear),
            new SqlParameter("@_12thPassingBoard",models._12PassingBoard),
            new SqlParameter("@_12thPassingPercentag",models._12PassingPercentag),


            new SqlParameter("@GraduationPassingYear",models.GraduationPassingYear),
            new SqlParameter("@GraduationPassingBoard",models.GraduationPassingBoard),
            new SqlParameter("@GraduationPassingPercentag",models.GraduationPassingPercentag),


            new SqlParameter("@Post_GraduationPassingYear",models.Post_GraduationPassingYear),
            new SqlParameter("@Post_GraduationPassingBoard",models.Post_GraduationPassingBoard),
            new SqlParameter("@Post_GraduationPassingPercentag",models.Post_GraduationPassingPercentag),

            new SqlParameter("@Any_OtherPassingYear",models.AnyOther_PassingYear),
            new SqlParameter("@Any_OtherPassingBoard",models.AnyOther_PassingBoard),
            new SqlParameter("@Any_OtherPassingPercentag",models.AnyOther_PassingPercentag),



             new SqlParameter("@StudentID",models.FormID),
             new SqlParameter("@Mode","STEP4"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }
        public static ResponseModels Step5(RegisterModels models)
        {
            ResponseModels result = new ResponseModels();
            result.Response = MethodResponse.Success;
            DataSet ds = new DataSet();
            SqlParameter[] pr = new SqlParameter[]
            {
            new SqlParameter("@ApplyingFor",models.Applaying),
            new SqlParameter("@DOB",models.DOB),
            new SqlParameter("@Gender",models.Gender),
            new SqlParameter("@FirstName",models.FirstName),
            new SqlParameter("@MiddleName",models.MiddleName),
            new SqlParameter("@LastName",models.LastName),
            new SqlParameter("@MobileNo",models.MobileNo),
            new SqlParameter("@Email",models.Email),
             new SqlParameter("@StudentID",models.FormID),
             new SqlParameter("@Mode","STEP5"),
            };
            ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                result.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                result.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());


                result.Response = MethodResponse.Success;
            }
            else
            {
                result.Response = MethodResponse.Invalid_Email_And_Password;
            }
            return result;
        }


        public static int UpdatePayment(string FID, string PID)
        {
            var xxx = "UPDATE tbl_StudentMaster SET PaymentID ='" + PID + "' WHERE ID = " + FID;


            SqlParameter[] pr = new SqlParameter[]
           {
            new SqlParameter("@PaymentID",PID),

             new SqlParameter("@StudentID",FID),
             new SqlParameter("@Mode","STEP6"),
           };

            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_SaveUpdateRecord", pr);
        }



        public static List<RegisterModels> GetAllStudentList()
        {
            List<RegisterModels> _List = new List<RegisterModels>();

            string _Qry = "Select * from tbl_StudentMaster";


            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, _Qry);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _List.Add(new RegisterModels
                    {
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["FirstName"].ToString(),
                        Email = dr["FirstName"].ToString(),
                        MobileNo = dr["FirstName"].ToString(),
                        ExaminationPrefrence1 = dr["CityPreference1"].ToString(),
                        ExaminationPrefrence2 = dr["CityPreference2"].ToString(),
                        Applaying = dr["ApplyingFor"].ToString(),
                    });

                }
            }


            return _List;


        }
    }
}