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
            
            if (rblchoice.SelectedItem.Value == "location")
            {
                tbllocation.Visible = true;
                tblcategory.Visible = false;
            }
            if (rblchoice.SelectedItem.Value == "category")
            {
                tbllocation.Visible = false;
                tblcategory.Visible = true;
            }
        }

      

        protected void rblchoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rblchoice.SelectedItem.Value=="location")
            {
                tbllocation.Visible = true;
                tblcategory.Visible = false;
            }
            if (rblchoice.SelectedItem.Value == "category")
            {
                tbllocation.Visible = false;
                tblcategory.Visible = true;
            }
        }

        protected void btnaddlocation_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string query = string.Format("insert into auditoriumtable (auditoriumname,noseats,address)  values('{0}',{1},'{2}')", txtlocationname.Text,txtnoofseats.Text,txtlocationaddress.Text );
            //string query1 = string.Format("update tblstudents set name='" + txtname.Text + "',pass='" + txtnewpass.Text + "',brid=" + ddlbranch.SelectedItem.Value + ",semester='" + ddlsemster.SelectedItem.Text + "',secid=" + ddlquestion.SelectedItem.Value + ",secans='" + txtsecans.Text + "',gender='" + ddlgender.SelectedItem.Text + "',email='" + txtemail.Text + "',phno='" + txtphonenumber.Text + "',dob='" + txtdob.Text + "',photo='photos/" + fupphoto.FileName + "',registered='1'  where sid=" + Session["UserName"]);
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            con.Open();
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
            lblmsglocation.Text = "Location " + txtlocationname.Text.ToString() + " has been succesfully added to database";
            txtlocationname.Text = null;
            txtnoofseats.Text = null;
            txtlocationaddress.Text = null;
        }

        protected void btnaddcategory_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string query = string.Format("insert into eventcategory (categoryname)  values('{0}')", txtcategory.Text);
            //string query1 = string.Format("update tblstudents set name='" + txtname.Text + "',pass='" + txtnewpass.Text + "',brid=" + ddlbranch.SelectedItem.Value + ",semester='" + ddlsemster.SelectedItem.Text + "',secid=" + ddlquestion.SelectedItem.Value + ",secans='" + txtsecans.Text + "',gender='" + ddlgender.SelectedItem.Text + "',email='" + txtemail.Text + "',phno='" + txtphonenumber.Text + "',dob='" + txtdob.Text + "',photo='photos/" + fupphoto.FileName + "',registered='1'  where sid=" + Session["UserName"]);
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            con.Open();
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
            lblmsgcategory.Text = "category " + txtcategory.Text.ToString() + " succesfully added to database";
            txtcategory.Text = null;
        }
    }
}