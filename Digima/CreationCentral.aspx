<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreationCentral.aspx.cs"
    Inherits="DigiMa.CreationCentral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>jQuery UI Sortable - Handle empty lists</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.1/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <style>
        #CreationCentralMain
        {
            font-family: "Lucida Grande" , "Lucida Sans Unicode" , "Helvetica" , "Arial,Verdana" , "sans-serif";
        }
        #itemsAvailable
        {
            margin-left: 200px;
            border: 1px solid Blue;
            height: 300px;
            margin-left: 400px;
            width: 200px;
        }
        #itemsSelected
        {
            margin-left: 700px;
            border: 1px solid Red;
            height: 300px;
            margin-top: -300px;
            width: 200px;
        }
        #sortable1, #sortable2, #sortable3
        {
            list-style-type: none;
            margin: 0;
            padding: 0;
            float: left;
            margin-right: 10px;
            background: #eee;
            padding: 5px;
            width: 143px;
        }
        #selectedUL li, #sortable2 li, #sortable3 li
        {
            margin: 5px;
            padding: 5px;
            font-size: 1.2em;
            width: 120px;
        }
    </style>
    <script>
        $(function () {
            $("ul.droptrue").sortable({
                connectWith: "ul"
            });

            $("ul.dropfalse").sortable({
                connectWith: "ul",
                dropOnEmpty: false
            });

            $("#sortable1, #sortable2, #sortable3").disableSelection();
        });
        function GetCount() {
            var ids = $("#sortable2 li").map(function () {
                return this.id.split("-")[1];
            }).get().join(",");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="CreationCentralMain">
        <div id="itemsAvailable">
            <ul id="sortable1" class="droptrue">
                <li class="ui-state-default" id="1">Facebook Campaigns</li>
                <li class="ui-state-default" id="2">MicroSite</li>
                <li class="ui-state-default" id="3">Website</li>
                <li class="ui-state-default" id="4">Youtube Video</li>
            </ul>
        </div>
        <div id="itemsSelected">
            <ul id="sortable2" class="droptrue" runat="server">
            </ul>
        </div>
        <br style="clear: both;" />
        <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click"
            OnClientClick="GetCount()" />
        <asp:HiddenField ID="hdnVals" runat="server" />
    </div>
    </form>
</body>
</html>
