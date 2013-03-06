<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="DigiMa.Error"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <style>
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
        .logo
        {
            float: left;
            margin-bottom: 20px;
            margin-left: 164px;
            margin-top: -23px;
            width: 250px;
        }
        table
        {
            background-color:Black;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <div style="color: #8F1313; margin-left: 50px; margin-top: 100px; text-align: center;">
        <h2>
            <span style="font-size: xx-large;">Oops..</span>
        </h2>
        <br />
        <span style="font-size: large;">Something went horribly horribly wrong and our website
            administrator has been notified.</span>
    </div>
    <div class="backwrapperError" style="display: block;" runat="server" visible="true"
        id="backDiv">
        
    </div>
</asp:Content>
