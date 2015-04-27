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

public partial class youlogin_forgot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        try
        {
            String x = txtUsername.Value;
            String y = txtEmail.Value;
            DataSet ds = new DataSet();
            con.Open();
            string strquery = "select * from dbo.Users where Username='" + x + "' and Email='"+y+"'";
            SqlCommand cmd = new SqlCommand(strquery, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            errorLabel.Visible = true;
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["SesPassChg"] = ds.Tables[0].Rows[0]["UserID"];
                Response.Redirect("forgotnewpass.aspx");
            }
            else
                errorLabel.Text = "Unable to Identify you, please try again";
            con.Close();      
        }
        catch (Exception ex)
        {
            errorLabel.Text = "<center><h2> Error occurred while Updating. Please try again</h2>";
        }
    }
}