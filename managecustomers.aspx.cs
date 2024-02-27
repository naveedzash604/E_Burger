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
    public partial class managecustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayCustomersTable("SELECT * FROM Users WHERE user_type = 'customer'");
        }

        public void displayCustomersTable(string query)
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
            htmlTable.Append("<th> Customer ID </th>");
            htmlTable.Append("<th> First Name </th>");
            htmlTable.Append("<th> Last Name </th>");
            htmlTable.Append("<th> Contact ID</th>");
            htmlTable.Append("<th> Email </th>");
            htmlTable.Append("<th> Address </th>");
            htmlTable.Append("<th>  </th>");
            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_id"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_fname"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_lname"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_contact"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_email"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["user_address"] + "</td>");
                htmlTable.Append("<td> <a href='deleteuser.aspx?user=" + dt.Rows[j]["user_id"] + "' class='btn btn-danger'> Delete </a> </td>");
                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</tbody>");
            htmlTable.Append("</table>");
            lblCustomersTable.Text = htmlTable.ToString();
        }
    }
}