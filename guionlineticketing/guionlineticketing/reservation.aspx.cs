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
            //if the event id is not in the session then redirect him to index.aspx
            if(Session["EventId"]==null)
            {
                Response.Redirect("index.aspx");
            }
            //creating an instance of sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //query to retrive data from event table using the event id stored in session variable
            string cmd = "select * from eventtable where id="+ Session["EventId"].ToString();
            //dataadapter to store the retrieved data
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, con);
            //dataset to store the data after the connection closes
            DataSet ds = new DataSet();
            con.Open();
            //opening the connection and filling the dataset using dataadapter
            adapter.Fill(ds,"event");
            //closing the connection
            con.Close();
            //retrieving the data from the data table
            DataTable dtable = ds.Tables["event"];
            DataRow drow = dtable.Rows[0];
            //displaying the event data in the appropriate fields drom data table
            lbleventname.Text = drow["eventname"].ToString();
            lbleventdate.Text = drow["eventdate"].ToString();
            lbleventtime.Text = drow["eventtime"].ToString();
            //if the user is logged in then autofill the user data in the form
            if (Session["UserID"] != null)
            {
                //query to retrive the user data using session varaible
                string cmd1 = "select * from usertable where id='" + Session["UserID"].ToString()+"'";
                //sqldata adapter to retrieve data
                SqlDataAdapter useradapter = new SqlDataAdapter(cmd1, con);
                con.Open();
                //opening the connection and filling the data table
                useradapter.Fill(ds, "user");
                con.Close();
                //retrieving the data from the data table
                DataTable dtableuser = ds.Tables["user"];
                DataRow drowuser = dtableuser.Rows[0];
                //filling the from using users data
                lbluserid.Text = drowuser["id"].ToString();
                txtname.Text = drowuser["username"].ToString();
                txtemail.Text = drowuser["email"].ToString();
                txtphonenum.Text = drowuser["phonenum"].ToString();
                txtcontactinfo.Text = drowuser["address"].ToString();
               

            }




            }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            //event gets fired up when user clicks confirm button
            string reservationtype = "guest";
            if (Session["UserID"] != null)
            {
                reservationtype = "user";
            }
            //creating instance of an sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //sql command to execute a stored procedure
            SqlCommand cmd = new SqlCommand("stp_reservationtable", con);
            //command type is stored procedure
            cmd.CommandType = CommandType.StoredProcedure;
            //adding the return value to stored procedure
            SqlParameter retval = new SqlParameter("@retval", System.Data.SqlDbType.Int);
            retval.Direction = System.Data.ParameterDirection.ReturnValue;
            //adding the parameters for stored procedures from the form
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
            //opening the connection and executing the stored procedure
            cmd.ExecuteNonQuery();
            //closing the connection
            con.Close();
            //storing the return value from the stored procedure as confirmation id
            int confirmationid= (int)retval.Value;
            //passing the confirmation id to the reservationconfirmation page as query string
            Response.Redirect("reservationconfirmation.aspx?confirm=" + confirmationid);
        }
    }
}