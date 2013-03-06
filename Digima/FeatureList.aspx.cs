using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.Common;

namespace DigiMa
{
    public partial class FeatureList : System.Web.UI.Page
    {
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