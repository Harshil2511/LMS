<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="receive_book_status.aspx.cs" Inherits="receive_book_status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <div style="text-align:center"><strong>Book Received Form</strong> </div>
<asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
    <Columns>
        <asp:BoundField HeaderStyle-Width="150px" DataField="Issue_id" HeaderText="Issue_id">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="Book_id" HeaderText="Book_id">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="book_name" HeaderText="book_name">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="employee_id" HeaderText="employee_id">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="emp_mail_id" HeaderText="emp_mail_id">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="Book_status" HeaderText="Book_status">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="fdate" HeaderText="fdate">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="tdate" HeaderText="tdate">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="bar_code" HeaderText="bar_code">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

         <asp:BoundField HeaderStyle-Width="150px" DataField="req_id" HeaderText="req_id">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>


         <asp:BoundField HeaderStyle-Width="150px" DataField="user_receipt_status" HeaderText="Acknowledgement">
            <HeaderStyle Width="150px"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>

             <asp:TemplateField HeaderText="SelectOne">
        <ItemTemplate>
         <%-- <input name="MyRadioButton" type="radio" value='<%# Eval("Book_id") %>' />--%>
            <asp:CheckBox ID="CheckBox1" runat="server" />
          <%-- <input name="MyRadioButtonn" type="radio" value='<%# Eval("Book_title") %>' />--%>
        </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>



    </Columns>

</asp:GridView>

    <br />

    <asp:Button ID="Button1" runat="server" Text="Received" OnClick="Button1_Click" />
</asp:Content>


