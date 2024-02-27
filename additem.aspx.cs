using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace E_Burger.Admin
{
    public partial class additem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = Request.QueryString["msg"];
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CommonItems commonItems = new CommonItems();

            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);

            Random rand = new Random();
            string imageExt = Path.GetExtension(fileItemImage.FileName);
            string imagename = rand.Next(1, 1000000000).ToString() + txtItemNames.Text.Trim()
                + imageExt;

            try
            {
                con.Open();

                string query = "INSERT INTO Items (item_name, item_price, item_description, item_image) VALUES ('" + txtItemNames.Text + "', '" + txtItemPrice.Text + "', '" + txtDescription.Text + "', '" + imagename + "')";

                SqlCommand cmd = new SqlCommand(query, con);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {
                    fileItemImage.PostedFile.SaveAs(Server.MapPath("~/images/") + imagename);

                    Response.Redirect("additem.aspx?msg=Item+Added+Succesfully");
                }
            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}