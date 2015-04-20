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

public partial class youlogin_RecentSearches : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String xx = Session["loginUnameSes"].ToString();
        if (xx == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            
            string group =
                        "<div><table id='myTable' class='table' width='100%'> <thead><tr role='row'> <th >Search Query</th> <th>Searched on</th></tr> </thead><tbody> ";
            DataSet ds1 = new DataSet();
            con.Open();
            string strquery1 = "select UserId from dbo.Users where Username='" + xx + "'";
            SqlCommand cmd1 = new SqlCommand(strquery1, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);

            int a = Convert.ToInt32(ds1.Tables[0].Rows[0]["UserId"]);
            con.Close();
            try
            {
                DataSet ds = new DataSet();
                con.Open();
                string strquery = "select s.SearchString,s.SearchTime from dbo.Users as u inner join Searches as s on u.UserId=s.UserId where s.UserId='" + a + "' order by s.SearchTime";
                SqlCommand cmd = new SqlCommand(strquery, con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    group = group + "<tr role='row'>";

                    group = group + "<td>" + rdr["SearchString"].ToString() + "</td>";

                    group = group + "<td>" + rdr["SearchTime"].ToString() + "</td>";

                    group = group + "</tr>";
                }
                group = group + "</tbody></table></div>";
                list1.InnerHtml = group;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}