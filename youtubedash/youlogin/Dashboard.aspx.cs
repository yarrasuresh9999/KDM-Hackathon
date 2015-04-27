using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Model;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class youlogin_Dashboard : System.Web.UI.Page
{
    protected void unhide()
    {
        list.InnerHtml = "";
        list.Visible = true;


        User user = (User)Session["User"];
        string constr = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        try
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("InsertSearch", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = user.UserID;
                    cmd.Parameters.Add("@SearchString", SqlDbType.VarChar, 500).Value = txt_Search.Text;
                    cmd.Parameters.Add("@SearchTime", SqlDbType.DateTime).Value = DateTime.Now;
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
        string searchString = txt_Search.Text;
        string maxCount = ddl_maxcount.SelectedItem.Text;
        string base_URL = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=" + searchString + "&maxResults=" + maxCount + "&key=AIzaSyDbY-NOOS4rZ6aYw3bMQsS78Xr9s2noAhE";

        try
        {
            HttpWebRequest myWebRequest = WebRequest.Create(base_URL) as HttpWebRequest;
            myWebRequest.ContentType = "application/json; charset=utf-8";
            //Console.WriteLine("\nThe Timeout time of the request before setting is : {0} milliseconds", myWebRequest.Timeout);

            // Set the 'Timeout' property in Milliseconds.
            myWebRequest.Timeout = 10000;


            WebResponse myWebResponse = myWebRequest.GetResponse();

            using (myWebResponse)
            {

                using (var reader = new StreamReader(myWebResponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var objText = reader.ReadToEnd();

                    RootObject myojb = (RootObject)js.Deserialize(objText, typeof(RootObject));

                    Session["Data"] = myojb;
                    bindData(myojb);
                }

            }

        }
        catch (Exception ex)
        {


        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            list.Visible = true;
            User xx = (User)Session["User"];
            if (xx == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            unhide();
        }

       
        //else
        //{

        //    list.Visible = false;

        //}
    }

    private void bindData(RootObject Obj)
    {
        string group = "<div><table id='myTable' class='table' width='100%'> <thead><tr role='row'> <th >Image</th> <th>Video Title</th><th>Published At</th><th>Channel Title</th><th>Description</th></tr> </thead><tbody> ";
        foreach (Item val in Obj.items)
        {
            string vid = val.id.videoId;
            if (string.IsNullOrEmpty(vid))
            {
                vid = val.snippet.channelId;
            }
            group = group + "<tr role='row'>";

            group = group + "<td><a data-fancybox-type='iframe' href='PlayVideo.aspx?id=" + vid + "' class='more' target = 'parent_blank'><img style = 'width: 80px; height:50px;' src = " + val.snippet.thumbnails.@default.url + " /></a></td>";

            group = group + "<td>" + val.snippet.title + "</td>";

            group = group + "<td>" + val.snippet.publishedAt + "</td>";

            group = group + "<td>" + val.snippet.channelTitle + "</td>";

            group = group + "<td>" + val.snippet.description + "</td>";

            group = group + "</tr>";
        }
        group = group + "</tbody></table></div>";
        list.InnerHtml = group;
    }
}