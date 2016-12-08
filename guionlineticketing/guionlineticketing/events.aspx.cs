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
            Session["EventId"] = passedid;
            if (passedid==null)
            {
                Response.Redirect("index.aspx");
            }
            try
                {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
                //SqlCommand cmd = new SqlCommand("SELECT [Bname], catname, [Author], [Edition], [Noofbooksavailable] FROM [tblbooks] b inner join tblcategory c on c.catid=b.catid WHERE ((b.[Catid] = " + ddlcategory.SelectedItem.Value + ") AND ([Bname] LIKE '%" + txtbookname.Text + "%') AND ([Author] LIKE '%" + txtauthorname.Text + "%'))", con);
                SqlCommand cmd = new SqlCommand("select e.id,e.eventname,e.eventcategory,a.auditoriumname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventtime,e.fare,e.noofseats,a.address from eventtable e inner join auditoriumtable a on e.auditoriumid=a.id where e.id=" + passedid, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dtvevent.DataSource = dr;
                dtvevent.DataBind();
                con.Close();
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
            
            Response.Redirect("reservation.aspx?event="+ Session["EventId"].ToString());
        }
    }
}