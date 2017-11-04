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
    public partial class Issue : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlCommand cmd1;
        MySql.Data.MySqlClient.MySqlCommand cmd2;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr, qry, qry1;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // MySql.Data.MySqlClient.MySqlCommand cmd;
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();
                queryStr = "select ItemId, ItemName from item";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "ItemName";
                DropDownList1.DataValueField = "ItemId";
                DropDownList1.DataBind();

                ConDataBind();

            }

            getID();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            try
            {
                bool fieldsReq = RequiredFieldValidate();
                if (fieldsReq)
                {
                    conn.Open();
                    queryStr = "insert into issue (IssueId,ItemName,QuantityIssue,Location,IssueDate) values ('" + txtItemIssueId.Text + "','" + Convert.ToString(DropDownList1.SelectedValue) + "','" + Convert.ToInt32(txtQtyIssue.Text) + "','" + Convert.ToString(location.SelectedValue) + "','" + txtIssueDate.Text + "')";
                    qry = "SELECT Quantity FROM item where ItemId='" + DropDownList1.SelectedValue + "'";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                    cmd1 = new MySql.Data.MySqlClient.MySqlCommand(qry, conn);

                    int Quantity = Convert.ToInt32(cmd1.ExecuteScalar());
                    int qty_issued = Convert.ToInt32(txtQtyIssue.Text);

                    if (Quantity < qty_issued)
                    {
                        
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Out Of Stock & Item cannot be isuued');</script>");

                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Issued.!  ');</script>");
                        int new_stock = Quantity - qty_issued;
                        qry1 = "UPDATE item  SET Quantity ='" + new_stock + "' where ItemId='" + DropDownList1.SelectedValue + "'";
                        cmd2 = new MySql.Data.MySqlClient.MySqlCommand(qry1, conn);
                        cmd2.ExecuteNonQuery();
                        ConDataBind();
                        clear();
                        getID();

                    }
                    

                    //cmd.ExecuteNonQuery();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Inserted.!  ');</script>");
                    //ConDataBind();
                    //clear();
                    //getID();
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
                string query = "DELETE from issue where IssueId=" + Convert.ToInt32(hidden_txtItemIssueId.Text);
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
            //txtItemIssueId.Text = null;
            txtQtyIssue.Text = null;
            location.Text = null;
            txtIssueDate.Text = null;
            tb_SearchId.Text = null;
        }

        public void getID()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM issue ORDER BY IssueId DESC LIMIT 1 ";
                //no of raws limin to 1
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("IssueId");
                    idd = idd + 1;
                    txtItemIssueId.Text = idd + "";


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

                if (selectedBy == "Issue ID")
                {
                    query = "SELECT * from issue where IssueId like '%" + Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Item Name")
                {
                    query = "SELECT * from issue where ItemName like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Quantity")
                {
                    query = "SELECT * from issue where QuantityIssue like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Location")
                {
                    query = "SELECT * from issue where Location like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Date")
                {
                    query = "SELECT * from issue where IssueDate like '%" + tb_SearchId.Text + "%'";
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Please enter valid Id');</script>");
                //throw;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidden_txtItemIssueId.Text = GridView1.SelectedRow.Cells[1].Text;
            txtItemIssueId.Text = GridView1.SelectedRow.Cells[1].Text;
            DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
            txtQtyIssue.Text = GridView1.SelectedRow.Cells[3].Text;
            location.SelectedValue = GridView1.SelectedRow.Cells[4].Text;
            txtIssueDate.Text = GridView1.SelectedRow.Cells[5].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(ConnString);
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE issue set ItemName = '" + DropDownList1.SelectedValue + "', QuantityIssue = '" + Convert.ToInt32(txtQtyIssue.Text) + "', Location = '" + location.SelectedValue + "', IssueDate = '" + txtIssueDate.Text + "' where IssueId =" + Convert.ToInt32(hidden_txtItemIssueId.Text);

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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM issue"))
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
                                //bind the data source
                            }
                            //count is 0 -> No recordsfound
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
            if (((txtQtyIssue.Text == "") || (txtIssueDate.Text == "")))
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