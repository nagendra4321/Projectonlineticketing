using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace guionlineticketing
{
    public partial class events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eventid = Request.QueryString["event"];
        }

        protected void btnreserve_Click(object sender, EventArgs e)
        {
            Response.Redirect("reservation.aspx");
        }
    }
}