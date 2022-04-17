<%@ Page Title="" Language="C#" MasterPageFile="~/lms.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
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
        .auto-style4 {
            height: 22px;
        }
        .auto-style5 {
            width: 166px;
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <table align="center" class="style1" style="border: 6px inset;margin-left: 31%;color: #4974a2 ;background-color:aliceblue ">
<tr>
<td colspan="3" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">
Add Book</td>
</tr>
<tr>
<td class="style5">
&nbsp;</td>
<td class="auto-style2">
    &nbsp;</td>
<td>
    &nbsp;</td>
</tr>
<tr>
<td class="style6">
<b>Book Title :</b>
</td>
<td class="auto-style2">
<asp:TextBox ID="txtfname" runat="server" Width="424px" autocomplete="off" ></asp:TextBox>
</td>
<td>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
ControlToValidate="txtfname" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%><asp:Label ID="Label3" runat="server" Text="*"></asp:Label>
</td>
</tr>
<tr>
<td class="style6">
<b>Description :</b>
</td>
<td class="auto-style2">
<asp:TextBox ID="txtlname" runat="server" Width="424px" Height="16px" autocomplete="off"></asp:TextBox>
</td>
<td>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
ControlToValidate="txtlname" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
</td>
</tr>
<tr>
<td class="style6">
<b>Author :</b>
</td>
<td class="auto-style2">
<asp:TextBox ID="txtcity" runat="server" Width="424px" autocomplete="off"></asp:TextBox>
</td>
<td>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
ControlToValidate="txtcity" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%><asp:Label ID="Label5" runat="server" Text="*"></asp:Label>
</td>
</tr>
<tr>
<td class="style6">
<b>Cost :</b>
</td>
<td class="auto-style2">
    <asp:TextBox ID="txtemail" runat="server" Width="424px" autocomplete="off"></asp:TextBox>
    </td>
<td>
    <asp:Label ID="Label4" runat="server" Text="*"></asp:Label>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
ControlToValidate="txtemail" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
ControlToValidate="txtemail" ErrorMessage="invalid email" ForeColor="Red" 
ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
</td>
</tr>
         <tr>
<td class="style6">
<b>Book Source :</b>
</td>
<td class="auto-style2">
<asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" GroupName="wsx" Text="     Purchase"/>&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" GroupName="wsx" Text="     Gifted"/>
&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="200px" autocomplete="off"></asp:TextBox>
</td>
<td>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
ControlToValidate="txtfname" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%><asp:Label ID="Label8" runat="server" Text="*"></asp:Label>
</td>
</tr>
<tr>
<td class="auto-style4">
   <b>Category:</b> &nbsp; </td>
<td class="auto-style5">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" Height="27px" Width="226px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ForeColor="Blue">
        <%--<asp:ListItem>Business Management</asp:ListItem>
        <asp:ListItem>Character Building</asp:ListItem>
        <asp:ListItem>Environment</asp:ListItem>
        <asp:ListItem>Health</asp:ListItem>
        <asp:ListItem>Inspirational</asp:ListItem>
        <asp:ListItem>Life Improvement</asp:ListItem>
        <asp:ListItem>Mind Management</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
        <asp:ListItem>Safety</asp:ListItem>--%>
    </asp:DropDownList>&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" OnClick="LinkButton1_Click">Add new Category</asp:LinkButton> <asp:TextBox ID="TextBox4" runat="server" Width="223px" BackColor="#99FF33"></asp:TextBox> &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" OnClick="LinkButton2_Click">SAVE</asp:LinkButton>
</td>
<td class="auto-style4">
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
ControlToValidate="DropDownList1" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
</td>
</tr>

       

        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Book Location:" Font-Bold="True"></asp:Label></td>
            <td>
                
                &nbsp;&nbsp;
                
                <asp:Label ID="Label6" runat="server" Text="Almirah" Font-Bold="True"></asp:Label>&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="50px" autocomplete="off" Height="20px"></asp:TextBox>&nbsp; <asp:Label ID="Label7" runat="server" Text="Shelf" Font-Bold="True"></asp:Label>&nbsp; <asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="50px" autocomplete="off"></asp:TextBox>
            </td>
             <td>*</td>

        </tr>

        <tr>
<td class="style6">
    <b>Bar Code:</b></td>
<td class="auto-style2">
<asp:TextBox ID="barcode" runat="server" Width="424px" autocomplete="off" Enabled="False"></asp:TextBox>
</td>
<td>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
ControlToValidate="barcode" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>--%></td>
</tr>


<tr>
<td class="auto-style1">
    </td>
<td class="auto-style3">
<asp:Button ID="btnregistration" runat="server" Text="Add" OnClick="btnregistration_Click" Width="62px" Font-Bold="True" Height="29px"  />
&nbsp; <asp:Button ID="Button2" runat="server" Text="Modify" Width="46px" />
    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Back" Width="42px"/>  <asp:Button ID="Button3" runat="server" Text="Reset" Width="62px" Font-Bold="True" Height="29px" OnClick="Button3_Click"/>  
</td>
<td class="auto-style1">
    </td>
</tr>


<tr>
<td class="auto-style1">
    <%--<asp:PlaceHolder ID="plBarCode" runat="server" />--%>
    </td>
<td class="auto-style1" colspan="2">
<asp:Label ID="lblmsg" runat="server" ForeColor="#009900"></asp:Label>
    
</td>
</tr>
        <tr>
            <td colspan="2"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Please enter valid integer or decimal number with 2 decimal places." ValidationExpression="((\d+)((\.\d{1,2})?))$" ForeColor="Red"></asp:RegularExpressionValidator></td>
        </tr>
</table>
</asp:Content>

