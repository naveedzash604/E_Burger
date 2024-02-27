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
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void displayCartTable(string query)
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

            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table class='table'>");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr>");
            htmlTable.Append("<th> No </th>");
            htmlTable.Append("<th> Item </th>");
            htmlTable.Append("<th> Unit Price </th>");
            htmlTable.Append("<th> Qty </th>");
            htmlTable.Append("<th> Total </th>");
            htmlTable.Append("<th> </th>");
            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_id"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_datetime"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_status"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_item"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_qty"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["order_total"] + "</td>");
                if (dt.Rows[j]["order_status"].ToString() != "cancelled")
                {
                    htmlTable.Append("<td> <a href='cus_cancelorder.aspx?order=" + dt.Rows[j]["order_id"] + "' class='btn btn-danger'> Cancel </a> </td>");
                }
                else
                {
                    htmlTable.Append("<td></td>");
                }
                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</tbody>");
            htmlTable.Append("</table>");
            lblCartTable.Text = htmlTable.ToString();
        }

        public int calculateTotalOrders(string userid)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int totalOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_user = '" + userid + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                totalOrders = dt.Rows.Count;
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return totalOrders;

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                Response.Redirect("checkout.aspx");
            }
            else
            {
                Response.Redirect("login.aspx?rurl=cart");
            }
        }
    }
}