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
    public partial class incomereport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFilterTitle.Text = "Income Report";
            displayIncomeTable("SELECT CONVERT(date, order_datetime) AS 'date', COUNT(order_id) AS 'total_orders', SUM(order_total) AS 'income' FROM Orders GROUP BY  CONVERT(date, order_datetime)");
        }

        public void displayIncomeTable(string query)
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
            htmlTable.Append("<table id='reportTable' class='display nowrap'>");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr>");
            htmlTable.Append("<th> Date </th>");
            htmlTable.Append("<th> Tootal Orders </th>");
            htmlTable.Append("<th> Income </th>");
            htmlTable.Append("</tr>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody>");
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + dt.Rows[j]["date"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["total_orders"] + "</td>");
                htmlTable.Append("<td>" + dt.Rows[j]["income"] + "</td>");
                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</tbody>");
            htmlTable.Append("</table>");
            lblIncomeTable.Text = htmlTable.ToString();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string fromDate = txtFromDate.Text;
            string toDate = txtToDate.Text;

            displayIncomeTable("SELECT CONVERT(date, order_datetime) AS 'date', COUNT(order_id) AS 'total_orders', SUM(order_total) AS 'income' FROM Orders WHERE CONVERT(date, order_datetime) BETWEEN '" + fromDate + "' AND '" + toDate + "' GROUP BY CONVERT(date, order_datetime)");
        }
    }
}