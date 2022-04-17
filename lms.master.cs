using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lms : System.Web.UI.MasterPage
{
    static string name_id;
    static string gv_unitidt;
    static string name_idd;
    string U_type;
    protected void Page_Load(object sender, EventArgs e)
    {
        name_id = Session["username"].ToString();
        name.Text = name_id;
        name_idd = Session["fname"].ToString();
        name2.Text = name_idd;
        gv_unitidt = Session["unitcodee"].ToString();
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
    //    Response.Redirect("All forms.aspx");
    //}
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string strcmd12;
        //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
        strcmd12 = "select user_type,unit_code,first_name,email from login where employee_code='" + name_id.Trim() + "'";
        SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        cn1.Open();
        SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
        SqlDataReader dr1 = cmd1.ExecuteReader();
        if (dr1.Read())
        {

            U_type = (dr1[0].ToString());


            if (U_type == "A" || U_type == "A")
            {

                Response.Redirect("All forms.aspx");

            }

            else
            {
                Response.Redirect("user_forms.aspx");

            }
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
}
