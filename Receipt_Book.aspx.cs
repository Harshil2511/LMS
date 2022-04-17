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

public partial class Receipt_Book : System.Web.UI.Page
{

    int aa;
    string bb;
    SqlConnection cn1w = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdw;
    SqlConnection cn1wY = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdwY;
    SqlCommand cmdwr;
    SqlConnection cn1wr = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlDataAdapter adaptw;
    string fdt, tdt, gv_bknme, gv_issue_id, gv_tdt , gv_jk;
    int gv_last_dt, gv_last_dty;
    string gv_emp, gv_book, gv_uc;
    string gv_bid;
    string gv_chkdt, GV_RQ_ID,gv_uncd;
    string gv_rdchk, u_bcde;
    string req_1, req_2, req_4,req_5;
    int req_3;
    int req_iii , gv_getdays;
    string strcmd129, U_gv_mail, EMLO, GV_ml;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        test();
        gv_uncd = Request.QueryString["ucd"].ToString();
        // gvCustomers.Visible = false;
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!this.IsPostBack)
        {
           // gv_uncd = Session["unitcode"].ToString();
            //Session["un_code"] = Request.QueryString["utype"].ToString();
            this.BindGrid();
        }
       // gv_uncd = Session["unitcode"].ToString();
      TextBox3.Text =   DropDownList1.Text;
    }
    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
               
                //cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%'";
               // cmd.CommandText = "SELECT Issue_id, Book_id, book_name, employee_id, emp_mail_id, Book_status,fdate,tdate,bar_code,req_id FROM Issued_book_master WHERE (receipt_stat is null or receipt_stat = '')  and Book_status = 'Issued' and bar_code LIKE '%' + @barcd + '%' AND UNIT_CODE = '" + gv_uncd + "' ";
                cmd.CommandText = "SELECT a.Issue_id, a.Book_id, a.book_name, a.employee_id, a.emp_mail_id, a.Book_status,a.fdate,a.tdate,a.bar_code,a.req_id,b.Author FROM Issued_book_master a ,book_master b WHERE a.Book_id = b.Book_id and (a.receipt_stat is null or a.receipt_stat = '')  and a.Book_status = 'Issued' and a.bar_code LIKE '%' + @barcd + '%' AND a.UNIT_CODE = '" + gv_uncd + "' ";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@barcd", TextBox2.Text.Trim());
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            //gv_chkdt = TextBox3.Text;
            //DateTime oDate = Convert.ToDateTime(gv_chkdt);
            //DateTime oDatee;
            string fdt, tdt, gv_bknme, gv_issue_id;

            foreach (GridViewRow row in gvCustomers.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    //gv_bid = row.Cells[1].Text;
                    //gv_book = row.Cells[8].Text;
                    //gv_bknme = row.Cells[2].Text.Replace("&#39;", "'"); 
                    //gv_issue_id = row.Cells[0].Text;
                    //gv_jk = row.Cells[9].Text;


                    gv_bid = row.Cells[1].Text;
                    gv_book = row.Cells[3].Text;
                    gv_bknme = row.Cells[4].Text.Replace("&#39;", "'");
                    gv_issue_id = row.Cells[0].Text;
                    gv_jk = row.Cells[2].Text;



                    //fdt = row.Cells[5].Text;
                    //tdt = row.Cells[6].Text;
                    //GV_RQ_ID = row.Cells[0].Text;


                   

                   
                                            ///////////////////////////////////////////// for checking the book status if reserved 
                    string strcmd12;
                    strcmd12 = "select Book_status,receipt_stat,bar_code from Issued_book_master where book_id = '" + gv_bid + "' AND (receipt_stat IS NULL OR receipt_stat = '') and UNIT_CODE = '" + gv_uncd + "' ";
                    SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    cn1.Open();
                    SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        string U_stst,U_rec_sts;
                        U_stst = (dr1[0].ToString());
                        U_rec_sts = (dr1[1].ToString());
                        u_bcde = (dr1[2].ToString());
                        if (U_stst == "Issued" && U_rec_sts == "")
                        {

                           

                            if(RadioButton1.Checked == true)
                            {
                                gv_rdchk = "Lost";

                            }

                            else if(RadioButton2.Checked == true)
                            {
                                gv_rdchk = "Scrapped";

                            }

                            else
                            {

                                gv_rdchk = "Good";

                            }

                            cmdw = new SqlCommand("insert into receipt_book(Book_id,book_name,issue_id,rec_dt,unit_code,book_condition) values(@Book_id,@book_name,@issue_id,@rec_dt,@unit_code,@book_condition)", cn1w);
                            cn1w.Open();
                            cmdw.Parameters.AddWithValue("@Book_id", gv_bid);
                            cmdw.Parameters.AddWithValue("@book_name", gv_bknme);
                            cmdw.Parameters.AddWithValue("@issue_id", gv_issue_id);
                            cmdw.Parameters.AddWithValue("@rec_dt", DateTime.Now.ToShortDateString());

                            cmdw.Parameters.AddWithValue("@unit_code", gv_uncd);
                            cmdw.Parameters.AddWithValue("@book_condition", gv_rdchk);

                            cmdw.ExecuteNonQuery();
                            cn1w.Close();


                            ///////////////////////////////////////////// check book prority level

                            //string strcmd12bk;
                            //strcmd12bk = "SELECT top 1 Request_id, employee_id, emp_name, book_name, Book_id, unit_code, fdate, tdate , bar_code,author_name,req_days  FROM Request_master WHERE (req_status IS NULL OR req_status = '') and bar_code = '" + u_bcde + " ' AND UNIT_CODE = '" + gv_uncd + "' ORDER BY fdate asc ";
                            //SqlConnection cn1bk = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //cn1bk.Open();
                            //SqlCommand cmd1bk = new SqlCommand(strcmd12bk, cn1bk);
                            //SqlDataReader dr1bk = cmd1bk.ExecuteReader();
                            //if (dr1bk.Read())
                            //{
                            //    string req_6;

                            //    req_1 = (dr1bk[1].ToString());
                            //    req_2 = (dr1bk[8].ToString());
                            //    req_3 = Convert.ToInt32(dr1bk[10]);
                            //    req_4 = (dr1bk[7].ToString());
                            //    req_5 = (dr1bk[0].ToString());
                            //    req_6 = (dr1bk[5].ToString());

                            //    DateTime oDaterrr = DateTime.Now.AddDays(req_3);

                              
                            //    SqlConnection cn1wwq = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //    SqlCommand cmdwwq;
                            //    SqlDataAdapter adaptwwq;
                            //    //cmdwwq = new SqlCommand("update book_master set avail_status ='Issued' , next_avail_date= '" + (String.Format("{0:d/M/YYYY}", req_4) + "' , book_status = '" + gv_rdchk + "'  where Book_id=@Book_id and barcode =@barcode"), cn1wwq);
                            //    cmdwwq = new SqlCommand("update book_master set avail_status ='Issued' , next_avail_date=@next_avail_date , book_status = '" + gv_rdchk + "'  where Book_id=@Book_id and barcode =@barcode", cn1wwq);
                            //    cn1wwq.Open();
                            //    cmdwwq.Parameters.AddWithValue("@Book_id", gv_bid);
                            //    cmdwwq.Parameters.AddWithValue("@barcode", gv_book);
                            //    cmdwwq.Parameters.AddWithValue("@next_avail_date", oDaterrr);
                            //    //cmdwwq.Parameters.AddWithValue("@book_status", gv_rdchk);
                            //    //cmdww.Parameters.AddWithValue("@next_avail_date", oDaterr);
                            //    cmdwwq.ExecuteNonQuery();
                            //    cn1wwq.Close();

                            //    SqlConnection cn1wwqt = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //    SqlCommand cmdwwqt;
                            //    SqlDataAdapter adaptwwqt;
                            //    cmdwwqt = new SqlCommand("update request_master set req_status ='Issued' , fdate=@fdate , tdate=@tdate where Request_id=@Request_id", cn1wwqt);
                            //    cn1wwqt.Open();
                            //  //  cmdwwqt.Parameters.AddWithValue("@Book_id", gv_bid);
                            //   // cmdwwqt.Parameters.AddWithValue("@barcode", req_2);
                            //    cmdwwqt.Parameters.AddWithValue("@Request_id", req_5);
                            //   // cmdwwqt.Parameters.AddWithValue("@employee_id", req_1);
                            //    cmdwwqt.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                            //    cmdwwqt.Parameters.AddWithValue("@tdate", oDaterrr.ToShortDateString());
                            //    cmdwwqt.ExecuteNonQuery();
                            //    cn1wwqt.Close();
                            //    strcmd129 = "select EMAIL from LOGIN where employee_code = '" + req_1 + "'";
                            //    SqlConnection cn19 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //    cn19.Open();
                            //    SqlCommand cmd19 = new SqlCommand(strcmd129, cn19);
                            //    SqlDataReader dr19 = cmd19.ExecuteReader();
                            //    if (dr19.Read())
                            //    {
                            //        U_gv_mail = (dr19[0].ToString());
                            //        cmdwY = new SqlCommand("insert into Issued_book_master(Book_id,book_name,employee_id,emp_mail_id,Book_status,fdate,tdate,bar_code,req_id,receipt_stat,unit_code) values(@Book_id,@book_name,@employee_id,@emp_mail_id,@Book_status,@fdate,@tdate,@bar_code,@req_id,@receipt_stat,@unit_code)", cn1wY);
                            //        cn1wY.Open();
                            //        cmdwY.Parameters.AddWithValue("@Book_id", gv_bid);
                            //        cmdwY.Parameters.AddWithValue("@book_name", gv_bknme);
                            //        cmdwY.Parameters.AddWithValue("@employee_id", req_1);
                            //        cmdwY.Parameters.AddWithValue("@emp_mail_id", U_gv_mail);
                            //        cmdwY.Parameters.AddWithValue("@Book_status", "Issued");
                            //        cmdwY.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                            //        //cmdw.Parameters.AddWithValue("@tdate", oDaterr.ToShortDateString());
                            //        cmdwY.Parameters.AddWithValue("@tdate", DateTime.Now.AddDays(req_3).ToShortDateString());
                            //        cmdwY.Parameters.AddWithValue("@bar_code", req_2);
                            //        cmdwY.Parameters.AddWithValue("@req_id", req_5);
                            //        cmdwY.Parameters.AddWithValue("@receipt_stat", "");
                            //        cmdwY.Parameters.AddWithValue("@unit_code", req_6);

                            //        cmdwY.ExecuteNonQuery();
                            //        cn1wY.Close();

                            //        string constry = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                            //        using (SqlConnection cony = new SqlConnection(constry))
                            //        {
                            //            using (SqlCommand cmdy = new SqlCommand())
                            //            {
                            //                cmdy.CommandText = "SELECT Request_id, employee_id, emp_name, book_name, Book_id, unit_code, fdate, tdate , bar_code  FROM Request_master WHERE Request_id = '" + req_5 + "'";
                            //                cmdy.Connection = cony;
                            //                //cmdy.Parameters.AddWithValue("@Book_title", "");
                            //                DataTable dty = new DataTable();
                            //                using (SqlDataAdapter sday = new SqlDataAdapter(cmdy))
                            //                {
                            //                    sday.Fill(dty);
                            //                    GridView1.DataSource = dty;
                            //                    GridView1.DataBind();
                            //                }

                            //                cony.Close();
                            //            }
                            //        }

                            //        using (StringWriter sw = new StringWriter())
                            //        {
                            //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                            //            {
                            //                GridView1.RenderControl(hw);
                            //                StringReader sr = new StringReader(sw.ToString());
                            //                MailMessage mm = new MailMessage("himanshukalra@vardhman.com", U_gv_mail);
                            //                mm.Subject = "Book Issued";
                            //                mm.Body = "Book Issued to:<hr /> Employee Code - " + req_1 + sw.ToString();
                            //                mm.IsBodyHtml = true;
                            //                SmtpClient smtp = new SmtpClient();
                            //                smtp.Host = "172.28.0.254";
                            //                smtp.EnableSsl = false;
                            //                NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
                            //                //NetworkCred.UserName = "sender@gmail.com";
                            //                //NetworkCred.Password = "<password>";
                            //                smtp.UseDefaultCredentials = true;
                            //                smtp.Credentials = NetworkCred;
                            //                smtp.Port = 25;
                            //                smtp.Send(mm);
                            //            }
                            //        }



                            //    }
                            //    SqlConnection cn1wwyH = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //    SqlCommand cmdwwyH;
                            //    SqlDataAdapter adaptwwyH;
                            //    cmdwwyH = new SqlCommand("update Issued_book_master set receipt_stat ='Received' where Book_id =@Book_id and Issue_id=@Issue_id and bar_code=@barcode", cn1wwyH);
                            //    cn1wwyH.Open();
                            //    cmdwwyH.Parameters.AddWithValue("@Book_id", gv_bid);
                            //    cmdwwyH.Parameters.AddWithValue("@barcode", gv_book);
                            //    cmdwwyH.Parameters.AddWithValue("@Issue_id", gv_issue_id);
                            //    //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                            //    cmdwwyH.ExecuteNonQuery();
                            //    cn1wwyH.Close();
                            //    BindGrid();
                            //    Label1.Visible = true;
                            //    GridView1.Visible = false;
                            //  //  Label1.Text = "Successfully Received";
                            ////cmdwr = new SqlCommand("insert into receipt_book(Book_id,book_name,issue_id,rec_dt,unit_code,book_condition) values(@Book_id,@book_name,@issue_id,@rec_dt,@unit_code,@book_condition)", cn1wr);
                            ////cn1wr.Open();
                            ////cmdwr.Parameters.AddWithValue("@Book_id", gv_bid);
                            ////cmdwr.Parameters.AddWithValue("@book_name", gv_bknme);
                            ////cmdwr.Parameters.AddWithValue("@issue_id", gv_issue_id);
                            ////cmdwr.Parameters.AddWithValue("@rec_dt", DateTime.Now.ToShortDateString());

                            ////cmdwr.Parameters.AddWithValue("@unit_code", gv_uncd);
                            ////cmdwr.Parameters.AddWithValue("@book_condition", gv_rdchk);

                            ////cmdwr.ExecuteNonQuery();
                            ////cn1wr.Close();
                            //    BindGrid();

                            //}

                            /////////////////////////////////////////////////
                           
                                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdww;
                                SqlDataAdapter adaptww;
                                cmdww = new SqlCommand("update book_master set avail_status ='Available' , next_avail_date= null , book_status = '" + gv_rdchk + "'  where Book_id=@Book_id and barcode =@barcode and UNIT_CODE = '" + gv_uncd + "'", cn1ww);
                                cn1ww.Open();
                                cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdww.Parameters.AddWithValue("@barcode", gv_book);
                                cmdww.Parameters.AddWithValue("@book_status", gv_rdchk);
                                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                                cmdww.ExecuteNonQuery();
                                cn1ww.Close();
                                //BindGrid();
                                //Label1.Visible = true;
                                //Label1.Text = "Successfully Received";

                                SqlConnection cn1wwy = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdwwy;
                                SqlDataAdapter adaptwwy;
                                cmdwwy = new SqlCommand("update Issued_book_master set receipt_stat ='Received' where Book_id =@Book_id and Issue_id=@Issue_id and bar_code=@barcode and UNIT_CODE = '" + gv_uncd + "'", cn1wwy);
                                cn1wwy.Open();
                                cmdwwy.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdwwy.Parameters.AddWithValue("@barcode", gv_book);
                                cmdwwy.Parameters.AddWithValue("@Issue_id", gv_issue_id);
                                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                                cmdwwy.ExecuteNonQuery();
                                cn1wwy.Close();
                                GridView1.Visible = false;
                                BindGrid();
                                Label1.Visible = true;
                                Label1.Text = "Successfully Received";

                                SqlConnection cn1wwyf = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdwwyf;
                                SqlDataAdapter adaptwwyf;
                                cmdwwyf = new SqlCommand("update Request_master set req_status ='Returned' where Book_id =@Book_id and Request_id=@Request_id and UNIT_CODE = '" + gv_uncd + "'", cn1wwyf);
                                cn1wwyf.Open();
                                cmdwwyf.Parameters.AddWithValue("@Request_id", gv_jk);
                                cmdwwyf.Parameters.AddWithValue("@Book_id", gv_bid);
                     
                                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                                cmdwwyf.ExecuteNonQuery();
                                cn1wwyf.Close();
                               
                            
                        }


                      
                    }


                    

                    




                    //////////////////////////////////////////////////////////// end of for checking previous request into request master





                }

                /////////////////////////////////////////////////////////////  for checking previous request into request master

                string strcmd12b, GV_LST;
                strcmd12b = "select top 1 Request_id,employee_id,book_name,Book_id,unit_code,fdate,tdate,req_status,bar_code,req_days from Request_master where book_id = '" + gv_bid + "' AND (req_status IS NULL OR req_status = '') and UNIT_CODE = '" + gv_uncd + "' order by Request_id ";
                SqlConnection cn1b = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                cn1b.Open();
                SqlCommand cmd1b = new SqlCommand(strcmd12b, cn1b);
                SqlDataReader dr1b = cmd1b.ExecuteReader();
                if (dr1b.Read())
                {
                    GV_LST = dr1b[1].ToString();
                    gv_getdays = Convert.ToInt32(dr1b[9].ToString());
                    SqlConnection cn1wwyf = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    SqlCommand cmdwwyf;
                    SqlDataAdapter adaptwwyf;
                    cmdwwyf = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@req_days  where Book_id =@Book_id and UNIT_CODE = '" + gv_uncd + "'" , cn1wwyf);
                    cn1wwyf.Open();
                    cmdwwyf.Parameters.AddWithValue("@Book_id", gv_bid);
                    cmdwwyf.Parameters.AddWithValue("@req_days", DateTime.Now.AddDays(gv_getdays));
                    //cmdwwyf.Parameters.AddWithValue("@barcode", gv_book);
                    //cmdwwyf.Parameters.AddWithValue("@Issue_id", gv_issue_id);
                    //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                    cmdwwyf.ExecuteNonQuery();
                    cn1wwyf.Close();

                    EMLO = Session["username"].ToString().ToUpper();
                    /////////////////////////////////////////////////////////////////////

                    string strcmd12zB;
                    strcmd12zB = "select mobile from LOGIN where EMPLOYEE_CODE = '" + GV_LST + "' and UNIT_CODE = '" + gv_uncd + "'";
                    SqlConnection cn1zB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    cn1zB.Open();
                    SqlCommand cmd1zB = new SqlCommand(strcmd12zB, cn1zB);
                    SqlDataReader dr1zB = cmd1zB.ExecuteReader();
                    if (dr1zB.Read())
                    {
                        GV_ml = dr1zB[0].ToString();

                        string mobile = GV_ml;
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Concat(new object[] { " http://180.179.146.71/api/v3/sendsms/plain?user=Vardhman&password=Sid@2014&sender=HLPDSK&SMSText= Your Requested Book is Available in Library now .", ".&GSM=91", mobile }));
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        string str2 = reader.ReadToEnd();
                        reader.Close();
                        response.Close();
                        

                    }

                    else
                    {


                    }
                    ////////////////////////////////////////////////////////////////////////
                    cn1zB.Close();
                   

                }

                else
                {


                }
                cn1b.Close();

            }
        }
    }
    //protected void datepicker_SelectionChanged(object sender, EventArgs e)
    //{
    //    TextBox3.Text = datepicker.SelectedDate.ToShortDateString();
    //    datepicker.Visible = false;
    //}
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    datepicker.Visible = true;
    //}
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, TextBox2.Text.Trim(), delegate(Match match)
        //    {
        //        return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
        //    }, RegexOptions.IgnoreCase);
        //}
    }

    protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        this.BindGrid();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if(RadioButton1.Checked == true)
        {
            RadioButton1.Checked = false;

        }

        if (RadioButton2.Checked == true)
        {
            RadioButton2.Checked = false;

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        int gv_var;
        gv_var =Convert.ToInt32(TextBox3.Text);

        if (gv_var == 0)
       {
           ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Please,Enter Days')</script>", false);

       }
        else
        {
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                if (chk != null & chk.Checked)
                {
                    gv_bid = row.Cells[1].Text;
                    gv_book = row.Cells[8].Text;
                    gv_bknme = row.Cells[2].Text;
                    gv_issue_id = row.Cells[0].Text;
                    gv_tdt = row.Cells[10].Text;
                    DateTime newdate = Convert.ToDateTime(gv_tdt);
                    DateTime newdatee = Convert.ToDateTime(gv_tdt);
                    gv_last_dt = Convert.ToInt32(TextBox3.Text);
                    gv_last_dty = Convert.ToInt32(TextBox3.Text);

                    SqlConnection cn1wwt = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    SqlCommand cmdwwt;
                    SqlDataAdapter adaptwwt;
                    cmdwwt = new SqlCommand("update Issued_book_master set tdate =@tdate where Issue_id=@Issue_id and UNIT_CODE = '" + gv_uncd + "'", cn1wwt);
                    cn1wwt.Open();
                    cmdwwt.Parameters.AddWithValue("@tdate", newdate.AddDays(gv_last_dt).ToShortDateString());
                    cmdwwt.Parameters.AddWithValue("@Issue_id", gv_issue_id);
                    cmdwwt.ExecuteNonQuery();
                    cn1wwt.Close();
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Successfully updated date. !!!')</script>", false);
                    //BindGrid();

                    SqlConnection cn1wwtX = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    SqlCommand cmdwwtX;
                    SqlDataAdapter adaptwwtX;
                    cmdwwtX = new SqlCommand("update book_master set next_avail_date =@next_avail_date where Book_id=@Book_id and UNIT_CODE = '" + gv_uncd + "'", cn1wwtX);
                    cn1wwtX.Open();
                    cmdwwtX.Parameters.AddWithValue("@next_avail_date", newdatee.AddDays(gv_last_dty));
                    cmdwwtX.Parameters.AddWithValue("@Book_id", gv_bid);
                    cmdwwtX.ExecuteNonQuery();
                    cn1wwtX.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Successfully updated date. !!!')</script>", false);
                    BindGrid();
                }

            }
    }
        

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox3.Text = DropDownList1.SelectedItem.Text;
    }
}