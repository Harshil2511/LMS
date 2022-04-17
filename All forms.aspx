<%@ Page Title="" Language="C#" MasterPageFile="~/lms.master" AutoEventWireup="true" CodeFile="All forms.aspx.cs" Inherits="All_forms" %>

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
    &nbsp;<table align="center" class="style1" style="border: 6px inset;margin-left: 32%;color: #4974a2 ; background-color: aliceblue ">
<tr>
<td style="border-bottom: thin solid #008080; font-weight: 700; text-align: center ; font-family: cursive;font-size: large" ;  class="auto-style6";>
ACTIVITY MENU</td>
</tr>
<br />
        <tr>
            <td>
                <br />
            </td>
        </tr>
<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton1" GroupName="Source" runat="server" Text="  Add Book" Font-Bold="True" font-size="Medium"/>
</td>
</tr>
<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton7" GroupName="Source" runat="server" Text="  Modify Book" Font-Bold="True" font-size="Medium" />
</td>
</tr>

       <%-- <tr>
<td class="auto-style7">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton5" GroupName="Source" runat="server" Text="  Print Bar Code" Font-Bold="True" font-size="Medium" />
    </td>
</tr>--%>


<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton2" GroupName="Source" runat="server" Text=" Book Bank" Font-Bold="True" font-size="Medium"/>
</td>
</tr>
<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton3" GroupName="Source" runat="server" Text=" Pending Requests" Font-Bold="True" font-size="Medium" />
</td>
</tr>
<tr>
<td class="auto-style6">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="RadioButton4" GroupName="Source" runat="server" Text=" Issued Books " Font-Bold="True" font-size="Medium" />
</td>
</tr>
        <tr>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton6" GroupName="Source" runat="server" Text="  Book Return" Font-Bold="True" font-size="Medium" />
            </td>
        </tr>

          <tr>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton8" GroupName="Source" runat="server" Text="  Reports" Font-Bold="True" font-size="Medium" />
            </td>
        </tr>

<tr>
<td class="auto-style3">
    &nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Submit" Width="454px" Font-Bold="True" Height="45px" BorderStyle="Ridge" BorderWidth="10px" /> <%--<asp:Button ID="Button2" runat="server" Text="Go Back" Width="77px" OnClick="Button2_Click" />--%></td>
</tr>
</table>
</asp:Content>