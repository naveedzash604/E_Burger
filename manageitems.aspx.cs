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
    public partial class manageitems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayItemsTable("SELECT * FROM Items");
        }

        public void displayItemsTable(string query)
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
            htmlTable.Append("<th> Item ID </th>");
            htmlTable.Append("<th> Item Name </th>");
            htmlTable.Append("<th> Item Price </th>");
            htmlTable.Append("<th> Item Description </th>");
            htmlTable.Append("<th>  </th>");
            htmlTable.Append("<th>  </th>");
            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + dt.Rows[j]["item_id"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["item_name"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["item_price"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["item_description"] + "</td>");
                htmlTable.Append("<td> <a href='edititem.aspx?item=" + dt.Rows[j]["item_id"] + "' class='btn btn-info'> Edit </a> </td>");
                htmlTable.Append("<td> <a href='deleteitem.aspx?item=" + dt.Rows[j]["item_id"] + "' class='btn btn-danger'> Delete </a> </td>");
                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</tbody>");
            htmlTable.Append("</table>");
            lblItemsTable.Text = htmlTable.ToString();
        }
    }
}