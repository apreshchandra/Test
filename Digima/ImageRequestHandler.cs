﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace DigiMa
{
    public class ImageRequestHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();

            if (context.Request.QueryString.Count != 0)
            {
                var storedImage = context.Session[CanvasAreaPromoTwo.STORED_IMAGE] as byte[];
                if (storedImage != null)
                {
                    Image image = GetImage(storedImage);
                    if (image != null)
                    {
                        context.Response.ContentType = "image/jpeg";
                        image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
            }
        }

        private Image GetImage(byte[] storedImage)
        {
            var stream = new MemoryStream(storedImage);
            return Image.FromStream(stream);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}