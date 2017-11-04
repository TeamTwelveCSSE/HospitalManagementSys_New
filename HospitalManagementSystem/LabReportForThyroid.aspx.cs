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
    public partial class LabReportForThyroid : System.Web.UI.Page
    {
        ThyroidObj thyroid = new ThyroidObj();
        LabReportObj labReport = new LabReportObj();
        DataManager dtMgr = new DataManager();
        DataTable dtbl = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            labReport = dtMgr.SessionValueLabReport;
            lblMsgPatient.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            thyroid.PatientId = int.Parse(txtPatientId.Text.Trim());
            thyroid.PatientName = txtPatientName.Text.Trim();
            thyroid.TSH = float.Parse(txtTSH.Text.Trim());
            thyroid.T4Total = float.Parse(txtT4.Text.Trim());
            thyroid.FreeT4 = float.Parse(txtFreeT4.Text.Trim());
            thyroid.FreeT3 = float.Parse(txtFreeT3.Text.Trim());

            if (dtMgr.InsertThyroidLabReportDetails(thyroid))
            {
                dtMgr.SendMail(labReport, thyroid);
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully generated') == true){" + "window.location.href = 'LabReport.aspx'" + "}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
            }
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Generate report failed');</script>");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearchPatient_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPatientId.Text.Trim()))
            {
                txtPatientId.BorderColor = Color.Red;
                lblMsgPatient.Visible = true;
            }

            else
            {
                if (String.IsNullOrEmpty(dtMgr.GetPatientName(txtPatientId.Text.Trim())))
                {
                    lblMsgPatient.Visible = true;
                }
                else
                {
                    txtPatientName.Text = dtMgr.GetPatientName(txtPatientId.Text.Trim());
                }
            }
        }
    }
}