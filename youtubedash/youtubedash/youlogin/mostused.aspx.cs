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

public partial class youlogin_mostused : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string group =
                    "<div><table id='myTable' class='table' width='100%'> <thead><tr role='row'> <th >Username</th> <th>Email</th><th>No. of Logins</th><th>Last Login</th></tr> </thead><tbody> ";
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        try
        {
            DataSet ds = new DataSet();
            con.Open();
            string strquery = "select Username,Email,login_attempts,LastLoginDate from dbo.Users order by login_attempts,Username";
            SqlCommand cmd = new SqlCommand(strquery, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read())
            {
                group = group + "<tr role='row'>";

                group = group + "<td>" + rdr["Username"].ToString() + "</td>";

                group = group + "<td>" + rdr["Email"].ToString() + "</td>";

                group = group + "<td>" + rdr["login_attempts"].ToString() + "</td>";

                group = group + "<td>" + rdr["LastLoginDate"].ToString() + "</td>";

               group = group + "</tr>";
            }
            group = group + "</tbody></table></div>";
            list.InnerHtml = group;
            con.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

}