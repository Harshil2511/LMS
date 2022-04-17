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
using System.Drawing;

public partial class ViewBook : System.Web.UI.Page
{
    string unitm;

    protected void Page_Load(object sender, EventArgs e)
    {


        test();
        Button1.Visible = true;
        unitm = Request.QueryString["ucd"].ToString();
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        if (!this.IsPostBack)
        {
            DropDownList1.Items.Clear();
            string strcmdtY = "select category from cat_master order by category ";
            SqlConnection cntY = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cntY.Open();
            SqlCommand cmdtY = new SqlCommand(strcmdtY, cntY);
            SqlDataAdapter datY = new SqlDataAdapter(cmdtY);
            DataSet dstY = new DataSet();
            datY.Fill(dstY);
            foreach (DataRow drtY in dstY.Tables[0].Rows)
            {
                DropDownList1.Items.Add(drtY[0].ToString());
            }
            cntY.Close();
            this.BindGrid();
            
        }
        Label2.Visible = false;
    }

    //protected void Search(object sender, EventArgs e)
    //{
    //    this.BindGrid();
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindGrid();
    }


    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like  '" + DropDownList1.SelectedValue + "' + '%' and unit_code = '" + unitm + "'";
                cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND catgeory like   + @catgeory  + '%' and unit_code = '" + unitm + "' ORDER BY BOOK_ID";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                if (DropDownList1.Text == "All")
                {
                    cmd.Parameters.AddWithValue("@catgeory", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@catgeory", DropDownList1.Text);

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

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomers.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, TextBox1.Text.Trim(), delegate(Match match)
            {
                return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
            }, RegexOptions.IgnoreCase);
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


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

       
            string constrT = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection conT = new SqlConnection(constrT))
            {
                using (SqlCommand cmdT = new SqlCommand())
                {
                    
                    //cmdT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,avail_status FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND   catgeory like  '" + DropDownList1.SelectedValue.Trim() + "' + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
                    //cmdT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND   catgeory like  '" + DropDownList1.SelectedValue.Trim() + "' + '%' and unit_code = '" + unitm + "'";
                    cmdT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND   catgeory like   + @catgeory + '%' and unit_code = '" + unitm + "'";
                    cmdT.Connection = conT;
                    cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                    if (DropDownList1.Text == "All")
                    {
                        cmdT.Parameters.AddWithValue("@catgeory", "");
                    }
                    else
                    {
                        cmdT.Parameters.AddWithValue("@catgeory", DropDownList1.Text);

                    }
                    DataTable dtT = new DataTable();
                    using (SqlDataAdapter sdaT = new SqlDataAdapter(cmdT))
                    {
                        sdaT.Fill(dtT);
                        gvCustomers.DataSource = dtT;
                        gvCustomers.DataBind();
                        if (gvCustomers.Rows.Count == 0)
                        {
                            Label2.Visible = true;
                        }

                    }
                }
            }

            //if (TextBox1.Text != "")
            //{
            //    string constrTT = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //    using (SqlConnection conTT = new SqlConnection(constrTT))
            //    {
            //        using (SqlCommand cmdTT = new SqlCommand())
            //        {
            //            cmdTT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,avail_status FROM Book_Master WHERE Book_title =  '" + TextBox1.Text + "'  and unit_code = '" + unitm + "' and book_status = 'Good'";
            //            cmdTT.Connection = conTT;
            //            //cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
            //            DataTable dtTT = new DataTable();
            //            using (SqlDataAdapter sdaTT = new SqlDataAdapter(cmdTT))
            //            {
            //                sdaTT.Fill(dtTT);
            //                gvCustomers.DataSource = dtTT;
            //                gvCustomers.DataBind();
            //                if (gvCustomers.Rows.Count == 0)
            //                {
            //                    Label2.Visible = true;
            //                }

            //            }
            //        }
            //    }

            //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            gvCustomers.AllowPaging = false;
            this.BindGrid();

            gvCustomers.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in gvCustomers.HeaderRow.Cells)
            {
                cell.BackColor = gvCustomers.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvCustomers.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvCustomers.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvCustomers.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvCustomers.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}