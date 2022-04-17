<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" EnableEventValidation ="false" AutoEventWireup="true" CodeFile="CheckRequestEmployee.aspx.cs" Inherits="CheckRequestEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" >
        .auto-style1 {
            height: 28px;
        }
        .auto-style2 {
            width: 203px;
        }
        .auto-style3 {
            height: 28px;
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
        .auto-style5 {
            height: 28px;
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
    <div style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Pending Requests" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
    <asp:Label ID="Label1" runat="server" Text="EmpCode" Font-Bold="True"></asp:Label>
    
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="117px"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="BarCode" Font-Bold="True"></asp:Label> &nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="117px"></asp:TextBox><asp:Calendar ID="datepicker" runat="server" visible="False" OnSelectionChanged="datepicker_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="109px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="140px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
    
    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Date</asp:LinkButton>--%><asp:Label ID="Label5" runat="server" Text="Days" Font-Bold="True"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>0</asp:ListItem>
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
    </asp:DropDownList>&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" Width="38px" ReadOnly></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Submit" Font-Bold="True" ForeColor="#339966" Width="87px" Height="30px" />
    <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>&nbsp;&nbsp; 
    <asp:Label ID="lblDifference" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <div id="bhjy" style="height:300px;overflow-y:scroll">
   <%-- <table align="center" class="style1" style="border: 6px inset;margin-left: 16%;color: #4974a2 ">--%>
        <table align="center" class="style1" style="border: 6px inset;color: #4974a2 ; width:99%">
<%--<tr>
<td colspan="2" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; color: unset; background-color: snow; font-size: initial; font-family: -webkit-pictograph;">
    &nbsp;<br />
    </td>
</tr>--%>
<%--<tr>--%>
<%--<td class="auto-style2">--%>
    <%--<asp:Label ID="Label1" runat="server" Text="EmpCode" Font-Bold="True"></asp:Label>
    
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="117px"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="BarCode" Font-Bold="True"></asp:Label> &nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="117px"></asp:TextBox><asp:Calendar ID="datepicker" runat="server" visible="False" OnSelectionChanged="datepicker_SelectionChanged" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="109px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="140px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
        <DayStyle Width="14%" />
        <NextPrevStyle Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
        <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        <TodayDayStyle BackColor="#CCCC99" />
    </asp:Calendar>
    
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Date</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="109px"></asp:TextBox>
     <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Submit" Font-Bold="True" ForeColor="#339966" Width="82px" />
    <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%> <%--<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblDifference" runat="server" Text="Label"></asp:Label>--%>
    <%--</td>--%>
<%--</tr>--%>
<tr>
<td class="auto-style2">
</td>
<td class="auto-style4">
    &nbsp;</td>
</tr>
<tr>
<td class="auto-style2">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" Width="106%" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged" AllowPaging="True" PageSize="4" >
         <Columns>

    <asp:BoundField HeaderStyle-Width="150px" DataField="Request_id" HeaderText="Request_id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" BackColor="#FFCCCC" />
             </asp:BoundField>
                  <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book_Id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

              <asp:BoundField HeaderStyle-Width="150px" DataField="bar_code" HeaderText="Bar_code" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>
             
    <asp:BoundField HeaderStyle-Width="150px" DataField="book_name" HeaderText="Book_name" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="author_name" HeaderText="Author" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="Employee_id">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

              <asp:BoundField HeaderStyle-Width="150px" DataField="emp_name" HeaderText="Employee name" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

        
           <%--   <asp:BoundField HeaderStyle-Width="150px" DataField="unit_code" HeaderText="unit_code" >
<HeaderStyle Width="150px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>

                <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="Request Date" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <%--DataFormatString="{0:d}"--%>

                <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="ToDate" DataFormatString="{0:d}" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             

              <asp:BoundField HeaderStyle-Width="150px" DataField="req_days" HeaderText="Days" >
<HeaderStyle Width="60px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

               <asp:TemplateField HeaderText="SelectOne">
        <ItemTemplate>
         <%-- <input name="MyRadioButton" type="radio" value='<%# Eval("Book_id") %>' />--%>
           <%-- <asp:CheckBox ID="CheckBox1" runat="server" />--%>
             <input id="radg" name="MyRadioButton" type="radio" 

                    value='<%# Eval("Request_id") %>' />
          <%-- <input name="MyRadioButtonn" type="radio" value='<%# Eval("Book_title") %>' />--%>
        </ItemTemplate>
                   <HeaderStyle BackColor="#66CCFF" />
                 <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
             <%--<asp:TemplateField HeaderText="SelectOne">
        <ItemTemplate>--%>
          <%--<input name="MyRadioButton" type="radio" value='<%# Eval("Book_id") %>' />--%>
          <%-- <input name="MyRadioButtonn" type="radio" value='<%# Eval("Book_title") %>' />--%>
       <%-- </ItemTemplate>
      </asp:TemplateField>--%>
              
</Columns></asp:GridView>

    <br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False">
        <Columns>
         <asp:BoundField HeaderStyle-Width="150px" DataField="Request_id" HeaderText="Request_id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" BackColor="#FFCCCC" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="Employee_id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="emp_name" HeaderText="Employee_name" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="book_name" HeaderText="Book_name" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book_Id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

           <%-- <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book_Id" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>

              <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="From date" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="To date" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

            </Columns>



    </asp:GridView>


</td>
<td class="auto-style4">
    &nbsp;</td>
</tr>
<tr>
<td class="auto-style2">
    &nbsp;</td>
<td class="auto-style4">
    &nbsp;</td>
</tr>


<tr>
<td class="auto-style3">

    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Book" Font-Bold="True" ForeColor="#339966" Width="68px" />--%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <%--<asp:Button ID="Button2" runat="server" Font-Bold="True" ForeColor="#339966" Text="Back" Width="58px" />--%>

</td>
<td class="auto-style5">
    </td>
</tr>


<tr>
<td class="auto-style1" colspan="2">
    &nbsp;</td>
</tr>

</table>
        </div>
</asp:Content>
