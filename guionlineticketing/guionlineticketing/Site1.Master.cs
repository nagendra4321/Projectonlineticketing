using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //load the date and time to be used to get the event that are active
            DateTime timenow = DateTime.Now;



        }

        protected void btn_signin_Click(object sender, EventArgs e)
        {
            //if the user clicks on signin button redirecting him to signin page
            Response.Redirect("Signin.aspx");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //if the user clicks on register button redirect him to register page
            Response.Redirect("Register.aspx");

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            //if the user clicks on logout button redirect him to index page
            //clear the session 
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}