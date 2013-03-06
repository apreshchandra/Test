using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigiMa.BizProcess;
using System.Data;
using DigiMa.Common;

namespace DigiMa
{
    public partial class SweepstakesWinners : System.Web.UI.Page
    {
        CommonUtility commonUtil = new CommonUtility();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ADID = Convert.ToString(Request["ADID"]);
            CanvasBizProcess canvBiz = new CanvasBizProcess();

            //Check if Winners are declared. If then show else insert
            if (!canvBiz.IsSweepWinnerDeclared(ADID) == true)
            {

                //Get Winners depending on no of winners chosen

                string WinnerCount = canvBiz.GetSweepWinnersCount(ADID);
                DataSet dtSweepWinners = new DataSet();
                dtSweepWinners = canvBiz.GetSweepWinners(Convert.ToInt32(WinnerCount), ADID);
                rptSweepWinners.DataSource = dtSweepWinners;
                rptSweepWinners.DataBind();

            }
            else
            {
                //Get Random winners on basis of WinnerCount
                DataSet dtSweepWinners = new DataSet();
                dtSweepWinners = canvBiz.ShowSweepstakesWinner(ADID);
                rptSweepWinners.DataSource = dtSweepWinners;
                rptSweepWinners.DataBind();
            }

        }

        protected void rptSweepWinners_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    // Retrieve the Literal control in the current DataListItem.
                    Label lblCount = (Label)e.Item.FindControl("lblCount");
                    lblCount.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString();

                    Image imgThumb = (Image)e.Item.FindControl("imgThumb");
                    imgThumb.ImageUrl = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();

                    Label lblName = (Label)e.Item.FindControl("lblName");
                    lblName.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString();

                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }
    }
}