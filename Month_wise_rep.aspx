<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Month_wise_rep.aspx.cs" Inherits="Month_wise_rep" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input[type=text]
        {
            margin-right:5px;
            position:relative;
            top:-2px
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=txtDate]").datepicker({
                showOn: 'button',
                dateFormat: "yy-mm-dd",
                buttonImageOnly: true,
                buttonImage: 'images/calendar.png'
            });
        });
    </script>

     <script type="text/javascript">
         $(function () {
             $("[id*=TextBox1]").datepicker({
                 showOn: 'button',
                 dateFormat: "yy-mm-dd",
                 buttonImageOnly: true,
                 buttonImage: 'images/calendar.png'
             });
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #5de66e;color: white;font-style: oblique;font-variant: all-small-caps;font-size: smaller;">
            <h1>Total No. of Books issued during the month</h1>
        
                <hr />
        </div>
    
        <div>    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Bold="True" ForeColor="#3399FF">Home</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="#0099FF" OnClick="LinkButton2_Click">All Reports</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton1" runat="server" Height="36px" ImageUrl="~/excel_for_ipad.png" OnClick="ImageButton1_Click" Width="69px" /></div>
        <br />
        <p style="font-size: smaller;">From Date:</p>
    <asp:TextBox ID="txtDate" runat="server" ReadOnly = "true"></asp:TextBox><br />
        <p style="font-size: smaller;"">To Date:</p>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true"></asp:TextBox><br /><br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" Font-Bold="true" />   &nbsp;   &nbsp;   
        <br />
        
        
        <br />
         <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" CellSpacing="2">
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
             <RowStyle BackColor="White" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </form>
</body>
</html>
