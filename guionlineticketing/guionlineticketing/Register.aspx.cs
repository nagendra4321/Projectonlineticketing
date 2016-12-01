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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                ((Button)Master.FindControl("btn_signin")).Visible = true;
                ((Button)Master.FindControl("btn_register")).Visible = false;
                ((HyperLink)Master.FindControl("username")).Visible = false;
                ((Button)Master.FindControl("btnlogout")).Visible = false;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["onlineticketingConnectionString"].ConnectionString);
            string query = string.Format("insert into usertable (id,password,username,dob,gender,securityquestion,securityanswer,address,email,phonenum)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", txtid.Text, txtnewpass.Text,txtname.Text,txtdob.Text, ddlgender.SelectedItem.Value, ddlquestion.SelectedItem.Value,txtsecans.Text, txtaddress.Text, txtemail.Text, txtphonenumber.Text);
            SqlCommand cmdsubmit = new SqlCommand(query, con);
            con.Open();
            int i = cmdsubmit.ExecuteNonQuery();
            con.Close();
        }
    }
}