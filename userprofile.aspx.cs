using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace E_Burger
{
    public partial class userprofile : System.Web.UI.Page
    {
        CommonItems commonItems = new CommonItems();

        public int userid;

        public void userdata()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to dat
            SqlConnection con = new SqlConnection(strcon);

            con.Open();

            string query = "SELECT * FROM Users WHERE user_id = " + userid;

            SqlCommand cmd = new SqlCommand(query, con);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblfname.Text = reader["user_fname"].ToString();
                    lbllname.Text = reader["user_lname"].ToString();
                    Lblemail.Text = reader["user_email"].ToString();                    
                    string imageName = reader["user_image"].ToString();
                    imageUser.ImageUrl = "images/" + imageName;
                }
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
                //userid = (int)Session["userid"];
                userid =Convert.ToInt32(Request.QueryString["userid"].ToString());
            }
            

            if (Request.QueryString["msg"] != null)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = Request.QueryString["msg"];
            }

            userdata();
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //create new sqlconnection and connection to database by using connection string from web.config file  
            SqlConnection conn = new SqlConnection(strcon);

            //string username = Lblemail.Text;
            //string password = txtupw.Text;
            //string password_hashed = commonItems.paswordHash(password);

            try
            {
                conn.Open();

                //string query = "SELECT *  FROM Users WHERE user_email = '" + username + "' AND user_password = '" + password_hashed + "' ";
                //SqlDataAdapter da = new SqlDataAdapter(query, conn);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                    //int usr_id = Int32.Parse(dt.Rows[0][0].ToString());
                    ////string userAuthLevel = dt.Rows[0]["user_type"].ToString();

                    ////Session["userid"] = usr_id;
                    ///
                    string imagename = "";
                    string query = "";
                    string encPwd = commonItems.paswordHash(txtupw.Text);

                if (fileItemImage.HasFile)
                    {
                        Random rand = new Random();
                        string imageExt = Path.GetExtension(fileItemImage.FileName);
                        imagename = rand.Next(1, 1000000000).ToString() + lblfname.Text.Trim()
                            + imageExt;
                    }

                    if (fileItemImage.HasFile)
                    {
                    //If File Uploaded
                     query = "UPDATE Users SET user_password = '" + encPwd + "',user_image = '" + imagename + "' WHERE user_id = " + userid ;
                    }
                    else
                    {
                    //If File not uploaded
                     query = "UPDATE Users SET user_password = '" + encPwd + "' WHERE user_id = "+ userid;
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    int db_ressult = cmd.ExecuteNonQuery();

                    if (db_ressult > 0)
                    {
                        if (fileItemImage.HasFile)
                        {
                            fileItemImage.PostedFile.SaveAs(Server.MapPath("~/images/") + imagename);
                        }

                        Response.Redirect("userprofile.aspx?userid="+ userid);
                        //Response.Redirect("edititem.aspx?item=" + itemid + "&msg=Item+Updated+Succesfully");
                    }               

                    //if (userAuthLevel == "customer")
                    //{
                    //    Response.Redirect("userprofile.aspx");
                    //}
                //}
                //else
                //{
                //    lblMsg.CssClass = "m-3";
                //    lblMsg.Text = "Incorrect Username or Paswword";
                //}
                conn.Close();
            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "m-3";
                lblMsg.Text = "Error in Update Info: " + ex.Message;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}