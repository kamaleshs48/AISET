﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Student.Repository.DL;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using AISET.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
namespace AISET.Repository.DL
{
    public static class CommanFunction
    {

        private static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        public static List<SelectListItem> GetStateList()
        {

            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, "Select Name FROM tbl_StateMaster Group By Name Order By Name ");

            List<SelectListItem> models = new List<SelectListItem>();


            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                models.Add(new SelectListItem
                {
                    Text = dr["NAME"].ToString(),

                    Value = dr["NAME"].ToString()
                });
            }
            return models;
        }
        public static string UrlEncode(string URL)
        {

            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(URL.ToString());
            return Convert.ToBase64String(encoded);
        }

        public static string UrlEncode(int encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe.ToString());
            return Convert.ToBase64String(encoded);
        }


        public static string UrlDecode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }

        private static Random random = new Random();
        public static string RandomPassword(int size = 4)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, size)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static DataSet GetDataSet(string Qry)
        {
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, Qry);
        }

        public static int ExecuteNonQuery(string Qry)
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.Text, Qry);
        }


        public static string GetResponse(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                // Set the Method property of the request to POST.
                request.Method = "GET";
                // Get the request stream.
                Stream dataStream = default(Stream);
                // = request.GetRequestStream();
                // Write the data to the request stream.
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                // Console.WriteLine(DirectCast(response, HttpWebResponse).StatusDescription)
                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                // Console.WriteLine(responseFromServer)
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            }
            catch
            {
                return "Error";
            }
        }
        public static DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            try
            {
                string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
                List<string> ColumnsName = new List<string>();

                foreach (string jSA in jsonStringArray)
                {
                    string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                    foreach (string ColumnsNameData in jsonStringData)
                    {
                        try
                        {
                            int idx = ColumnsNameData.IndexOf(":");
                            string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                            if (!ColumnsName.Contains(ColumnsNameString))
                            {
                                ColumnsName.Add(ColumnsNameString);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                        }
                    }
                    break; // TODO: might not be correct. Was : Exit For
                }
                foreach (string AddColumnName in ColumnsName)
                {
                    dt.Columns.Add(AddColumnName);
                }
                foreach (string jSA in jsonStringArray)
                {
                    string[] RowData__1 = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                    DataRow nr = dt.NewRow();
                    foreach (string rowData__2 in RowData__1)
                    {
                        try
                        {
                            int idx = rowData__2.IndexOf(":");
                            string RowColumns = rowData__2.Substring(0, idx - 1).Replace("\"", "");
                            string RowDataString = rowData__2.Substring(idx + 1).Replace("\"", "");
                            nr[RowColumns] = RowDataString;

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    dt.Rows.Add(nr);
                }
                return dt;
            }
            catch
            {
                return dt;
            }
        }

        public static List<ScheduleClassModels> MyScheduleClassList(int UserID)
        {
            List<ScheduleClassModels> _List = new List<ScheduleClassModels>();
            SqlParameter[] pr = new SqlParameter[] {
            new SqlParameter("@UserID",UserID),
            new SqlParameter("@Mode","GetScheduleClassListStudent")};
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_CreateScheduleClass", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _List.Add(new ScheduleClassModels
                    {
                        ClassDate = dr["SessionDate"].ToString(),
                        TeacherName = dr["TeacherName"].ToString(),
                        StartTime = dr["SessionStartTime"].ToString(),
                        EndTime = dr["SessionEndTime"].ToString(),
                        LessionName = dr["LessionName"].ToString(),
                        ClassID = Convert.ToInt32(dr["ClassID"].ToString()),
                        SessionDateTime = Convert.ToDateTime(dr["SessionDateTime"])

                    });
                }

            }
            return _List;

        }


        public static List<TestPaperModels> GetMyAssignPaperListList(int StudentID)
        {
            List<TestPaperModels> _List = new List<TestPaperModels>();
            SqlParameter[] pr = new SqlParameter[] {
            new SqlParameter("@StudentID",StudentID),
            new SqlParameter("@Mode","GetStudentTestPaperList")};
            DataSet ds = SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_GetStudentPapareList", pr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    _List.Add(new TestPaperModels
                    {
                        EncodedStudentID = UrlEncode(StudentID),
                        EncodedPaperID = UrlEncode(dr["Paper_ID"].ToString()),
                        PaperTitle = dr["Paper_Name"].ToString(),
                        TotalQuestion = Convert.ToInt32(dr["Total_Questions"].ToString()),
                        TimeDuration = dr["Duration"].ToString(),
                        PassingMarks = Convert.ToInt32(dr["Passing_Marks"].ToString()),
                        TestStatus = Convert.ToInt32(dr["TestStatus"].ToString()),

                        //TestStatus
                        _PaperDate = Convert.ToDateTime(dr["PaperDate"].ToString()),
                        PaperStartTime = Convert.ToDateTime(dr["StartTime"].ToString()).ToString("hh:mm tt"),
                        PaperEndTime = Convert.ToDateTime(dr["EndTime"].ToString()).ToString("hh:mm tt"),
                        PaperID = Convert.ToInt32(dr["Paper_ID"].ToString())

                    });
                }

            }
            return _List;

        }



        public static bool SendMail(string to, string subject, string body)
        {
            try
            {

                //Encoed
                byte[] bytes = Encoding.UTF8.GetBytes(body);
                string _body = Convert.ToBase64String(bytes);
                //decode

                string base64 = "YWJjZGVmPT0=";
                byte[] bytes1 = Convert.FromBase64String(base64);
                string str = Encoding.UTF8.GetString(bytes1);


                var values = new Dictionary<string, string>
{
            { "FromEmail", System.Configuration.ConfigurationSettings.AppSettings["FEmail"].ToString()},
            { "FromPassword",  System.Configuration.ConfigurationSettings.AppSettings["FPassword"].ToString() },
            { "toEmail", to },
            { "EmailBody",body},
            { "MailSubject", subject},
            { "MailDisplayName", "AISET" },
};

                var content = new System.Net.Http.FormUrlEncodedContent(values);

                var response = client.PostAsync("http://t1.roken4life.com/sendemail.aspx", content);//http://localhost:57867/SendEmail.aspx    http://t1.roken4life.com/sendemail.aspx

                var responseString = response.Result.Content.ReadAsStringAsync();// ReadAsStringAsync();




                return true;
            }
            catch (Exception ex)
            {
                var s = ex.ToString();
                return false;
            }
        }
        public static string GetEmailFooter()
        {
            string Footer = "<br/><br/><strong>NOTE:</strong><br/>";
            Footer += "<br/>-----------------------------------------------------------------------------------------------------------------<br/>";
            Footer += "<span style='font-size:10px;font-family:Times New Roman'>This is an auto-generated e-mail. Please Do not reply to this e-mail.</span>";
            Footer += "<br/>";

            Footer += "<br/>-----------------------------------------------------------------------------------------------------------------<br/>";
            return Footer;
        }

        internal static void SendEmailAsync(IdentityMessage message)
        {
            try
            {

                ////Encoed
                //byte[] bytes = Encoding.UTF8.GetBytes(body);
                //string _body = Convert.ToBase64String(bytes);
                ////decode

                //string base64 = "YWJjZGVmPT0=";
                //byte[] bytes1 = Convert.FromBase64String(base64);
                //string str = Encoding.UTF8.GetString(bytes1);


                var values = new Dictionary<string, string>
{
            { "FromEmail","kamaleshs48@gmail.com" },
            { "FromPassword",  "7042771792k"},
            { "toEmail", message.Destination},
            { "EmailBody",message.Body },
            { "MailSubject", message.Subject},
            { "MailDisplayName", "AISET | " + message.Subject},
};

                var content = new System.Net.Http.FormUrlEncodedContent(values);

                var response = client.PostAsync("http://t1.roken4life.com/sendemail.aspx", content);//http://localhost:57867/SendEmail.aspx    http://t1.roken4life.com/sendemail.aspx

                var responseString = response.Result.Content.ReadAsStringAsync();// ReadAsStringAsync();



                //using (MailMessage mail = new MailMessage())
                //{
                //    mail.From = new MailAddress("kamaleshs48@gmail.com");
                //    mail.To.Add(message.Destination);
                //    mail.Subject = "Hello World";
                //    mail.Body = "<h1>Hello</h1>";
                //    mail.IsBodyHtml = true;
                //   // mail.Attachments.Add(new Attachment("C:\\file.zip"));

                //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                //    {
                //        smtp.Credentials = new NetworkCredential("kamaleshs48@gmail.com", "7042771792k");
                //        smtp.EnableSsl = true;
                //        smtp.Send(mail);
                //    }
                //}



                // return true;
            }
            catch (Exception ex)
            {
                var s = ex.ToString();
                // return false;
            }

        }


        private static void SendEmailAsync(string MailBody, string toEmail, string MailSubject, string MailDisplayName, string FromEmail, string FromPassword)
        {
            // Plug in your email service here to send an email.
            try
            {
                var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential(FromEmail, FromPassword),

                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                };
                var @from = new MailAddress(FromEmail, MailDisplayName);
                var to = new MailAddress(toEmail);
                var mail = new MailMessage(@from, to)
                {
                    Subject = MailSubject,
                    Body = "<div style='font-size:12pt;font-family:Times New Roman!important'>" + MailBody + "</div>",
                    IsBodyHtml = true,
                };

                // Object state = mail;
                mail.Priority = MailPriority.High;
                client.Send(mail);

            }
            catch (Exception ex)
            {

                // _Error = ex.ToString();


            }
        }


        internal static object URLEncode(object p)
        {
            throw new NotImplementedException();
        }

        //public static int CreateScheduleClass(ScheduleClassModels model)
        //{
        //    SqlParameter[] pr = new SqlParameter[] {
        //    new SqlParameter("@TeacherID",model.TeacherID),
        //    new SqlParameter("@ClassID",model.ClassID),
        //    new SqlParameter("@SessionDate",model.ClassDate),
        //    new SqlParameter("@SessionStartTime",model.StartTime),
        //    new SqlParameter("@SessionEndTime",model.EndTime),
        //    new SqlParameter("@UserID",model.UserID),
        //    new SqlParameter("@LessionName",model.LessionName),
        //    new SqlParameter("@CourseName",model.LessionName),
        //    new SqlParameter("@Mode","Create")};
        //    SqlHelper.ExecuteDataset(SqlHelper.ConnectionStr(), CommandType.Text, "Sel");
        //    return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStr(), CommandType.StoredProcedure, "sp_CreateScheduleClass", pr);

        //}
    }
}