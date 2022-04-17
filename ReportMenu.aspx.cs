using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(1000);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("All forms.aspx");
    }
}