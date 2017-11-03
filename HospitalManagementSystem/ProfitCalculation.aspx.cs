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
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace HospitalManagementSystem
{
    public partial class ProfitCalculation : System.Web.UI.Page
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
            tb_profitAmount.Attributes["disabled"] = "disabled";
            tb_totalExpense.Attributes["disabled"] = "disabled";
            tb_totalIncome.Attributes["disabled"] = "disabled";
            //tb_from.Attributes["disabled"] = "disabled";
            //tb_to.Attributes["disabled"] = "disabled";
        }

        protected void Calendar2_SelectionChanged1(object sender, EventArgs e)
        {
            tb_to.Text = Calendar2.SelectedDate.ToString("dd-MM-yyyy");
            Calendar2.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tb_from.Text = Calendar1.SelectedDate.ToString("dd-MM-yyyy");
            Calendar1.Visible = false;
        }

        protected void btn_date1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void btn_date2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void ConDataBind1()
        {
            using (MySqlConnection con = new MySqlConnection(ConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM outpatientcharges where pay_date between '" + tb_from.Text + "'  AND '" + tb_to.Text + "' "))
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

        protected void ConDataBind2()
        {
            using (MySqlConnection con = new MySqlConnection(ConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM expenses where date between '" + tb_from.Text + "'  AND '" + tb_to.Text + "' "))
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
                                GridView2.DataSource = dt;
                                //GridView2.Columns[1].HeaderText = "ID";
                                //GridView2.Columns[2].HeaderText = "Expense Date";
                                //GridView2.Columns[3].HeaderText = "Expense Type";
                                //GridView2.Columns[4].HeaderText = "Description";
                                //GridView2.Columns[5].HeaderText = "Expense Amount";
                                GridView2.DataBind();

                            }
                            else
                            {
                                dt.Rows.Add(dt.NewRow());
                                GridView2.DataSource = dt;
                                GridView2.DataBind();
                                int columncount = GridView2.Rows[0].Cells.Count;
                                GridView2.Rows[0].Cells.Clear();
                                GridView2.Rows[0].Cells.Add(new TableCell());
                                GridView2.Rows[0].Cells[0].ColumnSpan = columncount;
                                GridView2.Rows[0].Cells[0].Text = "No Records Found";

                            }
                        }
                    }
                }
            }
        }


        protected void btn_view_Click(object sender, EventArgs e)
        {
            bool result = checkDateTextBoxes();
            if (result)
            {
                if (tb_from.Text == tb_to.Text)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Both dates cannot be same ');</script>");
                }

                else
                {
                    DateTime Test;
                    if (DateTime.TryParseExact(tb_from.Text, "dd-MM-yyyy", null, DateTimeStyles.None, out Test) == true && DateTime.TryParseExact(tb_to.Text, "dd-MM-yyyy", null, DateTimeStyles.None, out Test) == true)
                    {
                        ConDataBind1();
                        ConDataBind2();

                        /////////////////////////////////////////////Get total income ///////////////////////////////////////////
                        conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                        conn.Open();
                        try
                        {
                            cmd = conn.CreateCommand();
                            cmd.CommandText = "SELECT SUM(total_charge) as totalIncome FROM outpatientcharges WHERE pay_date between '" + tb_from.Text + "'  AND '" + tb_to.Text + "'  ";

                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                double total_income;
                                total_income = reader.GetDouble("totalIncome");
                                tb_totalIncome.Text = total_income.ToString();
                                lbl_income_value.Text = total_income.ToString();
                            }
                        }

                        catch (Exception ex)
                        {
                            lbl_errormsg_income.Visible = true;
                            lbl_income_value.Text = "0";
                        }
                        conn.Close();

                        ///////////////////////Get total expenses////////////////////////////////////////////////

                        conn.Open();
                        try
                        {
                            cmd = conn.CreateCommand();
                            cmd.CommandText = "SELECT SUM(amount) as totalExpense FROM expenses WHERE date between '" + tb_from.Text + "'  AND '" + tb_to.Text + "'  ";

                            reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                double total_expense;
                                total_expense = reader.GetDouble("totalExpense");
                                tb_totalExpense.Text = total_expense.ToString();
                                lbl_expense_value.Text = total_expense.ToString();
                            }
                        }

                        catch (Exception ex)
                        {
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('There are no expense details for the given time period');</script>");
                            lbl_errormsg_expense.Visible = true;
                            lbl_expense_value.Text = "0";
                        }
                        conn.Close();

                        ////////////////////////Get the profit amount//////////////////////////////////////////////////

                        try
                        {
                            double income = Convert.ToDouble(lbl_income_value.Text);
                            double expenses = Convert.ToDouble(lbl_expense_value.Text);
                            double profit = income - expenses;
                            if (profit == 0)
                            {
                                tb_profitAmount.Text = "0";
                            }

                            else
                            {
                                tb_profitAmount.Text = profit.ToString();
                                lbl_profit.Text = profit.ToString();
                            }
                        }

                        catch (Exception ex)
                        {
                            lbl_errormsg_profit.Visible = true;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter valid dates');</script>");
                    }



                }

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter both dates');</script>");

            }


        }

        public bool checkDateTextBoxes()
        {
            if (((tb_from.Text == "") || (tb_from.Text == null)) || ((tb_to.Text == "") || (tb_to.Text == null)))
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
            tb_from.Text = "";
            tb_to.Text = "";
            tb_profitAmount.Text = "";
            tb_totalExpense.Text = "";
            tb_totalIncome.Text = "";
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            //Print the account details
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<body><h2 style='text-align:center; color:Red'>Account Details <br/> from " + tb_from.Text + " to " + tb_to.Text + " </h2> <br/><br/><table align='center' border='2' cellpadding='0' cellspacing='0' width='250'><tr><td><p>From</p></td><td>" + tb_from.Text + "</td></tr><tr ><td > <p>To </p> </td ><td> " + tb_to.Text + " </td ></tr ><tr ><td ><p>Total Expenses</p> </td><td> " + lbl_expense_value.Text + " </td></tr><tr><td> <p>Total Income</p> </td><td> " + lbl_income_value.Text + " </td></tr><tr><td> <p>Profit Amount </p> </td><td> " + lbl_profit.Text + " </td></tr></table></body>");

                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.POSTCARD);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Account_Details" + tb_from.Text + " - " + tb_to.Text + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}