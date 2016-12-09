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
    public partial class addlocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to show the appropriate buttons for the admin if he is logged in it shows profile info and logout
            ((Button)Master.FindControl("btn_register")).Visible = false;
            if (Session["UserID"] != null && Session["UserID"].ToString() == "admin")
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Text = Session["UserId"].ToString();
                ((Button)Master.FindControl("btnlogout")).Visible = true;
            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                ((Button)Master.FindControl("btnlogout")).Visible = false;
                Response.Redirect("Signin.aspx");
            }
            //if the user selects the radio button add location show table location
            if (rblchoice.SelectedItem.Value == "location")
            {
                tbllocation.Visible = true;
                tblcategory.Visible = false;
            }
            //if the user selects the radio button add category show table category
            if (rblchoice.SelectedItem.Value == "category")
            {
                tbllocation.Visible = false;
                tblcategory.Visible = true;
            }
        }

      

        protected void rblchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if the user selects the radio button add location show table location
            if (rblchoice.SelectedItem.Value=="location")
            {
                tbllocation.Visible = true;
                tblcategory.Visible = false;
            }
            //if the user selects the radio button add category show table category
            if (rblchoice.SelectedItem.Value == "category")
            {
                tbllocation.Visible = false;
                tblcategory.Visible = true;
            }
        }

        protected void btnaddlocation_Click(object sender, EventArgs e)
        {
            //creating the instance of sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //sql query to add a new location
            string query = string.Format("insert into auditoriumtable (auditoriumname,noseats,address)  values('{0}',{1},'{2}')", txtlocationname.Text,txtnoofseats.Text,txtlocationaddress.Text );
            //sql command to execute the query
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            //opening the connection
            con.Open();
            //execcuting the query
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
            //displaying message to the user  about the succesfull addition and deleting data from controls
            lblmsglocation.Text = "Location " + txtlocationname.Text.ToString() + " has been succesfully added to database";
            txtlocationname.Text = null;
            txtnoofseats.Text = null;
            txtlocationaddress.Text = null;
        }

        protected void btnaddcategory_Click(object sender, EventArgs e)
        {
            //creating the instance of sql connection
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            //sql query to add a new category
            string query = string.Format("insert into eventcategory (categoryname)  values('{0}')", txtcategory.Text);
            //sql command to execute the query
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            //opening the connection
            con.Open();
            //execcuting the query
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
            //displaying message to the user  about the succesfull addition and deleting data from control
            lblmsgcategory.Text = "category " + txtcategory.Text.ToString() + " succesfully added to database";
            txtcategory.Text = null;
        }
    }
}