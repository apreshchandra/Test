<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CanvasAreaYoutubeVideoUpload.aspx.cs"
    Inherits="DigiMa.CanvasAreaYoutubeVideoUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="ScriptsSonetReach/jquery-1.5.0.min.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script>
        $('#btnUploadYTVideo').click(function () {
            $('#divLoading').show();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:FileUpload ID="fileYoutubeVideo" runat="server" />
        <asp:Button ID="btnUploadYTVideo" runat="server" Text="Upload" OnClick="btnUploadYTVideo_Click" />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1">
            <ProgressTemplate>
                <div align="center" style="font-weight: bold; background-color:Red;" id="divLoading">
                    Working.....
                    <asp:Image ID="aspImg1" runat="server" ImageUrl="~/Images/loading.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblVidURL" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
