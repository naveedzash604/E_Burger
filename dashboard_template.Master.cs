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
    public partial class dashboard_template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }

            loadUserName();

            if (Session["userrole"].ToString() == "admin")
            {
                admin_logo.Visible = true;
                cus_logo.Visible = false;

            }
            else
            {
                admin_logo.Visible = false;
                cus_logo.Visible = true;
            }
        }

        public void loadUserName()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to dat
            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            string query = "SELECT * FROM Users WHERE user_id = " + Session["userid"];

            SqlCommand cmd = new SqlCommand(query, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblLoggedUser.Text = reader["user_fname"].ToString() + " " + reader["user_lname"].ToString() + "(" + reader["user_type"].ToString() + ")";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}