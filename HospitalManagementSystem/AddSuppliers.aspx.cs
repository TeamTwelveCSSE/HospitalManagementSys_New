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
    
    public partial class AddSuppliers : System.Web.UI.Page
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
                    queryStr = "insert into supplier (SupplierId,SupplierName,Address,Email,Telephone,Description) values ('" + txtSupplierId.Text + "','" + txtSupplierName.Text + "','" + txtSupplierAddress.Text + "','" + txtSupplierEmail.Text + "','" + txtSupplierTelephone.Text + "','" + txtSupplierDescription.Text + "')";
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
                string query = "DELETE from supplier where SupplierId=" + Convert.ToInt32(hidden_txtSupplierId.Text);
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
            //txtSupplierId.Text = null;
            txtSupplierName.Text = null;
            txtSupplierEmail.Text = null;
            txtSupplierDescription.Text = null;
            txtSupplierTelephone.Text = null;
            txtSupplierAddress.Text = null;
            tb_SearchId.Text = null;
        }

        public void getID()
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection(ConnString);
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM supplier ORDER BY SupplierId DESC LIMIT 1 ";
                //no of raws limin to 1
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int idd;
                    idd = reader.GetInt32("SupplierId");
                    idd = idd + 1;
                    txtSupplierId.Text = idd + "";


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

                if (selectedBy == "Supplier ID")
                {
                    query = "SELECT * from supplier where SupplierId like '%"+ Convert.ToInt32(tb_SearchId.Text) + "%'";
                }
                else if (selectedBy == "Name")
                {
                    query = "SELECT * from supplier where SupplierName like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Address")
                {
                    query = "SELECT * from supplier where Address like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Email")
                {
                    query = "SELECT * from supplier where Email like '%" + tb_SearchId.Text + "%'";
                }
                else if (selectedBy == "Telephone")
                {
                    query = "SELECT * from supplier where Telephone like '%" + tb_SearchId.Text + "%'";
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
            hidden_txtSupplierId.Text = GridView1.SelectedRow.Cells[1].Text;
            txtSupplierId.Text = GridView1.SelectedRow.Cells[1].Text;
            txtSupplierName.Text = GridView1.SelectedRow.Cells[2].Text;
            txtSupplierAddress.Text = GridView1.SelectedRow.Cells[3].Text;
            txtSupplierEmail.Text = GridView1.SelectedRow.Cells[4].Text;
            txtSupplierTelephone.Text = GridView1.SelectedRow.Cells[5].Text;
            txtSupplierDescription.Text = GridView1.SelectedRow.Cells[6].Text;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(ConnString);
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE supplier set SupplierName = '" + txtSupplierName.Text + "', Address = '" + txtSupplierAddress.Text + "', Email = '" + txtSupplierEmail.Text + "', Telephone = '" + txtSupplierTelephone.Text + "', Description = '" + txtSupplierDescription.Text + "' where SupplierId =" + Convert.ToInt32(hidden_txtSupplierId.Text);

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
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM supplier"))
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
            if (((txtSupplierName.Text == "") || (txtSupplierAddress.Text == "")) || ((txtSupplierEmail.Text == "") || txtSupplierTelephone.Text == ""))
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