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
        }
    }
}