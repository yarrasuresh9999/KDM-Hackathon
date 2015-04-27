using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class youlogin_forgotnewpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["sesPassChg"]== null)
            Response.Redirect("Default.aspx");
    }
    protected void Register_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        try
        {
            String x = txtPassword.Value;
            String y = txtConfirmPass.Value;
            int a=Convert.ToInt32(Session["SesPassChg"]);

            if(x.Equals(y))
            {
            DataSet ds = new DataSet();
            con.Open();
           String strquery = "update dbo.Users set Password='"+x+"' where UserId='" + a+ "'";
            SqlCommand cmd = new SqlCommand(strquery, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            errorLabel.Visible = true;
            errorLabel.Text = "Congrats! Password Chnaged SuccessFully, you can Login just by clicking X on top right side of this box";
            con.Close();
            Session["sesPassChg"] = null;
            }
            else
            {
                 errorLabel.Visible = true;
                 errorLabel.Text = "Oops!! Both values must be same";
            }

        }
        catch (Exception ex)
        {
            errorLabel.Text = "<center><h2> Error occurred while Updating. Please try again</h2>";
        }
    }
}