using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DigiMa.Common;

namespace DigiMa
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        HtmlTableRow OnlyLoginShow = new HtmlTableRow();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserData"] != null)
                    OnlyLoginShow.Visible = true;
                else
                    OnlyLoginShow.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
