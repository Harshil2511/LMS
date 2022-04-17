using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_forms : System.Web.UI.Page
{
    static string name_id;
    string un_code, uncde;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["un_code"] = Request.QueryString["utype"].ToString();
        test();
        if (Session["username"] == null && Session["password"] == null)
        {

            Response.Redirect("Default.aspx");
            uncde = Session["un_code"].ToString();
        }

        //if (!this.IsPostBack)
        //{
        //    Session["un_code"] = Request.QueryString["utype"].ToString();
        //}


        //uncde = Session["un_code"].ToString();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{


    //}
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (RadioButton1.Checked == true)
        {
            uncde = Session["unitcodee"].ToString();
            Response.Redirect("receive_book_status.aspx?ucd=" + uncde);

        }

        if (RadioButton5.Checked == true)
        {
            uncde = Session["unitcodee"].ToString();
            //Response.Redirect("EmployeeRequestGen.aspx?ucd=" + uncde);
            Response.Redirect("Previous_issued_books.aspx?ucd=" + uncde);

        }




    }

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Default.aspx");

    //}
}