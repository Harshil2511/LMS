<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta http-equiv="pragma" content="no-cache" />
    <title>Default Page</title>
    <%--<link id="Link1" href="App_Themes/Theme1/style.css" rel="Stylesheet" type="text/css" runat="server" />--%>
    <link href="App_Themess/Theme1/style.css" rel="stylesheet" />
</head>

<body style="background-color: #ebf2f5">





    <form id="form1" runat="server">
    <div>
        <div id="wrap1" style="background-color: white; margin-top:3%">

<div id="header" style="padding: 0px!important">

 <%--<img id="Img1" alt="" src="App_Themes/Theme1/images/logo.jpg" runat="server" />--%><%--<img 
     src="logo.png" style = "margin-top: -3%" />--%> 
   <%-- <img src="download.jpg"  
        style="height: 95px; width: 72px; margin-top: 0px"/><br />&nbsp;--%>
    <%--<img src="CT-Drummer-Rswd.jpg" style="width: 109px; height: 18px" />--%>  <%--<div><canvas id="canvas" width="80" height="80" style="background-color:WHITE;margin-left: 87%;margin-top: -10%;">
</canvas></div>--%><%--<img src="indexx.png" />--%>
    <%--<img
     src="company-name.jpg" style="width: 247px; height: 48px;" />--%><%--<h1 style="font-size: x-large;
font-style: initial;
color: darkgray;">NAHAR SPINNING MILLS</h1>--%>
    <%--<img src="CT-Drummer-Rswd.jpg" style="width: 303px; height: 18px" />--%>
 <%--<img src ="App_Themes/Theme1/images/nsm1.JPG" id="nsm" alt="" runat="server"  style="padding-left:550px"   />--%>
 
 </div>

<div id="menu">
<%--<ul>
 <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="Default.aspx" title="">Home</a></li> 
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="iso units.aspx" title="">Iso Units</a></li> 
                        <li>&nbsp;&nbsp;&nbsp; <a href="" title="">Contact Us</a></li> 
                        <%--<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="yarns.aspx" title="">Products</a></li> --%>
                        <%--<li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#" title="">Support</a></li> 
                        <li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="#" title="">Site Map</a></li>--%>
<%--</ul>--%>
    <marquee><h2 style="color:white; background-color:#709dbb;font-style: oblique">LIBRARY MANAGEMENT SYSTEM</h2></marquee>
</div>

<div id="content1">
<div class="right1"> 
    <h1 style="color: darkslateblue;font-style: oblique;font-size: large">Books are a uniquely portable magic</h1>
<%--<h2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <STRONG> <u>NAHAR SPINNING MILLS</u> </STRONG><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    </h2>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div style="padding: 0px!important" class="text">
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<span style="font-weight: bold">Nahar Spinning Mills Ltd E-Tender Portal</span> is a
                        unique web application that automates and supports the tender process between the
                        buyers and vendors internationally or nationwide. The primary purpose of <span style="font-weight: bold">
                            Nahar Spinning Mills Ltd E-Tender Portal</span> is to publish tenders and provide
                        the means for bidders to access tender information and lodge electronic responses
                        to tenders.<span style="font-weight: bold">
                            <br />
                            Nahar Spinning Mills Ltd E-Tender Portal</span> is more than a website; it provides
                        business process automation and workflow management that simplifies the tender process
                        from end to end.<span style="font-weight: bold"> Nahar Spinning Mills Ltd E-Tender Portal</span>
                        is the best solution for Private agencies to facilitate communication with suppliers
                        and contractors in a prompt.<br />
                        <br />--%>
                     <%--<img style="height: 224px;width: 458px ; margin-left:-84px" src="library-management-architechture-500x500.png" /></div>--%>
    <img style="height: 224px;width: 458px ; margin-left:-84px" src="library-management-architechture-500x500.png" /></div>
</div>

<div class="left1"> 
<asp:Panel ID="pnllogin" runat="server" BorderWidth="12px" borderstyle= "outset" Height="243px">
<h2> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Login </h2>
<br />
<center>

