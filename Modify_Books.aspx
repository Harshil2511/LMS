<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Modify_Books.aspx.cs" Inherits="Modify_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css" >
        .auto-style1 {
            height: 28px;
        }
        .auto-style2 {
            width: 166px;
        }
        .auto-style3 {
            height: 28px;
            width: 166px;
        }
       
   /*#Content1
   {
       HEIGHT:300PX;  
       OVERFLOW-Y:SCROLL
   }*/




        .auto-style4 {
            width: 64px;
        }
        .auto-style5 {
            height: 28px;
            width: 64px;
        }




    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <div style="text-align:center"><asp:Label ID="Label3" runat="server" Text="Modify Book" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF" Font-Italic="True"></asp:Label></div>
   <br />
   <%-- <%--<asp:Label ID="Label1" runat="server" Text="Search" Font-Bold="True"></asp:Label> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Search" Font-Bold="True"></asp:Label> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Catgeory"></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Height="29px" Width="226px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ForeColor="Blue">
       <%-- <asp:ListItem></asp:ListItem>
        <asp:ListItem>Business Management</asp:ListItem>
        <asp:ListItem>Character Building</asp:ListItem>
        <asp:ListItem>Environment</asp:ListItem>
        <asp:ListItem>Health</asp:ListItem>
        <asp:ListItem>Inspirational</asp:ListItem>
        <asp:ListItem>Life Improvement</asp:ListItem>
        <asp:ListItem>Mind Management</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
        <asp:ListItem>Safety</asp:ListItem>--%>
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Font-Bold="True" ForeColor="#339966" Width="68px" Height="26px" />
   <asp:Label ID="Label2" runat="server" Text="No macthed found" Font-Bold="True" ForeColor="Red"></asp:Label>

    <div id="bhjy" style="height:300px;overflow-y:scroll">
    <%--<table align="center" class="style1" style="border: 6px inset;margin-left: 16%;color: #4974a2 ">--%>
         <table align="center" class="style1" style="border-style: inset; border-color: inherit; border-width: 6px; color: #4974a2; width:150%">
<tr>
<%--<td colspan="2" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; color: unset; background-color: snow; font-size: initial; font-family: -webkit-pictograph;">
    &nbsp;<br />
    </td>--%>
<%--</tr>--%>
<%--<tr>--%>
<%--<td class="auto-style2">--%>
    &nbsp;&nbsp;<%--<asp:Label ID="Label1" runat="server" Text="Search Book" Font-Bold="True"></asp:Label>--%>
    &nbsp;&nbsp;&nbsp;
    <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Font-Bold="True" ForeColor="#339966" Width="68px" />--%><%--<asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Get Book" Font-Bold="True" ForeColor="#339966" Width="68px" />--%>
    &nbsp;&nbsp;&nbsp;<br />
&nbsp;
    <%--</td>--%>
<%--</tr>--%>
<%--<tr>--%>
<%--<td class="auto-style2">
</td>
<td class="auto-style4">
    &nbsp;</td>--%>
</tr>
<tr>
<td class="auto-style2">
    <%--<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" Width="1200px">
         <Columns>
    <asp:BoundField HeaderStyle-Width="40px" DataField="Book_id" HeaderText="Book id" ItemStyle-CssClass="ContactName" >
<HeaderStyle Width="27px" BackColor="#66CCFF"></HeaderStyle>

<ItemStyle CssClass="ContactName" BackColor="#FFCCCC" Font-Bold="True"></ItemStyle>
             </asp:BoundField>
    <asp:BoundField HeaderStyle-Width="150px" DataField="Book_title" HeaderText="Book" >
<HeaderStyle Width="150px" BackColor="#66CCFF" HorizontalAlign="Center"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" Font-Bold="True"  />
             </asp:BoundField>

                <asp:BoundField HeaderStyle-Width="160px" DataField="Catgeory" HeaderText="Catgeory" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="50px" Font-Bold="True" HorizontalAlign="Center"  />
             </asp:BoundField>

    <asp:BoundField HeaderStyle-Width="150px" DataField="Author" HeaderText="Author" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" Font-Bold="True" />
             </asp:BoundField>
             <asp:BoundField HeaderStyle-Width="40px" DataField="pricing" HeaderText="Price" >
