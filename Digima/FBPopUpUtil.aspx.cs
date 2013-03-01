using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class FBPopUpUtil : System.Web.UI.Page
    {
        string contentType;
        string appconfigDID;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //get the content to show
            if (Request["Typ"] != null)
            {
                contentType = Request["Typ"].ToString();
            }

            if (Request["Loader"] != null)
            {
                appconfigDID = Request["Loader"].ToString();
            }

            CanvasBizProcess canvBiz = new CanvasBizProcess();
            string dataToShow= canvBiz.FetchSweepStakeUtilData(appconfigDID, contentType);
            if (dataToShow == "")
            {
                litFBData.Text = "No Data to Show !"; 
            }
            else
            {
                litFBData.Text = dataToShow;
            }
        }
    }
}