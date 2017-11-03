using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class frm_appointment_sessions : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=hospitalmgtsys;User Id=root;password=1234");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void addSessions()
        {
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into hospitalmgtsys.appointment_sessions(doc_id,session_date,session_time,no_of_appointments,appointment_no) values" +
            "('" + ddl_doctors.SelectedValue + "','" + cal_sessionDate.SelectedDate.ToString("dd-MM-yyyy") + "','" + txt_time.Text + "','"
            + txt_appointments.Text + "','" + 1 + "')";
            cmd.ExecuteNonQuery();

            con.Close();

            Response.Redirect("frm_session_details.aspx");
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            addSessions();
        }

        //according to the selected speciality ddl_doctor drop down list values are changed ...
        protected void ddl_speciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select doc_id,doc_name from doctor where speciality='" + ddl_speciality.SelectedValue + "'", con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddl_doctors.DataSource = ds;
            ddl_doctors.DataTextField = "doc_name";
            ddl_doctors.DataValueField = "doc_id";
            ddl_doctors.DataBind();
            ddl_doctors.Items.Insert(0, new ListItem("--Select--", "0"));

            con.Close();
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_session_details.aspx");
        }


        //allow only to select today and future dates from the calender
        protected void cal_sessionDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.CompareTo(DateTime.Today) < 0)
            {
                e.Day.IsSelectable = false;

            }

        }
    }
}