<HeaderStyle Width="60px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

               <asp:BoundField HeaderStyle-Width="60px" DataField="avail_status" HeaderText="Status" >
<HeaderStyle Width="100px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>
           
</Columns></asp:GridView>--%>
    
 <%-- <asp:GridView ID="GridView1" runat="server" DataKeyNames="Book_id" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="True" AutoGenerateDeleteButton="True" AutoGenerateColumns="False" AllowPaging="True" Width="98%">--%>
     <asp:GridView ID="GridView1" runat="server" DataKeyNames="Book_id" OnRowDataBound="OnRowDataBound" OnPageIndexChanging="OnPageIndexChanging" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="True" AutoGenerateDeleteButton="False" AutoGenerateColumns="False" AllowPaging="True" Width="98%">
<Columns>
    <asp:BoundField HeaderStyle-Width="40px" DataField="Book_id" HeaderText="Id" ItemStyle-CssClass="ContactName" >
<HeaderStyle Width="80px" BackColor="#66CCFF"></HeaderStyle>

<ItemStyle CssClass="ContactName" BackColor="#FFCCCC" Font-Bold="True"></ItemStyle>
             </asp:BoundField>
    <asp:BoundField HeaderStyle-Width="150px" DataField="Book_title" HeaderText="Book" >
<HeaderStyle Width="250px" BackColor="#66CCFF" HorizontalAlign="Center"></HeaderStyle>
             <ItemStyle width="14%" HorizontalAlign="Left" Font-Bold="True"  />
             </asp:BoundField>

              <%--  <asp:BoundField HeaderStyle-Width="160px" DataField="Catgeory" HeaderText="Catgeory" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="50px" Font-Bold="True" HorizontalAlign="Center"  />
             </asp:BoundField>--%>

    <asp:BoundField HeaderStyle-Width="150px" DataField="Author" HeaderText="Author" >
<HeaderStyle Width="150px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle width="14%" HorizontalAlign="Left" Font-Bold="True" />
             </asp:BoundField>
             <asp:BoundField HeaderStyle-Width="40px" DataField="pricing" HeaderText="Price" >
<HeaderStyle Width="60px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>

       <asp:BoundField HeaderStyle-Width="160px" DataField="contents" HeaderText="Content" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="40%" Font-Bold="True" HorizontalAlign="Left"  />
             </asp:BoundField>

    <asp:BoundField HeaderStyle-Width="160px" DataField="b_location" HeaderText="Almirah" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="10%" Font-Bold="True" HorizontalAlign="Left"  />
             </asp:BoundField>

    <asp:BoundField HeaderStyle-Width="160px" DataField="b_loc" HeaderText="Self" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="5%" Font-Bold="True" HorizontalAlign="Left"  />
             </asp:BoundField>

    <asp:TemplateField HeaderText="Category">  
                            <EditItemTemplate>  
                                <asp:DropDownList ID="DropDownList2" runat="server"   
SelectedValue='<%# Bind("catgeory") %>'>  
                                    <asp:ListItem>Business Management</asp:ListItem>
        <asp:ListItem>Character Building</asp:ListItem>
        <asp:ListItem>Environment</asp:ListItem>
        <asp:ListItem>Health</asp:ListItem>
        <asp:ListItem>Inspirational</asp:ListItem>
        <asp:ListItem>Life Improvement</asp:ListItem>
        <asp:ListItem>Mind Management</asp:ListItem>
        <%--<asp:ListItem>Others</asp:ListItem>--%>
        <asp:ListItem>Safety</asp:ListItem>
                                </asp:DropDownList>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("catgeory") %>'>  
                                </asp:Label>  
                            </ItemTemplate>  
                            <HeaderStyle BackColor="#66CCFF" />
                            <ItemStyle Width="30%" />
                        </asp:TemplateField>  

     <asp:BoundField HeaderStyle-Width="160px" DataField="o_catgeory" HeaderText="Book Source" >
<HeaderStyle Width="160px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle Width="50px" Font-Bold="True" HorizontalAlign="Center"  />
             </asp:BoundField>



         

              <%-- <asp:BoundField HeaderStyle-Width="60px" DataField="avail_status" HeaderText="Status" >
<HeaderStyle Width="100px" BackColor="#66CCFF"></HeaderStyle>
             <ItemStyle HorizontalAlign="Center" />
             </asp:BoundField>--%>
           
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