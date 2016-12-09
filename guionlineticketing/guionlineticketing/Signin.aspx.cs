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
    public partial class Signin : System.Web.UI.Page
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

                Response.Redirect("index.aspx");
            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((Button)Master.FindControl("btn_register")).Visible = true;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                ((Button)Master.FindControl("btnlogout")).Visible = false;
            }
            //setting the message lable to empty
            lblmsg.Text = null;

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //event fires on login button click
            //instance of a connection to connect to SQL server
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //Query to get the username and password with the user input data
            string query = string.Format("select * from usertable where id='{0}' and password='{1}'", txtusername.Text, txtpassword.Text);
            //sql command using the cconnection and query
            SqlCommand cmd = new SqlCommand(query, con);
            //opening the connection executing the query and saving
            //the data in the sql datareaader 
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string admin = "admin";
            if (dr.HasRows)
            {
                //if the user with the input exist save his data in the session and 
                //redirecting him to index page 
                dr.Read();
                string name = dr["username"].ToString();
                Session["Name"] = name;
                string id = dr["id"].ToString();
                //storing the data in the session variable
                Session["UserID"] = id;
                //if he is an admin redirect him to adminindex.aspx page
                if (Session["UserID"].ToString() == "admin")
                {
                    Response.Redirect("adminindex.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                //setting the message if the user does not exist with the input provided
                lblmsg.Text = "username or password is invalid please try again";
            }
            
        }

      
    }
}