using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class frm_chanelInfo : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=hospitalmgtsys;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                bindData();
            }
        }

        protected void bindData()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select d.doc_name,d.speciality,a.session_date,a.session_time,a.appointment_no from doctor d, appointment_sessions a" +
                " where d.doc_id = a.doc_id", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

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
        protected void ActionCommand(object sender, GridViewCommandEventArgs e)
        {
            string commandName = e.CommandName.ToString().Trim();
            GridViewRow row = dtg_dataGrid.Rows[Convert.ToInt32(e.CommandArgument)];
            if (commandName.Equals("Select"))
            {
                string doctor = row.Cells[0].Text;
                string speciality = row.Cells[1].Text;
                string date = row.Cells[2].Text;
                string time = row.Cells[3].Text;
                string appointmentNo = row.Cells[4].Text;

                if (appointmentNo.Equals("Not Given", StringComparison.Ordinal))
                {
                    row.Cells[5].Enabled = false;
                }
                else
                {
                    Response.Redirect(string.Format("frm_patient.aspx?par_doctorName={0}&par_speciality={1}&par_date={2}&par_time={3}&par_appointmentNo={4}", doctor,
                        speciality, date, time, appointmentNo));
                }
            }
            else
            {
                string doctor = row.Cells[0].Text;
                string speciality = row.Cells[1].Text;
                string date = row.Cells[2].Text;
                string time = row.Cells[3].Text;

                Response.Redirect(string.Format("frm_session_report.aspx?par_doctorName={0}&par_speciality={1}&par_date={2}&par_time={3}", doctor,
                    speciality, date, time));
            }
        }


        protected void search()
        {
            con.Open();

            String query;
            if (txtSearch.Text == "")
            {
                query = "select d.doc_name,d.speciality,a.session_date,a.session_time,a.appointment_no from doctor d, appointment_sessions a" +
                    " where d.doc_id = a.doc_id";
            }
            else
            {
                query = "select d.doc_name,d.speciality,a.session_date,a.session_time,a.appointment_no from doctor d, appointment_sessions a" +
                    " where d.doc_id = a.doc_id and (d.speciality like '" + txtSearch.Text + "%' or d.doc_name like '" + txtSearch.Text + "%')";
            }

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}