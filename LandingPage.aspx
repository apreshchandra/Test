<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="LandingPage.aspx.cs" Inherits="DigiMa.LandingPage"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="cphHead">
    <script src="ScriptsSonetReach/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/jquery-ui-1.8.17.custom.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Styles/stylesheet1.css" />
    <script src="ScriptsSonetReach/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="Styles/master_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/osx.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="Images/sonetreachicon.ico" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <link href="Styles/menu_style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/style_new_menu.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptsSonetReach/login.js"></script>
    <style type="text/css">
        .masterbody
        {
        }
        .footercopy
        {
            font-size: 11px;
            text-align: left;
            color: #939393;
            text-align: center;
            background-image: url(Images/master_bg.png);
        }
        .hidden
        {
            display: none;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 1px solid;
            width: 385px;
            margin-left: 25px;
        }
        .loginfield
        {
            margin-top: 130px;
            margin-left: 65px;
            position: absolute;
            font-family: verdana;
            color: #5b5c61;
            font-size: 11px;
            width: 490px;
        }
        
        .loginfieldArticle
        {
            margin-top: 75px;
        }
        .table
        {
            table-layout: fixed;
            overflow: hidden;
        }
        
        div.tabscontainer
        {
            margin: 15px 0px;
        }
        
        div.tabscontainer div.tabs
        {
            list-style: none;
            cursor: pointer;
            float: left;
            margin-top: 10px;
            margin-left: 5px;
            z-index: 2;
        }
        
        div.tabscontainer div.curvedContainer
        {
            margin-left: 197px;
            border: 1px solid #7c7c77;
            min-height: 400px;
            -moz-border-radius: 13px;
            border-radius: 13px;
            width: 848px;
        }
        
        div.tabscontainer div.curvedContainer .tabcontent
        {
            display: none;
            padding: 20px;
            font-size: 12px;
            font-family: Verdana;
        }
        
        div.tabs div.tab
        {
            display: block;
            height: 58px;
            background: #eeeeea;
            border: #d6d6d2 solid 1px;
            border-top: none;
            position: relative;
            color: #73736b;
            width: 190px;
        }
        
        div.tabs div.link
        {
            padding-left: 5px;
            padding-top: 5px;
            font-family: Verdana;
            font-size: 16px;
            font-weight: bold;
        }
        div.tabs div.link1
        {
            padding-left: 5px;
            padding-top: 5px;
            font-family: Verdana;
            font-size: 16px;
            font-weight: bold;
        }
        div.tabs div.link2
        {
            padding-left: 5px;
            padding-top: 5px;
            font-family: Verdana;
            font-size: 16px;
            font-weight: bold;
        }
        
        div.tabs div.tab.selected
        {
            color: #ffffff;
            border-right-color: #aeaeaa;
        }
        
        div.tabs div.tab.selected
        {
            background: url(menuSelBack.png) repeat-x;
            border-right-color: #7c7c77;
        }
        
        div.tabs div.tab.first
        {
            border-top: White solid 1px;
            -moz-border-radius-topleft: 13px;
            border-top-left-radius: 13px;
        }
        
        div.tabs div.tab.last
        {
            -moz-border-radius-bottomleft: 13px;
            border-bottom-left-radius: 13px;
        }
        
        div.tabs div.tab div.arrow
        {
            position: absolute;
            background: url(homeSelArrow.png) no-repeat;
            height: 58px;
            width: 17px;
            left: 100%;
            top: 0px;
            display: none;
        }
        
        div.tabs div.tab.selected div.arrow
        {
            display: block;
        }
        #tblPromotions
        {
            border: 1px solid #eeeeea;
            width: 100%;
        }
        #tblPromotions .tr .td
        {
            border: 1px solid #eeeeea;
        }
        #tblSweepstakes
        {
            border: 1px solid #eeeeea;
            width: 100%;
        }
        #tblSweepstakes .tr .td
        {
            border: 1px solid #eeeeea;
        }
        td.style1
        {
            border: 1px solid #eeeeea;
            width: 200px;
            height: 100px;
        }
        
        #Images
        {
            width: 200px;
            height: 100px;
        }
        #tblLog
        {
            table-layout: fixed;
            overflow: hidden;
        }
        #tdBack
        {
            margin-top: -27px;
            position: absolute;
        }
    </style>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js"></script>
    <script src="ScriptsSonetReach/jquery.simplemodal.js" type="text/javascript"></script>
    <script src="ScriptsSonetReach/osx.js" type="text/javascript"></script>
    <script type="text/javascript">
        function detectPopupBlocker() {
            var myTest = window.open("about:blank", "", "directories=no,height=50,width=50,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,top=1000,location=no");
            if (!myTest) {
                alert("A popup blocker was detected.Please turn off all pop blockers on your browser for best results.");
            } else {
                myTest.close();
            }
        }
        window.onload = detectPopupBlocker;

        function rotate() {
            $('#next').click();
        }



        $(document).ready(function () {

            $(".tabs .tab[id^=tab_menu]").click(function () {
                var curMenu = $(this);
                $(".tabs .tab[id^=tab_menu]").removeClass("selected");
                curMenu.addClass("selected");

                var index = curMenu.attr("id").split("tab_menu_")[1];
                $(".curvedContainer .tabcontent").css("display", "none");
                $(".curvedContainer #tab_content_" + index).css("display", "block");
            });
        });


        $(document).ready(function () {
            $(".link").mouseover(function () {
                $("#spanLink1").css('text-align', 'center');
            });
            $(".link").mouseout(function () {
                $(".link").css('text-align', 'left');
            });
            $(".link1").mouseover(function () {
                $(".link1").css('text-align', 'center');
            });
            $(".link1").mouseout(function () {
                $(".link1").css('text-align', 'left');
            });
            $(".link2").mouseover(function () {
                $(".link2").css('text-align', 'center');
            });
            $(".link2").mouseout(function () {
                $(".link2").css('text-align', 'left');
            });
        });
    </script>
    <script type="text/javascript">
        /*Sweepstakes Carousel*/
        $(document).ready(function () {
            //rotation speed and timer
            var speed = 5000;
            var run = setInterval('rotate()', speed);
            //if user clicked on prev button
            $('#prevSweep').click(function () {
                //grab the width and calculate left value
                var item_widthSweep = $('#slidesSweep li').outerWidth();
                var left_valueSweep = item_widthSweep * (-1);

                //move the last item before first item, just in case user click prev button
                $('#slidesSweep li:first').before($('#slidesSweep li:last'));

                //set the default item to the correct position 
                $('#slidesSweep ul').css({ 'left': left_valueSweep });
                //get the right position            
                var left_indent = parseInt($('#slidesSweep ul').css('left')) + item_widthSweep;

                //slide the item            
                $('#slidesSweep ul').animate({ 'left': left_indent }, 200, function () {

                    //move the last item and put it as first item               
                    $('#slidesSweep li:first').before($('#slidesSweep li:last'));

                    //set the default item to correct position
                    $('#slidesSweep ul').css({ 'left': left_valueSweep });

                });

                //cancel the link behavior            
                return false;

            });


            //if user clicked on next button
            $('#nextSweep').click(function () {

                //grab the width and calculate left value
                var item_widthSweep = $('#slidesSweep li').outerWidth();
                var left_valueSweep = item_widthSweep * (-1);

                //move the last item before first item, just in case user click prev button
                $('#slidesSweep li:first').before($('#slidesSweep li:last'));

                //set the default item to the correct position 
                $('#slidesSweep ul').css({ 'left': left_valueSweep });
                //get the right position
                var left_indent = parseInt($('#slidesSweep ul').css('left')) - item_widthSweep;

                //slide the item
                $('#slidesSweep ul').animate({ 'left': left_indent }, 200, function () {

                    //move the first item and put it as last item
                    $('#slidesSweep li:last').after($('#slidesSweep li:first'));

                    //set the default item to correct position
                    $('#slidesSweep ul').css({ 'left': left_valueSweep });

                });

                //cancel the link behavior
                return false;

            });

            //if mouse hover, pause the auto rotation, otherwise rotate it
            $('#slides').hover(

        function () {
            clearInterval(run);
        },
        function () {
            run = setInterval('rotate()', speed);
        }
    );

        });

        //a simple function to click next link
        //a timer will call this function, and the rotation will begin :)  
        function rotate() {
            $('#next').click();
        }
        function callModalPopUp(pageName) {
            //HideModalTable();
            document.getElementById('iFrameModal').src = pageName;
            document.getElementById('btnModal').click();
        }

        function closeModalExtender() {
            $("#hlnModalClose").trigger("click");
        }
    </script>
    <style type="text/css">
        .body
        {
            color: Red;
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
            margin-top: -6px;
            position: relative;
            width: 710px;
        }
        #btnCreationCentral
        {
            background-image: url('../Images/digima_get_started.png');
            background-repeat: no-repeat;
            border: 0 none;
            border-radius: 13px 13px 13px 13px;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 95px;
        }
        .logo
        {
            float: left;
            margin-bottom: 20px;
            margin-left: 164px;
            margin-top: -24px;
            width: 250px;
        }
        #carouselPromo
        {
            width: 255px;
            height: 290px;
            margin: 0 auto;
        }
        
        #slidesPromo
        {
            overflow: hidden; /* fix ie overflow issue */
            position: relative;
            width: 400px;
            height: 400px;
            border: 1px solid #ccc;
            margin-top: -290px;
        }
        
        /* remove the list styles, width : item width * total items */
        #slidesPromo ul
        {
            position: relative;
            left: 0;
            top: 0;
            list-style: none;
            margin: 0;
            padding: 0;
            width: 750px;
        }
        
        /* width of the item, in this case I put 250x250x gif */
        #slidesPromo li
        {
            width: 250px;
            height: 250px;
            float: left;
        }
        
        #slidesPromo li img
        {
            padding: 5px;
        }
        
        /* Styling for prev and next buttons */
        #buttonsPromo
        {
            padding: 0 0 5px 0;
            float: right;
        }
        
        #buttonsPromo a
        {
            display: block;
            width: 31px;
            height: 32px;
            text-indent: -999em;
            float: left;
            outline: 0;
        }
        
        a#prevPromo
        {
            height: 48px;
            width: 48px;
        }
        a#nextPromo
        {
            height: 48px;
            width: 48px;
        }
        #spanNextPromo
        {
            background-image: url(Images/next_button.png);
            display: block;
            height: 48px;
            width: 48px;
        }
        
        #spanPrevPromo
        {
            background-image: url('Images/prev_button.png');
            display: block;
            height: 48px;
            width: 48px;
        }
        
        .clear
        {
            clear: both;
        }
        #divPrevPromo
        {
            margin-top: 150px;
        }
        #divNextPromo
        {
            margin-top: -330px;
            margin-left: 650px;
        }
        
        
        
        #carouselSweep
        {
            width: 255px;
            height: 290px;
            margin: -60px auto 0;
        }
        
        #slidesSweep
        {
            overflow: hidden; /* fix ie overflow issue */
            position: relative;
            width: 250px;
            height: 250px;
            border: 1px solid #ccc;
            margin-top: -120px;
        }
        
        /* remove the list styles, width : item width * total items */
        #slidesSweep ul
        {
            position: relative;
            left: 0;
            top: 0;
            list-style: none;
            margin: 0;
            padding: 0;
            width: 750px;
        }
        
        /* width of the item, in this case I put 250x250x gif */
        #slidesSweep li
        {
            width: 250px;
            height: 250px;
            float: left;
        }
        
        #slidesSweep li img
        {
            padding: 5px;
        }
        
        /* Styling for prev and next buttons */
        #buttonsSweep
        {
            padding: 0 0 5px 0;
            float: right;
        }
        
        #buttonsSweep a
        {
            display: block;
            width: 31px;
            height: 32px;
            text-indent: -999em;
            float: left;
            outline: 0;
        }
        
        a#prevSweep
        {
            height: 48px;
            width: 48px;
        }
        a#nextSweep
        {
            height: 48px;
            width: 48px;
        }
        #spanNextSweep
        {
            background-image: url(Images/next_button.png);
            display: block;
            height: 48px;
            width: 48px;
        }
        
        #spanPrevSweep
        {
            background-image: url('Images/prev_button.png');
            display: block;
            height: 48px;
            width: 48px;
        }
        #divPrevSweep
        {
            margin-top: 150px;
        }
        #divNextSweep
        {
            margin-top: -330px;
            margin-left: 650px;
        }
        #tab_content_4
        {
            text-align: center;
        }
        #tab_content_5
        {
            text-align: center;
        }
        #tab_content_6
        {
            text-align: center;
        }
        .mGrid
        {
            border-collapse: collapse;
            border: none;
            font: Verdana;
            background-repeat: repeat;
            cursror: pointer;
        }
        .mGrid td
        {
            border: none;
            padding: .8em;
        }
        .mGrid th
        {
            border: none;
            padding: .8em;
            color: #8f1313;
        }
        .mGrid .alt
        {
            background-color: #fcfcfc;
            color: #fff;
        }
        .mGrid .pgr
        {
            background-color: #424242;
        }
        .mGrid .pgr table
        {
            margin: 5px 0;
        }
        .mGrid .pgr td
        {
            border-width: 0;
            padding: 0 6px;
            border-left: solid 1px #666;
            font-weight: bold;
            color: #fff;
            line-height: 12px;
        }
        .mGrid .pgr a
        {
            color: #666;
            text-decoration: none;
        }
        .mGrid tr:hover
        {
            background: #827e8e;
            color: #fff;
            cursor: pointer;
        }
        
        
        #tablist
        {
            padding: 3px 0;
            margin-left: 27px;
            margin-bottom: 0;
            margin-top: 0.1em;
            font-family: Verdana;
            font-size: 11px;
            font-weight: bold;
        }
        
        #tablist ul
        {
            padding: 0px;
            margin: 0px;
        }
        
        
        #tablist li
        {
            list-style: none;
            display: inline;
            margin: 0;
        }
        
        
        #tablist li a
        {
            text-decoration: none;
            padding: 3px 0.5em;
            margin-right: 3px;
            border: 1px solid #778;
            border-bottom: none;
            background: White;
            color: Gray;
        }
        
        #tablist li a:hover
        {
            background: #000000;
            color: Orange;
        }
        
        #tablist li a.active
        {
            background: #000000;
            color: Orange;
        }
        
        #tablist li a.visited
        {
            background: #000000;
            color: Orange;
        }
        #tablist ul li a:visited
        {
            color: red;
        }
        
        #tablist ul li a.selected
        {
            color: red;
        }
        
        
        #divMainContent
        {
            margin-left: 13px;
            margin-top: 120px;
        }
        #divCreation
        {
            margin-left: 825px;
            margin-top: 40px;
        }
        #tab_content_1
        {
            width: 700px;
        }
        #tblShowAll
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: Verdana;
            font-size: 13px;
            color: #ffbe31;
            border-radius: 5px;
        }
        #tblPromo
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 79px;
        }
        #tblVideo
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #tblSweep
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #tblContests
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #tblDeals
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #tblGroupDeals
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #tblCoupons
        {
            empty-cells: show;
            margin-top: 15px;
            font-family: "CenturyGothicRegular" , "Century Gothic" , Arial, Helvetica, sans-serif;
            font-size: medium;
            color: #ffbe31;
            border-radius: 5px;
            margin-left: 80px;
        }
        #AllDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #PromotionsDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #VideoShareDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #SweepDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #ContestDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #DealsDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #GrDealsDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        #CouponsDioo
        {
            border: 1px solid Gray;
            margin-left: 28px;
            margin-top: 15px;
            width: 749px;
            border-radius: 3px;
        }
        .PreviewButtons
        {
            background-image: url("images/preview_F.png");
            height: 28px;
            width: 98px;
            border: 0px;
            border-radius: 13px;
            cursor: pointer;
            background-color: transparent;
        }
        .getstarted
        {
            background-image: url('Images/FW_Get_started.png');
            background-repeat: no-repeat;
            border: 0 none;
            cursor: pointer;
            display: block;
            height: 25px;
            line-height: 25px;
            margin: 0;
            text-align: center;
            text-decoration: none;
            vertical-align: middle;
            width: 101px;
        }
        h2
        {
            color: White;
            font-size: 12px;
            font-weight: normal;
            margin: 0 0 0 -54px;
            padding: 0 24px 0 0;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
 <asp:literal runat="server" id="litLogin"></asp:literal>
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body" ID="body">
    <table style="margin-left: 75px; margin-top: 50px;">
        <tr>
            <td align="right">
                <asp:Button ID="btnCreationCentral" CssClass="getstarted" runat="server" OnClick="btnCreationCentral_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdAnalytics" runat="server" AutoGenerateColumns="false" GridLines="None"
                    BorderStyle="Solid" BorderColor="#901215" OnRowCommand="GridView_RowCommand"
                    CssClass="mGrid" AlternatingRowStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                    AlternatingRowStyle-VerticalAlign="Middle" RowStyle-VerticalAlign="Middle" ShowHeaderWhenEmpty="true"
                    EmptyDataText="No Data to display" Width="800px" AlternatingRowStyle-BackColor="#fff"
                    AlternatingRowStyle-ForeColor="#fff">
                    <Columns>
                        <asp:BoundField DataField="CustomTabName" HeaderText="App Name" ItemStyle-Width="100px">
                            <ItemStyle Width="100px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDT" HeaderText="Created On" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="false" />
                        <asp:BoundField DataField="AppStatus" HeaderText="Status" />
                        <asp:BoundField DataField="AppExpiryDT" HeaderText="Expires On" DataFormatString="{0:dd-MM-yyyy}"
                            HtmlEncode="false" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="showAnalytics" runat="server" CommandName="Analytics" CommandArgument='<%#Eval("AppID") %>'
                                    Text="View Analytics" Width="140px" Font-Underline="true" ForeColor="#8f1313">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#901215"
                        BackColor="silver" />
                    <AlternatingRowStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CCCCCC"
                        ForeColor="Black" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
