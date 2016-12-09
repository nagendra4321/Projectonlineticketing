using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class adminindex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to show the appropriate buttons for the user if he is guest it shows
            //signin and register if he is registered user and logged in it shows profile info and logout
            ((Button)Master.FindControl("btn_register")).Visible = false;
            if (Session["UserID"] != null && Session["UserID"].ToString() == "admin")
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Text = Session["UserId"].ToString();
                ((Button)Master.FindControl("btnlogout")).Visible = true;
            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                ((Button)Master.FindControl("btnlogout")).Visible = false;
                Response.Redirect("Signin.aspx");
            }
            //when the admin logs in this is used to display message for successfull login
            lblmsg.Text = "Succesfully logged in as " + Session["UserID"].ToString() + " .";
        }
    }
}