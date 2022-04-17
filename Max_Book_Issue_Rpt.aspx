<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Max_Book_Issue_Rpt.aspx.cs" Inherits="Max_Book_Issue_Rpt" %>

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
                dateFormat: "dd/mm/yy",
                buttonImageOnly: true,
                buttonImage: 'images/calendar.png'
            });
        });
    </script>

     <script type="text/javascript">
         $(function () {
             $("[id*=TextBox1]").datepicker({
                 showOn: 'button',
                 dateFormat: "dd/mm/yy",
                 buttonImageOnly: true,
                 buttonImage: 'images/calendar.png'
             });
         });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #5de66e;color: white;font-style: oblique;font-variant: all-small-caps;font-size: smaller;">
            <h1>Maximum number of books issued from " Category " </h1>
        
                <hr />
        </div>
          <div>    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#3399FF" OnClick="LinkButton1_Click">Home</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="#0099FF" OnClick="LinkButton2_Click">All Reports</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton2" runat="server" Height="36px" ImageUrl="~/excel_for_ipad.png" OnClick="ImageButton1_Click" Width="69px" /></div>
       <br />
        
        <p style="font-size: x-large;font-style: italic;">Catgeory:</p>
        <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FFFF99" Font-Bold="True" Height="19px" Width="213px"></asp:DropDownList><br />
        <br /><br />
        <br />
        <br />
        <div style="text-align: -moz-center;"><asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
             <FooterStyle BackColor="White" ForeColor="#000066" />
             <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
             <RowStyle ForeColor="#000066" />
             <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#007DBB" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView></div>
        

    </form>
</body>
</html>