<%@ Page Language="C#" AutoEventWireup="true" Inherits="DigiMa.SiteCreation" MasterPageFile="~/MasterPage.master"
    CodeBehind="~/SiteCreation.aspx.cs" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <script src="ScriptsSonetReach/jquery-1.5.1.js" type="text/javascript"></script>
    <%-- <script type="text/javascript">
        function pageLoad() {
            $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val("");
            if ($("#<%=hdnTemplatesImagePaths.ClientID%>").val() != null && $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val() == "") {
                var temp = new Array();
                temp = $("#<%=hdnTemplatesImagePaths.ClientID%>").val().split('~');
                document.getElementById('<%=imgPreveiw.ClientID%>').src = temp[0];
                $('#spanTemplateName').html($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[0].split('+')[0]);
                $("#<%=hdnCurrentTemplateId.ClientID%>").val($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[0].split('+')[1]);
                $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val(temp[0].split('/')[temp[0].split('/').length - 1]);
            }
        }
        function layout_next() {
            if ($("#<%=hdnTemplatesImagePaths.ClientID%>").val() != null) {
                var temp = new Array();
                temp = $("#<%=hdnTemplatesImagePaths.ClientID%>").val().split('~');
                for (var i = 0; i < temp.length - 1; i++) {
                    if (temp[i].split('/')[temp[i].split('/').length - 1] == $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val()) {
                        var x = i + 1;
//                        debugger;
//                        document.getElementById('<%=imgPreveiw.ClientID%>').src = temp[x];
                        $('#spanTemplateName').html($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[x].split('+')[0]);
                        $("#<%=hdnCurrentTemplateId.ClientID%>").val($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[x].split('+')[1]);
                    }
                }
                SetTemplatetoHidden();
            }
        }
        function layout_previous() {
            if ($("#<%=hdnTemplatesImagePaths.ClientID%>").val() != null) {
                var temp = new Array();
                temp = $("#<%=hdnTemplatesImagePaths.ClientID%>").val().split('~');
                for (var i = 1; i < temp.length; i++) {
                    if (temp[i].split('/')[temp[i].split('/').length - 1] == $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val()) {
                        var x = i - 1;
                        document.getElementById('<%=imgPreveiw.ClientID%>').src = temp[x];
                        $('#spanTemplateName').html($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[x].split('+')[0]);
                        $("#<%=hdnCurrentTemplateId.ClientID%>").val($("#<%=hdnTemplateNamesWithIds.ClientID%>").val().split('~')[x].split('+')[1]);
                    }
                }
                SetTemplatetoHidden();
            }
        }
        function SetTemplatetoHidden() {
            var x = document.getElementById('<%=imgPreveiw.ClientID%>').src.split('/');
            var y = x[document.getElementById('<%=imgPreveiw.ClientID%>').src.split('/').length - 1]; // x[document.getElementById('body_imgPreveiw').src.split('/').length - 2] +'/'+
            $("#<%=hdnSelectedTemplateImagePath.ClientID%>").val(y);
        }
    </script>--%>
    <style type="text/css">
        .logo
        {
            margin-bottom: 20px;
            margin-left: 164px;
            margin-top: -24px;
            padding: 22px 0 0 1px;
        }
        
        .previewborder
        {
            border: 1px solid #8f1315;
            margin: 0px 10px 0px 0px;
            
           
            
        }
        .mattblackmenu
        {
            left: 76px;
            position: absolute;
        }
        .menusubinsidepages
        {
            background: url("Images/submenubg.png") no-repeat scroll 0 0 transparent;
            float: left;
            height: 50px;
            margin-left: 180px;
            margin-top: -4px;
            position: relative;
            width: 710px;
        }
        .hide
        {
            display: none;
        }
        #spanTemplateName
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 18px;
            color: #901215;
            font-weight: bold;
            padding: 3px;
        }
        .pageheader
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 26px;
            color: #828386;
            font-weight: bold;
        }
        .heading
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 20px;
            color: #4F4F4F;
            text-decoration: underline;
            margin-left: -10px;
        }
        .text
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            color: Black;
            font-size: 15px;
        }
        .link
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            color: #0060A6;
            text-decoration: none;
            font-size: 13px;
        }
        .link:hover
        {
            text-decoration: underline;
        }
        .emptydatatext
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            color: Black;
            font-size: 16px;
            padding-top: 30px;
            height: 120px;
            vertical-align: bottom;
        }
        .errorMsg
        {
            color: #D8000C;
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 13px;
        }
        #body_preferenceDropDown
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
            font-size: 14px;
            border-radius: 4px;
            padding: 5px;
            font-weight: bold;
            width: 350px;
            color: White;
            background-color: #8f1315;
        }
        
        
       
        .backButton
        {
            background-image: url('Images/FW_back.png');
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 13px 0 0 13px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 89px;
            color: White;
            margin-left: 850px;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
   <table>
        <tr>
            <td>
                <asp:Button ID="btnBack" runat="server" class="backButton" Text="" OnClick="btnBack_Click" />
            </td>
        </tr>
        <tr>
            <td style="padding-top: 12px; padding-left: 240px;">
                <span class="pageheader">Choose an action and Site Template </span>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td align="center">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="preferenceDropDown" runat="server">
                                            <asp:ListItem Text="Facebook campaign & Microsite" Value="6" />
                                            <asp:ListItem Text="Facebook campiagn & Youtube video" Value="7" />
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table>
                                <tr class="regcontent">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td valign="middle" align="center" bgcolor="#ffffff" colspan="2">
                                        <table width="100%" style="color: #8f1315;">
                                            <tr>
                                                <td width="25%">
                                                    <div align="center">
                                                        Fabric
                                                    </div>
                                                </td>
                                                <td width="25%">
                                                    <div align="center">
                                                        Retail
                                                    </div>
                                                </td>
                                                <td width="25%">
                                                    <div align="center">
                                                        Real Estate
                                                    </div>
                                                </td>
                                                <td width="25%">
                                                    <div align="center">
                                                        Coupons
                                                    </div>
                                                </td>
                                               
                                                
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imgPreview1" CssClass="previewborder" name="large" runat="server"
                                                        ToolTip="Click to create site" OnClick="imgButtonClick1" ImageUrl="~/Template/Rstores.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgPreview2" CssClass="previewborder" name="large" runat="server"
                                                        ToolTip="Click to create site" OnClick="imgButtonClick2" ImageUrl="~/Template/ff.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgPreview3" CssClass="previewborder" name="large" runat="server"
                                                        ToolTip="Click to create site" OnClick="imgButtonClick3" ImageUrl="~/Template/RealEstate.jpg" />
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="imgPreviewCoupons" CssClass="previewborder" name="large" runat="server"
                                                        ToolTip="Click to create site" OnClick="imgPreviewCoupons_Click" ImageUrl="~/Template/Coupons.png" />
                                                </td>
                                                </tr>
                                                </table>

                                                <table  width="100%" style="color: #8f1315;">
                                                   <tr>
                                                      <td style="width:25%">
                                                         <div align="center">
                                                            Graffiti
                                                         </div>
                                                        
                                                      </td>
                                                      <td style="width:25%">
                                                      <div align="center">Restaurant
                                                         </div>
                                                         </td>
                                                         <td style="width:25%">
                                                        <%-- <div align="center">Educational
                                                         </div>--%>
                                                         </td>
                                                         <td>
                                                         <div>
                                                         </div>
                                                         </td>
                                                   </tr>
                                                </table>
                                                      <table  width="100%" style="color: #8f1315;">
                                                      <tr>
                                                      <td style="width:25%">

                                           
                          <asp:ImageButton  ID="imgPreviewPFrame" runat="server" CssClass="previewborder" name="large"
                         ToolTip="Click to create site" ImageUrl="~/Template/MedievalNoir.jpg" OnClick="imgPreviewPFrame_Click" Width="200px" Height="150px"/>
                                            </td>
                         <td style="width:25%">
                         <asp:ImageButton  ID="imgPreviewRestaurant" runat="server" CssClass="previewborder" name="large"
                          ToolTip="Click to create site" ImageUrl="~/Template/Restaurant.jpg" OnClick="imgPreviewRestaurant_Click" Width="200px" Height="150px"/>
                                            
                         </td>
                        <td style="width:25%">
                       <%-- <asp:ImageButton  ID="imgPreviewEducational" runat="server" CssClass="previewborder" name="large"
                          ToolTip="Click to create site" ImageUrl="~/Template/Educational.jpg" OnClick="imgPreviewEducational_Click" Width="200px" Height="150px"/>--%>
                        
                        </td>
                         <td>
                         </td>
                         </tr>
                      </table>
                                        <div>
                                            <asp:HiddenField ID="hdnSelectedTemplateImagePath" runat="server"  />
                                            <asp:HiddenField ID="hdnTemplatesImagePaths" runat="server"  />
                                            <asp:HiddenField ID="hdnTemplateNamesWithIds" runat="server"  />
                                            <asp:HiddenField ID="hdnCurrentTemplateId" runat="server" />
                                        </div>
                                        <table>
                                            <tr>
                                                <td>
                                                    &nbsp;<img id="imgPreveiw" height="0" width="0" name="large" visible="false" runat="server" />
                                                </td>
                                                <%--<td>
                                        <asp:Button runat="server" ID="btnUseTemplate" Text="Use Template" OnClick="btnUseTemplate_OnClick" />
                                    </td>--%>
                                            </tr>
                                            <%-- <td valign="bottom">
                            <asp:ImageButton ID="btnCreateSite" runat="server" Text="Create Site" OnClick="btnCreateSite_OnClick"
                                Width="207px" Height="100px" ImageUrl="~/Images1/CreateSite.jpg" />
                        </td>--%>
                                            <%--  <tr>
                        <td align="center">
                            <br />
                            <asp:Button ID="btnCreateSite" runat="server" Text="Create Site" OnClick="btnCreateSite_OnClick"
                                Width="150px" />
                            <br />
                            <br />
                        </td>
                    </tr>--%>
                                        </table>
                                        <br />
                                        <br />
                                    </td>
        </tr>
    </table>
</asp:Content>
