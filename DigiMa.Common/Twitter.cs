using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using Twitterizer;
using DigiMa.Data;
using System.Text;
using System.IO;
using System.Net;
using System.Web;

namespace DigiMa.Common
{
    public class Twitter
    {
        string retok = string.Empty;
        AppUser oDCAppUser = new AppUser();

        public bool AuthTweeterUser()
        {

            //TwitterAccount.VerifyCredentials();
            return true;
        }

        public string GetTwitterAuthURL(string ADID, string app_id, string PDID)
        {
            //string callbackurl = "http://127.0.0.1/Digima/SMTweet.aspx?ADID=" + (HttpUtility.UrlEncode(ADID)) + "&app_id=" + (HttpUtility.UrlEncode(app_id) + "&PDID=" + (HttpUtility.UrlEncode(PDID)));
           string callbackurl = "https://www.sonetreach.com/SMTweet.aspx?ADID=" + (HttpUtility.UrlEncode(ADID)) + "&app_id=" + (HttpUtility.UrlEncode(app_id) + "&PDID=" + (HttpUtility.UrlEncode(PDID)));
            string ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];
            OAuthTokenResponse oAuthTokResponse = OAuthUtility.GetRequestToken(ConsumerKey, ConsumerSecret, callbackurl);
            retok = oAuthTokResponse.Token;

            return "https://twitter.com/oauth/authorize?oauth_token=" + oAuthTokResponse.Token;
           

        }

        public bool CheckAppAuthorized(string token, string tokensecret)
        {
            var consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];



            OAuthTokens accessToken = new OAuthTokens();
            accessToken.AccessToken = token;//Session["AccessToken"].ToString(); //Session["Accesstoken"].ToString(); //"216580220-wUGWLtr4g2Rb2LknLXob9r7KbLlnE1dF0dshptDi";
            accessToken.AccessTokenSecret = tokensecret;//Session["TokenSecret"].ToString(); //Session["TokenSecret"].ToString();//"yo8Yh3h4DjVjzwiQn65XE7dKEPPT9ONmT75cVESh4";
            accessToken.ConsumerKey = consumerKey;
            accessToken.ConsumerSecret = consumerSecret;


