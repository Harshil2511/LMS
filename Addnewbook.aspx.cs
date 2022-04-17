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

public partial class Addnewbook : System.Web.UI.Page
{
    SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmd;
    SqlDataAdapter adapt; 
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
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
    }
    protected void btnregistration_Click(object sender, EventArgs e)
    {

        if (txtfname.Text != "" && txtlname.Text != "")
        {
            cmd = new SqlCommand("insert into Book_Master(Book_title,Unit_code,Author,pricing,contents,catgeory,barcode) values(@Book_title,@Unit_code,@Author,@pricing,@contents,@catgeory,@barcode)", cn1);
            cn1.Open();
            cmd.Parameters.AddWithValue("@Book_title", txtfname.Text);
            cmd.Parameters.AddWithValue("@Unit_code", "VMM");
            cmd.Parameters.AddWithValue("@Author", txtcity.Text);
            cmd.Parameters.AddWithValue("@pricing", txtemail.Text);
            cmd.Parameters.AddWithValue("@contents", txtlname.Text);
            cmd.Parameters.AddWithValue("@catgeory", txtpassword.Text);
            cmd.Parameters.AddWithValue("@barcode", barcode.Text);
            cmd.ExecuteNonQuery();
            cn1.Close();
           
            //MessageBox.Show("Record Inserted Successfully");
            get_barcode();
            txtfname.Text = "";
            txtcity.Text ="";
            txtemail.Text  ="";
            txtlname.Text ="";
            txtpassword.Text ="";
            barcode.Text = "";
            plBarCode.Controls.Clear();
            
        }

    }


    public void get_barcode()
    {
        string barCode = barcode.Text;
        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
        {
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                Font oFont = new Font("IDAutomationHC39M", 16);
                PointF point = new PointF(2f, 2f);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                SolidBrush whiteBrush = new SolidBrush(Color.White);
                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
            plBarCode.Controls.Add(imgBarCode);
        }

        lblmsg.Visible = true;
    }

    public void test()
    {
        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }
}