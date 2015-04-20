using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class youlogin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        failId.Value = "0";
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Value = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        String x = txtUsername.Value;
        if (chkRememberMe.Checked)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserName"].Value = txtUsername.Value.Trim();
        Response.Cookies["Password"].Value = txtPassword.Value.Trim();
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            try
            {
                int userId = 0; 
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Validate_User",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Username", txtUsername.Value);
                        cmd.Parameters.Add("@Password", txtPassword.Value);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                    errorLabel.Visible = true;
                    switch (userId)
                    {
                        case -1:
                            errorLabel.Text = "Username and/or password is incorrect.";
                            int attempts = Convert.ToInt32(failId.Value);
                            attempts += 1;
                            failId.Value = attempts.ToString();
                            break;
                        case -2:
                            errorLabel.Text = "Account has been deactivated.";
                            break;
                        default:
                            Session["loginUnameSes"] = x;
                            Response.Redirect("Dashboard.aspx"); 
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = "<center><h2> Error occurred while Updating. Please try again</h2>";
            }
    }
}