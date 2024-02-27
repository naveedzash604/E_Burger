using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace E_Burger.Admin
{
    public partial class edititem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["item"] != null)
            {
                string itemid = Request.QueryString["item"];

                if ((txtItemNames.Text == null || txtItemNames.Text == "") && (txtItemPrice.Text == null || txtItemPrice.Text == "") && (txtDescription.Text == null || txtDescription.Text == ""))
                {
                    loadProductDetails(int.Parse(itemid));
                }


            }
            else
            {
                Response.Redirect("products.aspx");
            }

            if (Request.QueryString["msg"] != null)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = Request.QueryString["msg"];
            }
        }

        public void loadProductDetails(int itemid)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to dat
            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            string query = "SELECT * FROM Items WHERE item_id = " + itemid;

            SqlCommand cmd = new SqlCommand(query, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    txtItemNames.Text = reader["item_name"].ToString();
                    txtItemPrice.Text = reader["item_price"].ToString();
                    txtDescription.Text = reader["item_description"].ToString();
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string itemName = txtItemNames.Text;

            CommonItems commonItems = new CommonItems();

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            string imagename = "";

            if (fileItemImage.HasFile)
            {
                Random rand = new Random();
                string imageExt = Path.GetExtension(fileItemImage.FileName);
                imagename = rand.Next(1, 1000000000).ToString() + txtItemNames.Text.Trim()
                    + imageExt;
            }
            string itemid = "0";
            if (Request.QueryString["item"] != null)
            {
                itemid = Request.QueryString["item"];
            }

            try
            {
                con.Open();

                string query = "";



                if (fileItemImage.HasFile)
                {
                    //If File Uploaded
                    query = "UPDATE Items SET item_name = '" + txtItemNames.Text + "', item_price = '" + txtItemPrice.Text + "', item_description = '" + txtDescription.Text + "', item_image = '" + imagename + "' WHERE item_id = '" + itemid + "' ";
                }
                else
                {
                    //If File not uploaded
                    query = "UPDATE Items SET item_name = '" + txtItemNames.Text + "', item_price = '" + txtItemPrice.Text + "', item_description = '" + txtDescription.Text + "' WHERE item_id = '" + itemid + "' ";
                }


                SqlCommand cmd = new SqlCommand(query, con);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {
                    if (fileItemImage.HasFile)
                    {
                        fileItemImage.PostedFile.SaveAs(Server.MapPath("~/images/") + imagename);
                    }

                    Response.Redirect("edititem.aspx?item=" + itemid + "&msg=Item+Updated+Succesfully");
                }


            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}