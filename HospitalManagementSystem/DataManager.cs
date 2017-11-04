using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.App_Code
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

        /// <summary>
        /// Add Employee Details to Database
        /// </summary>
        public bool InsertEmpDetails(EmployeeObj emp)
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
            return false;
        }

        public DataTable GetEmployeeInfo()
        {
            using (MySqlConnection con = db.GetOpenConnection())
            {
                using (cmd = new MySqlCommand("SELECT * FROM employee"))
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


        public string GetDOBbyNIC(string nic)
        {
            //NICcal n = new NICcal(nic);
            return null;
        }
    }
}