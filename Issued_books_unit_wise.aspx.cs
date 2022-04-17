using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Issued_books_unit_wise : System.Web.UI.Page
{
    string unitm, un_sess;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        test();
        unitm = Request.QueryString["ucd"].ToString();
        un_sess = Session["username"].ToString();
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!this.IsPostBack)
        {
            //Session["un_code"] = Request.QueryString["utype"].ToString();
            // gv_uc = Session["un_code"].ToString();
            // Session["fnamet"] = Request.QueryString["Fnamett"].ToString();
            // gv_fnameet = Session["fname"].ToString();
            this.BindGrid();
        }


    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "SELECT Issue_id, Book_id, book_name, employee_id, emp_mail_id, receipt_stat ,fdate,tdate,bar_code,req_id,user_receipt_status FROM Issued_book_master WHERE Book_status = 'Issued' and UNIT_CODE = '" + unitm + "' order by Issue_id desc";
                cmd.CommandText = "SELECT a.Issue_id, a.Book_id, a.book_name, a.employee_id, a.emp_mail_id, a.receipt_stat ,a.fdate,a.tdate,a.bar_code,a.req_id,a.user_receipt_status, C.emp_name, CASE WHEN B.rec_dt IS NULL THEN NULL ELSE B.rec_dt  END AS ret_dte FROM Request_master C , Issued_book_master A LEFT JOIN receipt_book B ON A.Issue_id = B.issue_id WHERE A.req_id = C.Request_id and a.unit_code = '" + unitm + "' AND A.Book_status = 'Issued' order by A.Issue_id desc";
                cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@Book_title", "");
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

                con.Close();
            }
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, TextBox1.Text.Trim(), delegate(Match match)
        //    {
        //        return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
        //    }, RegexOptions.IgnoreCase);
        //}
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{

    //}
}