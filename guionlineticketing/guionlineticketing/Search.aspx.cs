using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class Search : System.Web.UI.Page
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
            //setting the message lable to null
            lblmsg.Text = null;
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            //this event gets fired up when the user clicks on search button
            DateTime date;
            SqlCommand cmd;
            lblmsg.Text = "Search results are";
            //creating an instance of connecction
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //if user selects date choose command with date value included
            //if the user does not selects date choose command that does not include date
            if (Calendar1.SelectedDate.Date == DateTime.MinValue.Date)
            {
                cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.eventname like '%" + txteventname.Text + "%' and a.address like '%" + txtlocation.Text + "%'" , con);
            }
            else
            {
                date = Calendar1.SelectedDate;
                cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.eventname like '%" + txteventname.Text + "%' and a.address like '%" + txtlocation.Text + "%' and e.eventdate='" + date.ToString("yyyy-MM-dd") + "'", con);
            }
            //opening the connection and executing the reader
            //saving the data in the sqldatareader
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //binding the data to the grid view
            grdevents.DataSource = dr;
            grdevents.DataBind();
            //closing the connection
            con.Close();

            
            //Response.Redirect("searchresults.aspx");
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            //assigning the eventid to the each event view button in the grid row
            Button btn = (Button)sender;
            int eventid = Convert.ToInt32(btn.CommandArgument);
            //passing the event id to the events.aspx page as a query string
            Response.Redirect("events.aspx?event=" + eventid);
        }
    }
}