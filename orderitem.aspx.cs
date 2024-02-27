using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace E_Burger.Admin
{
    public partial class orderitem : System.Web.UI.Page
    {
        public string itemid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Request.QueryString["item"] != null)
            {
                itemid = Request.QueryString["item"];
                loadProductDetails(int.Parse(itemid));
            }
            else
            {
                Response.Redirect("products.aspx");
            }

            updateTotal();
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
                    lblitemID.Text = reader["item_id"].ToString();
                    lblItemName.Text = reader["item_name"].ToString();
                    lblItemPrice.Text = reader["item_price"].ToString();
                    lblItemDescription.Text = reader["item_description"].ToString();
                }
            }

        }
        protected void btnUpdateQty_Click(object sender, EventArgs e)
        {
            updateTotal();
        }

        public void updateTotal()
        {
            int qty = 0;

            if (txtQty.Text == "" || txtQty.Text == null)
            {
                qty = 0;

            }
            else
            {
                qty = int.Parse(txtQty.Text);
            }

            double total = qty * double.Parse(lblItemPrice.Text);
            lblTotal.Text = total.ToString();
        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("cart.aspx?itemid={0}&qty={1}", lblitemID.Text, txtQty.Text));

            //DateTime datetime = DateTime.Now;
            //double orderQty = double.Parse(txtQty.Text);
            //double orderTotal = double.Parse(lblTotal.Text);
            //string userid = Session["userid"].ToString();


            //CommonItems commonItems = new CommonItems();

            //string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            ////create new sqlconnection and connection to database by using connection string from web.config file  
            //SqlConnection con = new SqlConnection(strcon);


            //try
            //{
            //    con.Open();

            //    string query = "INSERT INTO Orders (order_datetime, order_status, order_qty, order_total, order_item, order_user) VALUES ('" + datetime + "', 'pending', '" + orderQty + "', '" + orderTotal + "', '" + itemid + "', '" + userid + "')";

            //    SqlCommand cmd = new SqlCommand(query, con);

            //    int db_ressult = cmd.ExecuteNonQuery();

            //    if (db_ressult > 0)
            //    {
            //        Response.Write("<script>alert('Order Placed Successfully')</script>");
            //        Response.Write("<script>location.href = 'products.aspx'</script>");
            //    }


            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}


        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}