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
            string query = "select r.resrvationtype,e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner"
                +"join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id";
            cmd = new SqlCommand("select r.resrvationtype,e.eventcategory,e.eventname,e.eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='"+ Session["UserId"].ToString() + "' and r.eventid=e.id inner join auditoriumtable a on e.auditoriumid=a.id", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            grdorders.DataSource = dr;
            grdorders.DataBind();
            con.Close();
        }
    }
}