<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Receipt_Book.aspx.cs" Inherits="Receipt_Book" %>

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
    <div style="text-align:center"><asp:Label ID="Label4" runat="server" Text="Book Return" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
   <div><asp:Label ID="Label2" runat="server" Text="BarCode" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="117px"></asp:TextBox>&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Check" Font-Bold="True" ForeColor="#339966" Width="64px" OnClick="Button1_Click1" />&nbsp;&nbsp;&nbsp; <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Reciept" Font-Bold="True" ForeColor="#339966" Width="67px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Extend date" Font-Bold="True" ForeColor="#339966" Width="90px" OnClick="Button2_Click" /></div><br />
    <div><asp:Label ID="Label5" runat="server" Text="Days" Font-Bold="True"></asp:Label>&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
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
    </asp:DropDownList>&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server" Width="38px" ReadOnly Enabled="False"></asp:TextBox>
        <br />
        <br />
    </div>

    <div><asp:Label ID="Label3" runat="server" Text="Book Condition" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="RadioButton1" runat="server" GroupName="th" Text="  Lost" />&nbsp;&nbsp; <asp:RadioButton ID="RadioButton2" runat="server" GroupName="th" Text="  Scrapped" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Black" OnClick="LinkButton1_Click">Clear</asp:LinkButton></div><br />
    <div><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
     <div id="bhjy" style="height:300px;overflow-y:scroll">
   <%-- <table align="center" class="style1" style="border: 6px inset;margin-left: 16%;color: #4974a2 ">--%>
        <table align="center" class="style1" style="border: 6px inset;color: #4974a2;width:99% ">
<%--<tr>
<td colspan="2" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; color: unset; background-color: snow; font-size: initial; font-family: -webkit-pictograph;">
    </td>
</tr>--%>
<%--<tr>
<td class="auto-style2">
    &nbsp;&nbsp;<br />
    
    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
    &nbsp;
            
    <%--</td>--%>
<%--</tr>--%>
<%--<tr>--%>
<%--<td class="auto-style6">
    

&nbsp;

</td>--%>
<%--<td class="auto-style7">--%>
    <%--</td>--%>
<%--</tr>--%>
<tr>

<td class="auto-style2">
    <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" Width="100%" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged" AllowPaging="True" PageSize="5" >
         <Columns>

    <asp:BoundField HeaderStyle-Width="150px" DataField="Issue_id" HeaderText="Issue_id" >
<HeaderStyle Width="79px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" BackColor="#FFCCCC" />
             </asp:BoundField>
    <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book_id" >
<HeaderStyle Width="97px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" BackColor="#FFCCCC"/>
             </asp:BoundField>

              <asp:BoundField HeaderStyle-Width="150px" DataField="req_id" HeaderText="Requset_id">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                 <asp:BoundField HeaderStyle-Width="150px" DataField="bar_code" HeaderText="Bar_code">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

    <asp:BoundField HeaderStyle-Width="150px" DataField="Book_name" HeaderText="Title" >
<HeaderStyle Width="309px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle width="12%" HorizontalAlign="Left" />
             </asp:BoundField>

              <asp:BoundField HeaderStyle-Width="150px" DataField="Author" HeaderText="Author" >
<HeaderStyle Width="309px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="20%" HorizontalAlign="Left" />
             </asp:BoundField>



             <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="Employee_id">
                 <HeaderStyle Width="137px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="150px" DataField="emp_mail_id" HeaderText="Emp_mail_id">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="150px" DataField="Book_status" HeaderText="Book_status">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="Issued Date">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                 <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="tdate">
                 <HeaderStyle Width="294px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>

                <%-- <asp:BoundField HeaderStyle-Width="150px" DataField="bar_code" HeaderText="Bar_code">
                 <HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" />
             </asp:BoundField>--%>

                
            <%--  <asp:BoundField HeaderStyle-Width="150px" DataField="unit_code" HeaderText="unit_code" >
<HeaderStyle Width="150px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="Fromdate" >
<HeaderStyle Width="150px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="ToDate" >
<HeaderStyle Width="150px"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>

               <asp:TemplateField HeaderText="SelectOne">
        <ItemTemplate>
         <%-- <input name="MyRadioButton" type="radio" value='<%# Eval("Book_id") %>' />--%>
            <asp:CheckBox ID="CheckBox1" runat="server" />
          <%-- <input name="MyRadioButtonn" type="radio" value='<%# Eval("Book_title") %>' />--%>
        </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>
             <%--<asp:TemplateField HeaderText="SelectOne">
        <ItemTemplate>--%>
          <%--<input name="MyRadioButton" type="radio" value='<%# Eval("Book_id") %>' />--%>
          <%-- <input name="MyRadioButtonn" type="radio" value='<%# Eval("Book_title") %>' />--%>
       <%-- </ItemTemplate>
      </asp:TemplateField>--%>
              
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
          <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
   
</asp:Content>
