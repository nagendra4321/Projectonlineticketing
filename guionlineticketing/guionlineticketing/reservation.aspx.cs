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
    public partial class reservation : System.Web.UI.Page
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string cmd = "select * from eventtable where id="+ Session["EventId"].ToString();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
            DataSet ds = new DataSet();
            con.Open();
            adapter.Fill(ds,"event");
            con.Close();
            DataTable dtable = ds.Tables["event"];
            DataRow drow = dtable.Rows[0];
            lbleventname.Text = drow["eventname"].ToString();
            lbleventdate.Text = drow["eventdate"].ToString();
            lbleventtime.Text = drow["eventtime"].ToString();
            if (Session["UserID"] != null)
            {
                string cmd1 = "select * from usertable where id='" + Session["UserID"].ToString()+"'";
                SqlDataAdapter useradapter = new SqlDataAdapter(cmd1, con);
                con.Open();
                useradapter.Fill(ds, "user");
                con.Close();
                DataTable dtableuser = ds.Tables["user"];
                DataRow drowuser = dtableuser.Rows[0];
                lbluserid.Text = drowuser["id"].ToString();
                txtname.Text = drowuser["username"].ToString();
                txtemail.Text = drowuser["email"].ToString();
                txtphonenum.Text = drowuser["phonenum"].ToString();
                txtcontactinfo.Text = drowuser["address"].ToString();
               

            }




            }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            string reservationtype = "guest";
            if (Session["UserID"] != null)
            {
                reservationtype = "user";
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //string studentid = txtsid.Text;
            //HiddenField hdnBookid = row.Cells[1].FindControl("hdnBookid") as HiddenField;
            //string Bookid = hdnBookid.Value;
            SqlCommand cmd = new SqlCommand("stp_reservationtable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter retval = new SqlParameter("@retval", System.Data.SqlDbType.Int);
            retval.Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retval);
            cmd.Parameters.Add("@reservationtype", SqlDbType.VarChar).Value = reservationtype;
            cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = lbluserid.Text;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtname.Text;
            cmd.Parameters.Add("@eventid", SqlDbType.Int).Value = int.Parse(Session["EventId"].ToString());
            cmd.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@seatid", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@cardnum", SqlDbType.VarChar).Value = txtname.Text;
            cmd.Parameters.Add("@cardname", SqlDbType.VarChar).Value = txtcardname.Text;
            cmd.Parameters.Add("@cvv", SqlDbType.Int).Value =int.Parse(txtcvv.Text);
            cmd.Parameters.Add("@expdate", SqlDbType.DateTime).Value = DateTime.ParseExact(txtExpirationdate.Text, "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            int confirmationid= (int)retval.Value;
            Response.Redirect("reservationconfirmation.aspx?confirm=" + confirmationid);
        }
    }
}