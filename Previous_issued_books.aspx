<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Previous_issued_books.aspx.cs" Inherits="Previous_issued_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" >
        .auto-style2 {
            width: 203px;
        }
               
   /*#Content1
   {
       HEIGHT:300PX;  
       OVERFLOW-Y:SCROLL
   }*/




        .auto-style4 {
            width: 44px;
        }
        



    </style>
   <%-- <script type = "text/javascript">

        function RadioCheck(rb) {

            var gv = document.getElementById("<%=gvCustomers.ClientID%>");

         var rbs = gv.getElementsByTagName("input");



         var row = rb.parentNode.parentNode;

         for (var i = 0; i < rbs.length; i++) {

             if (rbs[i].type == "radio") {

                 if (rbs[i].checked && rbs[i] != rb) {

                     rbs[i].checked = false;

                     break;

                 }

             }

         }

     }

</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <div style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Previous Books Issued" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
     <%--<asp:Calendar ID="datepicker" runat="server" visible="False" OnSelectionChanged="datepicker_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="151px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="216px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>--%>
    
<asp:Label ID="Label3" runat="server" Text="Days" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" BackColor="#FFFF99" >
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
    </asp:DropDownList>    &nbsp;&nbsp;&nbsp;    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" Width="38px" BackColor="#FFFF99"></asp:TextBox>&nbsp;&nbsp; <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Get Date</asp:LinkButton>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Submit" Font-Bold="True" ForeColor="#339966" Width="65px" Height="27px" />
    <br />
    <%--<br />--%>
    <div><asp:Label ID="Label4" runat="server" Text="Search Book" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" BackColor="#FFFF99" Font-Bold="True" ForeColor="Blue"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" BackColor="Yellow" Font-Bold="True" Font-Underline="False" OnClick="LinkButton1_Click">Click to Search</asp:LinkButton>&nbsp;&nbsp;&nbsp; </div>
    <br />
    <div style="background-color: chartreuse;
    font-size: large;width: 20%;"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Generate Request</asp:LinkButton></div>
    <div id="bhjy" style="height:300px;overflow-y:scroll">
        
   <%-- <table align="center" class="style1" style="border: 6px inset;margin-left: 16%;color: #4974a2 ">--%>
        <table align="center" class="style1" style="border: 6px inset;color: #4974a2;width: 99% ">
<%--<tr>--%>
<%--<td colspan="2" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; color: unset; background-color: snow; font-size: initial; font-family: -webkit-pictograph;">
    Book Issue Request<br />
    </td>--%>
<%--</tr>--%>
<%--<tr>--%>
<%--<td class="auto-style2">--%>
    <%--<asp:Calendar ID="datepicker" runat="server" visible="False" OnSelectionChanged="datepicker_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="151px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="216px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Get Date</asp:LinkButton>--%>
    
    <%--</td>--%>
<%--</tr>--%>
<tr>
<td class="auto-style2">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" Width="108%" >
         <Columns>
            <%-- <asp:TemplateField>

<ItemTemplate>

    <asp:RadioButton ID="RadioButton1" runat="server" onclick = "RadioCheck(this);"/>

    <asp:HiddenField ID="HiddenField1" runat="server"

        Value = '<%#Eval("Book_id")%>' />

</ItemTemplate>

</asp:TemplateField>--%>
            <%-- <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book id" ItemStyle-CssClass="ContactName">
                 <HeaderStyle Width="150px"></HeaderStyle>
                 <ItemStyle CssClass="ContactName" Font-Bold="False"></ItemStyle>
             </asp:BoundField>--%>
            <%-- <asp:TemplateField HeaderText="SelectOne">
                 <ItemTemplate>--%>
                     <%--<asp:CheckBox ID="chkSelect" runat="server" />--%>
                   <%--  <input id="radg" name="MyRadioButton" type="radio" 

                    value='<%# Eval("Book_id") %>' />--%>
                <%-- </ItemTemplate>
                 <HeaderStyle BackColor="#66CCFF" />
                 <ItemStyle HorizontalAlign="Center" />--%>
             <%--</asp:TemplateField>--%>
              <asp:BoundField HeaderStyle-Width="102px" DataField="Book_id" HeaderText="Book Id">
                 <HeaderStyle Width="95px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" BackColor="#FFCCCC" Font-Bold="True" />
             </asp:BoundField>
             <asp:BoundField HeaderStyle-Width="150px" DataField="Book_name" HeaderText="Book Name">
                 <HeaderStyle Width="318" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
             </asp:BoundField>
    <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="Employee_Id" >
<HeaderStyle Width="300" BackColor="#66CCFF"></HeaderStyle>
        <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
             </asp:BoundField>

               <asp:BoundField HeaderStyle-Width="150px" DataField="req_status" HeaderText="Request Status" >
<HeaderStyle Width="242px" BackColor="#66CCFF"></HeaderStyle>
                  <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
             </asp:BoundField>

           <%--  <asp:BoundField HeaderStyle-Width="150px" DataField="Book_status" HeaderText="Status" >
<HeaderStyle Width="102px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>
            
<%--             <asp:BoundField HeaderStyle-Width="150px" DataField="avail_status" HeaderText="Status" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

               <asp:BoundField HeaderStyle-Width="150px" DataField="next_avail_date" HeaderText="Avail Date" DataFormatString="{0:d}" >
<HeaderStyle Width="121px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

               <asp:BoundField HeaderStyle-Width="150px" DataField="barcode" HeaderText="BarCode" >
<HeaderStyle Width="113px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>

          
              
</Columns></asp:GridView>

    <asp:GridView ID="GridView1"  runat="server"></asp:GridView>
</td>
<td class="auto-style4">
    &nbsp;</td>
</tr>
<%--<tr>
<td class="auto-style2">
    &nbsp;</td>
<td class="auto-style4">
    &nbsp;</td>
</tr>--%>


<%--<tr>--%>
<%--<td class="auto-style3">--%>

    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Book" Font-Bold="True" ForeColor="#339966" Width="68px" />--%>
 
    <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
<%--</td>--%>
<%--<td class="auto-style5">
    </td>--%>
<%--</tr>--%>


<%--<tr>
<td class="auto-style1" colspan="2">
    &nbsp;</td>
</tr>--%>

</table>
      <div style="color:green"><b><asp:Label ID="Label1" runat="server" Text="Label"></b></asp:Label></div> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--<asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Send" Font-Bold="True" ForeColor="#339966" Width="47px" Height="34px" />--%>
        </div>
    
    </b>
    
</asp:Content>
