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
    public partial class Order : System.Web.UI.Page
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
                // MySql.Data.MySqlClient.MySqlCommand cmd;
                conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
                conn.Open();
                queryStr = "select SupplierId, SupplierName from supplier";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "SupplierName";
                DropDownList1.DataValueField = "SupplierId";
                DropDownList1.DataBind();

                ConDataBind();

            }
            //to get id for viewd text box by increment 1
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
                    queryStr = "insert into hospitalmgtsys.`order` (OrderId,SupplierName,OrderName,QuantityOrder,OrderDate) values ('" + txtOrderId.Text + "','" + Convert.ToString(DropDownList1.SelectedValue) + "','" + txtOrderName.Text + "','" + Convert.ToInt32(txtQtyOrder.Text) + "','" + txtOrderDate.Text + "')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                    cmd.ExecuteNonQuery();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Succesfully Order Inserted.!  ');</script>");
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
                string query = "DELETE from hospitalmgtsys.`order` where OrderId=" + Convert.ToInt32(hidden_txtOrderId.Text);
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
            txtOrderName.Text = null;
            txtQtyOrder.Text = null;
            txtOrderDate.Text = null;
            tb_SearchId.Text = null;
        }

        public void getID()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM hospitalmgtsys.`order` ORDER BY OrderId DESC LIMIT 1 ";
                //no of raws limin to 1
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("OrderId");
                    idd = idd + 1;
                    txtOrderId.Text = idd + "";


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

                if (selectedBy == "Order ID")
                {
                    query = "SELECT * from hospitalmgtsys.`order` where OrderId like '%" + Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Supplier ID")
                {
                    query = "SELECT * from hospitalmgtsys.`order` where SupplierName like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Order Name")
                {
                    query = "SELECT * from hospitalmgtsys.`order` where OrderName like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Quantity")
                {
                    query = "SELECT * from hospitalmgtsys.`order` where QuantityOrder like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Date")
                {
                    query = "SELECT * from hospitalmgtsys.`order` where OrderDate like '%" + tb_SearchId.Text + "%'";
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
            hidden_txtOrderId.Text = GridView1.SelectedRow.Cells[1].Text;
            txtOrderId.Text = GridView1.SelectedRow.Cells[1].Text;
            DropDownList1.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
            txtOrderName.Text = GridView1.SelectedRow.Cells[3].Text;
            txtQtyOrder.Text = GridView1.SelectedRow.Cells[4].Text;
            txtOrderDate.Text = GridView1.SelectedRow.Cells[5].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(ConnString);
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE hospitalmgtsys.`order` set SupplierName = '" + DropDownList1.SelectedValue + "', OrderName = '" + txtOrderName.Text + "', QuantityOrder = '" + Convert.ToInt32(txtQtyOrder.Text) + "', OrderDate = '" + txtOrderDate.Text + "' where OrderId =" + Convert.ToInt32(hidden_txtOrderId.Text);

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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM hospitalmgtsys.`order`"))
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
            if (((txtOrderName.Text == "") || (txtQtyOrder.Text == "")))
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