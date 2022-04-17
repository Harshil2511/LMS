using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class All_forms : System.Web.UI.Page
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
            Response.Redirect("Default2.aspx?ucd=" + uncde);

        }

        //if (RadioButton5.Checked == true)
        //{

        //    //Response.Redirect("Barcode.aspx");
        //    Response.Redirect("print_barcode_bookwise.aspx");

        //}

        if (RadioButton2.Checked == true)
        {
            uncde = Session["unitcodee"].ToString(); 
            Response.Redirect("ViewBook.aspx?ucd=" + uncde);

        }
         if (RadioButton4.Checked == true)
        {
            uncde = Session["unitcodee"].ToString();
            Response.Redirect("Issued_books_unit_wise.aspx?ucd=" + uncde);
         }

         if (RadioButton3.Checked == true)
         {
             uncde = Session["unitcodee"].ToString(); 
             Response.Redirect("CheckRequestEmployee.aspx?ucd=" + uncde);
         }

         if (RadioButton6.Checked == true)
         {
             uncde = Session["unitcodee"].ToString();
             Response.Redirect("Receipt_Book.aspx?ucd=" + uncde);
         }

         if (RadioButton7.Checked == true)
         {
             uncde = Session["unitcodee"].ToString();
             //Response.Redirect("Modify_Books.aspx?ucd=" + uncde);
             Response.Redirect("ModifyBooksLib.aspx?ucd=" + uncde);
         }

         if (RadioButton8.Checked == true)
         {
             //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Under Development')</script>", false);

             //Response.Redirect("Barcode.aspx");
              // Response.Redirect("ReportMenu.aspx");
               Response.Redirect("ReportMenu.aspx?ucd=" + uncde);
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