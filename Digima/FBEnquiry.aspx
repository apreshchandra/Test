<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="FBEnquiry.aspx.cs" Inherits="DigiMa.FBEnquiry" %>

<style type="text/css">
    .snBBBody
    {
        width: 380px;
        border: 0px solid Red;
    }
    .defaultPageStyle
    {
        font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
        font-size: 11px;
        border: 1px solid black;
        width: 100%;
        background-color: #d5e7f5;
    }
    .defaultFacebookButtonGeorgiaAquarium
    {
        background-image: url("../images/tab_1.png");
        background-position: 0 0;
        background: #0066cc;
        border-color: #000000;
        border-width: 2px;
        color: #fff;
        cursor: pointer;
        padding: 7px 7px;
        font-size: 11px;
        font-family: Segoe UI,Tahoma,Arial,Verdana,sans-serif;
        -moz-border-radius: 2px;
        -webkit-border-radius: 2px;
        -khtml-border-radius: 2px;
        text-decoration: none;
        text-align: justify;
        font-weight: bold;
        padding-left: 7px;
        padding-right: 7px;
        padding-top: 7px;
        padding-bottom: 7px;
        border: 1px solid #fff;
        border-radius: 4px;
    }
    .defaultFacebookButtonGeorgiaAquariumCancelButtonLink
    {
        background-position: 0 0;
        background: #E3CF57;
        border-color: #000000;
        border-width: 2px;
        color: #000080;
        cursor: pointer;
        font-size: 12px;
        font-family: Tahoma;
        text-decoration: none;
        text-align: justify;
        font-weight: bold;
        padding-left: 6px;
        padding-right: 6px;
        padding-top: 3px;
        padding-bottom: 3px;
        height: 40px;
    }
    .defaultPostContetPageStyle
    {
        font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
        font-size: 11px;
        border: 0px solid black;
        width: 360px;
    }
    
    .defaultSeeAllProductsStyle
    {
        width: 100%;
        background-color: #3B5998;
        color: White;
        padding: 5px;
        font-size: 14px;
        font-weight: bold;
    }
    .ActionLinks
    {
        float: right;
        padding-bottom: 5px;
    }
    .defaultFacebookButton
    {
        background-position: 0 0;
        background: #923030 none repeat scroll 0 0;
        border-color: #3B5998 #5973A9;
        border-style: solid;
        border-width: 1px;
        color: #FFFF00;
        cursor: pointer;
        font-size: 13px;
        font-family: Tahoma;
        text-decoration: none;
        padding-left: 6px;
        padding-right: 6px;
        padding-top: 3px;
        padding-bottom: 3px;
    }
    .defaultHeadingLabelStyle
    {
        background-color: #D2D9E6;
        color: #3B5998;
        padding: 5px;
        font-size: 12px;
    }
    .defaultActionButtonsContentStyle
    {
        border-top: 1px solid #D2D9E6;
        height: 34px;
        text-align: right;
        padding-right: 5px;
    }
    .defaultFacebookButton
    {
        background-position: 0 0;
        background: #923030 none repeat scroll 0 0;
        border-color: #3B5998 #5973A9;
        border-style: solid;
        border-width: 1px;
        color: #FFFF00;
        cursor: pointer;
        font-size: 13px;
        font-family: Tahoma;
        text-decoration: none;
        padding-left: 6px;
        padding-right: 6px;
        padding-top: 3px;
        padding-bottom: 3px;
    }
    .defaultPostTextTitleStyle
    {
        color: #3B5998;
        font-weight: bold;
    }
    .defaultPostTextCaptionStyle
    {
        color: #808080;
    }
    .defaultPostTextContentStyle
    {
        color: #808080;
        text-align: justify;
    }
    .defaultTextBoxStyle
    {
        width: 100%;
    }
    .defaultLabelStyle
    {
        width: 80px;
        vertical-align: top;
        font-size: 11px;
        padding-left: 5px;
        padding-top: 5px;
    }
    .defaultValueStyle
    {
        padding-top: 5px;
    }
    .defaultErrorMessage
    {
        color: Red;
        font-size: 11px;
    }
</style>
<script type="text/javascript">
    function CloseMe() {
        window.close();
        return false;
    }
</script>
<form name="frmPostToFriendsWall" id="frmPostToFriendsWall" runat="server" method="post"
style="background-color: Black;">
<asp:placeholder id="plcMainContent" runat="server">
<div style="background-image: url('Images/Post_BG.png');" id="mainBody">
<div style="background-color:Black;" >
                <img src="images/logo.png" border="0" alt="SonetReach" /></div>
<table class="defaultPageStyle" cellpadding="0" cellspacing="0">
    <tr><td colspan="2" class="defaultSeeAllProductsStyle">Product Inquiry</td></tr>
    <tr runat="server" id="trErrorMsg"><td colspan="2"><asp:Label runat="server" ID="lblValidationSummary" CssClass="defaultErrorMessage"></asp:Label></td></tr>
    <tr><td colspan="2" class="defaultHeadingLabelStyle defaultSelectYourFriendStyle">Personal information</td></tr>
    <tr>
        <td class="defaultLabelStyle">From Email :</td>
        <td class="defaultValueStyle"><asp:TextBox ID="txtLeadEmailID" runat="server" CssClass="defaultTextBoxStyle"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="defaultLabelStyle">Subject :</td>
        <td class="defaultValueStyle"><asp:TextBox ID="txtLeadContext" TextMode="MultiLine" Rows="1" runat="server" CssClass="defaultTextBoxStyle"></asp:TextBox></td>
    </tr>
    <tr>
        <td class="defaultLabelStyle">Content :</td>
        <td class="defaultValueStyle"><asp:TextBox ID="txtLeadContent" TextMode="MultiLine" Rows="4" runat="server" CssClass="defaultTextBoxStyle"></asp:TextBox></td>
    </tr>
    <tr><td colspan="2" class="defaultPostToWallContentStyle"><asp:Label ID="lblProductSummary" runat="server"></asp:Label></td></tr>
    <tr>
        <td colspan="2" class="defaultActionButtonsContentStyle">
            <asp:Button CssClass="defaultFacebookButtonGeorgiaAquarium" ID="BtnSubmit" runat="server" Text="Submit & Close" />
            <input type="button" id="BtnCancel" onclick="CloseMe()" value="Cancel" class="defaultFacebookButtonGeorgiaAquarium"/>
            <%--<a href="#" class="defaultFacebookButtonGeorgiaAquariumCancelButtonLink" id="BtnCancel" onclick="javascript:window.close(); return false;">Cancel</a>--%>
        </td>
    </tr>
</table>
</div>
</asp:placeholder>
</form>
