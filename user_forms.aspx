<%@ Page Language="C#" MasterPageFile="~/lms.master" AutoEventWireup="true" CodeFile="user_forms.aspx.cs" Inherits="user_forms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            height: 28px;
            width: 457px;
        }
        .auto-style6 {
            width: 457px;
        }
        .auto-style7 {
            width: 457px;
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="center" Runat="Server">
    <table align="center" class="style1" style="border: 6px inset;margin-left: 32%;color: #4974a2; background-color: aliceblue ">
<tr>
<td style="border-bottom: thin solid #008080; font-weight: 700; text-align: center; font-family: cursive;font-size: large" class="auto-style6">
ACTIVITY MENU</td>
</tr>
<tr>
<td class="auto-style7">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton5" GroupName="Source" runat="server" Text="  Generate Request" Font-Bold="True" font-size="Medium"  />
    </td>
</tr>
<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton1" GroupName="Source" runat="server" Text="  Acknowledgement" Font-Bold="True" font-size="Medium" />
</td>
</tr>

<tr>
<td class="auto-style3">
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Submit" Width="449px" Font-Bold="True" Height="34px" BorderStyle="Ridge" BorderWidth="10px"/><%--<asp:Button ID="Button2" runat="server" Text="Go Back" Width="77px" OnClick="Button2_Click" />--%></td>
</tr>
</table>
</asp:Content>