<table cellpadding="4" cellspacing="0">
    <tr>
                                        <td>
                                            <asp:Label ID="Label2" Text="Unit" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="width:2px">
                                        </td>
                                        <td>
                                            <%--<asp:TextBox ID="TextBox1" runat="server" Width="120px"></asp:TextBox>--%><asp:DropDownList ID="DropDownList1" runat="server">
                                                <asp:ListItem>500</asp:ListItem>
                                                <asp:ListItem>200</asp:ListItem>
                                                <asp:ListItem>300</asp:ListItem>
                                                 <asp:ListItem>530</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblname" Text="User Name" runat="server" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td style="width:2px">
                                        </td>
                                        <td>
                                            <asp:TextBox style="text-transform:uppercase" ID="txtname" runat="server" Width="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="lblpwd" runat="server" Font-Bold="True" Text="Password"></asp:Label>
                                        </td>
                                        <td style="width:2px">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtpass" runat="server" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" Width="120px"></asp:TextBox>
                                        </td>
                                        
                                    </tr>
                                </table>
                                <br />
                                <div>
                                    &nbsp;&nbsp;&nbsp;&nbsp;

                                    <br />

                                    <asp:Button ID="btnsignin" Text="Sign In" runat="server" BackColor="#b3eeff" ForeColor="#0B3B57"
                                        BorderStyle="ridge" BorderWidth="5px" OnClick="btnsignin_Click" 
                                        Font-Bold="True" Width="54px" /><br />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Invalid Login... !!!"></asp:Label>


                                </div>
                                <br />
                               <%-- <div>
                                    <asp:LinkButton ID="frgetpasslink" Text="FORGOT PASSWORD?" runat="server" 
                                        OnClick="frgetpasslink_Click" Font-Underline="True" Font-Bold="True"></asp:LinkButton>
                                </div>--%>
                                <br />
                                <%--<div style="font-style: italic">
                                    Want To Register With Us ..??
                                </div>--%>
                                <br />
                                <%--<div>
                                    <asp:Button ID="btnnewvendor" Text="Create New Account" runat="server" BackColor="#1F8EAD"
                                        ForeColor="#0B3B57" BorderStyle="Double" BorderWidth="1px" 
                                        OnClick="btnnewvendor_Click" Font-Bold="True" />
                                </div>--%>
                                 </center>
                                 <br />
                                 <br />
                     </asp:Panel>           
                               
    </div>
    
    </div>
    <div style="clear: both;"> </div>


<div id="footer" style= "background-color:#709dbb;font-style: oblique">
               <%-- <div class="counter">
                    <p>
                        <asp:Label ID="lblcnt" Text="WELCOME TO OUR PORTAL , YOU ARE VISITOR # :" runat="server"
                            Font-Bold="True"></asp:Label>
                        <asp:Label ID="lblCurrentNumberOfUsers" runat="server" Font-Bold="True"></asp:Label>
                    </p>
                </div>--%>
                
                <%--<div class="art-Footer">
                    <div class="art-Footer-inner">
                        <a href="#" class="art-rss-tag-icon" title="RSS"></a>
                        <div class="art-Footer-text">
                            <p>
                                <a href="contact us.aspx">Contact Us</a> | <a href="#">Terms of Use</a> | <a href="#">Trademarks</a>
                                | <a href="#">Privacy Statement</a><br />
                            </p>
                        </div>
                    </div>
                    <div class="art-Footer-background">
                    </div>
                </div>--%>
                
                <p class="art-page-footer" style="font-weight: lighter ; color:white">
                    Copyright (c) 2018. All rights reserved.Designed By IT Team,
                        LUDHIANA</a>.</p>
            </div>
    </div>
    </div>


    <script>
        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        var radius = canvas.height / 2;
        ctx.translate(radius, radius);
        radius = radius * 0.90
        setInterval(drawClock, 1000);

        function drawClock() {
            drawFace(ctx, radius);
            drawNumbers(ctx, radius);
            drawTime(ctx, radius);
        }

        function drawFace(ctx, radius) {
            var grad;
            ctx.beginPath();
            ctx.arc(0, 0, radius, 0, 2 * Math.PI);
            ctx.fillStyle = 'SKYBLUE';
            ctx.fill();
            grad = ctx.createRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
            grad.addColorStop(0, '#333');
            grad.addColorStop(0.5, 'white');
            grad.addColorStop(1, '#333');
            ctx.strokeStyle = grad;
            ctx.lineWidth = radius * 0.1;
            ctx.stroke();
            ctx.beginPath();
            ctx.arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
            ctx.fillStyle = '#333';
            ctx.fill();
        }

        function drawNumbers(ctx, radius) {
            var ang;
            var num;
            ctx.font = radius * 0.15 + "px arial";
            ctx.textBaseline = "middle";
            ctx.textAlign = "center";
            for (num = 1; num < 13; num++) {
                ang = num * Math.PI / 6;
                ctx.rotate(ang);
                ctx.translate(0, -radius * 0.85);
                ctx.rotate(-ang);
                ctx.fillText(num.toString(), 0, 0);
                ctx.rotate(ang);
                ctx.translate(0, radius * 0.85);
                ctx.rotate(-ang);
            }
        }

        function drawTime(ctx, radius) {
            var now = new Date();
            var hour = now.getHours();
            var minute = now.getMinutes();
            var second = now.getSeconds();
            //hour
            hour = hour % 12;
            hour = (hour * Math.PI / 6) +
    (minute * Math.PI / (6 * 60)) +
    (second * Math.PI / (360 * 60));
            drawHand(ctx, hour, radius * 0.5, radius * 0.07);
            //minute
            minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
            drawHand(ctx, minute, radius * 0.8, radius * 0.07);
            // second
            second = (second * Math.PI / 30);
            drawHand(ctx, second, radius * 0.9, radius * 0.02);
        }

        function drawHand(ctx, pos, length, width) {
            ctx.beginPath();
            ctx.lineWidth = width;
            ctx.lineCap = "round";
            ctx.moveTo(0, 0);
            ctx.rotate(pos);
            ctx.lineTo(0, -length);
            ctx.stroke();
            ctx.rotate(-pos);
        }
</script>



    </form>
</body>
</html>