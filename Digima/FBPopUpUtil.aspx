<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FBPopUpUtil.aspx.cs" Inherits="DigiMa.FBPopUpUtil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #FBData
        {
            background-color: #fff; /*position: fixed;*/
            _position: absolute; /* hack for internet explorer 6*/
            border: 10px solid #999999; /*z-index: 2;*/
            -moz-border-radius: 9px;
            -webkit-border-radius: 9px;
            font-size: 13px;
            font-family: Verdana;
            left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="FBData">
        <asp:Literal ID="litFBData" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
