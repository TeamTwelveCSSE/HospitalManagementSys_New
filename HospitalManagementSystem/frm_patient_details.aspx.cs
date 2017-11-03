using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class frm_patient_details : System.Web.UI.Page
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
            MySqlCommand cmd = new MySqlCommand("select p.appointment_id,d.doc_name,d.speciality,a.session_date,a.session_time,p.appointment_num,p.patient_name,"
                + "p.nic,p.phone,p.email from doctor d, appointment_sessions a, patient p where d.doc_id = a.doc_id and a.session_id = p.session_id", con);
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

        protected void dtg_dataGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_dataGrid.EditIndex = -1;
            bindData();
        }

        protected void dtg_dataGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int appid = Convert.ToInt32(dtg_dataGrid.DataKeys[e.RowIndex].Values["appointment_id"].ToString());

            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from patient where appointment_id=" + appid, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();

            if (result == 1)
            {
                bindData();
                lbl_result.ForeColor = Color.Red;
                lbl_result.Text = " details deleted successfully";

            }
        }


        protected void dtg_dataGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dtg_dataGrid.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void dtg_dataGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int appid = Convert.ToInt32(dtg_dataGrid.DataKeys[e.RowIndex].Value.ToString());

            TextBox txt_patientName = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_patientName");
            TextBox txt_nic = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_nic");
            TextBox txt_phone = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_phone");
            TextBox txt_email = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_email");

            con.Open();
            MySqlCommand cmd = new MySqlCommand("update patient set patient_name='" + txt_patientName.Text + "',nic='" + txt_nic.Text + "',phone='" + txt_phone.Text
                + "',email='" + txt_email.Text + "' where appointment_id=" + appid, con);
            cmd.ExecuteNonQuery();
            con.Close();

            lbl_result.ForeColor = Color.Green;
            lbl_result.Text = " Details Updated successfully";
            dtg_dataGrid.EditIndex = -1;
            bindData();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_chanelInfo.aspx");
        }

        protected void txt_search_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            String query;
            if (txt_search.Text == "")
            {
                query = "select p.appointment_id,d.doc_name,d.speciality,a.session_date,a.session_time,p.appointment_num,p.patient_name,p.nic,p.phone,p.email"
                    + " from doctor d, appointment_sessions a, patient p where d.doc_id = a.doc_id and a.session_id = p.session_id";
            }
            else
            {
                query = "select p.appointment_id,d.doc_name,d.speciality,a.session_date,a.session_time,p.appointment_num,p.patient_name,p.nic,p.phone,p.email"
                 + " from doctor d, appointment_sessions a, patient p where d.doc_id = a.doc_id and a.session_id = p.session_id and (p.patient_name like '"
                 + txt_search.Text + "%' or p.nic like '" + txt_search.Text + "%')";
            }

            con.Open();
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

        protected void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }
    }
}