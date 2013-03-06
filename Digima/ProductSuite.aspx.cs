using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Web.UI.WebControls;
using DigiMa.Common;

namespace DigiMa
{
    public partial class ProductSuite : System.Web.UI.Page
    {
        CanvasBizProcess canvBiz = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void learnCampaign_Click(object sender, EventArgs e)
        {
            Response.Redirect("LearnMoreCampaignBuilder.aspx");
        }

        protected void learnAnalytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("LearnMoreAnalytics.aspx");
        }

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            SessionData.Customer = null;
            SessionData.Config = null;
            SessionData.Product = null;

            Session.Abandon();
            Response.Redirect("Home.aspx");
        }
    }
}