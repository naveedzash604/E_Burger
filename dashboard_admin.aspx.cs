using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace E_Burger.Admin
{
    public partial class dashboard_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTotalOrders.Text = calculateTotalOrders().ToString();
            lblTotalProfit.Text = calculateTotalProfit().ToString();
            lblPendingOrders.Text = calculatePendingOrders().ToString();
            lblApprovedOrders.Text = calculateApprovedOrders().ToString();
        }
        public double calculateTotalProfit()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            double profit = 0;

            try
            {
                conn.Open();

                string query = "SELECT SUM(order_total) FROM Orders";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                profit = Int32.Parse(dt.Rows[0][0].ToString());

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

            return profit;
        }

        public int calculateTotalOrders()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int totalOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders";
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

        public int calculatePendingOrders()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int pendingOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_status='pending'";
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

        public int calculateApprovedOrders()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            int aprovedOrders = 0;

            try
            {
                conn.Open();

                string query = "SELECT * FROM Orders WHERE order_status='approved'";
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
    }
}