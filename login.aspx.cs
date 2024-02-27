using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace E_Burger
{
    public partial class login : System.Web.UI.Page
    {
        CommonItems commonItems = new CommonItems();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["msg"] != null)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = Request.QueryString["msg"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            string username = txtEmail.Text;
            string password = txtPwd.Text;
            string password_hashed = commonItems.paswordHash(password);

            try
            {
                conn.Open();

                string query = "SELECT *  FROM Users WHERE user_email = '" + username + "' AND user_password = '" + password_hashed + "' ";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int usr_id = Int32.Parse(dt.Rows[0][0].ToString());
                    string userAuthLevel = dt.Rows[0]["user_type"].ToString();

                    Session["userid"] = usr_id;
                    Session["userrole"] = userAuthLevel;

                    if (userAuthLevel == "admin")
                    {
                        Response.Redirect("dashboard_admin.aspx");
                    }
                    else if (userAuthLevel == "customer")
                    {
                        Response.Redirect("dashboard.aspx");
                    }
                }
                else
                {
                    lblMsg.CssClass = "m-3";
                    lblMsg.Text = "Incorrect Username or Paswword";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = "Error in Login: " + ex.Message;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        protected void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}