<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="ModifyBooksLib.aspx.cs" Inherits="ModifyBooksLib" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">

   <div style="text-align:center"><asp:Label ID="Label10" runat="server" Text="Modify Book" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
    <table style="">
        <tr>
            <td>
                 <asp:Label ID="Label11" runat="server" Text="Book Id:" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" Width="290px" ReadOnly></asp:TextBox>

            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Book Title:" Font-Bold="True"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="290px"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Description:" Font-Bold="True"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="TextBox4" runat="server" Height="70px" Width="290px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Author:" Font-Bold="True"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="290px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Cost:" Font-Bold="True"></asp:Label>
            </td>

            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>

       

         <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Catgeory:" Font-Bold="True"></asp:Label>
            </td>

            <td>
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Width="290px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Book Source:" Font-Bold="True"></asp:Label>
            </td>

            <td>
                <asp:RadioButton ID="RadioButton1" GroupName="jkl" runat="server" Font-Bold="True" Text="   Purchaase" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton2" GroupName="jkl" runat="server" Font-Bold="True" Text="   Gifted" />

            </td>
            
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Book Location:" Font-Bold="True"></asp:Label>
            </td>
            <td>

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Label ID="Label8" runat="server" Text="Almirah:" Font-Bold="True"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox8" runat="server" Width="42px"></asp:TextBox>
            
            </td>

            <td>
                <asp:Label ID="Label9" runat="server" Text="Shelf:" Font-Bold="True"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox7" runat="server" Width="42px"></asp:TextBox>
            </td>
        </tr>



    </table>
    
    <div style="text-align:center">
        <asp:Button ID="Button2" runat="server" Height="29px" Width="64px" Font-Bold="True" Text="Search" OnClick="Button2_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Modify" Height="29px" Width="64px" Font-Bold="True" OnClick="Button1_Click" />
    </div>
    <br />
         <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="3" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
              <Columns>
                  <asp:BoundField DataField="Book_id" HeaderText="Id" ItemStyle-Width="60" >
<ItemStyle Width="60px"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="Book_title" HeaderText="Book Title" ItemStyle-Width="200" >
<ItemStyle Width="200px"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField DataField="contents" HeaderText="Description" ItemStyle-Width="200" >
<ItemStyle Width="340px"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="Author" HeaderText="Author" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                  </asp:BoundField>
                   <asp:BoundField DataField="catgeory" HeaderText="catgeory" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="pricing" HeaderText="Cost" ItemStyle-Width="50" >
<ItemStyle Width="50px"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="o_catgeory" HeaderText="Book Source" ItemStyle-Width="150" >
<ItemStyle Width="150px"></ItemStyle>
                  </asp:BoundField>
                 <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="150" HeaderText="Edit" >
<ItemStyle Width="150px"></ItemStyle>
                  </asp:ButtonField>
                   </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="3" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
            
        </div>
</asp:Content>

