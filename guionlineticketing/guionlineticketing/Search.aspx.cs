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
            lblmsg.Text = null;
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            DateTime date;
            SqlCommand cmd;
            lblmsg.Text = "Search results are";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("SELECT [Bname], catname, [Author], [Edition], [Noofbooksavailable] FROM [tblbooks] b inner join tblcategory c on c.catid=b.catid WHERE ((b.[Catid] = " + ddlcategory.SelectedItem.Value + ") AND ([Bname] LIKE '%" + txtbookname.Text + "%') AND ([Author] LIKE '%" + txtauthorname.Text + "%'))", con);
            if (Calendar1.SelectedDate.Date == DateTime.MinValue.Date)
            {
                cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.eventname like '%" + txteventname.Text + "%' and a.address like '%" + txtlocation.Text + "%'" , con);
            }
            else
            {
                date = Calendar1.SelectedDate;
                cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.eventname like '%" + txteventname.Text + "%' and a.address like '%" + txtlocation.Text + "%' and e.eventdate='" + date.ToString("yyyy-MM-dd") + "'", con);
            }
            
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdevents.DataSource = dr;
            grdevents.DataBind();
            con.Close();

            
            //Response.Redirect("searchresults.aspx");
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int eventid = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("events.aspx?event=" + eventid);
        }
    }
}