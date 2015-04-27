using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Model;

public partial class youlogin_PlayVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string id  = Request.QueryString["id"];
        User user = (User)Session["User"];

        RootObject Data = (RootObject)Session["Data"];
        Item item = Data.items.FirstOrDefault(x => x.id.videoId == id);
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        try
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertVideos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.UserID;
                    cmd.Parameters.Add("@Video_ID", SqlDbType.VarChar, 50).Value = item.id.videoId;
                    cmd.Parameters.Add("@Thumbnail", SqlDbType.VarChar, 100).Value = item.snippet.thumbnails.@default.url;
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 500).Value = item.snippet.title;
                    cmd.Parameters.Add("@Description", SqlDbType.VarChar, 500).Value =item.snippet.description;
                    cmd.Parameters.Add("@PublishedAt", SqlDbType.DateTime).Value = DateTime.Parse(item.snippet.publishedAt);
                    cmd.Parameters.Add("@ChannelTitle", SqlDbType.VarChar).Value = item.snippet.channelTitle;
                    cmd.Parameters.Add("@Type", SqlDbType.VarChar, 10).Value = "video";
                    cmd.Parameters.Add("@ViewedTime", SqlDbType.DateTime).Value = DateTime.Now;
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    //com.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        {
            //errorLabel.Text = "<center><h2> Error occurred while Updating. Please try again</h2>";
        }

        Response.Redirect("https://www.youtube.com/watch?v=" + id);
    }
}