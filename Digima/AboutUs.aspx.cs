using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;
using DigiMa.Common;

namespace Digima
{
    public partial class AboutUs : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionData.Customer != null)
            {
                if (Request.QueryString["CDID"] == string.Empty)
                {
                    string newurl = Request.RawUrl;
                    newurl = newurl.Replace("?CDID=", "");
                    Response.Redirect(newurl);
                }
            }
        }
       
    }
}
