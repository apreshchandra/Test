using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using Google.GData.Client;
using Google.GData.YouTube;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class CanvasAreaYoutubeVideoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUploadYTVideo_Click(object sender, EventArgs e)
        {
            YouTubeRequestSettings ytsettings = new YouTubeRequestSettings("SonetReach", "AI39si4bVFP9AaDQuM12V5xTGF-pj87bxWApjm3KReLJFl67kkFfq3Jn32DikSJzRrqGo8mYY7Ww7XXD9JZDCezjMd9jUMtFCA", "sonetreach123@gmail.com", "sonetreach123");
            ytsettings.Timeout = -1;
            YouTubeRequest ytReq = new YouTubeRequest(ytsettings);
            ((GDataRequestFactory)ytReq.Service.RequestFactory).Timeout = 60 * 60 * 1000;
            Video video = new Video();
            video.Title = "the best paint in the world";
            video.Description = "sonet reach";
            video.Tags.Add(new MediaCategory("Sports", YouTubeNameTable.CategorySchema));
            video.YouTubeEntry.Private = false;
            video.YouTubeEntry.MediaSource = new MediaFileSource("D:\\Test_Vid.mp4", "video/mp4");
            Video createdVideo = ytReq.Upload(video);
            string videoID = createdVideo.VideoId;
            string youtubelink = "http://www.youtube.com/watch?v=" + videoID;
            lblVidURL.Style.Add("color", "Voilet");
            lblVidURL.Style.Add("font-family", "Segoe UI Light,Segoe UI,Tahoma,Arial,Verdana,sans-serif");
            lblVidURL.Text = "Your video has been uploaded to : " + youtubelink;
        }

        private void Analytics()
        {

        }
    }
}