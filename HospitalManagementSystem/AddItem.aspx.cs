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
    public partial class AddItem : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String queryStr, qry;
        String ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            //post to same page that form is on
            if (!this.IsPostBack)
            {
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
                    queryStr = "insert into item (ItemId,Category,ItemCode,ItemName,Quantity,ReOrderLevel,RackNo,Description,Date) values ('" + txtItemId.Text + "','"+Convert.ToString(category.SelectedValue)+ "','" + txtItemCode.Text + "','" + txtItemName.Text + "','" + Convert.ToInt32(txtQty.Text) + "','" + Convert.ToInt32(txtReOrder.Text) + "','" + Convert.ToString(RackNo.SelectedValue) + "','"+txtDescriptionItem.Text+"','"+ txtdate.Text+"')";
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
                string query = "DELETE from item where ItemId=" + Convert.ToInt32(hidden_txtItemId.Text);
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
            //txtItemId.Text = null;
            category.SelectedValue = null;
            txtItemCode.Text = null;
            txtItemName.Text = null;
            txtQty.Text = null;
            txtReOrder.Text = null;
            RackNo.SelectedValue = null;
            txtDescriptionItem.Text = null;
            txtdate.Text = null;
        }

        public void getID()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM item ORDER BY ItemId DESC LIMIT 1 ";
                //no of raws limin to 1
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("ItemId");
                    idd = idd + 1;
                    txtItemId.Text = idd + "";


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

                if (selectedBy == "Item ID")
                {
                    query = "SELECT * from item where ItemId like '%" + Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Category")
                {
                    query = "SELECT * from item where Category like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Item Code")
                {
                    query = "SELECT * from item where ItemCode like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Item Name")
                {
                    query = "SELECT * from item where ItemName like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Quantity")
                {
                    query = "SELECT * from item where Quantity like '%" + Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Re Order Level")
                {
                    query = "SELECT * from item where ReOrderLevel like '%" + Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Rack No")
                {
                    query = "SELECT * from item where RackNo like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Description")
                {
                    query = "SELECT * from item where Description like '%" + tb_SearchId.Text + "%'";
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
            hidden_txtItemId.Text = GridView1.SelectedRow.Cells[1].Text;
            txtItemId.Text = GridView1.SelectedRow.Cells[1].Text;
            category.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
            txtItemCode.Text = GridView1.SelectedRow.Cells[3].Text;
            txtItemName.Text = GridView1.SelectedRow.Cells[4].Text;
            txtQty.Text = GridView1.SelectedRow.Cells[5].Text;
            txtReOrder.Text = GridView1.SelectedRow.Cells[6].Text;
            RackNo.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
            txtDescriptionItem.Text = GridView1.SelectedRow.Cells[8].Text;
            txtdate.Text = GridView1.SelectedRow.Cells[9].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(ConnString);
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE item set Category = '" + Convert.ToString(category.SelectedValue) + "', ItemCode = '" + txtItemCode.Text + "', ItemName = '" + txtItemName.Text + "', Quantity = '" + Convert.ToInt32(txtQty.Text) + "', ReOrderLevel = '" + Convert.ToInt32(txtReOrder.Text) + "',RackNo = '"+Convert.ToString(RackNo.SelectedValue)+ "',Description = '"+txtDescriptionItem.Text+ "',Date = '"+txtdate.Text+ "' where ItemId =" + Convert.ToInt32(hidden_txtItemId.Text);

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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM item"))
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
            if (((txtItemName.Text == "") || (txtItemCode.Text == "")) || ((txtQty.Text == "") || txtReOrder.Text == ""))
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