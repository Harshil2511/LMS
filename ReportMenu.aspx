<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportMenu.aspx.cs" Inherits="ReportMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   

    
</head>
<body>
    <form id="form1" runat="server">
     <div style="background-color: #5de66e;color: white;font-style: oblique;font-variant: all-small-caps;font-size: smaller;">
            <h1>Reports from library software</h1>
        
                <hr />
        </div>
        <div><asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="#3399FF" OnClick="LinkButton1_Click">Home</asp:LinkButton></div>
        <br />
     <asp:TreeView ID="TreeView1" runat="server" ImageSet="WindowsHelp" LineImagesFolder="~/TreeLineImages"
                    OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Text="Library Reports" Value="Root 1">
                            <asp:TreeNode Text="Total No. of Books issued during the month." Value="A" 
                                NavigateUrl="~/Month_wise_rep.aspx"></asp:TreeNode>

                            <asp:TreeNode 
                                Text="Maximum number of books issued from &quot; Category &quot; " 
                                Value="LOCATION" NavigateUrl="~/Max_Book_Issue_Rpt.aspx"></asp:TreeNode>


                           

                        </asp:TreeNode>
                      <%--  <asp:TreeNode Text="Costing Report" Value="Root2">
                            <asp:TreeNode Text="Daily Costing Report of ployfilm" Value="A"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Daily_Sale_bopp.aspx" Text="Daily Sale" 
                                Value="Daily Sale"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Stock Report" Value="Stock Report">
                            <asp:TreeNode NavigateUrl="~/StockReportLotWise.aspx" Text="Stock LotWise" 
                                Value="Stock LotWise"></asp:TreeNode>
                        </asp:TreeNode>--%>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="1px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" BackColor="#B5B5B5" />
                </asp:TreeView>
        </form>
</body>
</html>

