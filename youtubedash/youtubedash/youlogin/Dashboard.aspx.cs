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

public partial class youlogin_Dashboard : System.Web.UI.Page
{
    protected void unhide()
    {
        list.Visible = false;
        Response.Redirect("Dashboard.aspx");
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            list.Visible = true;
            String xx = Session["loginUnameSes"].ToString();
            if (xx == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                YouTubeSearch.YTClass yt = new YouTubeSearch.YTClass();
                List<YouTubeSearch.VideoAttributes> lt = new List<YouTubeSearch.VideoAttributes>();
                //lt = yt.SearchVideos("s/o sathyamurthy", 10);
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "adityamusic", Description = "Listen & Enjoy Stylish Star Allu Arjun's S/O Satyamurthy Movie Full Songs. Hit Like & Comment your favorite song. Click Here to Share on Facebook ...", PublishedAt = DateTime.Parse("3/15/2015 9:26:16 AM"), Thumbnail = "https://i.ytimg.com/vi/I_OedGjNByY/hqdefault.jpg", Title = "S/o Satyamurthy Telugu Movie || Full Songs Jukebox || Allu Arjun,Samantha,Nithya Menon", Type = "video", VideoID = "I_OedGjNByY" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "tv9telugulive", Description = "Samantha, Allu Arjun and Trivikram in Tv9 Studio! ▻ Subscribe to Tv9 Telugu Live: https://youtube.com/tv9telugulive ▻ Circle us on G+: ...", PublishedAt = DateTime.Parse("4/8/2015 6:41:53 PM"), Thumbnail = "https://i.ytimg.com/vi/Lf82e6LIzYw/hqdefault.jpg", Title = "S/o Satyamurthy Team in Tv9 Studio - Samantha, Allu Arjun and Trivikram", Type = "video", VideoID = "Lf82e6LIzYw" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "AdityaMusicNMovies", Description = "Listen to the back to back songs from the movie S/o Satyamurthy. Click Here to Share on Facebook: http://on.fb.me/18FDAMI Click Here to Set your favorite song ...", PublishedAt = DateTime.Parse("3/15/2015 8:30:01 PM"), Thumbnail = "https://i.ytimg.com/vi/vaY1QQPsT2o/hqdefault.jpg", Title = "S/o Satyamurthy Back To Back Songs With Lyrics - Allu Arjun, Samantha, Trivikram, DSP", Type = "video", VideoID = "vaY1QQPsT2o" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "adityamusic", Description = "Listen & Enjoy Stylish Star Allu Arjun's S/O Satyamurthy Movie Full Songs. Hit Like & Comment your favorite song. Click Here to Share on Facebook ...", PublishedAt = DateTime.Parse("3/15/2015 9:26:16 AM"), Thumbnail = "https://i.ytimg.com/vi/I_OedGjNByY/hqdefault.jpg", Title = "S/o Satyamurthy Telugu Movie || Full Songs Jukebox || Allu Arjun,Samantha,Nithya Menon", Type = "video", VideoID = "I_OedGjNByY" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "tv9telugulive", Description = "Samantha, Allu Arjun and Trivikram in Tv9 Studio! ▻ Subscribe to Tv9 Telugu Live: https://youtube.com/tv9telugulive ▻ Circle us on G+: ...", PublishedAt = DateTime.Parse("4/8/2015 6:41:53 PM"), Thumbnail = "https://i.ytimg.com/vi/Lf82e6LIzYw/hqdefault.jpg", Title = "S/o Satyamurthy Team in Tv9 Studio - Samantha, Allu Arjun and Trivikram", Type = "video", VideoID = "Lf82e6LIzYw" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "AdityaMusicNMovies", Description = "Listen to the back to back songs from the movie S/o Satyamurthy. Click Here to Share on Facebook: http://on.fb.me/18FDAMI Click Here to Set your favorite song ...", PublishedAt = DateTime.Parse("3/15/2015 8:30:01 PM"), Thumbnail = "https://i.ytimg.com/vi/vaY1QQPsT2o/hqdefault.jpg", Title = "S/o Satyamurthy Back To Back Songs With Lyrics - Allu Arjun, Samantha, Trivikram, DSP", Type = "video", VideoID = "vaY1QQPsT2o" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "adityamusic", Description = "Listen & Enjoy Stylish Star Allu Arjun's S/O Satyamurthy Movie Full Songs. Hit Like & Comment your favorite song. Click Here to Share on Facebook ...", PublishedAt = DateTime.Parse("3/15/2015 9:26:16 AM"), Thumbnail = "https://i.ytimg.com/vi/I_OedGjNByY/hqdefault.jpg", Title = "S/o Satyamurthy Telugu Movie || Full Songs Jukebox || Allu Arjun,Samantha,Nithya Menon", Type = "video", VideoID = "I_OedGjNByY" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "tv9telugulive", Description = "Samantha, Allu Arjun and Trivikram in Tv9 Studio! ▻ Subscribe to Tv9 Telugu Live: https://youtube.com/tv9telugulive ▻ Circle us on G+: ...", PublishedAt = DateTime.Parse("4/8/2015 6:41:53 PM"), Thumbnail = "https://i.ytimg.com/vi/Lf82e6LIzYw/hqdefault.jpg", Title = "S/o Satyamurthy Team in Tv9 Studio - Samantha, Allu Arjun and Trivikram", Type = "video", VideoID = "Lf82e6LIzYw" });
                lt.Add(new YouTubeSearch.VideoAttributes() { ChannelTitle = "AdityaMusicNMovies", Description = "Listen to the back to back songs from the movie S/o Satyamurthy. Click Here to Share on Facebook: http://on.fb.me/18FDAMI Click Here to Set your favorite song ...", PublishedAt = DateTime.Parse("3/15/2015 8:30:01 PM"), Thumbnail = "https://i.ytimg.com/vi/vaY1QQPsT2o/hqdefault.jpg", Title = "S/o Satyamurthy Back To Back Songs With Lyrics - Allu Arjun, Samantha, Trivikram, DSP", Type = "video", VideoID = "vaY1QQPsT2o" });

                string group =
                            "<div><table id='myTable' class='table' width='100%'> <thead><tr role='row'> <th >Image</th> <th>Video Name</th><th>Description</th><th>Viewers count</th><th>Channel</th></tr> </thead><tbody> ";
                foreach (var val in lt)
                {
                    group = group + "<tr role='row'>";

                    group = group + "<td><a data-fancybox-type='iframe' href='https://www.youtube.com/watch?v=" + val.VideoID + "' class='more' target = 'parent_blank'><img style = 'width: 80px; height:50px;' src = " + val.Thumbnail + " /></a></td>";

                    group = group + "<td>" + val.Description + "</td>";

                    group = group + "<td>" + val.PublishedAt + "</td>";

                    group = group + "<td>" + val.ChannelTitle + "</td>";

                    group = group + "<td>" + val.Title + "</td>";

                    group = group + "</tr>";
                }
                group = group + "</tbody></table></div>";
                list.InnerHtml = group;
            }
        }
        //else
        //{
           
        //    list.Visible = false;
            
        //}
    }
}