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
    public partial class approveorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderid = "";

            if (Request.QueryString["order"] != null)
            {
                orderid = Request.QueryString["order"];
            }
            else
            {
                Response.Write("<script>alert('Failed to update status. Please try again!')</script>");
                Response.Write("<script>location.href = 'manageorders.aspx'</script>");
            };


            CommonItems commonItems = new CommonItems();

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);


            try
            {
                con.Open();

                string query = "UPDATE Orders SET order_status = 'approved' WHERE order_id = '" + orderid + "'";

                SqlCommand cmd = new SqlCommand(query, con);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {

                    Response.Write("<script>alert('Order Status updated succesfully!')</script>");
                    Response.Write("<script>location.href = 'manageorders.aspx'</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}