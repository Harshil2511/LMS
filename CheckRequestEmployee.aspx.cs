using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Mail;
using System.Net;

public partial class CheckRequestEmployee : System.Web.UI.Page
{
    int aa;
    string bb;
    SqlConnection cn1w = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdw;
    SqlDataAdapter adaptw;
    string gv_emp, gv_book, gv_uc;
    string gv_bid;
    string gv_chkdt, GV_RQ_ID, gv_ucm, gv_chhhdt;
    string unitm;
    TimeSpan Difference;
    int gv_set_datet, gv_convint;
    string R_id;
    string U_gv_mail, fdt, tdt, gv_empcd, gv_BCODE, gv_reqDays , U_gv_mailT ;
    int GVA_CHKDT, gva_redy, gva_redyy;



    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        DropDownList1.Enabled = false;
        TextBox3.Enabled = false;
        lblDifference.Visible = false;
        gv_ucm = Request.QueryString["ucd"].ToString();
        Label3.Visible = false;
        // gvCustomers.Visible = false;
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!this.IsPostBack)
        {
            //  Session["un_code"] = Request.QueryString["utype"].ToString();
            //gv_ucm = Session["unitcode"].ToString();
            this.BindGrid();
        }
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        Label1.Visible = false;
        Label2.Visible = false;
        // gv_ucm = Session["unitcode"].ToString();
        TextBox3.Text = DropDownList1.Text;
        TextBox3.Visible = false;
        DropDownList1.Visible = false;
        Label5.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string selectedValue = Request.Form["MyRadioButton"];
        Label1.Text = selectedValue;
        Label1.Visible = false;
        if (Label1.Text != "")
        {
            int SLECTD = Convert.ToInt16(Label1.Text);
            int gv_sdlt;

           // if (TextBox3.Text != "" && Label1.Text != "")
                if (Label1.Text != "")
            {

                ////////////////////////////////////////
                GVA_CHKDT = Convert.ToInt32(TextBox3.Text);
                //DateTime oDaterr = DateTime.Now.AddDays(GVA_CHKDT);
                ////////////////////////////////////////

                //gv_chkdt = TextBox3.Text;
                //DateTime oDate = Convert.ToDateTime(gv_chkdt);
                //DateTime oDater = Convert.ToDateTime(gv_chkdt);
                ////DateTime oDaterr = DateTime.Now;
                //DateTime oDatee;
                //int gv_totdys;
                //string fdt, tdt, gv_empcd, gv_BCODE;
                ////gv_totdys = Convert.ToInt32(oDate - oDater);
                ////if (oDate > oDater.AddDays(15))
                //Difference = oDater.Subtract(oDaterr);

                //lblDifference.Text = Convert.ToString(Difference.Days);
                //gv_convint = Convert.ToInt32(lblDifference.Text);
                //gv_set_datet = 15;
                //if (gv_convint < gv_set_datet)
                //{ 
                foreach (GridViewRow row in gvCustomers.Rows)
                {

                    //CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                    GV_RQ_ID = row.Cells[0].Text;
                    gv_sdlt = Convert.ToInt16(GV_RQ_ID);
                    if (SLECTD == gv_sdlt)
                    {
                        gv_bid = row.Cells[1].Text;
                        gv_book = row.Cells[3].Text.Replace("&#39;", "'");
                        fdt = row.Cells[7].Text;
                        tdt = row.Cells[8].Text;
                        GV_RQ_ID = row.Cells[0].Text;
                        gv_empcd = row.Cells[5].Text;
                        gv_BCODE = row.Cells[2].Text;
                        gv_reqDays = row.Cells[9].Text;
                        //gva_redy = Convert.ToInt32( gv_reqDays) + Convert.ToInt32(TextBox3.Text);
                        gva_redy = Convert.ToInt32(TextBox3.Text);
                        gva_redyy = Convert.ToInt32(gv_reqDays) + Convert.ToInt32(TextBox3.Text);
                        DateTime oDaterr = DateTime.Now.AddDays(gva_redy);
                        DateTime oDaterrr = DateTime.Now.AddDays(gva_redyy);
                        DateTime newdate = Convert.ToDateTime(tdt);
                       

                        ///////////////////////////////////////////// for checking the book status if reserved 
                        string strcmd12;
                        strcmd12 = "select avail_status from Book_Master where book_id = '" + gv_bid + "' and Unit_code = '" + gv_ucm + "' ";
                        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        cn1.Open();
                        SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            string U_stst;
                            U_stst = (dr1[0].ToString());

                            if (U_stst == "Issued" || U_stst == "Requested")
                            {
                                //Label1.Visible = true;
                               // Label1.Text = "Already Issued";
                                 ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Already Issued/Requested')</script>", false);

                            }


                            else
                            {

                                string strcmd129;
                                strcmd129 = "select EMAIL from LOGIN where employee_code = '" + gv_empcd + "' and Unit_code = '" + gv_ucm + "' ";
                                SqlConnection cn19 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                cn19.Open();
                                SqlCommand cmd19 = new SqlCommand(strcmd129, cn19);
                                SqlDataReader dr19 = cmd19.ExecuteReader();

                                if (dr19.Read())
                                {

                                    U_gv_mail = (dr19[0].ToString());

                                    cmdw = new SqlCommand("insert into Issued_book_master(Book_id,book_name,employee_id,emp_mail_id,Book_status,fdate,tdate,bar_code,req_id,receipt_stat,unit_code) values(@Book_id,@book_name,@employee_id,@emp_mail_id,@Book_status,@fdate,@tdate,@bar_code,@req_id,@receipt_stat,@unit_code)", cn1w);
                                    cn1w.Open();
                                    cmdw.Parameters.AddWithValue("@Book_id", gv_bid);
                                    cmdw.Parameters.AddWithValue("@book_name", gv_book);
                                    cmdw.Parameters.AddWithValue("@employee_id", gv_empcd);
                                    cmdw.Parameters.AddWithValue("@emp_mail_id", U_gv_mail);
                                    cmdw.Parameters.AddWithValue("@Book_status", "REQUEST ACCEPTED");
                                    cmdw.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                                    //cmdw.Parameters.AddWithValue("@tdate", oDaterr.ToShortDateString());
                                    cmdw.Parameters.AddWithValue("@tdate", oDaterrr.ToShortDateString());
                                    cmdw.Parameters.AddWithValue("@bar_code", gv_BCODE);
                                    cmdw.Parameters.AddWithValue("@req_id", GV_RQ_ID);
                                    cmdw.Parameters.AddWithValue("@receipt_stat", "");
                                    cmdw.Parameters.AddWithValue("@unit_code", gv_ucm);

                                   
                                }

                                //oDatee = oDate.AddDays(1);
                                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdww;
                                SqlDataAdapter adaptww;
                                //cmdww = new SqlCommand("update book_master set avail_status ='Issued' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + gv_ucm + "'", cn1ww);
                                cmdww = new SqlCommand("update book_master set avail_status ='Requested' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + gv_ucm + "'", cn1ww);
                                cn1ww.Open();
                                cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdww.Parameters.AddWithValue("@next_avail_date", newdate.AddDays(gva_redy));

                               


                                SqlConnection cn1wwt = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdwwt;
                                SqlDataAdapter adaptwwt;
                                cmdwwt = new SqlCommand("update Request_master set req_status ='REQUEST ACCEPTED' , req_days=@req_days , updated_days_date=@updated_days_date , tdate=@tdate where Request_id=@Request_id and book_id=@book_id and unit_code = '" + gv_ucm + "'", cn1wwt);
                                cn1wwt.Open();
                                cmdwwt.Parameters.AddWithValue("@Request_id", GV_RQ_ID);
                                cmdwwt.Parameters.AddWithValue("@req_days", gv_reqDays);
                                cmdwwt.Parameters.AddWithValue("@book_id", gv_bid);
                                cmdwwt.Parameters.AddWithValue("@tdate", newdate.AddDays(gva_redy).ToShortDateString());
                                cmdwwt.Parameters.AddWithValue("@updated_days_date", TextBox3.Text);
                                





                                //////////////////////////
                                cmdw.ExecuteNonQuery();
                                cn1w.Close();
                                Label1.Visible = true;
                                //////////////////////////
                                cmdww.ExecuteNonQuery();
                                cn1ww.Close();
                                BindGrid();
                                //Label3.Text = "Issued Successfully";
                                //////////////////////////
                                cmdwwt.ExecuteNonQuery();
                                cn1wwt.Close();
                                BindGrid();
                                Label3.Visible = true;
                                //Label3.Text = "Issued Successfully";
                                Label3.Text = "REQUEST ACCEPTED";

                                TextBox3.Text = "0";
                                DropDownList1.Text = "0";




                                ///////////////////////////////////////////////////////////////////////////////////////////////////

                                string constry = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                                using (SqlConnection cony = new SqlConnection(constry))
                                {
                                    using (SqlCommand cmdy = new SqlCommand())
                                    {
                                        cmdy.CommandText = "SELECT Request_id, employee_id, emp_name, book_name, Book_id, unit_code, fdate, tdate , bar_code  FROM Request_master WHERE Request_id = '" + GV_RQ_ID + "' and unit_code = '" + gv_ucm + "'";
                                        cmdy.Connection = cony;
                                        //cmdy.Parameters.AddWithValue("@Book_title", "");
                                        DataTable dty = new DataTable();
                                        using (SqlDataAdapter sday = new SqlDataAdapter(cmdy))
                                        {
                                            sday.Fill(dty);
                                            GridView1.DataSource = dty;
                                            GridView1.DataBind();
                                        }

                                        cony.Close();
                                    }
                                }


                                //string strcmd129;
                                //strcmd129 = "select EMAIL from LOGIN_TESTING where employee_code = '" + gv_empcd + "' and Unit_code = '" + gv_ucm + "' ";
                                //SqlConnection cn19 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                //cn19.Open();
                                //SqlCommand cmd19 = new SqlCommand(strcmd129, cn19);
                                //SqlDataReader dr19 = cmd19.ExecuteReader();
                                //if (dr19.Read())
                                //{
                                //string U_gv_mail;
                                //U_gv_mail = (dr19[0].ToString());


                                string strcmd129T;
                                strcmd129T = "select EMAIL from LOGIN where employee_code = '" + Session["username"].ToString().ToUpper() + "' and Unit_code = '" + gv_ucm + "' ";
                                SqlConnection cn19T = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                cn19T.Open();
                                SqlCommand cmd19T = new SqlCommand(strcmd129T, cn19T);
                                SqlDataReader dr19T = cmd19T.ExecuteReader();
                                if (dr19T.Read())
                                {
                                    U_gv_mailT = (dr19T[0].ToString());
                                }


                                using (StringWriter sw = new StringWriter())
                                {
                                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                    {
                                        GridView1.RenderControl(hw);
                                        StringReader sr = new StringReader(sw.ToString());
                                        MailMessage mm = new MailMessage(U_gv_mailT , U_gv_mail);
                                        mm.Subject = "LIBRARY-REQUEST ACCEPTED";
                                        mm.Body = "REQUEST ACCEPTED TO:<hr /> Employee Code - " + gv_empcd + sw.ToString();
                                        mm.IsBodyHtml = true;
                                        SmtpClient smtp = new SmtpClient();
                                        smtp.Host = "172.28.0.254";
                                        smtp.EnableSsl = false;
                                        NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
                                        //NetworkCred.UserName = "sender@gmail.com";
                                        //NetworkCred.Password = "<password>";
                                        smtp.UseDefaultCredentials = true;
                                        smtp.Credentials = NetworkCred;
                                        smtp.Port = 25;
                                        smtp.Send(mm);
                                    }
                                }


                                Label1.Visible = false;
                                //}
                                cn19.Close();






                                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////







                            }
                        }



                    }

                }
                //}
                //else
                //{
                //    lblDifference.Visible = true;
                //    lblDifference.Text = "You can not request more than 15 days of this book";

                //}
            }

        }
        //string selectedValue = Request.Form["MyRadioButton"];
        //Label1.Text = selectedValue;

        //for (int i = 0; i < gvCustomers.Rows.Count; i++)
        //{
        //    RadioButton rb = (RadioButton)gvCustomers.Rows[i].Cells[0].FindControl("RadioButton1");

        //    if (rb != null)
        //    {

        //        if (rb.Checked)
        //        {

        //            HiddenField hf = (HiddenField)gvCustomers.Rows[i].Cells[0].FindControl("HiddenField1");

        //            aa = Convert.ToInt32(gvCustomers.Rows[i].Cells[0].ToString());
        //            bb = gvCustomers.Rows[i].Cells[1].Text;

        //        }

        //    }

        //}

        //this.BindGrid();
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%'";
                cmd.CommandText = "SELECT Request_id, employee_id, emp_name, book_name, Book_id, unit_code, fdate, tdate , bar_code,author_name,req_days  FROM Request_master WHERE (req_status IS NULL OR req_status = '') AND UNIT_CODE = '" + gv_ucm + "' ORDER BY Request_id";
                cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
                    gvCustomers.Visible = true;
                }
            }
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
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

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
    protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void datepicker_SelectionChanged(object sender, EventArgs e)
    {
        TextBox3.Text = datepicker.SelectedDate.ToShortDateString();
        datepicker.Visible = false;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        datepicker.Visible = true;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox3.Text = DropDownList1.SelectedItem.Text;
    }
}