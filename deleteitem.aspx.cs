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
    public partial class deleteitem : System.Web.UI.Page
    {
        public string itemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["item"] != null)
            {
                itemid = Request.QueryString["item"];
                deleteProduct(int.Parse(itemid));
            }
            else
            {
                Response.Redirect("products.aspx");
            }
        }

        public void deleteProduct(int itemid)
        {
            CommonItems commonItems = new CommonItems();

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            try
            {
                con.Open();

                string query = "DELETE FROM Items WHERE item_id = " + itemid;

                SqlCommand cmd = new SqlCommand(query, con);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {
                    Response.Redirect("manageitems.aspx?msg=Deleted+Succesfully");
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