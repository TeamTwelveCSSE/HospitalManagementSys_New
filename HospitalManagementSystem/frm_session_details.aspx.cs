using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace HospitalManagementSystem
{
    public partial class frm_session_details : System.Web.UI.Page
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
            MySqlCommand cmd = new MySqlCommand("Select * from appointment_sessions", con);
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
            int sesid = Convert.ToInt32(dtg_dataGrid.DataKeys[e.RowIndex].Values["session_id"].ToString());

            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from appointment_sessions where session_id=" + sesid, con);
            int result = cmd.ExecuteNonQuery();

            con.Close();

            if (result == 1)
            {
                bindData();
                lbl_result.ForeColor = Color.Red;
                lbl_result.Text = " details deleted successfully";
            }
            else
            {
                lbl_result.Text = " Not allow to delete";
            }
        }

        protected void dtg_dataGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dtg_dataGrid.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void dtg_dataGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int sesid = Convert.ToInt32(dtg_dataGrid.DataKeys[e.RowIndex].Value.ToString());
            TextBox txt_date = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_date");
            TextBox txt_time = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_time");
            TextBox txt_appointments = (TextBox)dtg_dataGrid.Rows[e.RowIndex].FindControl("txt_appointments");

            con.Open();
            MySqlCommand cmd = new MySqlCommand("update appointment_sessions set session_date='" + txt_date.Text + "',session_time='" + txt_time.Text +
                "',no_of_appointments='" + txt_appointments.Text + "' where session_id=" + sesid, con);
            cmd.ExecuteNonQuery();
            con.Close();

            lbl_result.ForeColor = Color.Green;
            lbl_result.Text = " Details Updated successfully";
            dtg_dataGrid.EditIndex = -1;
            bindData();
        }

        protected void btn_navigate_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_appointment_sessions.aspx");
        }
    }
}