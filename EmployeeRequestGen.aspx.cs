using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Configuration;
using System.Globalization;

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Web.Mail;
//using System.Data.SqlClient;
//using System.Configuration;
//using System.Globalization;
//using SAP.Middleware.Connector;
//using System.IO;
//using System.Web.UI;
//using System.Net.Mail;
//using System.Net;

public partial class EmployeeRequestGen : System.Web.UI.Page
{
    SqlConnection cn1w = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdw;
    SqlDataAdapter adaptw;


    SqlConnection cn1wQQ = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdwQQ;
    SqlDataAdapter adaptwQQ;

    string gv_emp, gv_book, gv_uc,gv_fnameet,gv_umail;
    string gv_bid;
    string gv_chkdt, EMLO, gv_see , GV_ml;
    string unitm;
    int GV_ACHK;
    string gv_count , U_gv_mail_ADMIN ; 

    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBox1.Text = "";
        GridView1.Visible = false;
        Label1.Visible = false;
        test();
        unitm = Request.QueryString["ucd"].ToString();
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!this.IsPostBack)
        {
            //Session["un_code"] = Request.QueryString["utype"].ToString();
           // gv_uc = Session["un_code"].ToString();
           // Session["fnamet"] = Request.QueryString["Fnamett"].ToString();

            DropDownList2.Items.Clear();
            string strcmdtt = "select category from cat_master order by category ";
            SqlConnection cntt = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cntt.Open();
            SqlCommand cmdtt = new SqlCommand(strcmdtt, cntt);
            SqlDataAdapter datt = new SqlDataAdapter(cmdtt);
            DataSet dstt = new DataSet();
            datt.Fill(dstt);
            foreach (DataRow drtt in dstt.Tables[0].Rows)
            {
                DropDownList2.Items.Add(drtt[0].ToString());
            }
            cntt.Close();


            gv_fnameet = Session["fname"].ToString();
            gv_umail = Session["mail"].ToString();
            this.BindGrid();
        }
        //this.BindGrid();

       // gv_uc = Session["un_code"].ToString();
        gv_fnameet = Session["fname"].ToString();
        gv_umail = Session["mail"].ToString();

        TextBox1.Text = DropDownList1.Text;
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }



    private void BindGridd()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like + @catgeory  + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Book_title", TextBox2.Text.Trim());
                if (DropDownList2.Text == "All")
                {
                    cmd.Parameters.AddWithValue("@catgeory", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@catgeory", DropDownList2.Text);

                }
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
                    if (gvCustomers.Rows.Count == 0)
                    {
                        Label2.Visible = true;
                    }

                }
            }
        }
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string selectedValue = Request.Form["MyRadioButton"];
        Label1.Text = selectedValue;
        if (Label1.Text != "")
        {
            int SLECTD = Convert.ToInt32(Label1.Text);
            int gv_sdlt;
            if (TextBox1.Text != "" && Label1.Text != "")
            {
                //gv_chkdt = TextBox1.Text;
                //DateTime oDate = Convert.ToDateTime(gv_chkdt);
                //DateTime oDatee;
                //if (oDate > DateTime.Now)
                //{ 
                GV_ACHK = Convert.ToInt16(TextBox1.Text);
                DateTime oDaterr = DateTime.Now.AddDays(GV_ACHK);
                // gv_uc = Session["un_code"].ToString();

                foreach (GridViewRow row in gvCustomers.Rows)     
                //for (int i = 0; i < gvCustomers.Rows.Count; i++)//loop the GridView Rows
                {
                    string gv_bcdee,gv_authf;
                    //CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    //CheckBox chkb = (CheckBox)gvCustomers.Rows[i].Cells[0].FindControl("chk"); //find the CheckBox

                    //if (chk != null & chk.Checked)
                    //{
                    gv_bid = row.Cells[1].Text;
                    gv_sdlt = Convert.ToInt32(gv_bid);
                    if (SLECTD == gv_sdlt)
                    {
                        //gv_see = Session["username"].ToString();
                        //gv_book = row.Cells[2].Text.Replace("&#39;", "'");
                        //gv_bcdee = row.Cells[7].Text;
                        //gv_authf = row.Cells[3].Text.Replace("&amp;", ""); ;

                        gv_see = Session["username"].ToString();
                        gv_book = row.Cells[3].Text.Replace("&#39;", "'");
                        gv_bcdee = row.Cells[2].Text;
                        gv_authf = row.Cells[4].Text.Replace("&amp;", ""); ;



                        //gv_bid = gvCustomers.Rows[i].Cells[0].Text;
                        //gv_book = gvCustomers.Rows[i].Cells[1].Text; 
                        ///////////////////////////////////////////// for checking the book status if reserved 
                        string strcmd12;
                        //strcmd12 = "select avail_status from Book_Master where book_id = '" + gv_bid + "' and Unit_code = '" + unitm + "'";
                        //strcmd12 = "select employee_id,book_id,req_status from request_master where book_id = '" + gv_bid + "' and employee_id = '" + gv_see + "' and (req_status is null or req_status = 'REQUEST ACCEPTED' or req_status = 'Issued')";
                        strcmd12 = "select employee_id,book_id,req_status from request_master where employee_id = '" + gv_see + "' and unit_code = '" + unitm + "' and (req_status is null or req_status = 'REQUEST ACCEPTED' or req_status = 'Issued')";
                        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        cn1.Open();
                        SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            //string U_stst;
                            //U_stst = (dr1[0].ToString());

                            //if (U_stst == "Reserved" || U_stst == "Issued")
                            //{
                                

                            //}


                            //else
                            //{
                            //    cmdw = new SqlCommand("insert into Request_master(employee_id,book_name,Book_id,unit_code,fdate,tdate,bar_code,emp_name,author_name,req_days) values(@employee_id,@book_name,@Book_id,@unit_code,@fdate,@tdate,@bar_code,@emp_name,@author_name,@req_days)", cn1w);
                            //    cn1w.Open();

                            //    cmdw.Parameters.AddWithValue("@employee_id", Session["username"].ToString());
                            //    cmdw.Parameters.AddWithValue("@book_name", gv_book);
                            //    cmdw.Parameters.AddWithValue("@Book_id", gv_bid);
                            //    cmdw.Parameters.AddWithValue("@unit_code", unitm);
                            //    cmdw.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                            //    cmdw.Parameters.AddWithValue("@tdate", oDaterr.ToShortDateString());
                            //    cmdw.Parameters.AddWithValue("@bar_code", gv_bcdee);
                            //    //cmdw.Parameters.AddWithValue("@bar_code", gv_bcdee);
                            //    cmdw.Parameters.AddWithValue("@emp_name", gv_fnameet);
                            //    cmdw.Parameters.AddWithValue("@author_name", gv_authf);
                            //    cmdw.Parameters.AddWithValue("@req_days", GV_ACHK);
                            //    cmdw.ExecuteNonQuery();
                            //    cn1w.Close();
                            //    //TextBox1.Text = "";
                            //    Label1.Visible = true;

                             


                            //    string constry = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                            //    using (SqlConnection cony = new SqlConnection(constry))
                            //    {
                            //        using (SqlCommand cmdy = new SqlCommand())
                            //        {
                            //            cmdy.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_id = '" + gv_bid + "' and unit_code = '" + unitm + "'";
                            //            cmdy.Connection = cony;
                            //            //cmdy.Parameters.AddWithValue("@Book_title", "");
                            //            DataTable dty = new DataTable();
                            //            using (SqlDataAdapter sday = new SqlDataAdapter(cmdy))
                            //            {
                            //                sday.Fill(dty);
                            //                GridView1.DataSource = dty;
                            //                GridView1.DataBind();
                            //            }

                            //            cony.Close();
                            //        }
                            //    }


                            //    EMLO = Session["username"].ToString();
                            //    using (StringWriter sw = new StringWriter())
                            //    {
                            //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                            //        {
                            //            GridView1.RenderControl(hw);
                            //            StringReader sr = new StringReader(sw.ToString());
                            //            MailMessage mm = new MailMessage("himanshukalra@vardhman.com", "himanshukalra@vardhman.com");
                            //            mm.Subject = "Requested for Book";
                            //            mm.Body = "Requested Book From:<hr /> Employee Code - " + EMLO + sw.ToString() + "<br/>" + "Book Id -" + gv_bid + "<br/>" + "Book Name -" + gv_book + "<br/>" + "Author -" + gv_authf + "<br/><br/>";
                            //            //mm.Body = "Requested Book From:<hr /> Employee Code - ";
                            //            mm.IsBodyHtml = true;
                            //            SmtpClient smtp = new SmtpClient();
                            //            smtp.Host = "172.28.0.254";
                            //            smtp.EnableSsl = false;

                            //            NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
                            //            //NetworkCred.UserName = "sender@gmail.com";
                            //            //NetworkCred.Password = "<password>";
                            //            smtp.UseDefaultCredentials = true;
                            //            smtp.Credentials = NetworkCred;
                            //            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            //            smtp.Port = 25;
                            //            smtp.Send(mm);
                            //        }
                            //    }



                            //    ///////////////////////////////////////////// for uodating the status of checked book into book master 
                            //    //  oDatee = oDate.AddDays(1);
                            //    SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            //    SqlCommand cmdww;
                            //    SqlDataAdapter adaptww;
                            //    cmdww = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                            //    cn1ww.Open();
                            //    cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                            //    cmdww.Parameters.AddWithValue("@next_avail_date", oDaterr);
                            //    cmdww.ExecuteNonQuery();
                            //    cn1ww.Close();
                            //    BindGrid();
                            //    Label1.Text = "Your request has been submitted.";

                            //    /////////////////////////////////////////////


                            //    BindGrid();



                            //}Please return the book already issued to process this request
                          //  ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Already Requested by you')</script>", false);
     //////// set to be labled                       ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Please return the book already issued to process this request')</script>", false);
                        }


                        else
                        {
                            cmdwQQ = new SqlCommand("insert into Request_master(employee_id,book_name,Book_id,unit_code,fdate,tdate,bar_code,emp_name,author_name,req_days) values(@employee_id,@book_name,@Book_id,@unit_code,@fdate,@tdate,@bar_code,@emp_name,@author_name,@req_days)", cn1wQQ);
                            cn1wQQ.Open();

                            cmdwQQ.Parameters.AddWithValue("@employee_id", Session["username"].ToString().ToUpper());
                            cmdwQQ.Parameters.AddWithValue("@book_name", gv_book);
                            cmdwQQ.Parameters.AddWithValue("@Book_id", gv_bid);
                            cmdwQQ.Parameters.AddWithValue("@unit_code", unitm);
                            cmdwQQ.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                            cmdwQQ.Parameters.AddWithValue("@tdate", oDaterr.ToShortDateString());
                            cmdwQQ.Parameters.AddWithValue("@bar_code", gv_bcdee);
                            //cmdw.Parameters.AddWithValue("@bar_code", gv_bcdee);
                            cmdwQQ.Parameters.AddWithValue("@emp_name", gv_fnameet);
                            cmdwQQ.Parameters.AddWithValue("@author_name", gv_authf);
                            cmdwQQ.Parameters.AddWithValue("@req_days", GV_ACHK);
                            cmdwQQ.ExecuteNonQuery();
                            cn1wQQ.Close();
                            //TextBox1.Text = "";
                            Label1.Visible = true;
                          //  Label1.Text = "Your request has been submitted.";


                            string constryR = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                            using (SqlConnection conyR = new SqlConnection(constryR))
                            {
                                using (SqlCommand cmdyR = new SqlCommand())
                                {
                                    cmdyR.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_id = '" + gv_bid + "' and unit_code = '" + unitm + "'";
                                    cmdyR.Connection = conyR;
                                    //cmdy.Parameters.AddWithValue("@Book_title", "");
                                    DataTable dtyR = new DataTable();
                                    using (SqlDataAdapter sdayR = new SqlDataAdapter(cmdyR))
                                    {
                                        sdayR.Fill(dtyR);
                                        GridView1.DataSource = dtyR;
                                        GridView1.DataBind();
                                    }

                                    conyR.Close();
                                }
                            }


                            EMLO = Session["username"].ToString().ToUpper();


                            string strcmd12zB;

                            strcmd12zB = "select EMAIL from LOGIN where EMPLOYEE_CODE = '" + EMLO + "' and unit_code = '" + unitm + "'";
                            SqlConnection cn1zB = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            cn1zB.Open();
                            SqlCommand cmd1zB = new SqlCommand(strcmd12zB, cn1zB);
                            SqlDataReader dr1zB = cmd1zB.ExecuteReader();
                            if (dr1zB.Read())
                            {
                                GV_ml = dr1zB[0].ToString();

                            }

                              string strcmd129T;
                            strcmd129T = "select EMAIL from LOGIN where USER_TYPE = 'A' AND   Unit_code = '" + unitm + "' ";
                            SqlConnection cn19T = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            cn19T.Open();
                            SqlCommand cmd19T = new SqlCommand(strcmd129T, cn19T);
                            SqlDataReader dr19T = cmd19T.ExecuteReader();
                            if (dr19T.Read())
                            {
                                U_gv_mail_ADMIN = (dr19T[0].ToString());
                            }



                            using (StringWriter sw = new StringWriter())
                            {
                                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                {
                                    GridView1.RenderControl(hw);
                                    StringReader sr = new StringReader(sw.ToString());
                                    //MailMessage mm = new MailMessage(GV_ml, "himanshukalra@vardhman.com");
                                    MailMessage mm = new MailMessage(GV_ml, U_gv_mail_ADMIN );
                                    mm.Subject = "LIBRARY-Requested for Book";
                                    mm.Body = "Requested Book From:<hr /> Employee Code - " + EMLO.ToUpper() + sw.ToString() + "<br/>" + "Book Id -" + gv_bid + "<br/>" + "Book Name -" + gv_book + "<br/>" + "Author -" + gv_authf + "<br/><br/>";
                                    //mm.Body = "Requested Book From:<hr /> Employee Code - ";
                                    mm.IsBodyHtml = true;
                                    SmtpClient smtp = new SmtpClient();
                                    smtp.Host = "";    // from collage   (main thing the smtp server from where the mails are being sent)
                                    smtp.EnableSsl = false;

                                    NetworkCredential NetworkCred = new NetworkCredential("abc.com", "pass@125634");   // from collage
                                    //NetworkCred.UserName = "sender@gmail.com";
                                    //NetworkCred.Password = "<password>";
                                    smtp.UseDefaultCredentials = true;
                                    smtp.Credentials = NetworkCred;
                                    //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    smtp.Port = 25;
                                    smtp.Send(mm);
                                }
                            }


                            ////////////////////////////////////////////////////////////////////////////

                        string strcmd12z;
                        //strcmd12 = "select avail_status from Book_Master where book_id = '" + gv_bid + "' and Unit_code = '" + unitm + "'";
                        strcmd12z = "select Book_title,Author,avail_status from book_master where book_id = '" + gv_bid + "' and unit_code = '" + unitm + "'";
                        SqlConnection cn1z = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        cn1z.Open();
                        SqlCommand cmd1z = new SqlCommand(strcmd12z, cn1z);
                        SqlDataReader dr1z = cmd1z.ExecuteReader();
                        if (dr1z.Read())
                        {
                            gv_count = (dr1z[2].ToString());
                            if (gv_count == "Available")
                            {
                                SqlConnection cn1wwf = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdwwf;
                                SqlDataAdapter adaptwwf;
                                cmdwwf = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1wwf);
                                // cmdww = new SqlCommand("update book_master SET next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                                cn1wwf.Open();
                                cmdwwf.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdwwf.Parameters.AddWithValue("@next_avail_date", oDaterr);
                                cmdwwf.ExecuteNonQuery();
                                Label1.Text = ".";
                                //////// set to be labled         ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Your request has been submitted.')</script>", false);
                            }

                            else
                            {

                                // oDatee = oDate.AddDays(1);
                                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdww;
                                SqlDataAdapter adaptww;
                                //cmdww = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                                cmdww = new SqlCommand("update book_master SET next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                                cn1ww.Open();
                                cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdww.Parameters.AddWithValue("@next_avail_date", oDaterr);
                                cmdww.ExecuteNonQuery();
                                cn1ww.Close();
                                BindGrid();
                                Label1.Text = ".";
                                //////// set to be labled       ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Book is not available,Your request is put in queue !')</script>", false);
                            }

                        }
                        ///////////////////////////////////////////////////////////////////////////
                        else
                        {
                           
                        }


                            //BindGrid();
                            //Label1.Text = "Your request has been submitted.";

                        }
                        BindGrid();

                        /////////////////////////////////////////////

                        //Label2.Text = gvCustomers.Rows[0].Cells[0].Text.ToString();

                    }
                    //}
                }
               // TextBox1.Text = "";

                foreach (GridViewRow row in gvCustomers.Rows)
                {
                    //CheckBox chkrow = (CheckBox)row.FindControl("chkSelect");
                    //if (chkrow.Checked == true)
                    //{
                    //    chkrow.Checked = false;//it works 
                    //}
                }
                //}
                //else
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "Plaese,enter To date greater than system date or equal";

                //}

            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Plaese,Select Days";


            }


        }
        else
        {

            Label1.Visible = true;
            Label1.Text = "Plaese,Select Value First";

        }

    }

    //public string getdata()
    //{

        //StringBuilder strTable = new StringBuilder();
        //try
        //{
        //    strTable.Append("<table bgcolor='silver' border='1' cellpadding='2' cellspacing='1'>");
        //    strTable.Append("<tr>");
        //    //Create Header Row for Table
        //    foreach (GridViewRow col in gvCustomers.Columns)
        //    {
        //        strTable.AppendFormat("<th>{0}</th>", col.HeaderText);
        //    }
        //    strTable.Append("</tr>");
        //    //Create Table Rows
        //    for (int i = 0; i < gvCustomers.Rows.Count; i++)
        //    {
        //        strTable.Append("<tr>");
        //        foreach (DataGridViewCell cell in gvCustomers.Rows[i].Cells)
        //        {
        //            if (cell.Value != null)
        //            {
        //                strTable.AppendFormat("<td>{0}</td>", cell.Value.ToString());
        //            }
        //        }
        //        strTable.Append("</tr>");
        //    }
        //    strTable.Append("</table>");
        //}

        //catch (Exception ex)
        //{
        //   // MessageBox.Show("Error: " + ex.Message);
        //}
        //return strTable.ToString();

    //}

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' and avail_status in('Available','Reserved','Issued','Requested') AND Unit_code = '" + unitm + "' and book_status = 'Good' order by Book_id";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Book_title", "");
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
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

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    datepicker.Visible = true;  
    //}
    //protected void datepicker_SelectionChanged(object sender, EventArgs e)
    //{
    //    TextBox1.Text = datepicker.SelectedDate.ToShortDateString();
    //    datepicker.Visible = false;
    //    //TextBox1.Enabled = false;
    //}
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = DropDownList1.SelectedItem.Text;
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    BindGridd();
    //}
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridd();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string constrg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection cong = new SqlConnection(constrg))
        {
            using (SqlCommand cmdg = new SqlCommand())
            {
                cmdg.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like + @catgeory  + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
                cmdg.Connection = cong;
                cmdg.Parameters.AddWithValue("@Book_title", TextBox2.Text.Trim());
                if (DropDownList2.Text == "All")
                {
                    cmdg.Parameters.AddWithValue("@catgeory", "");
                }
                else
                {
                    cmdg.Parameters.AddWithValue("@catgeory", DropDownList2.Text);

                }
                DataTable dtg = new DataTable();
                using (SqlDataAdapter sdag = new SqlDataAdapter(cmdg))
                {
                    sdag.Fill(dtg);
                    gvCustomers.DataSource = dtg;
                    gvCustomers.DataBind();
                    if (gvCustomers.Rows.Count == 0)
                    {
                        Label2.Visible = true;
                    }

                }
            }
        }
    }
}