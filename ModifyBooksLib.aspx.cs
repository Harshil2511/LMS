using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ModifyBooksLib : System.Web.UI.Page
{
    string unitm, BSrc, BId ;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
       // Label2.Visible = false;
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

    public void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents , b_location , b_loc , catgeory , o_catgeory FROM Book_Master WHERE book_status = 'Good' AND unit_code = '" + unitm + "' order by Book_id ";
                cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
                DataTable dt = new DataTable();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }
        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BId = "";
         BId = GridView1.SelectedRow.Cells[0].Text;
       
        string strcmd = "select Book_id, Book_title, Author, pricing, contents , b_location , b_loc , catgeory , o_catgeory , b_source from Book_master where Book_id ='" + BId + "' AND unit_code = '" + unitm + "' ";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        cn.Open();
        SqlCommand cmd = new SqlCommand(strcmd, cn);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            BSrc          = (dr[9].ToString());
            TextBox5.Text = (dr[0].ToString());
            TextBox1.Text = (dr[1].ToString());
            TextBox4.Text = (dr[4].ToString());
            TextBox2.Text = (dr[2].ToString());
            TextBox3.Text = (dr[3].ToString());
            DropDownList1.Text = (dr[7].ToString());
            if(BSrc == "Purchase")
            {
                RadioButton1.Checked = true;
                RadioButton2.Checked = false;
            }
            else if(BSrc == "Gifted")
            {
                RadioButton2.Checked = true;
                RadioButton1.Checked = false;
            }
            else
            {
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;
            }
            TextBox6.Text = (dr[8].ToString());
            TextBox8.Text = (dr[5].ToString());
            TextBox7.Text = (dr[6].ToString());

        }
        cn.Close();
      //  BId = "";
        BSrc = "";


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (TextBox5.Text != "")
        {

            string strcmd12;
            strcmd12 = "select DISTINCT BOOK_ID from Request_master where book_id = '" + TextBox5.Text + "' AND unit_code = '" + unitm + "' ";
            SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Already Transacted')</script>", false);
            }

            else
            {
                SqlConnection cn1ww = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmdww;
                SqlDataAdapter adaptww;
                cmdww = new SqlCommand("update book_master set Book_title =@Book_title , Author =@Author , pricing =@pricing , contents =@contents , catgeory =@catgeory , o_catgeory =@o_catgeory , b_location =@b_location , b_loc =@b_loc , b_source =@b_source  where Book_id= '" + TextBox5.Text + "' AND unit_code = '" + unitm + "'", cn1ww);
                cn1ww.Open();
                //cmdww.Parameters.AddWithValue("@Book_id", BId);
                cmdww.Parameters.AddWithValue("@Book_title", TextBox1.Text);
                cmdww.Parameters.AddWithValue("@Author", TextBox2.Text);
                cmdww.Parameters.AddWithValue("@pricing", TextBox3.Text);
                cmdww.Parameters.AddWithValue("@contents", TextBox4.Text);
                cmdww.Parameters.AddWithValue("@catgeory", DropDownList1.Text);
                cmdww.Parameters.AddWithValue("@o_catgeory", TextBox6.Text);
                cmdww.Parameters.AddWithValue("@b_location", TextBox8.Text);
                cmdww.Parameters.AddWithValue("@b_loc", TextBox7.Text);
                if (RadioButton1.Checked == true)
                {
                    cmdww.Parameters.AddWithValue("@b_source", "Purchase");
                }
                if (RadioButton2.Checked == true)
                {
                    cmdww.Parameters.AddWithValue("@b_source", "Gifted");
                }



                cmdww.ExecuteNonQuery();
                cn1ww.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Record Updated Successfully')</script>", false);
                BindGrid();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Select Book Id')</script>", false);
        }

    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string constrG = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //using (SqlConnection conG = new SqlConnection(constrG))
        //{
        //    using (SqlCommand cmdG = new SqlCommand())
        //    {
        //        //cmd.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like  '" + DropDownList1.SelectedValue + "' + '%' and unit_code = '" + unitm + "'";
        //        cmdG.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents,catgeory,o_catgeory,b_location,b_loc,avail_status,book_status FROM Book_Master WHERE Book_title LIKE + @Book_title + '%' AND catgeory like   + @catgeory  + '%' and unit_code = '" + unitm + "'";
        //        cmdG.Connection = conG;
        //        cmdG.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());
        //        if (DropDownList1.Text == "All")
        //        {
        //            cmdG.Parameters.AddWithValue("@catgeory", "");
        //        }
        //        else
        //        {
        //            cmdG.Parameters.AddWithValue("@catgeory", DropDownList1.Text);

        //        }
        //        DataTable dt = new DataTable();
        //        using (SqlDataAdapter sda = new SqlDataAdapter(cmdG))
        //        {
        //            sda.Fill(dt);
        //            GridView1.DataSource = dt;
        //            GridView1.DataBind();
        //            if (GridView1.Rows.Count == 0)
        //            {
        //              //  Label2.Visible = true;
        //            }

        //        }
        //    }
        //}
        string constrT = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conT = new SqlConnection(constrT))
        {
            using (SqlCommand cmdT = new SqlCommand())
            {
                cmdT.CommandText = "SELECT Book_id, Book_title, Author, pricing, contents , b_location , b_loc , catgeory , o_catgeory FROM Book_Master WHERE Book_title LIKE '%' + @Book_title + '%' AND catgeory like   + @catgeory + '%' and unit_code = '" + unitm + "' and book_status = 'Good'";
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
                // cmdT.Parameters.AddWithValue("@Book_title", TextBox1.Text.Trim());

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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBox5.Text = "";
        //TextBox1.Text = "";
        //TextBox4.Text = "";
        //TextBox2.Text = "";
        //TextBox3.Text = "";
        //TextBox6.Text = "";
        //TextBox8.Text = "";
        //TextBox7.Text = "";
        //RadioButton1.Checked = false;
        //RadioButton2.Checked = false;


       

    }
}