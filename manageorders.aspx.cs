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

namespace E_Burger.Admin
{
    public partial class manageorders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["filter"] != null)
            {
                if (Request.QueryString["filter"] == "pending")
                {
                    lblFilterTitle.Text = "Pending Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'pending'");
                }
                else if (Request.QueryString["filter"] == "cancelled")
                {
                    lblFilterTitle.Text = "Cancelled Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'cancelled'");
                }
                else if (Request.QueryString["filter"] == "approved")
                {
                    lblFilterTitle.Text = "Approved Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'approved'");
                }
                else
                {
                    lblFilterTitle.Text = "All Orders";
                    displayOrdersTable("SELECT * FROM Orders");
                }
            }
            else
            {
                lblFilterTitle.Text = "All Orders";
                displayOrdersTable("SELECT * FROM Orders");
            }
        }
        public void displayOrdersTable(string query)
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
            htmlTable.Append("<th> Order ID </th>");
            htmlTable.Append("<th> Order Time </th>");
            htmlTable.Append("<th> Order Status </th>");
            htmlTable.Append("<th> Order Item ID</th>");
            htmlTable.Append("<th> Qty </th>");
            htmlTable.Append("<th> Order Total </th>");
            htmlTable.Append("<th> Order User ID </th>");
            htmlTable.Append("<th>  </th>");
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
                htmlTable.Append("<td>" + dt.Rows[j]["order_user"] + "</td>");
                if (dt.Rows[j]["order_status"].ToString() == "pending")
                {
                    htmlTable.Append("<td> <a href='approveorder.aspx?order=" + dt.Rows[j]["order_id"] + "' class='btn btn-success'> Approve </a> </td>");
                }
                else
                {
                    htmlTable.Append("<td> <a href='cancelorder.aspx?order=" + dt.Rows[j]["order_id"] + "' class='btn btn-danger'> Cancel </a> </td>");
                }
                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</tbody>");
            htmlTable.Append("</table>");
            lblOrdersTable.Text = htmlTable.ToString();
        }
    }
}