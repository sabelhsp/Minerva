using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minerva
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieName = new HttpCookie("UserName");
            cookieName = Request.Cookies["UserName"];
            if (cookieName != null)
            {
                labelWelcome.Text = "Welcome, " + cookieName.Value;
            }
            
        }
    }
}