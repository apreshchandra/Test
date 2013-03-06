using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;

namespace DigiMa
{
    public partial class Captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["captcha"] != null)
                {
                    this.Session["CaptchaImageText"] = GenerateRandomCode(6);
                }
                // Create a CAPTCHA image using the text stored in the Session object.
                CaptchaImage ci = new CaptchaImage(this.Session["CaptchaImageText"].ToString(), 200, 50, "Century Schoolbook");

                // Change the response headers to output a JPEG image.
                this.Response.Clear();
                this.Response.ContentType = "image/jpeg";

                // Write the image to the response stream in JPEG format.
                ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);

                // Dispose of the CAPTCHA image object.
                ci.Dispose();
            }
            catch
            {
                throw;
            }
        }

        private string GenerateRandomCode(int size)
        {
            try
            {
                char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
                string result = string.Empty;
                Random r = new Random();
                for (int i = 0; i < size; i++)
                {
                    result += cr[r.Next(0, cr.Length - 1)].ToString();
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}