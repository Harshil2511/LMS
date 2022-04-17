using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
//using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    static string name_id;
    static string gv_unitid;
    string gv_utyp;
    static string name_idd;
    string gv_chckPas, gv_unamk;
    protected void Page_Load(object sender, EventArgs e)
    {
        name_id = Session["username"].ToString();
        name.Text = name_id;
        name2.Text = Session["fname"].ToString();
        gv_unitid = Session["unitcode"].ToString();
        gv_utyp = Session["utypee"].ToString();
        name.Visible = false;
        if (Session["username"] == null && Session["password"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void linklogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    //Session.Abandon();
    //    Response.Redirect("All forms.aspx");
    //}
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (gv_utyp == "A")
        {
            Response.Redirect("All forms.aspx");
        }
        if (gv_utyp == "U")
        {

            //////////////////////
            string strcmd12m;
            //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
            strcmd12m = "select password from login where employee_code='" + name_id.Trim() + "' ";
            SqlConnection cn1m = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cn1m.Open();
            SqlCommand cmd1m = new SqlCommand(strcmd12m, cn1m);
            SqlDataReader dr1m = cmd1m.ExecuteReader();
            if (dr1m.Read())
            {
                gv_chckPas = (dr1m[0].ToString().ToUpper());
                gv_unamk = name_id.Trim().ToUpper();
                if (gv_chckPas == gv_unamk)
                {
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Invalid Login... !!!')</script>", false);
                    Response.Redirect("ChangePassword.aspx");

                }

                else
                {

                    Response.Redirect("user_forms.aspx");

                }

            }

            else
            {


            }
            //////////////////////


            //Response.Redirect("user_forms.aspx");
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
}
