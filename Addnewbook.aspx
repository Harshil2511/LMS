<%@ Page Title="" Language="C#" MasterPageFile="~/lms.master" AutoEventWireup="true" CodeFile="Addnewbook.aspx.cs" Inherits="Addnewbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <table align="center" class="style1" style="border: 6px inset">
<tr>
<td colspan="3" 
style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">
Add New Book</td>
</tr>
<tr>
<td class="style5">
&nbsp;</td>
<td class="style4">
&nbsp;</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td class="style6">
Book Name :
</td>
<td class="style4">
<asp:TextBox ID="txtfname" runat="server" Width="159px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
ControlToValidate="txtfname" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style6">
Detail :
</td>
<td class="style4">
<asp:TextBox ID="txtlname" runat="server" Width="159px" Height="33px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
ControlToValidate="txtlname" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style6">
Author :
</td>
<td class="style4">
<asp:TextBox ID="txtcity" runat="server" Width="159px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
ControlToValidate="txtcity" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="style6">
Pricing :
</td>
<td class="style4">
<asp:TextBox ID="txtemail" runat="server" Width="159px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
ControlToValidate="txtemail" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
ControlToValidate="txtemail" ErrorMessage="invalid email" ForeColor="Red" 
ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>--%>
</td>
</tr>
<tr>
<td class="style6">
    Category&nbsp; :</td>
<td class="style4">
<asp:TextBox ID="txtpassword" runat="server" Width="158px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
ControlToValidate="txtpassword" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>

        <tr>
<td class="style6">
    Bar Code&nbsp; :</td>
<td class="style4">
<asp:TextBox ID="barcode" runat="server" Width="159px"></asp:TextBox>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
ControlToValidate="barcode" ErrorMessage="!!" ForeColor="Red" 
SetFocusOnError="True"></asp:RequiredFieldValidator>
</td>
</tr>


<tr>
<td class="style5">
&nbsp;</td>
<td class="style4">
<asp:Button ID="btnregistration" runat="server" Text="Register" 
onclick="btnregistration_Click" />
</td>
<td>
&nbsp;</td>
</tr>

<tr>
<td class="style5">
&nbsp;</td>
<td class="style4">
<asp:PlaceHolder ID="plBarCode" runat="server" />
</td>
<td>
&nbsp;</td>
</tr>


<tr>
<td class="auto-style1">
    </td>
<td class="auto-style1" colspan="2">
<asp:Label ID="lblmsg" runat="server" ForeColor="#009900">Record Inserted Successfully</asp:Label>
</td>
</tr>
<tr>
<td colspan="3">
&nbsp;<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</td>
</tr>
</table>
</asp:Content>

