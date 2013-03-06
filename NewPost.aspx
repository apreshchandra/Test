<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="DigiMa.NewPost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="https://www.facebook.com/2008/fbml">
<head runat="server">
    <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
    <script type="text/javascript" src="ScriptsSonetReach/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        // holds the selected friends' FB IDs
        var selectedFBIDs = [];

        function CloseMe() {
            window.close();
            return false;
        }

        function disableEnterKey(e) {
            var key;
            if (window.event)
                key = window.event.keyCode; //IE
            else
                key = e.which; //firefox

            if (key == 13)
                return false;
            else
                return true;
        }

        function selectFriend(a, fbid) {
            if (a.className == 'friend-block') {
                // add
                a.className = 'friend-block friend-block-selected';
                selectedFBIDs.push(fbid);
            }
            else {
                // remove
                a.className = 'friend-block';
                if (selectedFBIDs.indexOf(fbid) != -1) {
                    selectedFBIDs.splice(selectedFBIDs.indexOf(fbid), 1);
                }
            }

            return false;
        }

        function FireOnPost() {

            var ID = this.document.getElementById("hidFriendsList");
            ID.value = selectedFBIDs;
        }

        function disablePopup() {
            $("#mainBody").fadeOut("slow");
        }
        $(document).keypress(function (e) {
            if (e.keyCode == 27)//Disable popup on pressing `ESC`
            {
                disablePopup();
                window.close();

            }
        });

        $("#BtnCancel").click(function () {
            disablePopup();
            window.close();
        });
        $("#ddlLocation").select(function () {
            $("#ddlLocation").slideDown('slow');
            $("#ddlLocation").css('border-radius', '4px');

        });

        $(document).ready(function () {

            $("#ddlLocation").css('background-color', '#6d84b4');
            jQuery('#ddlLocation').mouseover(function () {
                $('#ddlLocation').css('background-color', '#818185');
            });

            jQuery('#ddlLocation').mouseout(function () {
                $('#ddlLocation').css('background-color', '#6d84b4');
            });
            $("#plcMainContent").css({ "opacity": "2.1" });
        });




        $("#ddlGender").select(function () {
            $("#ddlGender").slideDown('slow');
        });

        $(document).ready(function () {

            $("#ddlGender").css('background-color', '#6d84b4');
            jQuery('#ddlGender').mouseover(function () {
                $('#ddlGender').css('background-color', '#818185');
            });

            jQuery('#ddlGender').mouseout(function () {
                $('#ddlGender').css('background-color', '#6d84b4');
            });
        });

    </script>
    <script language="javascript" type="text/C#">
            <asp:literal runat="server" id="litLogin"></asp:literal>
           
    </script>
    <style type="text/css">
        .snBBBody
        {
            width: 380px;
            border: 0px solid Red;
        }
        .defaultPostContetPageStyle
        {
            font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            font-size: 11px;
            border: 0px solid black;
            width: 360px;
            background-color: #f6f6f6;
            color: Black;
        }
        
        .defaultSeeAllProductsStyle
        {
            background: #6D84B4 none repeat scroll 0 0;
            border-color: #3B5998 #3B5998 -moz-use-text-color;
            border-style: solid solid none;
            border-width: 1px 1px medium;
            color: #FFFFFF;
            font-size: 14px;
            font-weight: bold;
            padding: 3px;
            margin: 0;
        }
        .ActionLinks
        {
            float: right;
            padding-bottom: 5px;
        }
        .defaultFacebookButton
        {
            border: 2px solid #00999999;
            background-color: #FFFFFF;
            color: #FFFFFF;
            font-size: 14px;
            width: 100px;
            height: 30px;
        }
        .defaultFriendList
        {
            background-color: #cae1f1;
            border: 1px solid #E9E9E9;
            overflow: auto;
            height: 380px;
        }
        .defaultFriendListContainerStyle
        {
            vertical-align: top;
        }
        .defaultCustomPostMessageStyle
        {
            width: 100%;
        }
        .defaultTextMessageStyle
        {
            width: 98%;
            font-size: 11px;
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
        .no-friends
        {
            color: #888888;
            font-size: 18px;
            padding: 20px 0;
            text-align: center;
        }
        .no-height
        {
            height: auto;
        }
        .friend-block
        {
            color: #666666;
            display: block;
            float: left;
            font-size: 11px;
            height: 56px;
            margin: 2px;
            overflow: hidden;
            padding: 3px;
            text-decoration: none;
            width: 159px;
        }
        .friend-block .friend-thumb
        {
            border: 1px solid #CCCCCC;
            float: left;
            height: 50px;
            line-height: 0;
            overflow: hidden;
            padding: 2px;
            width: 50px;
        }
        .friend-block .friend-thumb img
        {
            border: medium none;
            display: block;
            height: 50px;
            outline: medium none;
            width: 50px;
        }
        .friend-block .friend-info
        {
            float: left;
            height: 66px;
            margin-left: 6px;
            overflow: hidden;
            width: 97px;
        }
        .friend-block .friend-info span
        {
            display: block;
            overflow: hidden;
            white-space: nowrap;
            width: 97px;
        }
        .friend-block .friend-name
        {
            color: #000000;
        }
        .friend-block:hover
        {
            background-color: #EEEEEE;
            cursor: pointer;
        }
        .friend-block-selected, .friend-block-selected:hover
        {
            background-color: #3B5998;
            color: #CCCCCC;
        }
        .friend-block-selected .friend-thumb, .friend-block-selected:hover .friend-thumb
        {
            border: 1px solid #999999;
        }
        .friend-block-selected .friend-name, .friend-block-selected:hover .friend-name
        {
            color: #FFFFFF;
        }
        
        .defaultPostTextTitleStyle
        {
            color: #3B5998;
            font-weight: bold;
        }
        .bodyBG
        {
            background: url('');
        }
        .defaultFacebookButtonGeorgiaAquarium
        {
            margin: 2px 6px 6px 5px;
            border-color: #999999 #999999 #888888;
            border-style: solid;
            border-width: 1px;
            color: #333333;
            cursor: pointer;
            display: inline-block;
            font-size: 11px;
            font-weight: bold;
            padding: 2px 6px;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            white-space: nowrap;
        }
        .defaultFacebookButtonGeorgiaAquariumCancelButtonLink
        {
            display: inline-block;
            line-height: 1;
            padding: 7px 7px;
            text-decoration: none;
            font-weight: normal;
            color: #fff;
            background-color: #39c;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            -khtml-border-radius: 3px;
            border: 1px solid #fff;
            border-radius: 3px;
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
        #plcMainContent
        {
            background-color: #fff;
            position: fixed;
            _position: absolute; /* hack for internet explorer 6*/
            height: 545px;
            border: 10px solid #999999;
            z-index: 2;
            -moz-border-radius: 9px;
            -webkit-border-radius: 9px;
            width: 700px;
            font-family: "lucida grande" ,tahoma,verdana,arial,sans-serif;
            left: 10px;
            border-radius: 8ps;
        }
        #BtnPost
        {
            margin: 2px 6px 6px 5px;
            font-size: 13px;
            background-color: #5B74A8;
            background-position: 0 -48px;
            border-color: #29447E #29447E #1A356E;
            color: #FFFFFF;
            padding: 2px 6px;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            white-space: nowrap;
        }
    </style>
</head>
<body style="background: #e7ebf2;" id="mainBody">
    <form name="frmPostToFriendsWall" id="frmPostToFriendsWall" runat="server" method="post">
    <div id="plcMainContent" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td class="defaultSeeAllProductsStyle">
                    Post to your friends wall
                </td>
            </tr>
            <tr>
                <td class="defaultHeadingLabelStyle defaultSelectYourFriendStyle">
                    Select your friend
                </td>
            </tr>
            <tr>
                <td>
                    <div id="FilterArea">
                        <asp:DropDownList ID="ddlLocation" runat="server" EnableTheming="True" OnSelectedIndexChanged="ddlLocationOnSelectedIndexChanged"
                            AutoPostBack="true" ForeColor="White" Width="150px">
                            <asp:ListItem Text="All" Selected="True" Value="All"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlGender" runat="server" OnSelectedIndexChanged="ddlGenderOnSelectedIndexChanged"
                            AutoPostBack="true" Width="100px" ForeColor="White">
                            <asp:ListItem Text="All" Selected="True" Value="All"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="defaultFriendListContainerStyle">
                    <div class="defaultFriendList">
                        <asp:Repeater ID="rptAllFriends" runat="server" OnItemDataBound="rptAllFriends_OnItemDataBound">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlInvite" NavigateUrl="#" runat="server" CssClass="friend-block"
                                    URL="#">
                                    <div class="friend-thumb">
                                        <asp:Image ID="imgThumb" runat="server" /></div>
                                    <div id="friendInfo" runat="server" class="friend-info">
                                        <asp:Label ID="lblName" runat="server" CssClass="friend-name" />
                                        <asp:Label ID="lblLocation" runat="server" />
                                    </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="defaultActionButtonsContentStyle">
                    <%--<asp:Button CssClass="defaultFacebookButtonGeorgiaAquarium" ID="BtnPost" runat="server" Text="Post"
                        />--%>
                    <%--<input type="button" class="defaultFacebookButtonGeorgiaAquarium" id="BtnPost" onclick="FireOnPost();return false;" value="Post"/>--%>
                    <asp:Button CssClass="defaultFacebookButtonGeorgiaAquarium" ID="BtnPost" runat="server"
                        OnClick="defaultFacebookButton_OnClick" Text="Send" />
                    <input type="button" id="BtnCancel" onclick="CloseMe()" value="Cancel" class="defaultFacebookButtonGeorgiaAquarium" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hidFriendsList" runat="server" EnableViewState="true" />
    </div>
    <div id="plcSuccessContent" runat="server" visible="false">
        <span style="font-size: large; font-family: Segoe UI Semibold; text-align: center;">
            Successfully Posted!</span> &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <a href="#" class="defaultFacebookButtonGeorgiaAquarium" id="BtnCloseOnSucess" onclick="javascript:window.close(); return false;">
            Close</a>
    </div>
    </form>
</body>
</html>
