<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntrySweepStake.aspx.cs"
    Inherits="DigiMa.EntrySweepStake" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
    <script src="ScriptsSonetReach/jquery.calendrical.js" type="text/javascript"></script>
    <link href="Styles/calendrical.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica";
            font-size: 12px;
            line-height: 20px;
            font-weight: normal;
            color: #333333;
            background-color: #1b1b1b;
            text-align: left;
            padding: 0px;
            margin: 0px;
        }
        .textboxes
        {
            background-color: #eeeeee;
            width: 150px;
        }
        #mainContent
        {
            padding-left: 45px;
        }
        #tblEntry td
        {
            width: 80px;
        }
        #btnSubmit
        {
            background: none repeat scroll 0 0 #8B9904;
            border: medium none;
            border-radius: 13px 13px 13px 13px;
            color: White;
            cursor: pointer;
            display: block;
            font-family: Microsoft YaHei;
            font-size: 14px;
            font-weight: bold;
            height: 28px;
            line-height: 28px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 95px;
        }
        #btnCancel
        {
            background: none repeat scroll 0 0 #8B9904;
            border: medium none;
            border-radius: 13px 13px 13px 13px;
            color: White;
            cursor: pointer;
            display: block;
            font-family: Microsoft YaHei;
            font-size: 14px;
            font-weight: bold;
            height: 28px;
            line-height: 28px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 95px;
        }
        #selCountry
        {
            color: White;
            background-color: #8B9904;
            border-radius: 4px;
            font-family: Microsoft YaHei;
            width: 150px;
        }
        #selGender
        {
            color: White;
            background-color: #8B9904;
            border-radius: 4px;
            font-family: Microsoft YaHei;
            width: 150px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#datepickerEntryForm").calendricalDate({ usa: false });
            $("#selCountry").slideDown('slow');
            $("#selCountry").css('border-radius', '4px');
        });


        function closeITMan() {
            window.close();
        }
    </script>
</head>
<body style="background-color: Black; font-family: Verdana; color: #f7c357; font-size: 12px;">
    <form id="form1" runat="server">
    <div class="masterwrapper">
        <div class="sonetlogo">
            <a href="#">
                <img src="images/logo.png" border="0" alt="SonetReach" /></a></div>
    </div>
    <div class="clr">
    </div>
    <div id="mainContent">
        <table style="width: 46%; overflow: hidden;" id="tblEntry">
            <tr>
                <td>
                    First Name<span style="color: Red">*</span>:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="textboxes"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server" ErrorMessage="First Name is a mandatory field!"
                        ValidationGroup="vGRoup" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name<span style="color: Red">*</span> :
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="textboxes"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rvfLastName" ControlToValidate="txtLastName" runat="server" ErrorMessage="Last Name is a mandatory field!"
                        ValidationGroup="vGRoup" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textboxes" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Country <span style="color: Red">*</span>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="154px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Country is a mandatory field!"
                        SetFocusOnError="True" ControlToValidate="ddlCountry" ValidationGroup="vGRoup"
                        Display="None">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    City :
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="textboxes"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Zipcode :
                </td>
                <td>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="textboxes"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email <span style="color: Red">*</span>:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxes"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rvfEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="Email is a mandatory field!"
                        ValidationGroup="vGRoup" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rgexptxtEmailID" runat="server" ErrorMessage="Please enter valid Email ID"
                        ControlToValidate="txtEmail" ValidationGroup="vGRoup" Display="None" SetFocusOnError="True"
                        ValidationExpression="^[\w\.\-]+@[a-zA-Z0-9\-]+(\.[a-zA-Z0-9\-]{1,})*(\.[a-zA-Z]{2,3}){1,2}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Gender<span style="color: Red">*</span> :
                </td>
                <td>
                    <%--<select id="selGender" runat="server">
                        <option value="Female" selected="selected">Female</option>
                        <option value="Male">Male</option>
                    </select>--%>
                    <asp:DropDownList ID="ddlGender" runat="server" Width="154px">
                        <asp:ListItem Value="0" Selected="True">Enter Gender</asp:ListItem>
                        <asp:ListItem Value="Male" > Male</asp:ListItem>
                        <asp:ListItem Value="Female"> Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlGender"
                        InitialValue="0" runat="server" ErrorMessage="Gender is a mandatory field!" ValidationGroup="vGRoup"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    DOB <span style="color: Red">*</span> :
                </td>
                <td>
                    <input type="text" id="datepickerEntryForm" class="textboxes" runat="server" /><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" ControlToValidate="datepickerEntryForm" runat="server"
                        ErrorMessage="DOB is a mandatory field!" ValidationGroup="vGRoup" Display="None"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Telephone :
                </td>
                <td>
                    <asp:TextBox ID="txtTelePhone" runat="server" CssClass="textboxes"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile :
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="textboxes"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Remarks :
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textboxes" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                        ValidationGroup="vGRoup" EnableViewState="false" ViewStateMode="Disabled"></asp:Button>
                </td>
                <td align="left">
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="No thanks"
                        OnClientClick="javascript:closeITMan(); return false;"></asp:Button>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <span id="spanError" runat="server" style="color: Red; font-family: Verdana;"></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vGRoup"
                        ShowMessageBox="true" ShowSummary="false" Class="valSummary" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
