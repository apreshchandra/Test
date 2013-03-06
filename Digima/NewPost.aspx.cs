using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.HtmlControls;
using DigiMa.BizProcess;
using System.Text;
using DigiMa.Data;
using DigiMa.Common;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class NewPost : DigiMa.sNBBPage
    {
        //protected Repeater rptAllFriends;
        DataTable oFriendsTable = new DataTable();
        DataTable oFriendsLocationTable = new DataTable();
        DataTable oFriendsGenderTable = new DataTable();
        DataView dvData;
        SonetPie osonetpie = new SonetPie();
        //protected HtmlTextArea txtCustomPostMessage;
        //protected Label lblProductSummary;
        private AppProduct _oDCAppProduct;
        AppWallPost _oDCAppWallPost = new AppWallPost();
        FacebookBizProcess fbBizProc = new FacebookBizProcess();
        CommonUtility commonUtil = new CommonUtility();

        protected override void OnInit(EventArgs e)
        {
            HideBranding = true;
            EnableAppUser = true;
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                base.OnPreRender(e);
                DigiMa.Common.FaceBook oFBUtility = new DigiMa.Common.FaceBook();
                if (!IsPostBack)
                {
                    //Initialize API Core


                    //Call Getfriends call
                    DataTable oFriendsTable = new DataTable("FriendsTable");
                    DataColumn osoNETID = new DataColumn("soNETID");
                    oFriendsTable.Columns.Add(osoNETID);
                    DataColumn oImage = new DataColumn("Image");
                    oFriendsTable.Columns.Add(oImage);
                    DataColumn oName = new DataColumn("Name");
                    oFriendsTable.Columns.Add(oName);
                    DataColumn oLocation = new DataColumn("Location");
                    oFriendsTable.Columns.Add(oLocation);
                    DataColumn oGender = new DataColumn("Gender");
                    oFriendsTable.Columns.Add(oGender);
                    oFriendsTable = oFBUtility.GetFriendsDetail(Convert.ToString(QSVars["user_id"]), Convert.ToString(QSVars["oauth_token"]));



                    if (oFriendsTable != null)
                    {
                        //Get All Locations

                        var distinctLocations = (from row in oFriendsTable.AsEnumerable()
                                                 select row.Field<string>("Location")).Distinct();

                        foreach (string val in distinctLocations)
                        {
                            if (val != null)
                            {
                                ddlLocation.Items.Add(new ListItem(val, val));
                            }
                        }
                        Cache["FriendsDataTable"] = oFriendsTable;

                        //Bind DataSource of repeator control
                        rptAllFriends.DataSource = oFriendsTable;
                        rptAllFriends.DataBind();
                    }
                }

                //Initialize KOKO

                QSVars.Add("NTYP", "POST");
                osonetpie.QSvarsString = GetQsVarsCollection();
                osonetpie.AbsolutePath = AbsolutePagePath;

                //Call Service to load app settings

                _oDCAppProduct = fbBizProc.GetAppProductDetails(osonetpie, QSVars["PDID"].ToString());


                //Bind Post content at runtime
                if (_oDCAppProduct.DID.Equals("AP006KV63YSPT0ZDHTMD") || _oDCAppProduct.DID.Equals("AP001HC61GZN1739G4V2"))
                {

                }
                else if (_oDCAppProduct.DID.Equals("AP000CH69W22X9KDGZTT") || _oDCAppProduct.DID.Equals("AP001CS762FRSC4BPCV3") || _oDCAppProduct.DID.Equals("AP005S976CL8C85Y2HV5") || _oDCAppProduct.DID.Equals("AP002PX605GMMMG9MQ59"))
                {

                }
                else
                {

                }


                //Perform Post to wall friends & Store notifierDID stat
                if (this.IsPostBack && _oDCAppProduct != null && AppCustomer != null && AppConfig != null)
                {

                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), Convert.ToString(QSVars["UDID"]));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            BtnPost.Attributes.Add("onClick", "javascript:FireOnPost();");
        }

        public void ddlLocationOnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //get the selected Location and filter the friends List
                if (oFriendsTable.Rows.Count == 0)
                {
                    dvData = new DataView((DataTable)Cache["FriendsDataTable"]);
                    if (ddlLocation.SelectedValue.Equals("All"))
                    {
                        //Show all Friends for No Filter
                        rptAllFriends.DataSource = oFriendsTable;
                    }
                    else
                    {
                        if (ddlGender.SelectedValue.Equals("All"))
                        {
                            dvData.RowFilter = "Location = '" + ddlLocation.SelectedValue + "'";
                        }
                        else
                        {
                            dvData.RowFilter = "Location = '" + ddlLocation.SelectedValue + "' and Gender='" + ddlGender.SelectedValue + "'";
                        }
                    }
                    rptAllFriends.DataSource = dvData;
                    rptAllFriends.DataBind();
                }
                else
                {
                    //take from cache
                    dvData = new DataView(oFriendsTable);
                    if (ddlLocation.SelectedValue.Equals("All"))
                    {
                        //Show all Friends for No Filter
                        rptAllFriends.DataSource = oFriendsTable;
                    }
                    else
                    {
                        if (ddlGender.SelectedValue.Equals("All"))
                        {
                            dvData.RowFilter = "Location = '" + ddlLocation.SelectedValue + "'";
                        }
                        else
                        {
                            dvData.RowFilter = "Location = '" + ddlLocation.SelectedValue + "' and Gender='" + ddlGender.SelectedValue + "'";
                        }
                    }
                    rptAllFriends.DataSource = dvData;
                    rptAllFriends.DataBind();

                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }


        public void ddlGenderOnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Apply Filter
                if (oFriendsTable.Rows.Count == 0)
                {
                    //Now apply new filter on filtered data
                    dvData = new DataView((DataTable)Cache["FriendsDataTable"]);
                    if (ddlLocation.SelectedValue.Equals("All"))
                    {
                        //Show all Friends for No Filter
                        if (string.IsNullOrEmpty(ddlGender.SelectedValue))
                        {
                            rptAllFriends.DataSource = oFriendsTable;
                        }
                        else
                        {
                            dvData.RowFilter = "Gender = '" + ddlGender.SelectedValue + "'";
                        }
                    }
                    else
                    {
                        if (ddlLocation.SelectedValue.Equals("All"))
                        {
                            dvData.RowFilter = "Gender = '" + ddlGender.SelectedValue + "'";
                        }
                        else
                        {
                            dvData.RowFilter = "Gender = '" + ddlGender.SelectedValue + "'" + "and Location='" + ddlLocation.SelectedValue + "'";
                        }
                    }
                    rptAllFriends.DataSource = dvData;
                    rptAllFriends.DataBind();

                }
                else //Gender filter has been applied first
                {
                    dvData = new DataView(oFriendsTable);
                    if (ddlLocation.SelectedValue.Equals("All"))
                    {
                        //Show all Friends for No Filter
                        rptAllFriends.DataSource = oFriendsTable;
                    }
                    else
                    {
                        if (ddlLocation.SelectedValue.Equals("All"))
                        {
                            dvData.RowFilter = "Gender = '" + ddlGender.SelectedValue + "'";
                        }
                        else
                        {
                            dvData.RowFilter = "Gender = '" + ddlGender.SelectedValue + "'" + "and Location='" + ddlLocation.SelectedValue + "'";
                        }
                    }
                    rptAllFriends.DataSource = dvData;
                    rptAllFriends.DataBind();

                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        public void rptAllFriends_OnItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    // Retrieve the Literal control in the current DataListItem.
                    Image imgThumb = (Image)e.Item.FindControl("imgThumb");
                    imgThumb.ImageUrl = ((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString();

                    Label lblName = (Label)e.Item.FindControl("lblName");
                    lblName.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString();

                    Label lblLocation = (Label)e.Item.FindControl("lblLocation");
                    lblLocation.Text = ((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString();

                    HyperLink hlInvite = (HyperLink)e.Item.FindControl("hlInvite");
                    hlInvite.Attributes.Add("onclick", "return selectFriend(this, '" + ((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString() + "')");
                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        private string GetProductSummary()
        {
            StringBuilder oSBProductSummary = new StringBuilder();
            FacebookBizProcess fbBiz = new FacebookBizProcess();
            if (AppCustomer != null && _oDCAppProduct != null)
            {
                oSBProductSummary.Append("<table class=\"defaultPostContetPageStyle\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\"><tr>");
                oSBProductSummary.Append("<td width=\"80px\"><img src=\"https://www.testsonetreach.com/Images/newlogo_200x100.png\"/></td>");
                oSBProductSummary.Append("<td><span class=\"defaultPostTextTitleStyle\">" + fbBiz.GetCustomTabName(QSVars["app_id"].ToString()) + "</span> <br />");
                oSBProductSummary.Append("<span class=\"defaultPostTextCaptionStyle\">" + " " + "</span><br />");
                oSBProductSummary.Append("<span class=\"defaultPostTextContentStyle\">" + _oDCAppProduct.ProductShortDesc + "</span>");
                oSBProductSummary.Append("</td></tr></table>");
            }
            return oSBProductSummary.ToString();
        }


        public void defaultFacebookButton_OnClick(object sender, EventArgs e)
        {
            string[] sFriendList = Convert.ToString(FormVars["hidFriendsList"]).Split(new Char[] { ',' });
            if (!string.IsNullOrEmpty(sFriendList[0]))
            {
                StringBuilder oSBPageSElector = new StringBuilder();
                if (!FormVars.Contains("user_id"))
                {
                    FormVars.Add("user_id", QSVars["user_id"].ToString());
                }
                oSBPageSElector.Append("window.focus();window.open('https://www.facebook.com/dialog/apprequests?app_id=");
             oSBPageSElector.Append(QSVars["app_id"].ToString() + "&message=hello&from=" + QSVars["user_id"].ToString() + "&display=popup&to=" + Convert.ToString(FormVars["hidFriendsList"]) + "&redirect_uri=" + "https://www.sonetreach.com/CreateApp.aspx?app_id=" + QSVars["app_id"].ToString() + "\','name','height=270,width=460,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");
              //oSBPageSElector.Append(QSVars["app_id"].ToString() + "&message=hello&from=" + QSVars["user_id"].ToString() + "&display=popup&to=" + Convert.ToString(FormVars["hidFriendsList"]) + "&redirect_uri=" + "http://localhost/Digima/CreateApp.aspx?app_id=" + QSVars["app_id"].ToString() + "\','name','height=270,width=460,menubar=0,toolbar=0,statusbar=0,scrollbars=0,resizable=0');");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", oSBPageSElector.ToString(), true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "alert(\"Please select a friend !\")", true);
            }

        }
    }
}