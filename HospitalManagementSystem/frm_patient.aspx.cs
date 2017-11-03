using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Net.Mail;

namespace HospitalManagementSystem
{
    public partial class frm_patient : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;Initial Catalog=hospitalmgtsys;User Id=root;password=1234");

        //get data from frm_chanelInfo page
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["par_doctorName"] != null && Request.QueryString["par_speciality"] != null) && (Request.QueryString["par_date"] != null
                && Request.QueryString["par_time"] != null) && (Request.QueryString["par_appointmentNo"] != null))
            {
                string doctor = Request.QueryString["par_doctorName"];
                string speciality = Request.QueryString["par_speciality"];
                string date = Request.QueryString["par_date"];
                string time = Request.QueryString["par_time"];
                string appointmentNo = Request.QueryString["par_appointmentNo"];

                txt_doctorName.Text = doctor;
                txt_speciality.Text = speciality;
                txt_date.Text = date;
                txt_time.Text = time;
                txt_appointmentNo.Text = appointmentNo;

            }
        }

        private void addPatient()
        {
            con.Open();

            MySqlCommand cmdx = new MySqlCommand("select doc_id from doctor where doc_name='" + txt_doctorName.Text + "'", con);
            string doctorID = cmdx.ExecuteScalar().ToString();

            MySqlCommand cmdy = new MySqlCommand("select session_id from appointment_sessions where session_date='" + txt_date.Text + "' and doc_id='" + doctorID + "'", con);
            string sesssionID = cmdy.ExecuteScalar().ToString();

            MySqlCommand cmdv = new MySqlCommand("select no_of_appointments from appointment_sessions where session_date='" + txt_date.Text + "' and doc_id='" + doctorID + "'", con);
            string numOfApoointments = cmdv.ExecuteScalar().ToString();
            int no_of_appointments = int.Parse(numOfApoointments);

            int appointmentNo = int.Parse(txt_appointmentNo.Text);

            String appointmentNo_string;
            int newAppointmentNo;
            if (appointmentNo == no_of_appointments)
            {
                appointmentNo_string = "Not Given";
            }
            else
            {
                newAppointmentNo = appointmentNo + 1;
                appointmentNo_string = newAppointmentNo.ToString();
            }

            MySqlCommand cmdz = con.CreateCommand();
            cmdz.CommandText = "UPDATE hospitalmgtsys.appointment_sessions SET appointment_no='" + appointmentNo_string + "' WHERE session_id='" + sesssionID + "'";
            cmdz.ExecuteNonQuery();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into hospitalmgtsys.patient(doc_id,session_id,appointment_num,patient_name,nic,phone,email) values('" + doctorID + "','"
                + sesssionID + "','" + txt_appointmentNo.Text + "','" + txt_patientName.Text + "','" + txt_nic.Text + "','" + txt_phone.Text + "','"
                + txt_email.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            addPatient();
            SendMail();

            Response.Redirect("frm_patient_details.aspx");
        }

        private void SendMail()
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("thanuji.shashikala@gmail.com", "11dec@1993");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("thanuji.shashikala@gmail.com");
            msg.To.Add(new MailAddress(txt_email.Text));

            msg.Subject = "Appontment for the doctor";
            msg.IsBodyHtml = true;
            msg.Body = "You have made an appoinment today to meet the " + txt_speciality.Text + " Dr." + txt_doctorName.Text + " on " + txt_date.Text + " at "
                + txt_time.Text + ". Your appointment number is " + txt_appointmentNo.Text;

            try
            {
                client.Send(msg);
                lbl_message.Text = "Your message has been successfully sent.";
            }
            catch (Exception ex)
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "Error occured while sending your message." + ex.Message;
            }
        }

        protected void btn_view_Click(object sender, EventArgs e)
        {
            Response.Redirect("frm_patient_details.aspx");
        }
    }
}