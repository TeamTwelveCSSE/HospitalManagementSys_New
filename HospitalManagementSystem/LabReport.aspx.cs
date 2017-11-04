using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class LabReport : System.Web.UI.Page
    {
        LabReportObj labReport = new LabReportObj();
        DataManager dtMgr = new DataManager();
        DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            divFailed.Visible = false;
            lblFailed.Visible = false;
            lblMsgPatient.Visible = false;
            lblMsgTest.Visible = false;

            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");

            dtbl = dtMgr.GetTestInfo();
            if (dtbl == null)
            {
                divFailed.Visible = true;
                lblFailed.Visible = true;
                lblFailed.Text = "No Records Found";
            }
            else
            {
                GridReport.DataSource = dtbl;
                GridReport.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            labReport.PatientNumber = int.Parse(txtPNo.Text.Trim());
            labReport.PatientName = txtPatientName.Text.Trim();
            labReport.Email = txtMail.Text.Trim();
            labReport.TestNumber = int.Parse(txtNumber.Text.Trim());
            labReport.TestName = txtTestName.Text.Trim();
            labReport.Date = DateTime.Parse(txtDate.Text.Trim()).Date;
            labReport.Amount = float.Parse(txtAmount.Text.Trim());
            labReport.Description = txtDesc.Text.Trim();

            if (dtMgr.InsertLabReportDetails(labReport))
            {
                dtMgr.SessionValueLabReport = labReport;
                btnGenerateReport.Enabled = true;
                btnGenerateReport.BackColor = System.Drawing.ColorTranslator.FromHtml("#96C03A");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Successfully insert data');</script>");
            }

            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data insertion failed');</script>");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtMgr.DeleteLabReportDetails(txtLabTestId.Text.Trim()))
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully deleted') == true){" + "window.location.href = 'LabReport.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data deletion failed');</script>");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            labReport.LabTestId = int.Parse(txtLabTestId.Text.Trim());
            labReport.PatientNumber = int.Parse(txtPNo.Text.Trim());
            labReport.PatientName = txtPatientName.Text.Trim();
            labReport.Email = txtMail.Text.Trim();
            labReport.TestNumber = int.Parse(txtNumber.Text.Trim());
            labReport.TestName = txtTestName.Text.Trim();
            labReport.Date = DateTime.Parse(txtDate.Text.Trim()).Date;
            labReport.Amount = float.Parse(txtAmount.Text.Trim());
            labReport.Description = txtDesc.Text.Trim();

            if (dtMgr.UpdateLabReportDetails(labReport))
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully updated') == true){" + "window.location.href = 'LabReport.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data update failed');</script>");

        }

        protected void btnDelete_Click(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridViewTest_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewTest_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridEmp_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void brnSearch_Click(object sender, EventArgs e)
        {
            string query = null;
            string selectedBy = lstSearch.SelectedValue.ToString();

            try
            {
                if (selectedBy == "Lab Test Id")
                {
                    query = @"SELECT * FROM labreport WHERE LabTestId=@value";
                }
                else if (selectedBy == "Patient Number")
                {
                    query = @"SELECT * FROM labreport WHERE PatientNumber=@value";
                }
                else if (selectedBy == "Patient Name")
                {
                    query = @"SELECT * FROM labreport WHERE PatientName=@value";
                }
                else if (selectedBy == "Test Number")
                {
                    query = @"SELECT * FROM labreport WHERE TestNumber=@value";
                }
                else if (selectedBy == "Test Name")
                {
                    query = @"SELECT * FROM labreport WHERE TestName=@value";
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
                    GridReport.DataSource = dtbl;
                    GridReport.DataBind();
                }

            }
            catch (Exception ex)
            {
                EventLogUtil.Log(string.Format("Failed to search labreport from value: {0} of {1}. Exception : {2}", selectedBy, txtSearch.Text.Trim(), ex.Message));
            }
        }

        protected void btnSearchPatient_Click(object sender, ImageClickEventArgs e)
        {
            string[] patientDetails = new string[2];
            if (String.IsNullOrEmpty(txtPNo.Text.Trim()))
            {
                txtPNo.BorderColor = Color.Red;
                lblMsgPatient.Visible = true;
            }

            else
            {
                patientDetails = dtMgr.GetPatientDetails(txtPNo.Text.Trim());
                if (patientDetails.Length == 0)
                {
                    lblMsgPatient.Visible = true;
                }
                else
                {
                    txtPatientName.Text = patientDetails[0];
                    txtMail.Text = patientDetails[1];
                }
            }
        }

        protected void btnSearchTest_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumber.Text.Trim()))
            {
                txtNumber.BorderColor = Color.Red;
                lblMsgTest.Visible = true;
            }

            else
            {
                if (String.IsNullOrEmpty(dtMgr.GetTestName(txtNumber.Text.Trim())))
                {
                    lblMsgTest.Visible = true;
                }
                else
                {
                    txtTestName.Text = dtMgr.GetTestName(txtNumber.Text.Trim());
                }
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("LabReportForThyroid.aspx");
        }
    }
}