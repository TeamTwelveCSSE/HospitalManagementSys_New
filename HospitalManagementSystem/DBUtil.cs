using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using HospitalManagementSystem;

namespace HospitalManagementSystem.App_Code
{
    public class DBUtil
    {
        MySqlConnection conn = null;
        string conString = string.Empty;

        public DBUtil()
        {
            conString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }

        public bool OpenConnection()
        {
            try
            {                
                conn = new MySqlConnection(conString);
                conn.Open();

                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public MySqlConnection GetOpenConnection()
        {
            try
            {
                conn = new MySqlConnection(conString);
                conn.Open();

                return conn;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            conn.Close();  
        }

        public MySqlCommand CreateCommand()
        {
            return conn.CreateCommand();
        }
    }
}