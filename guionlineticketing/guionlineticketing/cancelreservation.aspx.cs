using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class cancelreservation : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select r.id,e.eventcategory,e.eventname,CONVERT(VARCHAR(10), e.eventdate, 111) as eventdate,e.eventname,e.eventtime,e.fare,a.auditoriumname,a.address from reservationtable r inner join eventtable e on r.userid='" + Session["UserId"].ToString() + "' and r.eventid=e.id  inner join auditoriumtable a on e.auditoriumid=a.id where e.eventdate>GETDATE() and r.reservation='reserved'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                grdcancelreservation.DataSource = dr;
                grdcancelreservation.DataBind();
                con.Close();
            }
            
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int reservationid = Convert.ToInt32(btn.CommandArgument);
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
                //string studentid = txtsid.Text;
                //HiddenField hdnBookid = row.Cells[1].FindControl("hdnBookid") as HiddenField;
                //string Bookid = hdnBookid.Value;
                SqlCommand cmd = new SqlCommand("stp_cancelreservation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter retval = new SqlParameter("@retval", System.Data.SqlDbType.Int);
                retval.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(retval);
                cmd.Parameters.Add("@reservationid", SqlDbType.VarChar).Value = reservationid;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                int confirmationid = (int)retval.Value;
                Response.Redirect(Request.Url.ToString());
            }
          
        }
    }
}