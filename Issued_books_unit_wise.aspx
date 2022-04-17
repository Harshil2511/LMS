<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Issued_books_unit_wise.aspx.cs" Inherits="Issued_books_unit_wise" %>

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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div style="text-align:center"><asp:Label ID="Label2" runat="server" Text="Issued Books" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
    <div id="bhjy" style="height:300px;overflow-y:scroll">
        
   <%-- <table align="center" class="style1" style="border: 6px inset;margin-left: 16%;color: #4974a2 ">--%>
        <table align="center" class="style1" style="border: 6px inset;color: #4974a2;width: 99%; ">
<%--<tr>--%>
<%--<td colspan="2" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; color: unset; background-color: snow; font-size: initial; font-family: -webkit-pictograph;">
    Book Issue Request<br />
    </td>--%>
<%--</tr>--%>
<tr>
<td class="auto-style2">
    &nbsp;&nbsp; 
    
    </td>
</tr>
<tr>
<td class="auto-style2">
    <asp:GridView ID="GridView1" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging"   runat="server" PageSize="4">
        <Columns>
            
            <asp:BoundField HeaderStyle-Width="102px" DataField="Issue_id" HeaderText="Issue Id">
                 <HeaderStyle Width="59px" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" BackColor="#FFCCCC" Font-Bold="True" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="req_id" HeaderText="Request Id">
                 <HeaderStyle Width="74" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book Id">
                 <HeaderStyle Width="72" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

             <asp:BoundField HeaderStyle-Width="150px" DataField="bar_code" HeaderText="BarCode">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="book_name" HeaderText="Book Title">
                 <HeaderStyle Width="130" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="Employee Id">
                 <HeaderStyle Width="92" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            
             <asp:BoundField HeaderStyle-Width="150px" DataField="emp_name" HeaderText="Emp Name">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="emp_mail_id" HeaderText="Mail Id">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

           <%-- <asp:BoundField HeaderStyle-Width="150px" DataField="receipt_stat" HeaderText="R_Status">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>--%>

            <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="Issued Date" DataFormatString="{0:d}">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="To Date"  DataFormatString="{0:d}">
                 <HeaderStyle Width="157" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
             </asp:BoundField>

            <asp:BoundField HeaderStyle-Width="150px" DataField="ret_dte" HeaderText="Return Date">
                 <HeaderStyle Width="90" BackColor="#66CCFF"></HeaderStyle>
                 <ItemStyle HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>

            




        </Columns>
         



    </asp:GridView>
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

