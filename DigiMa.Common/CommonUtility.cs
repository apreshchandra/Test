using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.DirectoryServices;
using DigiMa.Data;

using System.Security.Cryptography;

namespace DigiMa.Common
{
    public class CommonUtility
    {
        public static string AppSettings(string sKey, string sDefaultValue)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[sKey] != null && !string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.AppSettings[sKey].ToString()))
            {
                sDefaultValue = System.Configuration.ConfigurationManager.AppSettings[sKey].ToString();
            }
            return sDefaultValue;
        }

        public static string Encrypt(string sKey, string sData)
        {
            try
            {
                //sKey = string.IsNullOrEmpty(sKey) ? SessionData.SessionID : sKey;
                if (!string.IsNullOrEmpty(sData))
                {
                    byte[] bData = UTF8Encoding.UTF8.GetBytes(sData);
                    using (MD5CryptoServiceProvider oMD5CSP = new MD5CryptoServiceProvider())
                    {
                        using (TripleDESCryptoServiceProvider oTriCSP = new TripleDESCryptoServiceProvider())
                        {
                            oTriCSP.Key = oMD5CSP.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey));
                            oTriCSP.Mode = CipherMode.ECB;
                            oTriCSP.Padding = PaddingMode.PKCS7;
                            using (ICryptoTransform oCT = oTriCSP.CreateEncryptor())
                            {
                                byte[] resultArray = oCT.TransformFinalBlock(bData, 0, bData.Length);
                                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return sData;
        }

        public static string Decrypt(string sKey, string sData)
        {
            try
            {
                //sKey = string.IsNullOrEmpty(sKey) ? SessionData.SessionID : sKey;
                if (!string.IsNullOrEmpty(sData))
                {
                    byte[] bData = UTF8Encoding.UTF8.GetBytes(sData);
                    using (MD5CryptoServiceProvider oMD5CSP = new MD5CryptoServiceProvider())
                    {
                        using (TripleDESCryptoServiceProvider oTriCSP = new TripleDESCryptoServiceProvider())
                        {
                            oTriCSP.Key = oMD5CSP.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey));
                            oTriCSP.Mode = CipherMode.ECB;
                            oTriCSP.Padding = PaddingMode.PKCS7;
                            using (ICryptoTransform cTransform = oTriCSP.CreateDecryptor())
                            {
                                byte[] resultArray = cTransform.TransformFinalBlock(bData, 0, bData.Length);
                                return UTF8Encoding.UTF8.GetString(resultArray);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return sData;
        }

        public static string Encrypt(string toEncrypt) // added to encript the url
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
                string key = ")(*&";
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data of the Cryptographic service provide. Best Practice
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //Return the encrypted data into unreadable string format
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public static string Decrypt(string toDecript) //Url
        {
            try
            {
                byte[] keyArray;
                //get the byte code of the string
                byte[] toEncryptArray = Convert.FromBase64String(toDecript);
                string key = ")(*&";
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider
                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)

                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                //Release resources held by TripleDes Encryptor
                tdes.Clear();
                //return the Clear decrypted TEXT
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public void SendInfoMail(string infoMessage, string subject, string body, string emailTo)
        {

            try
            {
                MailMessage mail = new MailMessage();
                //string adminid = txtmailid;
                string adminid = "support@sonetreach.com";
                string admpass = "S0netsupp0rt";


                System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);

                mail.From = new MailAddress(adminid); //AppUser email

                mail.To.Add(new MailAddress(emailTo)); //Inquiry Email
                mail.Subject = subject;  // Mail Subject
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Mail Priority

                StringBuilder strBody = new StringBuilder();

                strBody.Append("<div><center><table border=\"2px black\" width=\"800px\" style=\"height:200px;\">");
                strBody.Append("<tr><td style=\"height: 40px; width: 400px;\">");
                strBody.Append("<center><span style=\"color: Black; font-family: Tahoma; font-size: small;\">");
                strBody.Append(infoMessage);
                strBody.Append("</span></center></td></tr><tr><td>");
                strBody.Append("<span style=\"font-family: Verdana;\">");
                strBody.Append("<br>");
                strBody.Append(body);
                strBody.Append("<br>");
                strBody.Append("<br>");
                strBody.Append("Sent By: SonetReach");

                strBody.Append("</span></td></tr></tr></table></center></div>");

                mail.Body = strBody.ToString();
                SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
                mSMTPClient.UseDefaultCredentials = true;
                mSMTPClient.EnableSsl = false;
                mSMTPClient.Credentials = auth;

                mSMTPClient.Send(mail);

            }
            catch (Exception ex)
            {
                SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        public void SendErrorMail(string exMessage, string exStackTrace, string methodName, string className, string userID)
        {
            MailMessage mail = new MailMessage();
            //string adminid = txtmailid;
            string adminid = "support@sonetreach.com";//ConfigurationManager.AppSettings["usermailid"];
            string admpass = "S0netsupp0rt";// ConfigurationManager.AppSettings["userpassword"];
            System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);
            mail.From = new MailAddress(adminid);//TODO: Put actual sender email address
            mail.To.Add(new MailAddress("apresh.chandra@smnetserv.com"));
            mail.Subject = "Exception in SonetReach - " + exMessage;    // Mail Subject
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Mail Priority

            StringBuilder strBody = new StringBuilder();

            strBody.Append("<div><center><table border=\"2px black\" width=\"800px\" style=\"height:200px;\">");
            strBody.Append("<tr><td style=\"background-color: Black; height: 40px; width: 400px;\">");
            strBody.Append("<center><span style=\"color: Red; font-family: Verdana; font-size: large;\">");
            strBody.Append("SONETREACH Exception ");
            strBody.Append("</span></center></td></tr><tr><td>");
            strBody.Append("<span style=\"font-family: Verdana;\">");
            strBody.Append("<br/>");
            strBody.Append("Hello");
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Please have a look at : <br /><br/>");

            strBody.Append("<br><br>");
            strBody.Append("Exception Message :");
            strBody.Append(exMessage);
            strBody.Append("<br><br>");
            strBody.Append("In Class: &nbsp;");
            strBody.Append(className);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("In Method: ");
            strBody.Append(methodName);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Incident Occurred at: ");
            strBody.Append(DateTime.Now.ToString() + " IST  ");
            strBody.Append("<br>");
            strBody.Append("For Customer ID: ");
            strBody.Append(userID);
            strBody.Append("<br>");
            strBody.Append("<br>");
            strBody.Append("Stack Trace Detail:");
            strBody.Append("<br>");
            strBody.Append(exStackTrace);
            strBody.Append("</span></td></tr></tr></table></center></div>");

            mail.Body = strBody.ToString();
            SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
            mSMTPClient.EnableSsl = false;
            mSMTPClient.UseDefaultCredentials = true;
            mSMTPClient.Credentials = auth;
            mSMTPClient.Port = 25; // PORT NUMBER
            mSMTPClient.Host = "smtpauth.net4india.com";
            mSMTPClient.Send(mail);
        }

        public void SendEnquiryMail(string toEmailID, string subject, string body, string tabName, AppProduct oAppProduct, string fromEmailID)
        {
            try
            {
                if (!string.IsNullOrEmpty(fromEmailID))
                {
                    MailMessage mail = new MailMessage();
                    //string adminid = txtmailid;
                    string adminid = "support@sonetreach.com";
                    string admpass = "S0netsupp0rt";


                    System.Net.NetworkCredential auth = new System.Net.NetworkCredential(adminid, admpass);

                    mail.From = new MailAddress(fromEmailID); //AppUser email

                    mail.To.Add(new MailAddress(toEmailID)); //Inquiry Email
                    mail.Subject = subject;  // Mail Subject
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High; //Mail Priority

                    StringBuilder strBody = new StringBuilder();

                    strBody.Append("<div><center><table border=\"2px black\" width=\"800px\" style=\"height:200px;\">");
                    strBody.Append("<tr><td style=\"background-color: Black; height: 40px; width: 400px;\">");
                    strBody.Append("<center><span style=\"color: Red; font-family: Verdana; font-size: large;\">");
                    strBody.Append("Enquiry for " + tabName);
                    strBody.Append("</span></center></td></tr><tr><td>");
                    strBody.Append("<span style=\"font-family: Verdana;\">");
                    strBody.Append("<br/>");
                    strBody.Append("Hello");
                    strBody.Append("<br>");
                    strBody.Append("<br>");
                    strBody.Append(body);
                    strBody.Append("<br>");
                    strBody.Append("<br>");
                    strBody.Append("Sent By: " + toEmailID);

                    strBody.Append("</span></td></tr></tr></table></center></div>");

                    mail.Body = strBody.ToString();
                    SmtpClient mSMTPClient = new SmtpClient("smtpauth.net4india.com", 25);
                    mSMTPClient.UseDefaultCredentials = true;
                    mSMTPClient.EnableSsl = false;
                    mSMTPClient.Credentials = auth;

                    mSMTPClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), SessionData.Customer.CustomerID);
            }
        }

        /// <summary>
        /// Creates the virtual directory.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <param name="appName">Name of the app.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public static bool CreateVirtualDirectory(string metabasePath, string vDirName, string physicalPath)
        {
            try
            {
                //string metabasePath = "";
                //string vDirName = "Apresh";
                //string physicalPath = "D:\\Digima\\Digima\\Digima\\Sites\\Final\\53";
                DirectoryEntry site = new DirectoryEntry(metabasePath);
                string className = site.SchemaClassName.ToString();
                if ((className.EndsWith("Server")) || (className.EndsWith("VirtualDir")))
                {
                    DirectoryEntries vdirs = site.Children;
                    DirectoryEntry newVDir = vdirs.Add("Apresh", (className.Replace("Service", "VirtualDir")));
                    newVDir.Properties["Path"][0] = physicalPath;
                    newVDir.Properties["AccessScript"][0] = true;
                    // These properties are necessary for an application to be created.
                    newVDir.Properties["AppFriendlyName"][0] = "Apresh";
                    newVDir.Properties["AppIsolated"][0] = "1";
                    newVDir.Properties["AppRoot"][0] = "/LM" + metabasePath.Substring(metabasePath.IndexOf("/", ("IIS://".Length)));

                    newVDir.CommitChanges();


                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed in CreateVDir with the following exception: \n{0}", ex.Message);
            }
            return true;
        }
    }
}
