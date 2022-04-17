using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class receive_book_status : System.Web.UI.Page
{
    string unitm,un_sess;

    protected void Page_Load(object sender, EventArgs e)
    {
       // Label1.Visible = false;
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
                //cmd.CommandText = "SELECT Issue_id, Book_id, book_name, employee_id, emp_mail_id, Book_status,fdate,tdate,bar_code,req_id,user_receipt_status FROM Issued_book_master WHERE (user_receipt_status is null or user_receipt_status = '')  and Book_status = 'Issued' and UNIT_CODE = '" + unitm + "' and employee_id = '" + un_sess + "' ";
                cmd.CommandText = "SELECT Issue_id, Book_id, book_name, employee_id, emp_mail_id, Book_status,fdate,tdate,bar_code,req_id,user_receipt_status FROM Issued_book_master WHERE Book_status = 'REQUEST ACCEPTED' and (user_receipt_status is null or user_receipt_status = '')  and employee_id = '" + un_sess + "' ";
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

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
            if (chk != null & chk.Checked)
            {
                string gv_id, gv_bid, gv_eid, gv_uid;
                gv_id = row.Cells[0].Text;
                gv_bid = row.Cells[1].Text;
                gv_eid = row.Cells[3].Text;
                gv_uid = row.Cells[9].Text;


                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmdww;
                SqlDataAdapter adaptww;
                cmdww = new SqlCommand("update Issued_book_master set user_receipt_status ='RECEIVED' , Book_status = 'Issued' where Book_id= '" + gv_bid + "' and Unit_code = '" + unitm + "' AND ISSUE_ID = '" + gv_id + "' AND EMPLOYEE_ID = '" + gv_eid + "'", cn1ww);
                cn1ww.Open();
                //cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                cmdww.ExecuteNonQuery();
                cn1ww.Close();
                BindGrid();

                SqlConnection cn1wwq = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmdwwq;
                SqlDataAdapter adaptwwq;
                cmdwwq = new SqlCommand("update book_master set avail_status ='Issued' where Book_id= '" + gv_bid + "' and Unit_code = '" + unitm + "'", cn1wwq);
                cn1wwq.Open();
                //cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                cmdwwq.ExecuteNonQuery();
                cn1wwq.Close();

                SqlConnection cn1wwqq = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmdwwqq;
                SqlDataAdapter adaptwwqq;
                cmdwwqq = new SqlCommand("update request_master set req_status ='Issued' where Request_id= '" + gv_uid + "' and Unit_code = '" + unitm + "'", cn1wwqq);
                cn1wwqq.Open();
                //cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                cmdwwqq.ExecuteNonQuery();
                cn1wwqq.Close();
            

            }
        }
    }
}