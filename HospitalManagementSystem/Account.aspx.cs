using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace HospitalManagementSystem
{
    public partial class Account : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ConDataBind();
            }

            getID();
        }

        protected void btn_date_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tb_expensedate.Text = Calendar1.SelectedDate.ToString("dd-MM-yyyy");
            Calendar1.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {
                //check whether all the fields are not null
                bool fieldsReq = RequiredFieldValidate();
                if (fieldsReq)
                {
                    conn.Open();
                    queryStr = "insert into expenses (expense_id,date,type,description,amount) values ('" + tb_expenseid.Text + "','" + tb_expensedate.Text + "','" + Convert.ToString(list_expensetype.SelectedValue) + "','" + tb_expensedescription.Text + "','" + tb_expenseamount.Text + "')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted.!  ');</script>");
                    ConDataBind();
                    clear();
                    getID();
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please fill required fields');</script>");
                }
            }

            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data insertion failed');</script>");
            }

            conn.Close();

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                string query = "DELETE from expenses where expense_id=" + Convert.ToInt32(hidden_expense_id.Text);
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully deleted') == true){}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
                ConDataBind();
                clear();
                getID();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data deletion failed');</script>");
            }
        }

        public void clear()
        {
            this.tb_expenseamount.Text = null;
            this.tb_expensedescription.Text = null;
            this.tb_expensedate.Text = null;
            this.list_expensetype.SelectedValue = null;
        }

        public void getID()
        {
            //get the expense ID incrementing it by 1
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM expenses ORDER BY expense_id DESC LIMIT 1 ";

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("expense_id");
                    idd = idd + 1;
                    tb_expenseid.Text = idd + "";


                }
            }
            catch { }
            conn.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                string selectedBy = DropDownSearch.SelectedValue.ToString();

                if (selectedBy == "Expense ID")
                {
                    query = "SELECT * from expenses where expense_id=" + Convert.ToInt32(tb_SearchId.Text);
                }
                else if (selectedBy == "Date")
                {
                    query = "SELECT * from expenses where date='" + tb_SearchId.Text + "'";
                }
                else if (selectedBy == "Type")
                {
                    query = "SELECT * from expenses where type='" + tb_SearchId.Text + "'";
                }
                else if (selectedBy == "Description")
                {
                    query = "SELECT * from expenses where description='" + tb_SearchId.Text + "'";
                }
                else if (selectedBy == "Amount")
                {
                    query = "SELECT * from expenses where amount='" + tb_SearchId.Text + "'";
                }
                using (MySqlConnection con = new MySqlConnection(ConnString))
                {
                    using (cmd = new MySqlCommand(query))
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
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please fill the fields ');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidden_expense_id.Text = GridView1.SelectedRow.Cells[1].Text;
            //tb_expenseid.Text = GridView1.SelectedRow.Cells[1].Text;
            tb_expensedate.Text = GridView1.SelectedRow.Cells[2].Text;
            list_expensetype.SelectedValue = GridView1.SelectedRow.Cells[3].Text;
            tb_expensedescription.Text = GridView1.SelectedRow.Cells[4].Text;
            tb_expenseamount.Text = GridView1.SelectedRow.Cells[5].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(ConnString);
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE expenses set date = '" + tb_expensedate.Text + "', type = '" + Convert.ToString(list_expensetype.SelectedValue) + "', description = '" + tb_expensedescription.Text + "', amount = '" + tb_expenseamount.Text + "' where expense_id =" + Convert.ToInt32(hidden_expense_id.Text);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "string", "<script>" + "if(confirm('Successfully updated') == true){}" + "else{" + "alert('not confirmed!')" + "}" + "</script>");
                ConDataBind();
                clear();
                getID();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Data updation failed');</script>");
            }
        }

        public void refresh(GridView dataGridView)
        {
        }

        protected void ConDataBind()
        {
            using (MySqlConnection con = new MySqlConnection(ConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT *  FROM expenses"))
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

        protected bool RequiredFieldValidate()
        {
            if (((tb_expensedate.Text == "") || (list_expensetype.SelectedValue == "")) || ((tb_expensedescription.Text == "") || (tb_expenseamount.Text == "")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}