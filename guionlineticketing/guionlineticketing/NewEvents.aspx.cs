using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class NewEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        

        
        protected void btnview_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int eventid = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("events.aspx?event="+eventid);
        }

       
    }
}