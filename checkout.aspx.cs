using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Burger
{
    public partial class checkout : System.Web.UI.Page
    {
        public int User_id;

        public void conford()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT user_fname,user_lname,user_address,user_contact FROM Users WHERE user_id='" + User_id + "' ", con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                lblfname.Text = reader.GetString(0);
                lbllname.Text = reader.GetString(1);
                lbladdress.Text = reader.GetString(2);
                lblcontact.Text = reader.GetString(3);

                reader.Close();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                User_id = (int)Session["userid"];
            }

            if (Request.QueryString["msg"] != null)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = Request.QueryString["msg"];
            }

            conford();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}