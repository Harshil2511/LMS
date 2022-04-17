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

public partial class _Default : System.Web.UI.Page
{
    string U_type, empl;
    static string gv_unitid;
    string u_unt, gv_fname, gv_mail;
    string gv_chckPas, gv_unamk;
    protected void Page_Load(object sender, EventArgs e)
    {
        test();
        Label1.Visible = false;


    }
    protected void btnsignin_Click(object sender, EventArgs e)
    {
        try
        {

            string strcmd12;
            //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
            strcmd12 = "select user_type,unit_code,first_name,email from login where employee_code='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
            SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            cn1.Open();
            SqlCommand cmd1 = new SqlCommand(strcmd12, cn1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {

                U_type = (dr1[0].ToString());
                u_unt = (dr1[1].ToString());
                gv_fname = (dr1[2].ToString());
                gv_mail = (dr1[3].ToString());
                Session["utypee"] = (dr1[0].ToString());
                Session["username"] = txtname.Text.Trim();
                Session["password"] = txtpass.Text.Trim();
                Session["unitcode"] = DropDownList1.Text;
                Session["unitcodee"] = DropDownList1.Text;
                Session["fname"] = gv_fname;
                Session["mail"] = gv_mail;

                if (U_type == "A" || U_type == "A")
                {
                    //Response.Redirect("Addnewbook.aspx?utype=" + U_type);
                    Response.Redirect("All forms.aspx?utype=" + u_unt);
                    //Response.Redirect("EmployeeRequestGen.aspx?utype=" + u_unt);
                    //Response.Redirect("CheckRequestEmployee.aspx?utype=" + u_unt);
                    //Response.Redirect("Receipt_Book.aspx?utype=" + u_unt);

                }

                else if (U_type == "U" || U_type == "U")
                {
                    /////////////////////////////////////////  him

                    string strcmd12m;
                    //strcmd12 = "select user_type,unit_code,first_name from login1 where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text.Trim() + "' and unit_code = '" + DropDownList1.Text + "'";
                    strcmd12m = "select password from login where employee_code='" + txtname.Text.Trim() + "' AND unit_code = " + DropDownList1.Text + " ";
                    SqlConnection cn1m = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    cn1m.Open();
                    SqlCommand cmd1m = new SqlCommand(strcmd12m, cn1m);
                    SqlDataReader dr1m = cmd1m.ExecuteReader();
                    if (dr1m.Read())
                    {
                        // gv_chckPas = (dr1m[0].ToString());
                        // gv_unamk   = txtname.Text.Trim();
                        gv_chckPas = (dr1m[0].ToString().ToUpper());
                        gv_unamk = txtname.Text.ToUpper();
                        if (gv_chckPas == gv_unamk)
                        {
                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Invalid Login... !!!')</script>", false);
                            Response.Redirect("ChangePassword.aspx");

                        }

                        else
                        {

                            Response.Redirect("user_forms.aspx?utype=" + u_unt + "&Fnamett=" + gv_fname + "&mail=" + gv_mail);

                        }

                    }

                    else
                    {


                    }

                    //////////////////////////////////////// him_end


                    //Response.Redirect("EmployeeRequestGen.aspx?utype=" + u_unt + "&Fnamett=" + gv_fname);
                    //Response.Redirect("user_forms.aspx?utype=" + u_unt + "&Fnamett=" + gv_fname + "&mail=" + gv_mail);
                }
            }

            else
            {
                Label1.Visible = true;
            }

            //using (SqlConnection cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            //{
            //    using (SqlCommand cmd1 = new SqlCommand("select user_type, employee_id  from login where employee_id='" + txtname.Text.Trim() + "' and password='" + txtpass.Text + "", cn1))
            //    {
            //        cn1.Open();
            //        using (SqlDataReader reader = cmd1.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                U_type = reader[0].ToString();
            //                empl = reader[1].ToString();
            //                Session["username"] = txtname.Text.Trim();
            //                Session["password"] = txtpass.Text.Trim();
            //    if (U_type == "A" || U_type == "A")
            //    {
            //        Response.Redirect("Addnewbook.aspx?utype=" + U_type);
            //    }


            //            }
            //        }
            //    }
            //}



            //if (dr1.HasRows)
            //{
            //    string U_type;
            //    U_type = dr1.
            //    Session["username"] = txtname.Text.Trim();
            //    Session["password"] = txtpass.Text.Trim();
            //    if (U_type == "A" || U_type == "A")
            //    {
            //        Response.Redirect("Addnewbook.aspx?utype=" + U_type);
            //    }
            //}
        }
        //else
        //{

            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "<script>alert('Invalid Login... !!!')</script>", false);
        //    Label1.Visible = true;
        //}
        //cn1.Close();
        //dr1.Close();





        catch (Exception ex)
        {
        }
        finally
        {
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