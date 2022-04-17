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

public partial class Previous_issued_books : System.Web.UI.Page
{
    SqlConnection cn1w = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmdw;
    SqlDataAdapter adaptw;
    string gv_emp, gv_book, gv_uc, gv_fnameet, gv_umail;
    string gv_bid;
    string gv_chkdt, EMLO;
    string unitm;
    int GV_ACHK;

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
            gv_fnameet = Session["fname"].ToString();
            gv_umail = Session["mail"].ToString();
            this.BindGrid();
        }
        //this.BindGrid();

        // gv_uc = Session["un_code"].ToString();
        gv_fnameet = Session["fname"].ToString();
        gv_umail = Session["mail"].ToString();

        TextBox1.Text = DropDownList1.Text;
        DropDownList1.Visible = false;
        TextBox1.Visible = false;
        Label3.Visible = false;
        Button3.Visible = false;
        Label4.Visible = false;
        LinkButton1.Visible = false;
        TextBox2.Visible = false;
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }



    //private void BindGridd()
    //{
    //    string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(constr))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
    //            cmd.Connection = con;
    //            cmd.Parameters.AddWithValue("@Book_title", TextBox2.Text.Trim());
    //            DataTable dt = new DataTable();
    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //            {
    //                sda.Fill(dt);
    //                gvCustomers.DataSource = dt;
    //                gvCustomers.DataBind();
    //                if (gvCustomers.Rows.Count == 0)
    //                {
    //                    Label2.Visible = true;
    //                }

    //            }
    //        }
    //    }
    //}

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
            int SLECTD = Convert.ToInt16(Label1.Text);
            int gv_sdlt;
            if (TextBox1.Text != "" && Label1.Text != "")
            {
                //gv_chkdt = TextBox1.Text;
                //DateTime oDate = Convert.ToDateTime(gv_chkdt);
                DateTime oDatee;
                //if (oDate > DateTime.Now)
                //{ 
                GV_ACHK = Convert.ToInt16(TextBox1.Text);
                DateTime oDaterr = DateTime.Now.AddDays(GV_ACHK);
                // gv_uc = Session["un_code"].ToString();

                foreach (GridViewRow row in gvCustomers.Rows)
                //for (int i = 0; i < gvCustomers.Rows.Count; i++)//loop the GridView Rows
                {
                    string gv_bcdee, gv_authf;
                    //CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    //CheckBox chkb = (CheckBox)gvCustomers.Rows[i].Cells[0].FindControl("chk"); //find the CheckBox

                    //if (chk != null & chk.Checked)
                    //{
                    gv_bid = row.Cells[1].Text;
                    gv_sdlt = Convert.ToInt16(gv_bid);
                    if (SLECTD == gv_sdlt)
                    {

                        gv_book = row.Cells[2].Text;
                        gv_bcdee = row.Cells[8].Text;
                        gv_authf = row.Cells[3].Text;
                        //gv_bid = gvCustomers.Rows[i].Cells[0].Text;
                        //gv_book = gvCustomers.Rows[i].Cells[1].Text; 
                        ///////////////////////////////////////////// for checking the book status if reserved 
                        string strcmd12;
                        strcmd12 = "select avail_status from Book_Master where book_id = '" + gv_bid + "' and Unit_code = '" + unitm + "'";
                        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        cn1.Open();
                        SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        if (dr1.Read())
                        {
                            string U_stst;
                            U_stst = (dr1[0].ToString());

                            if (U_stst == "Reserved" || U_stst == "Issued")
                            {

                            }


                            else
                            {
                                cmdw = new SqlCommand("insert into Request_master(employee_id,book_name,Book_id,unit_code,fdate,tdate,bar_code,emp_name,author_name) values(@employee_id,@book_name,@Book_id,@unit_code,@fdate,@tdate,@bar_code,@emp_name,@author_name)", cn1w);
                                cn1w.Open();

                                cmdw.Parameters.AddWithValue("@employee_id", Session["username"].ToString());
                                cmdw.Parameters.AddWithValue("@book_name", gv_book);
                                cmdw.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdw.Parameters.AddWithValue("@unit_code", unitm);
                                cmdw.Parameters.AddWithValue("@fdate", DateTime.Now.ToShortDateString());
                                cmdw.Parameters.AddWithValue("@tdate", oDaterr);
                                cmdw.Parameters.AddWithValue("@bar_code", gv_bcdee);
                                //cmdw.Parameters.AddWithValue("@bar_code", gv_bcdee);
                                cmdw.Parameters.AddWithValue("@emp_name", gv_fnameet);
                                cmdw.Parameters.AddWithValue("@author_name", gv_authf);
                                cmdw.ExecuteNonQuery();
                                cn1w.Close();
                                //TextBox1.Text = "";
                                Label1.Visible = true;

                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Road ID already exists... !')</script>", false);



                                /////////////////////////////////////////////// for uodating the status of checked book into book master 
                                //oDatee = oDate.AddDays(1);
                                //SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                //SqlCommand cmdww;
                                //SqlDataAdapter adaptww;
                                //cmdww = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                                //cn1ww.Open();
                                //cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                                //cmdww.Parameters.AddWithValue("@next_avail_date", oDatee);
                                //cmdww.ExecuteNonQuery();
                                //cn1ww.Close();
                                //BindGrid();
                                //Label1.Text = "Your request has been submitted.";

                                ///////////////////////////////////////////////


                                string constry = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                                using (SqlConnection cony = new SqlConnection(constry))
                                {
                                    using (SqlCommand cmdy = new SqlCommand())
                                    {
                                        cmdy.CommandText = "SELECT Book_title , Book_id, Author, pricing, contents,catgeory,pricing,avail_status,next_avail_date,barcode FROM Book_Master WHERE Book_id = '" + gv_bid + "' and unit_code = '" + unitm + "'";
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


                                EMLO = Session["username"].ToString();
                                using (StringWriter sw = new StringWriter())
                                {
                                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                    {
                                        GridView1.RenderControl(hw);
                                        StringReader sr = new StringReader(sw.ToString());
                                        MailMessage mm = new MailMessage("himanshukalra@vardhman.com", "himanshukalra@vardhman.com");
                                        mm.Subject = "Requested for Book";
                                        mm.Body = "Requested Book From:<hr /> Employee Code - " + EMLO + sw.ToString() + "<br/>" + "Book Id -" + gv_bid + "<br/>" + "Book Name -" + gv_book + "<br/>" + "Author -" + gv_authf + "<br/><br/>";
                                        //mm.Body = "Requested Book From:<hr /> Employee Code - ";
                                        mm.IsBodyHtml = true;
                                        SmtpClient smtp = new SmtpClient();
                                        smtp.Host = "172.28.0.254";
                                        smtp.EnableSsl = false;

                                        NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
                                        //NetworkCred.UserName = "sender@gmail.com";
                                        //NetworkCred.Password = "<password>";
                                        smtp.UseDefaultCredentials = true;
                                        smtp.Credentials = NetworkCred;
                                        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.Port = 25;
                                        smtp.Send(mm);
                                    }
                                }



                                ///////////////////////////////////////////// for uodating the status of checked book into book master 
                                //  oDatee = oDate.AddDays(1);
                                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                                SqlCommand cmdww;
                                SqlDataAdapter adaptww;
                                cmdww = new SqlCommand("update book_master set avail_status ='Reserved' , next_avail_date=@next_avail_date where Book_id=@Book_id and Unit_code = '" + unitm + "'", cn1ww);
                                cn1ww.Open();
                                cmdww.Parameters.AddWithValue("@Book_id", gv_bid);
                                cmdww.Parameters.AddWithValue("@next_avail_date", oDaterr);
                                cmdww.ExecuteNonQuery();
                                cn1ww.Close();
                                BindGrid();
                                Label1.Text = "Your request has been submitted.";

                                /////////////////////////////////////////////


                                BindGrid();
                                //MailAddress SendFrom = new MailAddress("himanshukalra@vardhman.com");
                                //MailAddress SendTo = new MailAddress("himanshukalra@vardhman.com");
                                //System.Net.Mail.MailMessage MyMessage = new System.Net.Mail.MailMessage(SendFrom, SendTo);
                                //MyMessage.Subject = "Requested for Book";
                                //MyMessage.Body = "<html><BODY><div style='background-color:rgb(133, 178, 19);width:100%;color:white;height:20px;padding: 13px;font-size: 24px;font-style: oblique'><b><u>REQUESTED FOR BOOK</u><b></div><div style='color:AD2424;height:20px;padding: 5px;font-size: 15px;width:50%;background-color: rgb(188, 210, 131)'>DATE - " + DateTime.Now.ToShortDateString() + " </div><br/> <div>   </div><br/><div style='background-color:rgb(133, 178, 19);width:100%;color:white;height:20px;padding: 13px;font-size: 19px'>This is a system generated mail. Please do not reply.</div></BODY></html>";
                                //MyMessage.IsBodyHtml = true;

                                //SmtpClient smtp = new SmtpClient();
                                //smtp.Host = "172.28.0.254";
                                //smtp.EnableSsl = false;
                                //NetworkCredential NetworkCred = new NetworkCredential("himanshukalra@vardhman.com", "pass@1234");
                                //smtp.UseDefaultCredentials = true;
                                //smtp.Credentials = NetworkCred;
                                //smtp.Port = 25;
                                //smtp.Send(MyMessage);


                            }
                        }
                        BindGrid();

                        /////////////////////////////////////////////

                        //Label2.Text = gvCustomers.Rows[0].Cells[0].Text.ToString();

                    }
                    //}
                }
                TextBox1.Text = "";

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
        //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "SELECT Book_id,Book_name,employee_id,emp_mail_id,Book_status FROM Issued_book_master WHERE employee_id = '" + Session["username"].ToString() + "' AND Book_status = 'Issued' AND Unit_code = '" + unitm + "'";
        //        cmd.Connection = con;
        //        //cmd.Parameters.AddWithValue("@Book_title", "");
        //        DataTable dt = new DataTable();
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //        {
        //            sda.Fill(dt);
        //            gvCustomers.DataSource = dt;
        //            gvCustomers.DataBind();
        //        }

        //        con.Close();
        //    }
        //}

        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Book_id,Book_name,employee_id,req_status FROM request_master WHERE employee_id = '" + Session["username"].ToString() + "' AND req_status in ('Issued') AND Unit_code = '" + unitm + "'";
                cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@Book_title", "");
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       // BindGridd();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeRequestGen.aspx?ucd=" + unitm);
    }
}