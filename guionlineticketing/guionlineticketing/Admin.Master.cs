using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            //if the user clicks on logout redirect him to sign page
            //clearing the session
            Session.Clear();
            Response.Redirect("Signin.aspx");
        }

        protected void btn_signin_Click(object sender, EventArgs e)
        {
            //if the user clicks on  sign in button redirect him to sign in page
            Response.Redirect("signin.aspx");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //if the user clicks on register button redirect him to register page
            Response.Redirect("register.aspx");
        }
    }
}