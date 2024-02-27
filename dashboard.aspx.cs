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
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = "";

            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                userid = Session["userid"].ToString();
            }

            if (Request.QueryString["filter"] != null)
            {
                if (Request.QueryString["filter"] == "pending")
                {
                    lblFilterTitle.Text = "Pending Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'pending' AND order_user = '" + userid + "'");
                }
                else if (Request.QueryString["filter"] == "cancelled")
                {
                    lblFilterTitle.Text = "Cancelled Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'cancelled' AND order_user = '" + userid + "'");
                }
                else if (Request.QueryString["filter"] == "approved")
                {
                    lblFilterTitle.Text = "Approved Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_status = 'approved' AND order_user = '" + userid + "'");
                }
                else
                {
                    lblFilterTitle.Text = "All Orders";
                    displayOrdersTable("SELECT * FROM Orders WHERE order_user = '" + userid + "'");
                }
            }
            else
            {
                lblFilterTitle.Text = "All Orders";
                displayOrdersTable("SELECT * FROM Orders WHERE order_user = '" + userid + "'");
            }

            displayStats(userid);

        }


        public void displayStats(string userid)
        {
            lblAllOrders.Text = calculateTotalOrders(userid).ToString();
            lblApprovedOrders.Text = calculateApprovedOrders(userid).ToString();
            lblCancelledOrders.Text = calculateCancelledOrders(userid).ToString();
            lblPendingOrders.Text = calculatePendingOrders(userid).ToString();
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
            lblOrdersTable.Text = htmlTable.ToString();
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

        public int calculatePendingOrders(string userid)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int pendingOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_user = '" + userid + "' AND order_status='pending' ";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                pendingOrders = dt.Rows.Count;
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

            return pendingOrders;
        }

        public int calculateApprovedOrders(string userid)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int aprovedOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_user = '" + userid + "' AND order_status='approved'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                aprovedOrders = dt.Rows.Count;
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

            return aprovedOrders;
        }

        public int calculateCancelledOrders(string userid)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int cancelledOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_user = '" + userid + "' AND order_status='cancelled'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cancelledOrders = dt.Rows.Count;
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

            return cancelledOrders;
        }
    }
}