using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;

namespace PungryMeister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://192.168.50.51/PungryServices/PungryService.asmx");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            if (response.StatusDescription.Equals("OK") && content.Length != 0)
            {
                //do nothing
                SendInfoMail("ALL IS WELL");
                Application.Exit();
            }
            else
            {
                //send an error mail
                SendInfoMail("PUNGRY ERROR");
                Application.Exit();
            }
        }

        public void SendInfoMail(string TOGGLE)
        {

            try
            {
                MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add("apresh.chandra@smnetserv.com");
                message.Subject = TOGGLE;
                message.From = new System.Net.Mail.MailAddress("apreshchandra3@gmail.com");
                message.Body = "PUNGRY SERVICE ERROR!";
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("apreshchandra3@gmail.com", "Istanbul33");
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
