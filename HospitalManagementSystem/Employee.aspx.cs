using HospitalManagementSystem.App_Code;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Employee : System.Web.UI.Page
    {
        EmployeeObj emp = new EmployeeObj();
        DataManager dtMgr = new DataManager();
        DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //dtbl = dtMgr.GetEmployeeInfo();
            //if (dtbl.Rows.Count > 0)
            //{
            //    GridEmp.DataSource = dtbl;
            //    GridEmp.DataBind();
            //}
            //else 
            //{
            //    dtbl.Rows.Add(dtbl.NewRow());
            //    GridEmp.DataSource = dtbl;
            //    GridEmp.DataBind();
            //    int columnCount = GridEmp.Rows[0].Cells.Count;
            //    GridEmp.Rows[0].Cells.Clear();
            //    GridEmp.Rows[0].Cells.Add(new TableCell());
            //    GridEmp.Rows[0].Cells[0].ColumnSpan = columnCount;
            //    GridEmp.Rows[0].Cells[0].Text = "No Records Found";
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //emp.EmpId = Int32.Parse(txtEmpIDRegister.Text.Trim());
            emp.EmpType = lstEmpType.SelectedValue;
            emp.FirstName = txtFirstName.Text.Trim();
            emp.LastName = txtLastName.Text.Trim();
            emp.Address = txtAddress.Text;
            emp.NIC = txtNIC.Text.Trim();
            emp.DOB = DateTime.Parse(txtDOB.Text).Date;
            if(radioBtnMale.Checked)
                emp.Gender = radioBtnMale.Text;
            else
                emp.Gender = radioBtnFemale.Text;
            emp.Email = txtMail.Text.Trim();
            emp.Contact = txtContact.Text.Trim();
            emp.Basic_Salary = float.Parse(txtSalary.Text.Trim());
            emp.SLMC_No = txtSLMCNo.Text.Trim();

            dtMgr.InsertEmpDetails(emp);


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void GetGender_DOB(string nic)
        {
            DataManager dtMgr = new DataManager();


        }
    }
}