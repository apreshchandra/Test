using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Text;
using DigiMa.BizProcess;
using DigiMa.Data;
using DigiMa.Common;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class FBEnquiry : DigiMa.sNBBPage
    {
        private AppProduct _oAppProduct;
        protected PlaceHolder plcSuccessContent;
        FacebookBizProcess fbBizProc = new FacebookBizProcess();
        AppUser oDCAppUser = new AppUser();
        AppProduct oAppProduct = new AppProduct();
        string custTabName;

        protected override void OnInit(EventArgs e)
        {
            HideBranding = true;
            EnableAppUser = true;
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //Initialize API Core
            FaceBook oFacebook = new FaceBook();

            //Initialize KOKO
            SonetPie osonetpie = new SonetPie();
            QSVars.Add("NTYP", "LEAD");
            osonetpie.QSvarsString = GetQsVarsCollection();
            osonetpie.AbsolutePath = AbsolutePagePath;

            //Load app settings

            oDCAppUser = fbBizProc.GetAppUser(osonetpie, QSVars["ADID"].ToString(), QSVars["user_id"].ToString());


            oAppProduct = fbBizProc.GetAppProductDetails(osonetpie, QSVars["PDID"].ToString());

            //get Inquiry Email if exists
            //fetch Inmquiry EMAIL data
            string inquiryEmail;
            inquiryEmail = fbBizProc.GetInquiryEmail(Convert.ToString(QSVars["ADID"]));

            //Bind Post content at runtime
            if (oAppProduct.DID.Equals("AP006KV63YSPT0ZDHTMD"))
            {
                txtLeadContent.Text = "I am interested to know more on this event.";
            }
            else if (oAppProduct.DID.Equals("AP000CH69W22X9KDGZTT") || oAppProduct.DID.Equals("AP001CS762FRSC4BPCV3") || oAppProduct.DID.Equals("AP005S976CL8C85Y2HV5") || oAppProduct.DID.Equals("AP002PX605GMMMG9MQ59"))
            {
                txtLeadContent.Text = "I am interested to know more on this product.";
            }
            lblProductSummary.Text = GetProductSummary();

            //Prefill product context
            if (oAppProduct != null)
            {
                if (oAppProduct.DID.Equals("AP006KV63YSPT0ZDHTMD"))
                {
                    txtLeadContext.Text = oAppProduct.ProductName + " event inquiry";
                }
                else if (oAppProduct.DID.Equals("AP000CH69W22X9KDGZTT") || oAppProduct.DID.Equals("AP001CS762FRSC4BPCV3") || oAppProduct.DID.Equals("AP005S976CL8C85Y2HV5") || oAppProduct.DID.Equals("AP002PX605GMMMG9MQ59"))
                {
                    txtLeadContext.Text = oAppProduct.ProductName + " product inquiry";
                }
            }
            else
                txtLeadContext.Text = "product inquiry";

            //Prefill Email id
            if (!string.IsNullOrEmpty(inquiryEmail)) txtLeadEmailID.Text = oDCAppUser.EmailID;

            //Clear Error text
            lblValidationSummary.Text = string.Empty;

            //Perform Post to wall friends & Store notifierDID stat
            if (this.IsPostBack && oAppProduct != null && AppCustomer != null && AppConfig != null)
            {
                if (FormVars.Contains("BtnSubmit"))
                {
                    if (Convert.ToString(FormVars["txtLeadEmailID"]).Trim().Length <= 0) Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Specify email id.\")", true);
                    else if (Convert.ToString(FormVars["txtLeadContext"]).Trim().Length <= 0) lblValidationSummary.Text = "Specify email subject.";
                    else if (Convert.ToString(FormVars["txtLeadContent"]).Trim().Length <= 0) lblValidationSummary.Text = "Specify email content.";
                    else
                    {
                        AppLeadData oAppLeadData = new AppLeadData();
                        oAppLeadData.EmailID = Convert.ToString(FormVars["txtLeadEmailID"]);
                        oAppLeadData.Subject = Convert.ToString(FormVars["txtLeadContext"]);
                        oAppLeadData.Body = Convert.ToString(FormVars["txtLeadContent"]);
                        string _sNotifierDID = new AppNotifier().GetNewDIDWithPrefix();
                        if (QSVars.Contains("NDID"))
                            QSVars["NDID"] = _sNotifierDID;
                        else
                            QSVars.Add("NDID", _sNotifierDID);
                        if (fbBizProc.RaiseAppNotifier(oDCAppUser, "LEAD", QSVars["UDID"].ToString(), QSVars["PDID"].ToString(), QSVars["NDID"].ToString(), oAppLeadData, string.Empty))
                        {
                            //Now send email
                            CommonUtility comUtil = new CommonUtility();
                            custTabName = fbBizProc.GetCustomTabName(Convert.ToString(QSVars["app_id"]));                            
                            comUtil.SendEnquiryMail(inquiryEmail, oAppLeadData.Subject, oAppLeadData.Body, custTabName, oAppProduct,oDCAppUser.EmailID);

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
                        }
                    }
                }
            }

            //Set error message section
            if (!string.IsNullOrEmpty(lblValidationSummary.Text)) trErrorMsg.Visible = true; else trErrorMsg.Visible = false;
        }

        private string GetProductSummary()
        {
            StringBuilder oSBProductSummary = new StringBuilder();

            if (AppCustomer != null && _oAppProduct != null)
            {
                oSBProductSummary.Append("<table class=\"defaultPostContetPageStyle\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\"><tr>");
                oSBProductSummary.Append("<td width=\"80px\"><img src=\"https://www.testsonetreach.com/Images/newlogo_200x100.png\"/></td>");
                oSBProductSummary.Append("<td><span class=\"defaultPostTextTitleStyle\">" + fbBizProc.GetCustomTabName(QSVars["app_id"].ToString()) + "</span> <br />");
                oSBProductSummary.Append("<span class=\"defaultPostTextCaptionStyle\">" + " " + "</span><br />");
                oSBProductSummary.Append("<span class=\"defaultPostTextContentStyle\">" + oAppProduct.ProductShortDesc + "</span>");
                oSBProductSummary.Append("</td></tr></table>");
            }
            return oSBProductSummary.ToString();
        }

    }
}