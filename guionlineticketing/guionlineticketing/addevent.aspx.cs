using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace guionlineticketing
{
    public partial class addevent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddevent_Click(object sender, EventArgs e)
        {
            DateTime date = caldate.SelectedDate;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string query = string.Format("insert into eventtable (eventname,eventcategory,auditoriumid,eventdate,eventtime,noofseats,fare)  values('{0}','{1}',{2},'{3}','{4}',{5},{6})", txteventmane.Text, ddlcategory.SelectedItem.Text, ddllocation.SelectedItem.Value, date.ToString("yyyy-MM-dd"), txttime.Text,txtnoofseats.Text,txtfare.Text);
            //string query1 = string.Format("update tblstudents set name='" + txtname.Text + "',pass='" + txtnewpass.Text + "',brid=" + ddlbranch.SelectedItem.Value + ",semester='" + ddlsemster.SelectedItem.Text + "',secid=" + ddlquestion.SelectedItem.Value + ",secans='" + txtsecans.Text + "',gender='" + ddlgender.SelectedItem.Text + "',email='" + txtemail.Text + "',phno='" + txtphonenumber.Text + "',dob='" + txtdob.Text + "',photo='photos/" + fupphoto.FileName + "',registered='1'  where sid=" + Session["UserName"]);
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            con.Open();
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
        }

        protected void imageupload_Load(object sender, EventArgs e)
        {
            if (imageupload.HasFile)
            {
                imageupload.PostedFile.SaveAs(Server.MapPath("~/images/" + imageupload.FileName));


            }
        }
    }
}