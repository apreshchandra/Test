using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMa.BizProcess;
using System.Web.UI;
using DigiMa.Common;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class PreviewApp : System.Web.UI.Page
    {
        string PDID = string.Empty;
        string CDID = string.Empty;
        string TDID = string.Empty;
        private const string TRUE = "Y";
        string likeWork = string.Empty;
        string shareWork = string.Empty;
        string leadWork = string.Empty;
        string postWork = string.Empty;
        string commWork = string.Empty;
        string captionWork = string.Empty;
        string printWork = string.Empty;
        string emailWork = string.Empty;
        string twitterWork = string.Empty;
        private const string NO_PREVIEW = "No Preview Available";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request["TDID"].ToString()))
                    {
                        TDID = Request["TDID"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["PDID"].ToString()))
                    {
                        PDID = Request["PDID"].ToString();
                    }
                    if (!string.IsNullOrEmpty(Request["CDID"].ToString()))
                    {
                        CDID = Request["CDID"].ToString();
                    }



                    FacebookBizProcess fbBiz = new FacebookBizProcess();

                    //Fetch Product Info to show Selected Widgets during Preview
                    string tempTEMPLATE = fbBiz.GetPreviewProduct(PDID).Rows[0]["ProductHTML"].ToString();



                    if (!tempTEMPLATE.Equals(NO_PREVIEW)) //Check if Preview is available
                    {
                        //SHARE, LIKE, INQUIRY
                        if (SessionData.Product.LikeWidgetAdded.Equals(TRUE))
                        {
                            likeWork = tempTEMPLATE.Replace("Like", "<input id=\"LikeButton\" type=\"button\"  disabled=\"disabled\">");
                        }
                        else
                        {
                            likeWork = tempTEMPLATE.Replace("Like", "");
                        }
                        if (SessionData.Product.ShareWidgetAdded.Equals(TRUE))
                        {
                            shareWork = likeWork.Replace("ShButton", "<input id=\"ShareButton\" type=\"button\"  disabled=\"disabled\">");
                        }
                        else
                        {
                            shareWork = likeWork.Replace("ShButton", "");
                        }
                        if (SessionData.Product.InquiryWidgetAdded.Equals(TRUE))
                        {
                            leadWork = shareWork.Replace("Lead", "<input id=\"LeadButton\" type=\"button\" disabled=\"disabled\">");
                        }
                        else
                        {
                            leadWork = shareWork.Replace("Lead", "");
                        }
                        if (SessionData.Product.TwitterWidgetAdded.Equals(TRUE))
                        {
                            twitterWork = leadWork.Replace("TwButton", "<input id=\"TwiButton\" type=\"button\" disabled=\"disabled\">");
                        }
                        else
                        {
                            twitterWork = leadWork.Replace("TwButton", "");
                        }



                        //RECOMMEND
                        if (SessionData.Product.ReccWidgetAdded.Equals(TRUE))
                        {
                            if (TDID == "3")
                            {
                                postWork = twitterWork.Replace("ReButton", "<input id=\"ReccoButton\" type=\"button\" disabled=\"disabled\">");
                            }
                            else if (TDID == "5")
                            {
                                postWork = twitterWork.Replace("ReButton", "<input id=\"ReccoButton\" type=\"button\" disabled=\"disabled\">");
                            }
                            else if (TDID == "6")
                            {
                                postWork = twitterWork.Replace("ReButton", "<input id=\"ReccoButton\" type=\"button\" disabled=\"disabled\">");
                            }
                            else if (TDID == "4")
                            {
                                postWork = twitterWork.Replace("ReButton", "<input id=\"ReccoButton\" type=\"button\" disabled=\"disabled\">");
                            }
                        }
                        else
                        {
                            postWork = twitterWork.Replace("ReButton", "");
                        }

                        //COMMENTS
                        if (SessionData.Product.CommentsWidgetAdded.Equals(TRUE))
                        {
                            commWork = postWork.Replace("CommBox", "<img id=\"imgComment\" alt=\"\" src=\"Images/fb-comment_Preview.jpg\">");
                        }
                        else
                        {
                            commWork = postWork.Replace("CommBox", "");
                        }


                        //CAPTION
                        if (!string.IsNullOrEmpty(SessionData.Product.AppCaption))
                        {
                            captionWork = commWork.Replace("Caption", SessionData.Product.AppCaption);
                        }
                        else
                        {
                            captionWork = commWork.Replace("Caption", "");
                        }

                        if (TDID == "7")
                        {
                            printWork = captionWork.Replace("Print", "<input id=\"printButton\" type=\"button\" disabled=\"disabled\">");
                            emailWork = printWork.Replace("Email", "<input id=\"emailButton\" type=\"button\" disabled=\"disabled\">");
                        }



                        //Finally, render the preview
                        litPreview.Text = captionWork;
                    }
                    else
                    {
                        litPreview.Text = NO_PREVIEW;
                    }

                }
            }
            catch (Exception ex)
            {
                CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }

        }

        protected void btnCancelPreview_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "parent.closeModalExtender();", true);
        }
    }
}