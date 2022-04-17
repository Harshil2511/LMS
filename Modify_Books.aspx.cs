using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Modify_Books : System.Web.UI.Page
{
    string unitm;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        Label2.Visible = false;
        unitm = Request.QueryString["ucd"].ToString();
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }
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
            this.BindGrid();
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
    private void BindGrid()
    {
        //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand("SELECT Book_id,Book_title,Author,pricing FROM Book_Master"))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = con;
        //            sda.SelectCommand = cmd;
        //            using (DataTable dt = new DataTable())
        //            {
        //                sda.Fill(dt);
        //                GridView1.DataSource = dt;
        //                GridView1.DataBind();
        //            }
        //        }
        //    }
        //}
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents , b_location , b_loc , catgeory , o_catgeory FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like  '" + DropDownList1.SelectedValue + "' + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count == 0)
                    {
                        Label2.Visible = true;
                    }

                }
            }
        }
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.BindGrid();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int Book_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string Book_title = (row.Cells[2].Controls[0] as TextBox).Text;
        string Author = (row.Cells[3].Controls[0] as TextBox).Text;
        string pricing = (row.Cells[4].Controls[0] as TextBox).Text;
        string contents = (row.Cells[5].Controls[0] as TextBox).Text;
        string location = (row.Cells[6].Controls[0] as TextBox).Text;
        string blocation = (row.Cells[7].Controls[0] as TextBox).Text;
        string ocatgeory = (row.Cells[9].Controls[0] as TextBox).Text;
        DropDownList drpgender = GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;

        string strcmd12;
        strcmd12 = "select DISTINCT BOOK_ID from Request_master where book_id = '" + Book_id + "'";
        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        cn1.Open();
        SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        if (dr1.Read())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Already Transacted')</script>", false);
        }
        //GridViewRow row = GridView1.Rows[e.RowIndex];
        //int Book_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //string Book_title = (row.Cells[2].Controls[0] as TextBox).Text;
        //string Author = (row.Cells[3].Controls[0] as TextBox).Text;
        //string pricing = (row.Cells[4].Controls[0] as TextBox).Text;
        //string contents = (row.Cells[5].Controls[0] as TextBox).Text;
        //string ocatgeory = (row.Cells[7].Controls[0] as TextBox).Text;
        //DropDownList drpgender = GridView1.Rows[e.RowIndex].FindControl("DropDownList2") as DropDownList;
        else
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Book_Master SET Book_title = @Book_title, Author = @Author, pricing = @pricing, contents=@contents, catgeory=@catgeory , o_catgeory=@o_catgeory , b_location=@b_location , b_loc=@b_loc  WHERE Book_id = @Book_id"))
                {
                    cmd.Parameters.AddWithValue("@Book_id", Book_id);
                    cmd.Parameters.AddWithValue("@Book_title", Book_title);
                    cmd.Parameters.AddWithValue("@Author", Author);
                    cmd.Parameters.AddWithValue("@pricing", pricing);
                    cmd.Parameters.AddWithValue("@contents", contents);
                    cmd.Parameters.AddWithValue("@catgeory", drpgender.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@o_catgeory", ocatgeory);
                    cmd.Parameters.AddWithValue("@b_location", location);
                    cmd.Parameters.AddWithValue("@b_loc", blocation);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
    }

    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView1.EditIndex = -1;
        this.BindGrid();
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
        //{
        //    (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        //}
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId"))
        //    {
        //        cmd.Parameters.AddWithValue("@CustomerId", customerId);
        //        cmd.Connection = con;
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
        //this.BindGrid();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string constrT = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conT = new SqlConnection(constrT))
        {
            using (SqlCommand cmdT = new SqlCommand())
            {
                cmdT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents , b_location , b_loc , catgeory , o_catgeory FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND   catgeory like  '" + DropDownList1.SelectedValue.Trim() + "' + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
                cmdT.Connection = conT;
                cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dtT = new DataTable();
                using (SqlDataAdapter sdaT = new SqlDataAdapter(cmdT))
                {
                    sdaT.Fill(dtT);
                    GridView1.DataSource = dtT;
                    GridView1.DataBind();
                    if (GridView1.Rows.Count == 0)
                    {
                        Label2.Visible = true;
                    }

                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.BindGrid();
    }
}