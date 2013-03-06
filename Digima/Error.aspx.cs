using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RawUrl != null)
            {
                if (Request.RawUrl.Contains("NewPost.aspx"))
                {
                    backDiv.Visible = false;
                }
                if (Request.RawUrl.Contains("CreateApp.aspx"))
                {
                    backDiv.Visible = false; 
                }
            }
        }
    }
}