            TwitterResponse<TwitterUser> tweetResp = TwitterAccount.VerifyCredentials(accessToken);
            if (tweetResp.Result == RequestResult.Success)
            {
                // User is authenticated
                return true;
            }
            else
            {
                // GetTwitterAuthURL(ADID, app_id);  // USer Has not authorized the app
                return false;
            }

        }

        public string CreateCachedAccessToken(string OauthToken, string Oauthverifier)
        {
            string ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];

            OAuthTokenResponse responseToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, OauthToken, Oauthverifier);

            SessionData.TwitterData = new TwitterData();

            //Cache the UserId
            //SessionData.TwitterData.CachedUserId1 = responseToken.UserId.ToString();

            OAuthTokens accessToken = new OAuthTokens();
            accessToken.AccessToken = responseToken.Token;
            accessToken.AccessTokenSecret = responseToken.TokenSecret;
            accessToken.ConsumerKey = ConsumerKey;
            accessToken.ConsumerSecret = ConsumerSecret;


            SessionData.TwitterData.TokenKey = responseToken.Token;
            SessionData.TwitterData.TokenSecretKey = responseToken.TokenSecret;
            SessionData.TwitterData.CachedUserId1 = Convert.ToString(responseToken.UserId);
            //SessionData.TwitterData.AccessToken1 = accessToken.ToString();
            //string authtok = accessToken.ToString();

            //TwitterStatus.Update(accessToken, "tttt");
            return responseToken.UserId.ToString();

        }

        public OAuthTokens GetTokens(string OauthToken, string Oauthverifier)
        {
            string ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
            string ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];

            OAuthTokenResponse responseToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, OauthToken, Oauthverifier);

            SessionData.TwitterData = new TwitterData();

            //Cache the UserId
            //SessionData.TwitterData.CachedUserId1 = responseToken.UserId.ToString();

            OAuthTokens accessToken = new OAuthTokens();
            accessToken.AccessToken = responseToken.Token;
            accessToken.AccessTokenSecret = responseToken.TokenSecret;
            accessToken.ConsumerKey = ConsumerKey;
            accessToken.ConsumerSecret = ConsumerSecret;


            SessionData.TwitterData.TokenKey = responseToken.Token;
            SessionData.TwitterData.TokenSecretKey = responseToken.TokenSecret;
            SessionData.TwitterData.CachedUserId1 = Convert.ToString(responseToken.UserId);
            //SessionData.TwitterData.AccessToken1 = accessToken.ToString();
            //string authtok = accessToken.ToString();

            //TwitterStatus.Update(accessToken, "tttt");
            return accessToken;
        }

        public AppUser GetUserDetail(string userid, AppUser oDCAppUser)
        {

            StringBuilder _sbUserInfoURL = new StringBuilder();
            _sbUserInfoURL.Append("https://api.twitter.com/1/users/lookup.json?user_id=" + userid);


            //Parse json to get MXDBAppUser
            string _sUserInfoJson = CallWebRequest("GET", _sbUserInfoURL.ToString(), string.Empty);
            object[] oUserLocationDataRow = new object[7];
            //Convert Json to JsonDictionary <of String, object>
            System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            object _oJSONObject = _oJavaScriptSerializer.DeserializeObject(_sUserInfoJson);
            int i = 0;
            for (i = 0; i <= ((object[])_oJSONObject).Length - 1; i++)
            {
                Dictionary<string, object> _ojsonUserDetails = (Dictionary<string, object>)((object[])_oJSONObject)[i];
                foreach (KeyValuePair<string, object> _oKeyjsonUserDetailsItem in _ojsonUserDetails)
                {
                    switch (_oKeyjsonUserDetailsItem.Key)
                    {
                        case "name": //set Name
                            oDCAppUser.UserName = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "profile_image_url": //set image
                            oDCAppUser.ImageURL = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "followers_count": //set followers count
                            oDCAppUser.SFriend_count = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "location": //set City
                            oDCAppUser.City = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;



                        //case "current_location": // set current location
                        //    if (_oKeyjsonUserDetailsItem.Value != null && Convert.ToString(_oKeyjsonUserDetailsItem.Value).Length > 0)
                        //    {
                        //        //set location fields
                        //        Dictionary<string, object> jsonlocationDict = (Dictionary<string, object>)_oKeyjsonUserDetailsItem.Value;
                        //        foreach (KeyValuePair<string, object> _olocationItem in jsonlocationDict)
                        //        {
                        //            switch (_olocationItem.Key.ToLower())
                        //            {
                        //                case "city":
                        //                    if (Convert.ToString(_olocationItem.Value).Length > 0)
                        //                    {
                        //                        string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                        //                        if (_olocationvalue.Length >= 1) oDCAppUser.City = _olocationvalue[0];
                        //                    }
                        //                    break;

                        //                case "state":
                        //                    if (Convert.ToString(_olocationItem.Value).Length > 0)
                        //                    {
                        //                        string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                        //                        if (_olocationvalue.Length >= 1) oDCAppUser.State = _olocationvalue[0];
                        //                    }
                        //                    break;

                        //                case "country":
                        //                    if (Convert.ToString(_olocationItem.Value).Length > 0)
                        //                    {
                        //                        string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                        //                        if (_olocationvalue.Length >= 1) oDCAppUser.Country = _olocationvalue[0];
                        //                    }
                        //                    break;

                        //                default:
                        //                    break; //Could not parse location json element
                        //            }
                        //        }
                        //    }
                        //    break;
                        //case "sex": oDCAppUser.Gender = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                        //    break;
                        //case "birthday_date": oDCAppUser.SBirthdate = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                        //    break;
                        //case "friend_count": oDCAppUser.SFriend_count = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                        //    break;
                    }
                }
            }

            return oDCAppUser;
        }


        public string CallWebRequest(string Method, string Url, string PostData)
        {
            try
            {
                string ResponseString = "";

                // setup request object
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
                Request.Method = Method;
                Request.ServicePoint.Expect100Continue = false;
                Request.UserAgent = "soNET";
                Request.Timeout = 20000;

                // add post data
                if (Method == "POST")
                {
                    Request.ContentType = "application/x-www-form-urlencoded";
                    Stream RequestStream = Request.GetRequestStream();
                    if (RequestStream != null)
                    {
                        StreamWriter RequestWriter = new StreamWriter(RequestStream);
                        RequestWriter.Write(PostData);
                        RequestWriter.Close();
                    }
                }

                WebResponse Response = Request.GetResponse();
                if (Response != null)
                {
                    System.IO.Stream Stream = Response.GetResponseStream();
                    if (Stream != null)
                    {
                        StreamReader Reader = new StreamReader(Stream);
                        ResponseString = Reader.ReadToEnd();
                        Reader.Close();
                        Stream.Close();
                    }
                }

                return ResponseString;
            }
            catch (Exception ex)
            {
                //commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), Url);
            }
            return string.Empty;
        }

        //public bool UpdateStatus()
        //{

        //    try
        //    {
        //        string text = "ABCD";
        //        // add these to web.config or your preferred location             

        //        string ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
        //        string ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];

        //        //OAuthTokenResponse responseToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, access_token);




        //        OAuthTokens accessTokenpost = new OAuthTokens();
        //        accessTokenpost.AccessToken = "770916956-RfWmuH5a0e37RrEp1ers2daHIh5c46TsvwRID3aO";
        //        accessTokenpost.AccessTokenSecret = "777gLKVs4gCNh3WSva6eEuCq1d9zl294wE1Odl9TlY";
        //        accessTokenpost.ConsumerKey = ConsumerKey;
        //        accessTokenpost.ConsumerSecret = ConsumerSecret;

        //        TwitterStatus.Update(accessTokenpost,text);

        //        TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(accessTokenpost, "Hello, #Twitterizer");
        //        if (tweetResponse.Result == RequestResult.Success)
        //        {
        //            // Tweet posted successfully!
        //        }
        //        else
        //        {
        //            // Something bad happened
        //        }

        //        //TwitterStatus TweetStatus = new TwitterStatus(accessTokenpost);
        //        //TweetStatus.Update(text + " - http://www.sonetreach.com");                   

        //        //string ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
        //        //string ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];

        //        ////OAuthTokenResponse responseToken = OAuthUtility.GetAccessToken(ConsumerKey, ConsumerSecret, requestToken);
        //        ////TwitterData otwitterData = new TwitterData();
        //        //////Cache the UserId
        //        ////SessionData.TwitterData.CachedUserId1 = responseToken.UserId.ToString();

        //        ////OAuthTokens accessToken = new OAuthTokens();
        //        ////accessToken.AccessToken = responseToken.Token;
        //        ////accessToken.AccessTokenSecret = responseToken.TokenSecret;
        //        ////accessToken.ConsumerKey = ConsumerKey;
        //        ////accessToken.ConsumerSecret = ConsumerSecret;


        //        ////SessionData.TwitterData.AccessToken1 = accessToken.ToString();

        //        //string text = string.Empty;


        //        ////TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(accessToken, text);
        //        //TwitterStatus.Update(requestToken, "tttt");


        //        //twitterService.SendTweet(tweetMessage); 
        //        return true;
        //    }
        //    catch (Exception ex)
        //    { 

        //    }


        //    return false;
        //}


        public bool UpdateStatus(string token, string SecretKey)
        {
            try
            {
                var consumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"];
                var consumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"];

                OAuthTokens accessToken = new OAuthTokens();
                accessToken.AccessToken = token;
                accessToken.AccessTokenSecret = SecretKey;
                accessToken.ConsumerKey = consumerKey;
                accessToken.ConsumerSecret = consumerSecret;

                string postcontent = "Testrun via Promotions";

                TwitterResponse<TwitterStatus> tweetResponse = TwitterStatus.Update(accessToken, postcontent);
                if (tweetResponse.Result == RequestResult.Success)
                {
                    //Tweeted Successfully
                }
                else
                {
                    // Something bad happened
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;

        }

    }
}
