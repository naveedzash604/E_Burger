using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace E_Burger
{
    public partial class main_template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                ////login.Visible = false;
                //logout1.Visible = false;
                //signup.Visible = true;
                //myac.Visible = false;


                if (Session["userrole"].ToString() == "admin")
                {
                    login.Visible = false;
                    myacc.Visible = false;
                    signup.Visible = false;
                    cus_home.Visible = false;
                    cus_aboutus.Visible = false;
                    cus_cart.Visible = false;
                    adm_home.Visible = true;
                    logout.Visible = true;
                    admin_logo.Visible = true;
                    cus_logo.Visible = false;

                }
                else
                {
                    login.Visible = false;
                    logout.Visible = true;
                    myacc.Visible = true;
                    signup.Visible = false;
                    adm_home.Visible = false;
                    admin_logo.Visible = false;
                    cus_logo.Visible = true;
                }
            }
            else
            {

                login.Visible = true;
                logout.Visible = false;
                myacc.Visible = false;
                adm_home.Visible = false;
                admin_logo.Visible = false;
                cus_logo.Visible = true;
            }

        }

        protected void logout1_Click(object sender, EventArgs e)
        {
           
        }
    }
}