using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class reservationconfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to show the appropriate buttons for the user if he is guest it shows
            //signin and register if he is registered user and logged in it shows profile info and logout
            if (Session["UserID"] != null)
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((Button)Master.FindControl("btn_register")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Text = Session["UserId"].ToString();
                ((Button)Master.FindControl("btnlogout")).Visible = true;

            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = true;
                ((Button)Master.FindControl("btn_register")).Visible = true;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                ((Button)Master.FindControl("btnlogout")).Visible = false;
            }
            //if the querystring does not have a confirmation number redirect user to index page
            if(Request.QueryString["confirm"]==null)
            {
                Response.Redirect("index.aspx");
            }
            //storing the confirmation number from the query string
            string confirmationid = Request.QueryString["confirm"];
            //displaying the confirmation number to the user
            lblconfirmationnumber.Text = confirmationid;
        }
    }
}