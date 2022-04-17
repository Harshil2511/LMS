using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Max_Book_Issue_Rpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DropDownList1.Items.Clear();
            string strcmdt = "select category from cat_master order by category ";
            SqlConnection cnt = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cnt.Open();
            SqlCommand cmdt = new SqlCommand(strcmdt, cnt);
            SqlDataAdapter dat = new SqlDataAdapter(cmdt);
            DataSet dst = new DataSet();
            dat.Fill(dst);
            foreach (DataRow drt in dst.Tables[0].Rows)
            {
                DropDownList1.Items.Add(drt[0].ToString());
            }
            cnt.Close();

        }

        string constrTY = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conTY = new SqlConnection(constrTY))
        {
            using (SqlCommand cmdTY = new SqlCommand())
            {
                cmdTY.CommandText = "select a.book_id,a.book_title,a.catgeory,  count(a.Book_id) as MaximumNoIssued  from Book_Master a,Issued_book_master b where a.Book_id = b.Book_id and a.catgeory = '" + DropDownList1.SelectedValue.Trim() + "'  group by a.book_id,a.book_title,a.catgeory   order by a.Book_id ";
                cmdTY.Connection = conTY;
                //cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dtTY = new DataTable();
                using (SqlDataAdapter sdaTY = new SqlDataAdapter(cmdTY))
                {
                    sdaTY.Fill(dtTY);
                    GridView1.DataSource = dtTY;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count == 0)
                    {
                        //Label2.Visible = true;
                    }

                }
            }
        }
        //ImageButton1.Visible = true;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         string constrT = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conT = new SqlConnection(constrT))
        {
            using (SqlCommand cmdT = new SqlCommand())
            {
                cmdT.CommandText = "select a.book_id,a.book_title,a.catgeory,  count(a.Book_id) as MaximumNoIssued  from Book_Master a,Issued_book_master b where a.Book_id = b.Book_id and a.catgeory = '" + DropDownList1.SelectedValue.Trim() + "'  group by a.book_id,a.book_title,a.catgeory   order by a.Book_id ";
                cmdT.Connection = conT;
                //cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dtT = new DataTable();
                using (SqlDataAdapter sdaT = new SqlDataAdapter(cmdT))
                {
                    sdaT.Fill(dtT);
                    GridView1.DataSource = dtT;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count == 0)
                    {
                        //ImageButton1.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('No Record Found')</script>", false);
                    }

                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("All forms.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportMenu.aspx");
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
            GridView1.AllowPaging = false;
            // this.BindGrid();

            GridView1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in GridView1.HeaderRow.Cells)
            {
                cell.BackColor = GridView1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GridView1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
}