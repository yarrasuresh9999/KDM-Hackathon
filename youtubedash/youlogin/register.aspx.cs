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

public partial class youlogin_register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        try
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Register_User", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtUsername.Value;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = txtPassword.Value;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Value;
                    cmd.Parameters.Add("@CreatedDate", SqlDbType.VarChar, 50).Value = DateTime.Now.ToString();
                    cmd.Parameters.Add("@LastLoginDate", SqlDbType.VarChar, 50).Value = DBNull.Value;
                    cmd.Parameters.Add("@failId", SqlDbType.Int).Value = result;
                    cmd.Parameters.Add("@login_attempts", SqlDbType.Int).Value = result;
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    //com.ExecuteNonQuery();
                    con.Close();
                    errorLabel.Visible = true;
                    if(result > 0)
                    {
                        errorLabel.Text = "Registered Successfully";
                    }
                    else
                    {
                        errorLabel.Text = "Unable to register try again";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errorLabel.Text = "<center><h2> Error occurred while Updating. Please try again</h2>";
        }
    }
}