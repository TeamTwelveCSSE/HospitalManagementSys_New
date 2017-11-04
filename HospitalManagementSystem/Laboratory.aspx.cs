using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Laboratory : System.Web.UI.Page
    {
        TestObj test = new TestObj();
        DataManager dtMgr = new DataManager();
        DataTable dtbl = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            dtbl = dtMgr.GetTestInfo();
            if (dtbl == null)
            {
                divFailed.Visible = true;
                lblFailed.Visible = true;
                lblFailed.Text = "No Records Found";
            }
            else
            {
                GridTest.DataSource = dtbl;
                GridTest.DataBind();
            }
            divFailed.Visible = false;
            lblFailed.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            test.TestCategory = lstSection.SelectedValue;
            test.TestName = txtTestName.Text.Trim();
            test.TestDesc = txtTestDesc.Text.Trim();
            test.TestStatus = radioActive.SelectedValue;
            test.TestUnit = lstUnit.SelectedValue;
            test.TestAmount = float.Parse(txtTestAmount.Text.Trim());

            if (dtMgr.InsertTestDetails(test))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully submited') == true){" + "window.location.href = 'Laboratory.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            }

            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data insertion failed');</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            test.TestId = int.Parse(txtTestNo.Text.Trim());
            test.TestCategory = lstSection.SelectedValue;
            test.TestName = txtTestName.Text.Trim();
            test.TestDesc = txtTestDesc.Text.Trim();
            test.TestStatus = radioActive.SelectedValue;
            test.TestUnit = lstUnit.SelectedValue;
            test.TestAmount = float.Parse(txtTestAmount.Text.Trim());

            if (dtMgr.UpdateTestDetails(test))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully updated') == true){" + "window.location.href = 'Laboratory.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data update failed');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtMgr.DeleteTestDetails(txtTestNo.Text.Trim()))
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully deleted') == true){" + "window.location.href = 'Laboratory.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data deletion failed');</script>");
        }

        protected void brnSearch_Click(object sender, EventArgs e)
        {
            string query = null;
            string selectedBy = lstSearch.SelectedValue.ToString();
            try
            {

                if (selectedBy == "Test Id")
                {
                    query = @"SELECT * FROM test WHERE TestId=@value";
                }
                else if (selectedBy == "Test Category")
                {
                    query = @"SELECT * FROM test WHERE TestCategory=@value";
                }
                else if (selectedBy == "Test Name")
                {
                    query = @"SELECT * FROM test WHERE TestName=@value";
                }
                else if (selectedBy == "Status")
                {
                    query = @"SELECT * FROM test WHERE Status=@value";
                }
                else if (selectedBy == "Unit")
                {
                    query = @"SELECT * FROM test WHERE Unit=@value";
                }

                dtbl = dtMgr.SearchDetails(query, txtSearch.Text.Trim());

                if (dtbl == null)

                {
                    divFailed.Visible = true;
                    lblFailed.Visible = true;
                    lblFailed.Text = "No Records Found";
                }
                else
                {
                    GridTest.DataSource = dtbl;
                    GridTest.DataBind();
                }

            }
            catch (Exception ex)
            {
                EventLogUtil.Log(string.Format("Failed to search test from value: {0} of {1}. Exception : {2}", selectedBy, txtSearch.Text.Trim(), ex.Message));
            }
        }

        protected void GridEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTestNo.Text = GridTest.SelectedRow.Cells[1].Text.ToString();
            lstSection.SelectedValue = GridTest.SelectedRow.Cells[2].Text;
            txtTestName.Text = GridTest.SelectedRow.Cells[3].Text;
            txtTestDesc.Text = GridTest.SelectedRow.Cells[4].Text;
            radioActive.SelectedValue = GridTest.SelectedRow.Cells[5].Text;
            lstUnit.SelectedValue = GridTest.SelectedRow.Cells[6].Text;
            txtTestAmount.Text = GridTest.SelectedRow.Cells[7].Text;

            btnUpdate.Enabled = true;
            btnUpdate.BackColor = System.Drawing.ColorTranslator.FromHtml("#96C03A");

            btnDelete.Enabled = true;
            btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#96C03A");
        }

        protected void GridViewTest_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridViewTest_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}