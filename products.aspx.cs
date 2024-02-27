using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace E_Burger
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayProducts("SELECT * FROM Items");
        }

        public void displayProducts(string query)
        {
            DataTable dt = new DataTable();

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to dat
            SqlConnection con = new SqlConnection(strcon);


            using (con)
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    con.Close();
                }
            }

            StringBuilder productList = new StringBuilder();

            for (int j = 0; j < dt.Rows.Count; j++)
            {

                productList.Append("<div class='product-box'>");
                productList.Append("<i><img src='images/" + dt.Rows[j]["item_image"] + "'/></i>");
                productList.Append("<h3>" + dt.Rows[j]["item_name"] + "</h3>");
                productList.Append("<span>" + "LKR. " + dt.Rows[j]["item_price"] + "</span>");
                productList.Append("<br />");

                if (Session["userid"] != null)
                {
                    productList.Append("<a href='product_details.aspx?item=" + dt.Rows[j]["item_id"] + "' class='btn btn-light'> View Item</a>");
                }

                productList.Append("</div>");

            }
            lblProductsList.Text = productList.ToString();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();


            displayProducts("SELECT * FROM Items WHERE item_name LIKE '%" + search + "%'");
        }
    }
}