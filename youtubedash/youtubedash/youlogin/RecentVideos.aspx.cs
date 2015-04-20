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

public partial class youlogin_RecentVideos : System.Web.UI.Page
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
                       "<div><table id='myTable' class='table' width='100%'> <thead><tr role='row'> <th >Thumbnail</th> <th>Description</th> <th>Viewed On</th></tr> </thead><tbody> ";
            
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
                string strquery = "select v.Thumbnail,v.VideoID,v.Description,v.ViewedTime from dbo.Users as u inner join Videos as v on u.UserId=v.UserId where v.UserId='" + a + "' order by v.ViewedTime";
                SqlCommand cmd = new SqlCommand(strquery, con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    group = group + "<tr role='row'>";
                    group = group + "<td><a data-fancybox-type='iframe' href='https://www.youtube.com/watch?v=" + rdr["VideoID"].ToString() + "' class='more'><img style = 'width: 80px; height:50px;' src = " + rdr["Thumbnail"].ToString() + " /></a></td>";

                    group = group + "<td>" + rdr["Description"].ToString() + "</td>";

                    group = group + "<td>" + rdr["ViewedTime"].ToString() + "</td>";

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