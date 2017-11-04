using HospitalManagementSystem.App_Code;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace HospitalManagementSystem
{
    public class DataManager
    {
        MySqlCommand cmd = null;
        DBUtil db = new DBUtil();

        public float GetBasicSalary(string type)
        {
            float salary = 0;

            string query = @"SELECT s.Basic_Salary
                            FROM Salary s
                            WHERE s.Type = :salary";
            return salary;
        }

     /* |====================|
        |Section: Employee   |
        |====================|*/

        /// <summary>
        /// Add Employee Details to Database(Table: employee)
        /// </summary>
        public bool InsertEmpDetails(EmployeeObj emp)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"INSERT INTO employee (Employee_Id, Employee_Type, First_Name, Last_Name, Address, NIC, DOB, Gender, E_Mail, Contact, Basic_Salary, SLMC_RegNo)
                                    VALUES (@empId, @empType, @firstName, @lastName, @address, @nic, @dob, @gender, @email, @contact, @salary, @regno)";

                    cmd.Parameters.AddWithValue("@empId", emp.EmpId);
                    cmd.Parameters.AddWithValue("@empType", emp.EmpType);
                    cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@address", emp.Address);
                    cmd.Parameters.AddWithValue("@nic", emp.NIC);
                    cmd.Parameters.AddWithValue("@dob", emp.DOB);
                    cmd.Parameters.AddWithValue("@gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@email", emp.Email);
                    cmd.Parameters.AddWithValue("@contact", emp.Contact);
                    cmd.Parameters.AddWithValue("@salary", emp.Basic_Salary);
                    cmd.Parameters.AddWithValue("@regno", emp.SLMC_No);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to insert employee for Employee_Id: {0}. Exception : {1}", emp.EmpId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update Employee Details to Database
        /// </summary>
        public bool UpdateEmpDetails(EmployeeObj emp)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"UPDATE employee SET Employee_Type=@empType, First_Name=@firstName, Last_Name=@lastName, Address=@address, NIC=@nic, DOB=@dob,
                                                        Gender=@gender, E_Mail=@email, Contact=@contact, Basic_Salary=@salary, SLMC_RegNo=@regno WHERE Employee_Id=@empId";

                    cmd.Parameters.AddWithValue("@empId", emp.EmpId);
                    cmd.Parameters.AddWithValue("@empType", emp.EmpType);
                    cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", emp.LastName);
                    cmd.Parameters.AddWithValue("@address", emp.Address);
                    cmd.Parameters.AddWithValue("@nic", emp.NIC);
                    cmd.Parameters.AddWithValue("@dob", emp.DOB);
                    cmd.Parameters.AddWithValue("@gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@email", emp.Email);
                    cmd.Parameters.AddWithValue("@contact", emp.Contact);
                    cmd.Parameters.AddWithValue("@salary", emp.Basic_Salary);
                    cmd.Parameters.AddWithValue("@regno", emp.SLMC_No);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to update employee for Employee_Id: {0}. Exception : {1}", emp.EmpId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete Employee Details from Database
        /// </summary>
        public bool DeleteEmpDetails(string empid)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"DELETE FROM employee WHERE Employee_Id=@empId";

                    cmd.Parameters.AddWithValue("@empId", empid);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to delete employee for Employee_Id: {0}. Exception : {1}", empid, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Search Employee Details from Database
        /// </summary>
        public DataTable SearchDetails(string query, string value)
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {                
                using (cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Get Employee Details from Database
        /// </summary>
        public DataTable GetEmployeeInfo()
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {
                //SELECT e.Employee_Id ID, e.Employee_Type Type, e.First_Name FirstName, e.Last_Name LastName, e.Address, e.NIC, e.Gender, e.E_Mail Email, e.Contact, e.SLMC_RegNo SLMCNo  FROM employee e
                using (cmd = new MySqlCommand("SELECT *  FROM employee e"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }

        }

        /* |=================|
           |Section: Test    |
           |=================|*/

        /// <summary>
        /// Add Test Details to Database(Table: test)
        /// </summary>
        public bool InsertTestDetails(TestObj test)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"INSERT INTO test (TestId, TestCategory, TestName, TestDescription, Status, Unit, Amount)
                                    VALUES (@testId, @testCategory, @testName, @testDesc, @status, @unit, @amount)";

                    cmd.Parameters.AddWithValue("@testId", test.TestId);
                    cmd.Parameters.AddWithValue("@testCategory", test.TestCategory);
                    cmd.Parameters.AddWithValue("@testName", test.TestName);
                    cmd.Parameters.AddWithValue("@testDesc", test.TestDesc);
                    cmd.Parameters.AddWithValue("@status", test.TestStatus);
                    cmd.Parameters.AddWithValue("@unit", test.TestUnit);
                    cmd.Parameters.AddWithValue("@amount", test.TestAmount);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to insert test for Test ID: {0}. Exception : {1}", test.TestId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update Test Details to Database
        /// </summary>
        public bool UpdateTestDetails(TestObj test)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"UPDATE test SET TestCategory=@testCategory, TestName=@testName, TestDescription=@testDesc, Status=@status, Unit=@unit, Amount=@amount
                                    WHERE TestId=@testId";

                    cmd.Parameters.AddWithValue("@testId", test.TestId);
                    cmd.Parameters.AddWithValue("@testCategory", test.TestCategory);
                    cmd.Parameters.AddWithValue("@testName", test.TestName);
                    cmd.Parameters.AddWithValue("@testDesc", test.TestDesc);
                    cmd.Parameters.AddWithValue("@status", test.TestStatus);
                    cmd.Parameters.AddWithValue("@unit", test.TestUnit);
                    cmd.Parameters.AddWithValue("@amount", test.TestAmount);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to update test for Test ID: {0}. Exception : {1}", test.TestId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete Test Details from Database
        /// </summary>
        public bool DeleteTestDetails(string testId)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"DELETE FROM test WHERE TestId=@testId";

                    cmd.Parameters.AddWithValue("@testId", testId);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to delete test for Test ID: {0}. Exception : {1}", testId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Search Test Details from Database
        /// </summary>
        public DataTable SearchTestDetails(string query, string value)
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {
                using (cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Get Test Details from Database
        /// </summary>
        public DataTable GetTestInfo()
        {
            using ( MySqlConnection con = db.GetOpenConnection())
            {                
                using (cmd = new MySqlCommand("SELECT * FROM test"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }

        }

        /* |========================|
           |Section: Test Report    |
           |========================|*/

        /// <summary>
        /// Add Lab Report Details to Database(Table: labreport)
        /// </summary>
        public bool InsertLabReportDetails(LabReportObj labReport)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"INSERT INTO labreport (LabTestId, PatientNumber, PatientName, Email, TestNumber, TestName, Date, Amount, Description)
                                    VALUES (@labTestId, @patientNo, @patientName, @email, @testNo, @testName, @date, @amount, @desc)";

                    cmd.Parameters.AddWithValue("@labTestId", labReport.LabTestId);
                    cmd.Parameters.AddWithValue("@patientNo", labReport.PatientNumber);
                    cmd.Parameters.AddWithValue("@patientName", labReport.PatientName);
                    cmd.Parameters.AddWithValue("@email", labReport.Email);
                    cmd.Parameters.AddWithValue("@testNo", labReport.TestNumber);
                    cmd.Parameters.AddWithValue("@testName", labReport.TestName);
                    cmd.Parameters.AddWithValue("@date", labReport.Date);
                    cmd.Parameters.AddWithValue("@amount", labReport.Amount);
                    cmd.Parameters.AddWithValue("@desc", labReport.Description);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to insert labreport for Lab Test ID: {0}. Exception : {1}", labReport.LabTestId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Update Lab Report Details to Database
        /// </summary>
        public bool UpdateLabReportDetails(LabReportObj labReport)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"UPDATE labreport SET PatientNumber=@patientNo, PatientName=@patientName, Email=@email, TestNumber=@testNo,
                                                        TestName=@testName, Date=@date, Amount=@amount, Description=@desc
                                    WHERE LabTestId=@labTestId";

                    cmd.Parameters.AddWithValue("@labTestId", labReport.LabTestId);
                    cmd.Parameters.AddWithValue("@patientNo", labReport.PatientNumber);
                    cmd.Parameters.AddWithValue("@patientName", labReport.PatientName);
                    cmd.Parameters.AddWithValue("@email", labReport.Email);
                    cmd.Parameters.AddWithValue("@testNo", labReport.TestNumber);
                    cmd.Parameters.AddWithValue("@testName", labReport.TestName);
                    cmd.Parameters.AddWithValue("@date", labReport.Date);
                    cmd.Parameters.AddWithValue("@amount", labReport.Amount);
                    cmd.Parameters.AddWithValue("@desc", labReport.Description);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to update labreport for Lab Test ID: {0}. Exception : {1}", labReport.LabTestId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Delete Lab Report Details from Database
        /// </summary>
        public bool DeleteLabReportDetails(string labTestId)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"DELETE FROM labreport WHERE LabTestId=@labTestId";

                    cmd.Parameters.AddWithValue("@labTestId", labTestId);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to delete labreport for Lab Test ID: {0}. Exception : {1}", labTestId, e.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Search Lab Report Details from Database
        /// </summary>
        public DataTable SearchLabReportDetails(string query, string value)
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {
                using (cmd = new MySqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Get Lab Report Details from Database
        /// </summary>
        public DataTable GetLabReportInfo()
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {
                using (cmd = new MySqlCommand("SELECT * FROM labreport"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();

                            if (dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }

            }

        }

        /// <summary>
        /// Get Patient Name from Database
        /// </summary>
        public string[] GetPatientDetails(string patientId)
        {
            string[] patientDetails = new string[2];
            if (db.OpenConnection())
            {
                cmd = db.CreateCommand();

                cmd.CommandText = "SELECT PatientName, Email FROM Patient_Lab WHERE PatientId=@patientID";

                cmd.Parameters.AddWithValue("@patientID", patientId);

                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        patientDetails[0] = reader.GetString("PatientName").ToString();
                        patientDetails[1] = reader.GetString("Email").ToString();

                        return patientDetails;
                    }
                }
            }

            cmd.Dispose();
            db.CloseConnection();

            return null;
        }

        /// <summary>
        /// Get Test Name from Database
        /// </summary>
        public string GetTestName(string testId)
        {
            if (db.OpenConnection())
            {
                cmd = db.CreateCommand();

                cmd.CommandText = "SELECT TestName FROM test WHERE TestId=@testId";

                cmd.Parameters.AddWithValue("@testId", testId);

                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        return reader.GetString("TestName").ToString();
                    }
                }
            }

            cmd.Dispose();
            db.CloseConnection();

            return null;
        }

        /* |================================|
           |Section: Thyroid Test Report    |
           |================================|*/

        /// <summary>
        /// Add Thyroid Test Report Details to Database(Table: ReportThyroid)
        /// </summary>
        public bool InsertThyroidLabReportDetails(ThyroidObj thyroid)
        {
            try
            {
                if (db.OpenConnection())
                {
                    cmd = db.CreateCommand();

                    cmd.CommandText = @"INSERT INTO ReportThyroid (ReportId, PatientId, PatientName, TSH, T4Total, FreeT4, FreeT3)
                                    VALUES (@reportId, @patientId, @patientName, @tsh, @t4Total, @freeT4, @freeT3)";

                    cmd.Parameters.AddWithValue("@reportId", thyroid.ReportId);
                    cmd.Parameters.AddWithValue("@patientId", thyroid.PatientId);
                    cmd.Parameters.AddWithValue("@patientName", thyroid.PatientName);
                    cmd.Parameters.AddWithValue("@tsh", thyroid.TSH);
                    cmd.Parameters.AddWithValue("@t4Total", thyroid.T4Total);
                    cmd.Parameters.AddWithValue("@freeT4", thyroid.FreeT4);
                    cmd.Parameters.AddWithValue("@freeT3", thyroid.FreeT3);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    db.CloseConnection();

                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to insert ThyroidLabReportDetails for ReportId: {0}. Exception : {1}", thyroid.ReportId, e.Message));
                return false;
            }

            return true;
           
        }

        /// <summary>
        /// Get Patient Name from Database
        /// </summary>
        public string GetPatientName(string patientId)
        {
            if (db.OpenConnection())
            {
                cmd = db.CreateCommand();

                cmd.CommandText = "SELECT PatientName FROM Patient_Lab WHERE PatientId=@patientId";

                cmd.Parameters.AddWithValue("@patientId", patientId);

                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    if (reader.Read())
                    {
                        return reader.GetString("PatientName").ToString();
                    }
                }
            }

            cmd.Dispose();
            db.CloseConnection();

            return null;
        }

        public void SendMail(LabReportObj labReport, ThyroidObj thyroid)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    string mailFrom = ConfigurationManager.AppSettings["EmailFrom"];
                    string mailPassword = ConfigurationManager.AppSettings["EmailPassword"];
                    mail.From = new MailAddress(mailFrom);
                    mail.To.Add(labReport.Email);
                    mail.Subject = ConfigurationManager.AppSettings["EmailSubject"] + "( " + labReport.PatientName + " : " + labReport.Date + ")";
                    mail.Body = "<h1>Thyroid Function</h1>" + "<br>Report ID: " + thyroid.ReportId + "<br> <br>TSH: " + thyroid.TSH + "<br>T4 Total: " + thyroid.T4Total + "<br>Free T4: " + thyroid.FreeT4 + "<br>Free T3: " + thyroid.FreeT3;
                    //mail.Body = "<h1>Item Name: Item1" + "<br> Employee ID: 001" + "<br> Qty: 2" + "<br> Order Date: 22/03/2017" + "<br> Required Date: 02/04/2017" + "</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(mailFrom, mailPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }

            catch (Exception e)
            {
                EventLogUtil.Log(string.Format("Failed to send a mail to {0}. Exception : {1}", labReport.Email, e.Message));
                
            }
        }

        public LabReportObj SessionValueLabReport
        {

            get
            {
                object value = HttpContext.Current.Session["SessionValue"];
                return value == null ? null : (LabReportObj)value;
            }

            set
            {
                HttpContext.Current.Session["SessionValue"] = value;
            }
        }
    }
}