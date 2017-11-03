using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace HospitalManagementSystem
{
    public partial class OutPatientCharges : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlCommand cmd2;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        MySql.Data.MySqlClient.MySqlDataReader reader1;
        MySql.Data.MySqlClient.MySqlDataReader reader2;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ConDataBind();
            }
            getPaymentID();
            //tax & hospital fees are harcoded value.they are constants
            //So those are disabled textboxes with a constant value
            tb_tax.Text = "5%";
            tb_hoscharge.Text = "500.00";
            tb_paymentid.Attributes["disabled"] = "disabled";
            tb_patientname.Attributes["disabled"] = "disabled";

            //Refering another table values.So made them as disabled
            tb_doctorname.Attributes["disabled"] = "disabled";
            tb_chanelleddate.Attributes["disabled"] = "disabled";
            tb_doccharge.Attributes["disabled"] = "disabled";
            tb_hoscharge.Attributes["disabled"] = "disabled";
            tb_tax.Attributes["disabled"] = "disabled";
            //tb_paymentdate.Attributes["disabled"] = "disabled";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getPatientDetails();
            btn_calculate.Enabled = true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btn_calculate_Click(object sender, EventArgs e)
        {
            getPatientDetails();

            try
            {
                if (tb_other.Text == null || tb_other.Text == "")
                {
                    //When there is no other amount in the patient's bill
                    double total = 0;
                    double doc_fees = Convert.ToDouble(tb_doccharge.Text);
                    double hos_fees = Convert.ToDouble(tb_hoscharge.Text);
                    hidden_doctorcharge.Text = tb_doccharge.Text;
                    double other_fees = 0;
                    String tax = tb_tax.Text;
                    hidden_other.Text = "0";

                    double taxx = Convert.ToDouble(tax.Replace("%", ""));
                    total = (doc_fees + hos_fees + other_fees) * ((taxx + 100) / 100);
                    tb_total.Text = total.ToString();
                    hidden_total.Text = total.ToString();
                }

                else
                {
                    //When there is other amount in the patient's bill
                    double total = 0;
                    double doc_fees = Double.Parse(tb_doccharge.Text);
                    hidden_doctorcharge.Text = tb_hoscharge.Text;
                    double hos_fees = Convert.ToDouble(tb_hoscharge.Text);
                    double other_fees = Convert.ToDouble(tb_other.Text);

                    String tax = tb_tax.Text;
                    hidden_other.Text = tb_other.Text;
                    double taxx = Convert.ToDouble(tax.Replace("%", ""));
                    total = (doc_fees + hos_fees + other_fees) * ((taxx + 100) / 100);
                    tb_total.Text = total.ToString();
                    hidden_total.Text = total.ToString();

                }

                btn_print.Enabled = true;

            }

            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter valid values ');</script>");
            }

            btn_add.Enabled = true;

        }

        protected bool check_patientID()
        {
            //Check whether patient ID is null
            if (tb_patientid.Text == null || tb_patientid.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected bool validate_patientID()
        {
            //check whether the patient ID is in the correct format
            try
            {
                int t = Convert.ToInt32(tb_patientid.Text);
                lbl_validate.Visible = false;
                return true;
            }
            catch
            {
                lbl_validate.Visible = true;
                if (lbl_validate.Text == null || lbl_validate.Text == "")
                {
                    lbl_validate.Visible = false;
                    return true;
                }
                lbl_validate.Visible = true;
                return false;
            }
        }

        public void getPaymentID()
        {

            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM outpatientcharges ORDER BY payid DESC LIMIT 1 ";

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("payid");
                    idd = idd + 1;
                    tb_paymentid.Text = idd + "";
                }
            }
            catch { }
            conn.Close();
        }

        public void getPatientDetails()
        {
            lbl_hidden_patient_id.Text = tb_patientid.Text;
            bool validation = validate_patientID();
            bool checking = check_patientID();
            if (validation == true && checking == true)
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();
                try
                {
                    string check = "select count(*)  from patient where appointment_id='" + lbl_hidden_patient_id.Text.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(check, conn);
                    int cnt = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (cnt == 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter a valied Patient Id');</script>");

                    }
                    else
                    {
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "select * from patient where appointment_id ='" + lbl_hidden_patient_id.Text + "' ";
                        String session_id;
                        String doc_id;
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {

                            tb_patientname.Text = reader.GetString("patient_name");
                            hidden_PatientName.Text = tb_patientname.Text;
                            tb_mail.Text = reader.GetString("email");
                            hidden_mail.Text = tb_mail.Text;
                            session_id = reader.GetString("session_id");
                        }
                        conn.Close();

                        conn.Open();
                        cmd1 = conn.CreateCommand();
                        cmd1.CommandText = "select * from  appointment_sessions a,patient p where a.session_id = p.session_id and  p.patient_name ='" + tb_patientname.Text + "' ";

                        reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            tb_chanelleddate.Text = reader1.GetString("session_date");
                            hidden_channeleddate.Text = tb_chanelleddate.Text;
                            doc_id = reader1.GetString("doc_id");
                        }//
                        conn.Close();

                        conn.Open();
                        cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "select * from  doctor d,appointment_sessions a where a.doc_id = d.doc_id and a.session_date='" + tb_chanelleddate.Text + "'";

                        reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            tb_doctorname.Text = reader2.GetString("doc_name");
                            tb_doccharge.Text = reader2.GetString("chanel_fee");
                        }
                        conn.Close();

                    }
                }

                catch { }
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            getPatientDetails();
            bool var_checkAllFields = checkAllFields();

            bool var_checkPaymentStatus = checkPaymentStatus();
            if (var_checkAllFields)
            {
                if (var_checkPaymentStatus)
                {
                    conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                    conn.Open();
                    if (tb_other.Text == "" || tb_other.Text == null)
                    {
                        queryStr = "insert into outpatientcharges (patient_id,patient_name,doc_charge,channel_date,other,hos_charge,total_charge,pay_status,pay_date) values ('" + Convert.ToString(tb_patientid.Text) + "','" + Convert.ToString(tb_patientname.Text) + "','" + Convert.ToDouble(tb_doccharge.Text) + "','" + Convert.ToString(tb_chanelleddate.Text) + "',0,'" + Convert.ToDouble(tb_hoscharge.Text) + "','" + Convert.ToDouble(tb_total.Text) + "','Paid', '" + getPaymentDate() + "' )";
                        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                        cmd.ExecuteNonQuery();
                    }

                    else
                    {
                        queryStr = "insert into outpatientcharges (patient_id,patient_name,doc_charge,channel_date,other,hos_charge,total_charge,pay_status,pay_date) values ('" + Convert.ToString(tb_patientid.Text) + "','" + Convert.ToString(tb_patientname.Text) + "','" + Convert.ToDouble(tb_doccharge.Text) + "', '" + Convert.ToString(tb_chanelleddate.Text) + "' ,'" + Convert.ToDouble(tb_other.Text) + "','" + Convert.ToDouble(tb_hoscharge.Text) + "','" + Convert.ToDouble(tb_total.Text) + "','Paid', '" + getPaymentDate() + "' )";
                        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted  ');</script>");

                    btn_email.Enabled = true;
                    ConDataBind();
                    clear();
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Payment has already been done ');</script>");
                }

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please fill all the fields');</script>");
            }
        }

        public bool checkAllFields()
        {
            if (tb_total.Text == null || tb_total.Text == "" || tb_patientid.Text == null || tb_patientid.Text == "" || tb_patientname.Text == null || tb_patientname.Text == "" || tb_doctorname.Text == null || tb_doctorname.Text == "" || tb_chanelleddate.Text == null || tb_chanelleddate.Text == "" || tb_doccharge.Text == null || tb_doccharge.Text == "" || tb_hoscharge.Text == null || tb_hoscharge.Text == "" || tb_tax.Text == null || tb_tax.Text == "" || tb_chanelleddate.Text == null || tb_chanelleddate.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            this.tb_patientid.Text = "";
            this.tb_patientname.Text = "";

            this.tb_doctorname.Text = "";
            this.tb_chanelleddate.Text = "";
            this.tb_doccharge.Text = "";
            this.tb_other.Text = "";
            this.tb_total.Text = "";
        }

        protected void ConDataBind()
        {
            using (MySqlConnection con = new MySqlConnection(ConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM outpatientcharges"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            con.Close();
                            if (dt.Rows.Count > 0)
                            {
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                            }
                            else
                            {
                                dt.Rows.Add(dt.NewRow());
                                GridView1.DataSource = dt;
                                GridView1.DataBind();
                                int columncount = GridView1.Rows[0].Cells.Count;
                                GridView1.Rows[0].Cells.Clear();
                                GridView1.Rows[0].Cells.Add(new TableCell());
                                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                                GridView1.Rows[0].Cells[0].Text = "No Records Found";
                            }
                        }
                    }
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_patientid.Text = GridView1.SelectedRow.Cells[2].Text;
            tb_patientname.Text = GridView1.SelectedRow.Cells[3].Text;
            //tb_doctorname.Text = GridView1.SelectedRow.Cells[3].Text;
            tb_chanelleddate.Text = GridView1.SelectedRow.Cells[10].Text;
            tb_doccharge.Text = GridView1.SelectedRow.Cells[4].Text;
            tb_other.Text = GridView1.SelectedRow.Cells[5].Text;
            tb_total.Text = GridView1.SelectedRow.Cells[7].Text;
        }

        public String getPaymentDate()
        {
            //payment date means current date
            // DateTime today = DateTime.Today;
            return DateTime.Today.ToString("dd-MM-yyyy");
        }

        public bool checkPaymentStatus()
        {
            //Check whether the patient has already completed a payment for the same doctor and for the same channel date
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();

            string checkstatus = "select count(*)  from outpatientcharges where patient_id='" + tb_patientid.Text.ToString() + "' and doc_charge='" + Convert.ToDouble(tb_doccharge.Text) + "' and channel_date='" + tb_chanelleddate.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(checkstatus, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (count != 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        protected void btn_email_Click(object sender, EventArgs e)
        {   //Sending mails to patien's accounts using default email address
            getPatientDetails();
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("maxsilvesterjohn@gmail.com", "maxsilvesterjohn123");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("maxsilvesterjohn@gmail.com");
            msg.To.Add(new MailAddress(hidden_mail.Text.ToString()));

            msg.Subject = "Your Payment is Scussfully received";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<body><table align='center' border='1' cellpadding='0' cellspacing='0' width='600'><tr><td align='center' bgcolor='#808080' style='padding: 40px 0 30px 0;'><table border='1' cellpadding='0' cellspacing='0' width='80%' style='background-color:white; font-family:Calibri' id='t1'><tr><td style='text-align:center; font-size:22px'>Hi " + hidden_PatientName.Text + "</td></tr><tr><td style='padding: 10px 0 0px 0;'>&emsp;Issued : " + getPaymentDate() + " <p style='font-weight:bolder'>&emsp;Thank you for choosing MEDICAL+ for your health care needs. </p><p style='color:green; font-weight:bolder;text-align:center;font-size:30px'>&emsp;Your payment is successfull !!!</p></td></tr><tr><td style='font-weight:bolder;'><u> <p style='font-size:40px; text-align:center'>Account Summary</p></u><br/><br/>&emsp;Channeled Date : " + hidden_channeleddate.Text + "<br />&emsp;Patient Name : " + hidden_PatientName.Text + "<p style='font-size:20px'>&emsp;Total Charges&emsp;&emsp;&emsp;&emsp;" + hidden_total.Text + "</p>&emsp;&emsp;&emsp;Doctor Charge &emsp;&emsp;&emsp; &nbsp;  &nbsp;" + hidden_doctorcharge.Text + "  <br />&emsp;&emsp;&emsp;Hospital Charge  &emsp;&emsp;&emsp;  " + tb_hoscharge.Text + "<br />&emsp;&emsp;&emsp;Other  &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp; &nbsp;    " + hidden_other.Text + "      <br />&emsp;&emsp;&emsp;Tax   &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;    " + tb_tax.Text + "       <br /><br /> <br /> <br /></td></tr></table></td></tr><tr></tr></table></body>");

            try
            {
                client.Send(msg);
                lbl_emailValidation.Text = "Your message has been successfully sent.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Your message has been successfully sent  ');</script>");
                lbl_emailValidation.Enabled = true;
            }
            catch (Exception ex)
            {
                lbl_emailValidation.ForeColor = System.Drawing.Color.Red;
                lbl_emailValidation.Text = "Error occured while sending your message." + ex.Message;
                lbl_emailValidation.Enabled = true;
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            getPatientDetails();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<body><table align='center' border='1' cellpadding='0' cellspacing='0' width='600'><tr><td align='center' bgcolor='#808080' style='padding: 0px 0 30px 0;'><table border='1' cellpadding='0' cellspacing='0' width='80%' style='background-color:white; font-family:Calibri' align='center' id='t1'><tr><td style='text-align:center; font-size:22px'>Hi " + hidden_PatientName.Text + "</td></tr><tr><td style='padding: 10px 0 0px 0;'>&emsp;Issued : " + getPaymentDate() + " <p style='font-weight:bolder'>&emsp;Thank you for choosing MEDICAL+ for your health care needs. </p><p style='color:green; font-weight:bolder;text-align:center;font-size:30px'>&emsp;Your payment is successfull !!!</p></td></tr><tr><td style='font-weight:bolder;'><u> <p style='font-size:40px; text-align:center'>Account Summary</p></u><br/><br/>&emsp;Channeled Date : " + hidden_channeleddate.Text + "<br />&emsp;Patient Name : " + hidden_PatientName.Text + "<p style='font-size:20px'>&emsp;Total Charges&emsp;&emsp;&emsp;&emsp;" + hidden_total.Text + "</p>&emsp;&emsp;&emsp;Doctor Charge &emsp;&emsp;&emsp; &nbsp;  &nbsp;" + hidden_doctorcharge.Text + "  <br />&emsp;&emsp;&emsp;Hospital Charge  &emsp;&emsp;&emsp;  " + tb_hoscharge.Text + "<br />&emsp;&emsp;&emsp;Other  &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp; &nbsp;    " + hidden_other.Text + "      <br />&emsp;&emsp;&emsp;Tax   &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;    " + tb_tax.Text + "       <br /><br /> <br /> <br /></td></tr></table></td></tr><tr></tr></table></body>");

                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.LEGAL_LANDSCAPE);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Payment_Invoice_" + tb_patientname.Text + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}