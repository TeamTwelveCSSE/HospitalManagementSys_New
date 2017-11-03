using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HospitalManagementSystem
{
    public partial class frm_session_report : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=hospitalmgtsys;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["par_doctorName"] != null && Request.QueryString["par_speciality"] != null) && (Request.QueryString["par_date"] != null &&
                Request.QueryString["par_time"] != null))
            {
                string doctorName = Request.QueryString["par_doctorName"];
                string speciality = Request.QueryString["par_speciality"];
                string date = Request.QueryString["par_date"];
                string time = Request.QueryString["par_time"];

                con.Open();

                MySqlCommand cmd = new MySqlCommand("select doc_id from doctor where doc_name='" + doctorName + "'", con);
                string doctorID = cmd.ExecuteScalar().ToString();

                MySqlCommand cmdy = new MySqlCommand("select session_id from appointment_sessions where session_date='" + date + "' and doc_id='" + doctorID + "'", con);
                string sesssionID = cmdy.ExecuteScalar().ToString();

                int session = int.Parse(sesssionID);
                MySqlCommand cmdx = new MySqlCommand("select p.appointment_id,p.appointment_num,p.patient_name,p.nic,p.phone,p.email from patient p" +
                    " where p.session_id='" + session + "'", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmdx);
                DataSet ds = new DataSet();
                da.Fill(ds);

                con.Close();

                txt_doctorID.Text = doctorID;
                txt_doctorName.Text = doctorName;
                txt_speciality.Text = speciality;
                txt_sessionID.Text = sesssionID;
                txt_date.Text = date;
                txt_time.Text = time;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtg_dataGrid.DataSource = ds;
                    dtg_dataGrid.DataBind();

                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    dtg_dataGrid.DataSource = ds;
                    dtg_dataGrid.DataBind();
                    int columncount = dtg_dataGrid.Rows[0].Cells.Count;
                    dtg_dataGrid.Rows[0].Cells.Clear();
                    dtg_dataGrid.Rows[0].Cells.Add(new TableCell());
                    dtg_dataGrid.Rows[0].Cells[0].ColumnSpan = columncount;
                    dtg_dataGrid.Rows[0].Cells[0].Text = "No Records Found";
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            PdfPTable PdfPTable = new PdfPTable(dtg_dataGrid.HeaderRow.Cells.Count);

            foreach (TableCell TableCell in dtg_dataGrid.HeaderRow.Cells)
            {
                PdfPCell PdfPCell = new PdfPCell(new Phrase(TableCell.Text));
                PdfPTable.AddCell(PdfPCell);
            }

            //loop through each grid view row
            int count = 0;
            foreach (GridViewRow GridViewRow in dtg_dataGrid.Rows)
            {
                //loop through each cell
                count++;
                foreach (TableCell TableCell in GridViewRow.Cells)
                {
                    PdfPCell PdfPCell = new PdfPCell(new Phrase(TableCell.Text));
                    PdfPTable.AddCell(PdfPCell);
                }
            }
            Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);//margineleft,right,top,bottom
            PdfWriter.GetInstance(pdfdoc, Response.OutputStream);

            Paragraph docid = new Paragraph("Doctor ID             :" + txt_doctorID.Text);
            Paragraph docname = new Paragraph("Doctor Name        :" + txt_doctorName.Text);
            Paragraph docspec = new Paragraph("Specialization       :" + txt_speciality.Text);
            Paragraph sesid = new Paragraph("Session ID           :" + txt_sessionID.Text);
            Paragraph sesdate = new Paragraph("Session Date       :" + txt_date.Text);
            Paragraph sestime = new Paragraph("Session Time       :" + txt_time.Text);
            Paragraph space = new Paragraph(" ");
            Paragraph patientCount = new Paragraph("Total number of patients :" + count);
            pdfdoc.Open();
            pdfdoc.Add(docid);
            pdfdoc.Add(docname);
            pdfdoc.Add(docspec);
            pdfdoc.Add(sesid);
            pdfdoc.Add(sesdate);
            pdfdoc.Add(sestime);
            pdfdoc.Add(space);
            pdfdoc.Add(PdfPTable);
            pdfdoc.Add(space);
            pdfdoc.Add(patientCount);
            pdfdoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=AppointmentSessionReport.pdf");
            Response.Write(pdfdoc);
            Response.Flush();
            Response.End();

        }

    }
}