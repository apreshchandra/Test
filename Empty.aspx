<%@ Page Language="C#" AutoEventWireup="true" Inherits="Empty" Codebehind="Empty.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList runat="server" ID="ddl" EnableViewState="false">
            <asp:ListItem Text="A" Value="A" Selected="True"></asp:ListItem>
            <asp:ListItem Text="A" Value="A"></asp:ListItem>
            <asp:ListItem Text="B" Value="B"></asp:ListItem>
            <asp:ListItem Text="A" Value="A"></asp:ListItem>
        </asp:DropDownList>

        <select id="ddlhTML">
        <option value="A" selected="selected">A</option>
        <option value="A">A</option>
        <option value="C">C</option>
        </select>

        <asp:Button runat="server" />
    </div>
    </form>
</body>
</html>
