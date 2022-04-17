using System;
using System.Collections;
using System.Configuration;
using System.Data;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public partial class Default2 : System.Web.UI.Page
{
    string unitm, Gv_id, gv_idd, gv_main;
    int GV_BAR,GV_BAR_MAIN;
    int GV_BARB, GV_BAR_MAINB;
    SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmd;
    SqlDataAdapter adapt; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Visible = false;
        Button2.Visible = false;
        TextBox4.Visible = false;
       // Label1.Visible = false;
        //TextBox1.Visible = false;
        LinkButton2.Visible = false;
        test();
        unitm = Request.QueryString["ucd"].ToString();
        lblmsg.Visible = false;
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }

        //else
        //{
        //    string utyp = Request.QueryString["utype"];  
        //    Label1.Visible = true;
        //    Label1.Text = "welcome" + Session["username"];  
        //}

       //TextBox1.Enabled = false;
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
      

    }
    protected void btnregistration_Click(object sender, EventArgs e)
    {

        if (txtfname.Text != "" && txtcity.Text != "" && txtemail.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && (RadioButton1.Checked == true && TextBox1.Text != "" || RadioButton2.Checked == true && TextBox1.Text != ""))
        {

            

            string strcmd126;
            //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
            strcmd126 = "select DISTINCT barcode from BOOK_MASTER where barcode='" + barcode.Text.Trim() + "' AND UNIT_CODE = '" + unitm + "' ";
            SqlConnection cn16 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cn16.Open();
            SqlCommand cmd16 = new SqlCommand(strcmd126, cn16);
            SqlDataReader dr16 = cmd16.ExecuteReader();
            if (dr16.Read())
            {

            }
           
           else
            {

                ////////////////////////////////////////////////////////////////
                string strcmd12;
                strcmd12 = "select MAX(barcode) from BOOK_MASTER WHERE UNIT_CODE = '" + unitm + "' ";
                SqlConnection cn11 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                cn11.Open();
                SqlCommand cmd1 = new SqlCommand(strcmd12, cn11);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                   
                    if (dr1[0] == DBNull.Value)
                    {
                        GV_BAR_MAIN = 100001;
                        barcode.Text = GV_BAR_MAIN.ToString();

                    }
                    else
                    {
                        GV_BAR = Convert.ToInt32(dr1[0]);
                        GV_BAR_MAIN = GV_BAR + 1;
                        barcode.Text = GV_BAR_MAIN.ToString() ;

                    }

                }
                cn11.Close();

                ///////////////////////////////////////////////////////////////

                //////////////////////////////////////////////////////////////


                string strcmd12Y;
                strcmd12Y = "select MAX(Book_id) from BOOK_MASTER WHERE UNIT_CODE = '" + unitm + "' ";
                SqlConnection cn11Y = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                cn11Y.Open();
                SqlCommand cmd1Y = new SqlCommand(strcmd12Y, cn11Y);
                SqlDataReader dr1Y = cmd1Y.ExecuteReader();
                if (dr1Y.Read())
                {
                     if (dr1Y[0] == DBNull.Value)
                    {
                       //// GV_BARB = 100001;
                       //// GV_BAR_MAINB = GV_BARB;
                        //  barcode.Text = GV_BAR_MAIN.ToString();
                            if (unitm == "100")
                        {
                            GV_BARB = 100001;
                            GV_BAR_MAINB = GV_BARB;
                            barcode.Text = GV_BAR_MAINB.ToString();
                        }

                        else if (unitm == "530")
                        {
                            GV_BARB = 530001;
                            GV_BAR_MAINB = GV_BARB;
                            barcode.Text = GV_BAR_MAINB.ToString();
                        }




                    }

                    else 
                    {
                        GV_BARB = Convert.ToInt32(dr1Y[0]);
                        GV_BAR_MAINB = GV_BARB + 1;
                        //  barcode.Text = GV_BAR_MAIN.ToString();
                        barcode.Text = GV_BAR_MAINB.ToString();
                    }
                   
                       // GV_BARB = Convert.ToInt32(dr1Y[0]);
                      //  GV_BAR_MAINB = GV_BARB + 1;
                      ////  barcode.Text = GV_BAR_MAIN.ToString();

                    

                }
                cn11Y.Close();



                /////////////////////////////////////////////////////////////



                cmd = new SqlCommand("insert into Book_Master(Book_id,Book_title,Unit_code,Author,pricing,contents,catgeory,barcode,avail_status,next_avail_date,c_user,o_catgeory,b_location,book_status,b_loc,b_source) values(@Book_id,@Book_title,@Unit_code,@Author,@pricing,@contents,@catgeory,@barcode,@avail_status,@next_avail_date,@c_user,@o_catgeory,@b_location,@book_status,@b_loc,@b_source)", cn1);
            cn1.Open();
            cmd.Parameters.AddWithValue("@Book_id", GV_BAR_MAINB);
            cmd.Parameters.AddWithValue("@Book_title", txtfname.Text);
            cmd.Parameters.AddWithValue("@Unit_code", unitm);
            cmd.Parameters.AddWithValue("@Author", txtcity.Text);
            cmd.Parameters.AddWithValue("@pricing", txtemail.Text);
            cmd.Parameters.AddWithValue("@contents", txtlname.Text);
            cmd.Parameters.AddWithValue("@catgeory", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@barcode", barcode.Text);
            cmd.Parameters.AddWithValue("@avail_status", "Available");
            cmd.Parameters.AddWithValue("@next_avail_date", DBNull.Value);
            cmd.Parameters.AddWithValue("@c_user", Session["username"].ToString().ToUpper());
            cmd.Parameters.AddWithValue("@o_catgeory", TextBox1.Text);
            cmd.Parameters.AddWithValue("@b_location", TextBox2.Text);
            cmd.Parameters.AddWithValue("@book_status", "Good");
            cmd.Parameters.AddWithValue("@b_loc", TextBox3.Text);
            if(RadioButton1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@b_source", "Purchase");
            }
            else
            {
                cmd.Parameters.AddWithValue("@b_source", "Gifted");

            }
            cmd.ExecuteNonQuery();
            cn1.Close();

            //MessageBox.Show("Record Inserted Successfully");
            get_barcode();
            txtfname.Text = string.Empty;
            txtcity.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtlname.Text = string.Empty;
            //txtpassword.Text = "";
            barcode.Text = string.Empty;
            lblmsg.Visible = false;
            //lblmsg.Text = "Record Inserted Successfully.!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Record Inserted Successfully')</script>", false);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
           // Response.Redirect(Request.Url.AbsoluteUri);
            

            //plBarCode.Controls.Clear();
            //Response.Redirect("Default2.aspx");
        }
            cn16.Close();
        }

        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "All * fields are required.!";

        }



    }


    public void get_barcode()
    {
        //string barCode = barcode.Text;
        //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
        //{
        //    using (Graphics graphics = Graphics.FromImage(bitMap))
        //    {
        //        Font oFont = new Font("IDAutomationHC39M", 16);
        //        PointF point = new PointF(2f, 2f);
        //        SolidBrush blackBrush = new SolidBrush(Color.Black);
        //        SolidBrush whiteBrush = new SolidBrush(Color.White);
        //        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
        //        graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
        //    }
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        byte[] byteImage = ms.ToArray();

        //        Convert.ToBase64String(byteImage);
        //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //    }
           //plBarCode.Controls.Add(imgBarCode);
        //}

        //lblmsg.Visible = true;
    }

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //   // Response.Redirect("All forms.aspx");
    //}
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(DropDownList1.Text == "Others")
        //{
        //    TextBox1.Enabled = true;
        //}
        //else
        //{
        //    TextBox1.Enabled = false;
        //    TextBox1.Text = "";

        //}

    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        TextBox4.Visible = true;
        TextBox4.Enabled = true;
        LinkButton2.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox4.Visible = false;
        TextBox4.Text = "";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if(TextBox4.Text != "")
        {

            SqlConnection cn1B = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmdB;
            cmdB = new SqlCommand("insert into CAT_MASTER(CATEGORY) values(@CATEGORY)", cn1B);
            cn1B.Open();
            cmdB.Parameters.AddWithValue("@CATEGORY", TextBox4.Text);
            cmdB.ExecuteNonQuery();
            cn1B.Close();

            DropDownList1.Items.Clear();
            string strcmdtF = "select category from cat_master order by category ";
            SqlConnection cntF = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cntF.Open();
            SqlCommand cmdtF = new SqlCommand(strcmdtF, cntF);
            SqlDataAdapter datF = new SqlDataAdapter(cmdtF);
            DataSet dstF = new DataSet();
            datF.Fill(dstF);
            foreach (DataRow drtF in dstF.Tables[0].Rows)
            {
                DropDownList1.Items.Add(drtF[0].ToString());
            }
            cntF.Close();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Category Successfully Inserted')</script>", false);
            TextBox4.Text = "";

        }

        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Please,fill category')</script>", false);
            TextBox4.Text = "";

        }
    }
}