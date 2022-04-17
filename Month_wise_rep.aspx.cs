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

public partial class Month_wise_rep : System.Web.UI.Page
{
    string U_type;
    string dt, dtt;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
         dt = Request.Form[txtDate.UniqueID];
         dtt = Request.Form[TextBox1.UniqueID];
        if (dt == "" && dt == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Selected Date: " + dt + "');", true);
        }

        else
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.CommandText = "SELECT Issue_id, Book_id, book_name, employee_id, emp_mail_id, receipt_stat ,fdate,tdate,bar_code,req_id,user_receipt_status FROM Issued_book_master WHERE Book_status = 'Issued' and UNIT_CODE = '" + unitm + "' order by Issue_id desc";
                    cmd.CommandText = "SELECT * from Issued_book_master  where CONVERT(NVARCHAR(50),CONVERT(DATE, fdate,105)) between '" + dt + "' and '" + dtt + "'";
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@Book_title", "");
                    DataTable dty = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dty);
                        GridView1.DataSource = dty;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                    }

                    con.Close();
                }
            }

        }
       
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

   
   
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("All forms.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportMenu.aspx");
    }
}