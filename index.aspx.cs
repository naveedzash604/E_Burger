using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Burger
{
    public partial class index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}