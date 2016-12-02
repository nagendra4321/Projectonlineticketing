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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
            string query = "select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner"
                +"join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id";
            cmd = new SqlCommand("select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='"+ Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdorders.DataSource = dr;
            grdorders.DataBind();
            con.Close();
        }

        protected void btncancelres_Click(object sender, EventArgs e)
        {
            Response.Redirect("cancelreservation.aspx");
        }

        protected void rbnall_CheckedChanged(object sender, EventArgs e)
        {
            grdorders.Visible = true;
            grdactive.Visible = false;
            grdcancelled.Visible = false;
            grdpastevents.Visible = false;
        }

        protected void rbnactive_CheckedChanged(object sender, EventArgs e)
        {
            grdorders.Visible = false;
            grdactive.Visible = true;
            grdcancelled.Visible = false;
            grdpastevents.Visible = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
           cmd = new SqlCommand("select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id  where e.eventdate < GETDATE() and r.reservation='reserved'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdactive.DataSource = dr;
            grdactive.DataBind();
            con.Close();
        }

        protected void rbnpast_CheckedChanged(object sender, EventArgs e)
        {
            grdorders.Visible = false;
            grdactive.Visible = false;
            grdcancelled.Visible = false;
            grdpastevents.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
           cmd = new SqlCommand("select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id where e.eventdate < GETDATE()", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdpastevents.DataSource = dr;
            grdpastevents.DataBind();
            con.Close();
        }

        protected void rbncancelled_CheckedChanged(object sender, EventArgs e)
        {
            grdorders.Visible = false;
            grdactive.Visible = false;
            grdcancelled.Visible = true;
            grdpastevents.Visible = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            SqlCommand cmd;
            cmd = new SqlCommand("select e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id where r.reservation='cancelled'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdcancelled.DataSource = dr;
            grdcancelled.DataBind();
            con.Close();
        }
    }
}