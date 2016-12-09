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
    public partial class profile : System.Web.UI.Page
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

            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = true;
                ((Button)Master.FindControl("btn_register")).Visible = true;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                Response.Redirect("Signin.aspx");
            }
            //sql connection instance to create a new sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
            string query = "select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner"
                +"join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id";
            //sql command to execute query to get all the user reserved events
            cmd = new SqlCommand("select e.eventcategory as Event_Category,e.eventname as Name,CONVERT(VARCHAR(10), e.eventdate, 111) as Date,e.eventtime as TIme,e.fare as Fare,a.auditoriumname as Venue,a.address as Address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id", con);
            con.Open();
            //opening the connection and retreiving the data
            SqlDataReader dr = cmd.ExecuteReader();
            grdorders.DataSource = dr;
            //binding the data to the grid view
            grdorders.DataBind();
            //closing the connection
            con.Close();
        }

        protected void btncancelres_Click(object sender, EventArgs e)
        {
            //if the user hits on cancel reservation redirect him to cancelresrvation.aspx page
            Response.Redirect("cancelreservation.aspx");
        }

        protected void rbnall_CheckedChanged(object sender, EventArgs e)
        {
            //when user hits the radiobutton all events just view all the events grid
            grdorders.Visible = true;
            grdactive.Visible = false;
            grdcancelled.Visible = false;
            grdpastevents.Visible = false;
        }

        protected void rbnactive_CheckedChanged(object sender, EventArgs e)
        {
            //when user hits the radiobutton active events  just view active events grid
            grdorders.Visible = false;
            grdactive.Visible = true;
            grdcancelled.Visible = false;
            grdpastevents.Visible = false;
            //creating the sql connection  instance
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
            //command to execute query to retrive all the reservations that are active
           cmd = new SqlCommand("select e.eventcategory as Event_Category,e.eventname as Name,CONVERT(VARCHAR(10), e.eventdate, 111) as Date,e.eventtime as TIme,e.fare as Fare,a.auditoriumname as Venue,a.address as Address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id  where e.eventdate > GETDATE() and r.reservation='reserved'", con);
            con.Open();
            //opening the connection and execute the reader
            SqlDataReader dr = cmd.ExecuteReader();
            //binding the data to the grid view
            grdactive.DataSource = dr;
            grdactive.DataBind();
            //closing the connection
            con.Close();
        }

        protected void rbnpast_CheckedChanged(object sender, EventArgs e)
        {
            //when user hits the radiobutton past events  just view past events grid
            grdorders.Visible = false;
            grdactive.Visible = false;
            grdcancelled.Visible = false;
            grdpastevents.Visible = true;
            //creating sqlconnection instnace
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //command to execute query to retrive all the past reservations that are not active
            SqlCommand cmd;
           cmd = new SqlCommand("select e.eventcategory as Event_Category,e.eventname as Name,CONVERT(VARCHAR(10), e.eventdate, 111) as Date,e.eventtime as TIme,e.fare as Fare,a.auditoriumname as Venue,a.address as Address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id where e.eventdate < GETDATE()", con);
            con.Open();
            //opening the connection and execute the reader
            //binding the data to the grid view
            SqlDataReader dr = cmd.ExecuteReader();
            grdpastevents.DataSource = dr;
            grdpastevents.DataBind();
            con.Close();
        }

        protected void rbncancelled_CheckedChanged(object sender, EventArgs e)
        {
            //when user hits the radiobutton cancelled events  just view cancelled events grid
            grdorders.Visible = false;
            grdactive.Visible = false;
            grdcancelled.Visible = true;
            grdpastevents.Visible = false;
            //creating sqlconnection instnace
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
            //command to execute query to retrive all the cancelled reservations 
            cmd = new SqlCommand("select e.eventcategory as Event_Category,e.eventname as Name,CONVERT(VARCHAR(10), e.eventdate, 111) as Date,e.eventtime as TIme,e.fare as Fare,a.auditoriumname as Venue,a.address as Address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id where r.reservation='cancelled'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            //opening the connection and execute the reader
            //binding the data to the grid view
            grdcancelled.DataSource = dr;
            grdcancelled.DataBind();
            con.Close();
        }
    }
}