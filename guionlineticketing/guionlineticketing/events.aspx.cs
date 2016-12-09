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
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to show the appropriate buttons for the user if he is guest it shows
            //signin and register if he is registered user and logged in it shows profile info and logout
            //storing the eventid passed in the query string  to display the event
            string eventid = Request.QueryString["event"];
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
            string passedid = Request.QueryString["event"];
            //storing the eventid in session
            Session["EventId"] = passedid;
            //if passed id is null then redirect the user to index.aspx
            if (passedid==null)
            {
                Response.Redirect("index.aspx");
            }
            try
                {
                //creating an instance of SQL connection
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
                //sql command to retrieve the event from database using passed id
                SqlCommand cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.id=" + passedid, con);
                //opening the database connection
                con.Open();
                //executing the reader using this connection and storing the retrieved data in sqldatareader
                SqlDataReader dr = cmd.ExecuteReader();
                //binding the data to the deails view
                dtvevent.DataSource = dr;
                dtvevent.DataBind();
                //closing the connection
                con.Close();
                //if the event date is already gone or number os available seats are less than 0
                //displaying a message to the user
                int seats = Convert.ToInt32(dtvevent.Rows[4].Cells[1].Text);
                DateTime eventdate = Convert.ToDateTime(dtvevent.Rows[2].Cells[1].Text);
                if (eventdate < DateTime.Now || seats <= 0)
                {
                    btnreserve.Enabled = false;
                    Session["EventId"] = null;
                    lblmsg.Text = "reservation date for this event is completed or no seats are available ";
                }
               
            }
            catch
            {
                Response.Redirect("index.aspx");
            }

        }

        protected void btnreserve_Click(object sender, EventArgs e)
        {
            //when user clicks on reserve button redirect him to reservation page and pass event id as query string
            Response.Redirect("reservation.aspx?event="+ Session["EventId"].ToString());
        }
    }
}