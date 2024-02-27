using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace E_Burger
{
    public partial class product_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Request.QueryString["item"] != null)
            {
                string itemid = Request.QueryString["item"];
                loadProductDetails(int.Parse(itemid));
                linkOrderItem.NavigateUrl = "orderitem.aspx?item=" + itemid;
            }
            else
            {
                Response.Redirect("products.aspx");
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
                    lblItemName.Text = reader["item_name"].ToString();
                    lblItemPrice.Text = "LKR. " + reader["item_price"].ToString();
                    lblItemDescription.Text = reader["item_description"].ToString();
                    string imageName = reader["item_image"].ToString();
                    imageItem.ImageUrl = "images/" + imageName;
                }
            }

        }
    }
}