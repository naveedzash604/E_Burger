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
    public partial class signup : System.Web.UI.Page
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

            //Encrypted Password
            string encPwd = commonItems.paswordHash(txtPwd.Text);
            try
            {
                con.Open();

                string query = "INSERT INTO Users (user_fname, user_lname, user_contact, user_address,user_email, user_type, user_password) VALUES ('" + txtFName.Text + "', '" + txtLName.Text + "', '" + txtContact.Text + "', '" + txtAddress.Text + "', '" + txtEmail.Text + "', 'customer', '" + encPwd + "')";

                SqlCommand cmd = new SqlCommand(query, con);

                int db_ressult = cmd.ExecuteNonQuery();

                if (db_ressult > 0)
                {
                    Response.Redirect("signup.aspx?msg=Sign+Up+Success");
                    //lblError.CssClass = "m-3";
                    //lblError.Text = "Succesfully Inserted";
                }


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
    }
}