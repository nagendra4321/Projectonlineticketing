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
            lblmsg.Text = null;

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string query = string.Format("select * from usertable where id='{0}' and password='{1}'", txtusername.Text, txtpassword.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string admin = "admin";
            if (dr.HasRows)
            {
                dr.Read();
                string name = dr["username"].ToString();
                Session["Name"] = name;
                string id = dr["id"].ToString();
                Session["UserID"] = id;
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
                lblmsg.Text = "username or password is invalid please try again";
            }
            //if (Session["UserID"].ToString() == admin)
            //{
            //    Response.Redirect("index.aspx");
            //}
            //else
            //{
            //    Response.Redirect("index.aspx");
            //}

        }

      
    }
}