using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    string unitm;
    SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
    SqlCommand cmd;
    SqlDataAdapter adapt; 
    string gv_chckPas ;

    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        Label5.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

      string strcmd12m;
        //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
        strcmd12m = "select employee_code from login where employee_code='" + Session["username"].ToString() + "'";
        SqlConnection cn1m = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        cn1m.Open();
        SqlCommand cmd1m = new SqlCommand(strcmd12m, cn1m);
        SqlDataReader dr1m = cmd1m.ExecuteReader();
        if (dr1m.Read())
        {
            gv_chckPas = (dr1m[0].ToString());

            if (gv_chckPas == TextBox2.Text.ToUpper())
            {
                Label5.Visible = true;
                Label5.Text = "Not Allowed for Same as an User-ID";

            }




 else
            {
                cmd = new SqlCommand("update LOGIN set password = '" + TextBox1.Text + "' where employee_code = '" + Session["username"].ToString() + "'  ", cn1);
                cn1.Open();
                //cmd.Parameters.AddWithValue("@b_location", TextBox2.Text);
                //cmd.Parameters.AddWithValue("@book_status", "Good");
                cmd.ExecuteNonQuery();
                cn1.Close();
                Label5.Visible = true;
                Label5.Text = "Changed Successfully";

            }

        }


        
    }

     public void test()
    {
        HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
        HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
        HttpContext.Current.Response.AddHeader("Expires", "0");

        HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();
    }

}