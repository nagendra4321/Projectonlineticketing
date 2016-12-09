using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace guionlineticketing
{
    public partial class addevent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to show the appropriate buttons for the admin if he is logged in it shows profile info and logout
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
            //changing the message label to null
            lblmsg.Text = " ";

        }

        protected void btnaddevent_Click(object sender, EventArgs e)
        {
            //storing the date and time at that instance of time to use next time
            DateTime date = caldate.SelectedDate;
            //creating the instance of sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //sql query to add a new event
            string query = string.Format("insert into eventtable (eventname,eventcategory,auditoriumid,eventdate,eventtime,noofseats,fare)  values('{0}','{1}',{2},'{3}','{4}',{5},{6})", txteventmane.Text, ddlcategory.SelectedItem.Text, ddllocation.SelectedItem.Value, date.ToString("yyyy-MM-dd"), txttime.Text,txtnoofseats.Text,txtfare.Text);
            //sql command to execute the query
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            //opening the connection
            con.Open();
            //execcuting the query
            int i = cmdsubmit.ExecuteNonQuery();
            //closing the connection
            con.Close();
            //after adding the event displaying the message to the user
            lblmsg.Text = "Event " + txteventmane.Text.ToString() + " has been created";
            //deleting the data from the controls
            txteventmane.Text = null;
            txtfare.Text = null;
            txtnoofseats.Text = null;
            txttime.Text = null;
            caldate.SelectedDate = DateTime.Now;
        }

        protected void imageupload_Load(object sender, EventArgs e)
        {
            if (imageupload.HasFile)
            {
                imageupload.PostedFile.SaveAs(Server.MapPath("~/images/" + imageupload.FileName));


            }
        }
    }
}