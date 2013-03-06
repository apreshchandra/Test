using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DigiMa.Data;
using System.Data;
using System.Net;
using System.Runtime;
using System.Configuration;
using Newtonsoft;
using System.IO;

namespace DigiMa.Common
{
    public class FaceBook
    {
        #region Variables
        private string _sFaceBookAppID = "124512147619758";
        private string _sFaceBookAppKey = "2bc92dc6d0ada2e53c652714d8709a67";
        private string _sFaceBookAppSecretKey = "0420bf8dc81c95e9528bc6261277c397";
        private string _sFaceBookAppRelativePath = "https://www.testsonetreach.com/soNet/brandbuilder/";
        private string _sFaceBookAppCanvasPath = "http://apps.facebook.com/sonet-titantrack/";
        CommonUtility commUtil = new CommonUtility();
        string ActiveURL;
        string NotifyURL;
        #endregion

        public FaceBook()
        {
            ActiveURL = ConfigurationManager.AppSettings["ActiveURL"];
            NotifyURL = ConfigurationManager.AppSettings["NotifyURL"];
        }

        public void Authorize(System.Web.UI.Page oSoNetPage, string sExtendedPermissions, AppConfiguration oAppConfiguration)
        {
            try
            {
                StringBuilder _sbAuthorizeURL = new StringBuilder();
                _sbAuthorizeURL.Append("https://graph.facebook.com/oauth/authorize?");
                _sbAuthorizeURL.Append("client_id=" + oAppConfiguration.AppID);
                //default permissions: user_location,user_work_history,friends_location,friends_work_history,publish_stream,offline_access
                _sbAuthorizeURL.Append("&scope=" + sExtendedPermissions);
                _sbAuthorizeURL.Append("&redirect_uri=" + HttpUtility.HtmlEncode(oAppConfiguration.AppPath));

                StringBuilder _sbAuthorizeResponse = new StringBuilder();
                _sbAuthorizeResponse.Append("<script> ");
                _sbAuthorizeResponse.Append("if (parent != self) ");
                _sbAuthorizeResponse.Append("top.location.href = \"" + _sbAuthorizeURL.ToString() + "&v=1.0\"; ");
                _sbAuthorizeResponse.Append("else self.location.href = \"" + _sbAuthorizeURL.ToString() + "&v=1.0\"; ");
                _sbAuthorizeResponse.Append("</script>");

                HttpContext.Current.Response.Write(_sbAuthorizeResponse.ToString());
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }

        public void AuthorizeMob(System.Web.UI.Page oSoNetPage, string sExtendedPermissions, AppConfiguration oAppConfiguration)
        {
            try
            {
                StringBuilder _sbAuthorizeURL = new StringBuilder();
                _sbAuthorizeURL.Append("http://m.facebook.com/dialog/oauth/?");
                //'+ window.location + '&response_type=token
                _sbAuthorizeURL.Append("client_id=" + oAppConfiguration.AppID);
                //default permissions: user_location,user_work_history,friends_location,friends_work_history,publish_stream,offline_access
                _sbAuthorizeURL.Append("&scope=" + sExtendedPermissions);
                _sbAuthorizeURL.Append("&redirect_uri=" + NotifyURL + "MobileRedirect.aspx?app_id=" + oAppConfiguration.AppID);
                _sbAuthorizeURL.Append("&display=touch");

                StringBuilder _sbAuthorizeResponse = new StringBuilder();
                _sbAuthorizeResponse.Append("<script> ");
                _sbAuthorizeResponse.Append("if (parent != self) ");
                _sbAuthorizeResponse.Append("top.location.href = \"" + _sbAuthorizeURL.ToString() + "&v=1.0\"; ");
                _sbAuthorizeResponse.Append("else self.location.href = \"" + _sbAuthorizeURL.ToString() + "&v=1.0\"; ");
                _sbAuthorizeResponse.Append("</script>");

                HttpContext.Current.Response.Write(_sbAuthorizeResponse.ToString());
                HttpContext.Current.Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
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
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), Url);
            }
            return string.Empty;
        }

        public bool CallPostToWall(string sAccessToken, AppWallPost oDCAppWallPost)
        {
            StringBuilder _sbPostToWallURL = new StringBuilder();
            StringBuilder _sbPostToWallPostData = new StringBuilder();
            try
            {
                _sbPostToWallURL.Append("https://graph.facebook.com/");
                _sbPostToWallURL.Append(oDCAppWallPost.ToUserID);
                _sbPostToWallURL.Append("/feed?");
                _sbPostToWallURL.Append("access_token=" + sAccessToken);


                _sbPostToWallPostData.Append("message=" + oDCAppWallPost.Message);
                _sbPostToWallPostData.Append("&picture=" + oDCAppWallPost.Picture);
                _sbPostToWallPostData.Append("&link=" + oDCAppWallPost.Link);
                _sbPostToWallPostData.Append("&name=" + oDCAppWallPost.Name);
                _sbPostToWallPostData.Append("&caption=" + oDCAppWallPost.Caption);
                _sbPostToWallPostData.Append("&description=" + oDCAppWallPost.Description);
                _sbPostToWallPostData.Append("&scope=publish_stream");

                CallWebRequest("POST", _sbPostToWallURL.ToString(), _sbPostToWallPostData.ToString());// replaced POST with GET for 400-BAD REQUEST ERROR
                return true;
            }
            catch (Exception ex)
            {
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), _sbPostToWallURL.ToString() + " DATA--> " + _sbPostToWallPostData.ToString());
            }
            return false;
        }

        public string CallPostToWallAppRequests(AppWallPost oDCAppWallPost, string appID)
        {
            StringBuilder _sbPostToWallURL = new StringBuilder();
            StringBuilder _sbPostToWallPostData = new StringBuilder();
            try
            {
                _sbPostToWallURL.Append("https://www.facebook.com/dialog/apprequests?");
                _sbPostToWallURL.Append("app_id=" + appID);
                _sbPostToWallURL.Append("&message=" + oDCAppWallPost.Message);
                _sbPostToWallURL.Append("&to=" + oDCAppWallPost.ToUserID);
                _sbPostToWallURL.Append("redirect_uri=https://www.testsonetreach.com/CreateApp.aspx?app_id=" + appID);

                string returend = CallWebRequest("POST", _sbPostToWallURL.ToString(), _sbPostToWallPostData.ToString());// replaced POST with GET for 400-BAD REQUEST ERROR
                return returend;
            }
            catch (Exception ex)
            {
                commUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), _sbPostToWallURL.ToString() + " DATA--> " + _sbPostToWallPostData.ToString());
            }
            return "";
        }

        public bool CallPages(string pageID, string acctok, string tabID, string custname, string customAppLogo)
        {
            try
            {
                StringBuilder _sbPostToWallURL = new StringBuilder();
                _sbPostToWallURL.Append("https://graph.facebook.com/");
                _sbPostToWallURL.Append(pageID);
                _sbPostToWallURL.Append("/tabs/" + tabID);
                _sbPostToWallURL.Append("&access_token=" + acctok);
                _sbPostToWallURL.Append("&custom_name=" + custname);


                StringBuilder _sbPostToWallPostData = new StringBuilder();
                //_sbPostToWallPostData.Append("custom_name=" + custname);
                _sbPostToWallPostData.Append("");


                CallWebRequest("POST", _sbPostToWallURL.ToString(), _sbPostToWallPostData.ToString());


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetPageAccessToken(string orig_Access_token)
        {
            StringBuilder _sbPostToWallURL = new StringBuilder();
            _sbPostToWallURL.Append("https://graph.facebook.com/me/accounts?access_token=");
            _sbPostToWallURL.Append(orig_Access_token);
            string resposnestring; string page_access_tok;


            resposnestring = CallWebRequest("GET", _sbPostToWallURL.ToString(), "");// replaced POST with GET for 400-BAD REQUEST ERROR


            return resposnestring;
        }

        public bool IsPageLiked(string pageID, string acc_tok)
        {
            StringBuilder sbPageLiked = new StringBuilder();
            sbPageLiked.Append("https://graph.facebook.com/me/likes/" + pageID + "&access_token=" + acc_tok);


            string myLikes = CallWebRequest("GET", sbPageLiked.ToString(), "");

            if (myLikes.Contains(pageID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public DataTable GetFriendsDetail(string sUserID, string soauth_token)
        {
            if (string.IsNullOrEmpty(soauth_token)) throw new Exception("Specify valid access token.");
            if (string.IsNullOrEmpty(sUserID)) throw new Exception("Specify valid userid.");

            StringBuilder _sbFriendInfoURL = new StringBuilder();
            _sbFriendInfoURL.Append("https://api.facebook.com/method/fql.query?query=");
            _sbFriendInfoURL.Append("SELECT uid,name,pic,sex,current_location,birthday_date FROM user WHERE uid in (select uid2 from friend where uid1=");
            _sbFriendInfoURL.Append(sUserID + ")");
            _sbFriendInfoURL.Append("&access_token=" + soauth_token);
            _sbFriendInfoURL.Append("&format=JSON");

            //Parse json to get MXDBAppUser
            string _sFriendsInfoJson = CallWebRequest("GET", _sbFriendInfoURL.ToString(), string.Empty);

            //Create DataTable
            DataTable oFriendsTable = new DataTable("FriendsTable");
            DataColumn osoNETID = new DataColumn("soNETID");
            oFriendsTable.Columns.Add(osoNETID);
            DataColumn oImage = new DataColumn("Image");
            oFriendsTable.Columns.Add(oImage);
            DataColumn oName = new DataColumn("Name");
            oFriendsTable.Columns.Add(oName);
            DataColumn oLocation = new DataColumn("Location");
            oFriendsTable.Columns.Add(oLocation);
            DataColumn oGender = new DataColumn("Gender");
            oFriendsTable.Columns.Add(oGender);
            DataColumn oBithdate = new DataColumn("Birthdate");
            oFriendsTable.Columns.Add(oBithdate);


            //Convert Json to JsonDictionary <of String, object>
            System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            object _oJSONObject = _oJavaScriptSerializer.DeserializeObject(_sFriendsInfoJson);
            int i = 0;
            for (i = 0; i <= ((object[])_oJSONObject).Length - 1; i++)
            {
                Dictionary<string, object> _ojsonFriendDetails = (Dictionary<string, object>)((object[])_oJSONObject)[i];

                //'Parse & Save individual friends details
                object[] oFriendDataRow = new object[6];

                foreach (KeyValuePair<string, object> _oKeyjsonFriendDetailsItem in _ojsonFriendDetails)
                {
                    switch (_oKeyjsonFriendDetailsItem.Key)
                    {
                        case "uid": //set friendID
                            oFriendDataRow[0] = Convert.ToString(_oKeyjsonFriendDetailsItem.Value);
                            break;

                        case "name": //set User name
                            oFriendDataRow[2] = Convert.ToString(_oKeyjsonFriendDetailsItem.Value);
                            break;

                        case "pic": //set User picture
                            oFriendDataRow[1] = Convert.ToString(_oKeyjsonFriendDetailsItem.Value);
                            break;

                        case "sex": //set User picture
                            oFriendDataRow[4] = Convert.ToString(_oKeyjsonFriendDetailsItem.Value);
                            break;
                        case "current_location":
                            try
                            {
                                if (_oKeyjsonFriendDetailsItem.Value != null && Convert.ToString(_oKeyjsonFriendDetailsItem.Value).Length > 0)
                                {
                                    //set location fields
                                    Dictionary<string, object> jsonlocationDict = (Dictionary<string, object>)_oKeyjsonFriendDetailsItem.Value;
                                    foreach (KeyValuePair<string, object> _olocationItem in jsonlocationDict)
                                    {
                                        switch (_olocationItem.Key.ToLower())
                                        {
                                            case "city":
                                                if (Convert.ToString(_olocationItem.Value).Length > 0)
                                                {
                                                    string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                    if (_olocationvalue.Length >= 1) oFriendDataRow[3] += _olocationvalue[0] + ",";
                                                }
                                                break;
                                            case "state":
                                                if (Convert.ToString(_olocationItem.Value).Length > 0)
                                                {
                                                    string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                    if (_olocationvalue.Length >= 1) oFriendDataRow[3] += _olocationvalue[0] + ",";
                                                }
                                                break;
                                            case "country":
                                                if (Convert.ToString(_olocationItem.Value).Length > 0)
                                                {
                                                    string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                    if (_olocationvalue.Length >= 1) oFriendDataRow[3] += _olocationvalue[0];
                                                }
                                                break;
                                            default:
                                                break; //Could not parse location json element
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                //Something went wrong while parsing friend current_location   
                                throw ex;
                            }
                            break;
                        case "birthday_date":
                            try
                            {
                                if (_oKeyjsonFriendDetailsItem.Value != null && Convert.ToString(_oKeyjsonFriendDetailsItem.Value).Length > 0)
                                {
                                    oFriendDataRow[5] = System.DBNull.Value;
                                }
                                else
                                {
                                    oFriendDataRow[5] = Convert.ToString(_oKeyjsonFriendDetailsItem.Value);
                                }
                            }
                            catch (Exception ex)
                            {
                                //Something went wrong while parsing friend birthdate   
                                throw ex;
                            }
                            break;
                    }
                }

                //Save Parsed Object into Friend details table
                oFriendsTable.Rows.Add(oFriendDataRow);
            }

            return oFriendsTable;
        }

        public AppUser GetUserDetail(string sUserID, string soauth_token, AppUser oDCAppUser)
        {
            if (string.IsNullOrEmpty(soauth_token)) throw new Exception("Specify valid access token.");
            if (string.IsNullOrEmpty(sUserID)) throw new Exception("Specify valid userid.");

            StringBuilder _sbUserInfoURL = new StringBuilder();
            _sbUserInfoURL.Append("https://api.facebook.com/method/fql.query?query=");
            _sbUserInfoURL.Append("SELECT name,pic,current_location,email,sex,birthday_date,friend_count FROM user WHERE uid =");
            _sbUserInfoURL.Append("'" + sUserID + "'");
            _sbUserInfoURL.Append("&access_token=" + soauth_token);
            _sbUserInfoURL.Append("&format=JSON");

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
                        case "name": //set Email
                            oDCAppUser.UserName = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "pic": //set User name
                            oDCAppUser.ImageURL = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "email": //set contact email
                            oDCAppUser.EmailID = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;

                        case "current_location": // set current location
                            if (_oKeyjsonUserDetailsItem.Value != null && Convert.ToString(_oKeyjsonUserDetailsItem.Value).Length > 0)
                            {
                                //set location fields
                                Dictionary<string, object> jsonlocationDict = (Dictionary<string, object>)_oKeyjsonUserDetailsItem.Value;
                                foreach (KeyValuePair<string, object> _olocationItem in jsonlocationDict)
                                {
                                    switch (_olocationItem.Key.ToLower())
                                    {
                                        case "city":
                                            if (Convert.ToString(_olocationItem.Value).Length > 0)
                                            {
                                                string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                if (_olocationvalue.Length >= 1) oDCAppUser.City = _olocationvalue[0];
                                            }
                                            break;

                                        case "state":
                                            if (Convert.ToString(_olocationItem.Value).Length > 0)
                                            {
                                                string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                if (_olocationvalue.Length >= 1) oDCAppUser.State = _olocationvalue[0];
                                            }
                                            break;

                                        case "country":
                                            if (Convert.ToString(_olocationItem.Value).Length > 0)
                                            {
                                                string[] _olocationvalue = Convert.ToString(_olocationItem.Value).Split(new string[] { "," }, StringSplitOptions.None);
                                                if (_olocationvalue.Length >= 1) oDCAppUser.Country = _olocationvalue[0];
                                            }
                                            break;

                                        default:
                                            break; //Could not parse location json element
                                    }
                                }
                            }
                            break;
                        case "sex": oDCAppUser.Gender = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;
                        case "birthday_date": oDCAppUser.SBirthdate = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;
                        case "friend_count": oDCAppUser.SFriend_count = Convert.ToString(_oKeyjsonUserDetailsItem.Value);
                            break;
                    }
                }
            }

            return oDCAppUser;
        }



        public string GetEmbedURL(string url, AppUser oDCAppUser)
        {
            try
            {
                string RetHTML = "";
                StringBuilder _sbFriendInfoURL = new StringBuilder();
                _sbFriendInfoURL.Append("http://api.embed.ly/1/oembed?url=");
                _sbFriendInfoURL.Append(HttpUtility.UrlEncode(url));
                _sbFriendInfoURL.Append("&maxwidth=450");
                _sbFriendInfoURL.Append("&format=JSON");

                //Parse json to get MXDBAppUser
                string _sFriendsInfoJson = CallWebRequest("GET", _sbFriendInfoURL.ToString(), string.Empty);

                //Create DataTable
                DataTable oFriendsTable = new DataTable("FriendsTable");
                DataColumn osoNETID = new DataColumn("HTML");
                oFriendsTable.Columns.Add(osoNETID);
                //DataColumn oImage = new DataColumn("Image");
                //oFriendsTable.Columns.Add(oImage);
                //DataColumn oName = new DataColumn("Name");
                //oFriendsTable.Columns.Add(oName);
                //DataColumn oLocation = new DataColumn("Location");
                //oFriendsTable.Columns.Add(oLocation);
                //DataColumn oGender = new DataColumn("Gender");
                //oFriendsTable.Columns.Add(oGender);


                //Convert Json to JsonDictionary <of String, object>
                System.Web.Script.Serialization.JavaScriptSerializer _oJavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                Dictionary<string, object> values = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(_sFriendsInfoJson);
                if (values.Keys.Count > 0)
                {
                    if (values.Keys.Contains("html"))
                    {
                        RetHTML = values["html"].ToString();
                    }
                    else
                    {
                        RetHTML = string.Empty;
                    }
                }
                return RetHTML;
            }
            catch (Exception ex)
            {
                //Something went wrong while parsing friend current_location   
                throw ex;
            }


        }
        #region "Signed_Request"
        public void ParseSignedRequest(ref Hashtable QSVars)
        {
            //Check signed request qsvar
            if (QSVars.Contains("signed_request"))
            {
                //Seperate Signature & Payload
                string _rawSignedRequest = string.Empty;
                _rawSignedRequest = Convert.ToString(QSVars["signed_request"]);

                string[] _signedRequest = _rawSignedRequest.Split(new string[] { "." }, StringSplitOptions.None);
                string _expectedSignature = Base64UrlDecode(_signedRequest[0]);
                string _payload = _signedRequest[1];

                //Validate SingedRequest                
                System.Security.Cryptography.HMACSHA256 oHMACSHA256 = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(_sFaceBookAppSecretKey));
                string hash = Convert.ToBase64String(oHMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(_payload)));
                string hashDecoded = Base64UrlDecode(hash);

                if (hashDecoded == _expectedSignature)
                {
                    //Return decoded payload params
                    Dictionary<string, string> _oSignedRequestParams = DecodePayloadToParams(QSVars, _payload);

                    //Set Auto Persist QSvars of facebook
                    foreach (KeyValuePair<string, string> _oKeyValueItem in _oSignedRequestParams)
                    {
                        if (!QSVars.Contains(_oKeyValueItem.Key))
                        {
                            QSVars.Add(_oKeyValueItem.Key, _oKeyValueItem.Value);
                        }
                        else
                        {
                            QSVars[_oKeyValueItem.Key] = _oKeyValueItem.Value;
                        }
                    }
                }
                else
                {
                    //Return empty signed request params, Singnature is different
                    //return new Dictionary<string, string>();
                }
            }
            else
            {
                //Return empty signed request params no signed_request qsvar found
                //return new Dictionary<string, string>();
            }
        }

        public void ParseSignedRequest(ref Hashtable QSVars, ref Hashtable FormVars, AppConfiguration oAppConfiguration)
        {
            //Check signed request qsvar
            if (FormVars.Contains("signed_request") || QSVars.Contains("signed_request"))
            {
                //Seperate Signature & Payload
                string _rawSignedRequest = string.Empty;
                _rawSignedRequest = Convert.ToString(FormVars["signed_request"]);

                string[] _signedRequest = _rawSignedRequest.Split(new string[] { "." }, StringSplitOptions.None);
                string _expectedSignature = Base64UrlDecode(_signedRequest[0]);
                string _payload = _signedRequest[1];

                //Validate SingedRequest                
                System.Security.Cryptography.HMACSHA256 oHMACSHA256 = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(oAppConfiguration.AppKey));
                string hash = Convert.ToBase64String(oHMACSHA256.ComputeHash(Encoding.UTF8.GetBytes(_payload)));
                string hashDecoded = Base64UrlDecode(hash);

                if (true) //hashDecoded == _expectedSignature
                {
                    //Return decoded payload params
                    Dictionary<string, string> _oSignedRequestParams = DecodePayloadToParams(QSVars, _payload);

                    //Set Auto Persist QSvars of facebook
                    foreach (KeyValuePair<string, string> _oKeyValueItem in _oSignedRequestParams)
                    {
                        if (!QSVars.Contains(_oKeyValueItem.Key))
                        {
                            QSVars.Add(_oKeyValueItem.Key, _oKeyValueItem.Value);
                        }
                        else
                        {
                            QSVars[_oKeyValueItem.Key] = _oKeyValueItem.Value;
                        }
                    }
                }
                else
                {
                    //Return empty signed request params, Singnature is different
                    //return new Dictionary<string, string>();
                }
            }
            else
            {
                //Return empty signed request params no signed_request qsvar found
                //return new Dictionary<string, string>();
            }
        }

        private string Base64UrlDecode(string encodedValue)
        {
            encodedValue = encodedValue.Replace("+", "-").Replace("/", "_").Trim();
            int pad = encodedValue.Length % 4;
            if (pad > 0)
            {
                pad = 4 - pad;
            }
            encodedValue = encodedValue.PadRight(encodedValue.Length + pad, Convert.ToChar("="));
            return encodedValue;
        }

        private Dictionary<string, string> DecodePayloadToParams(Hashtable QSVars, string payload)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string decodedJson = payload.Replace("=", string.Empty).Replace("-", "+").Replace("_", "/");
            byte[] base64JsonArray = Convert.FromBase64String(decodedJson.PadRight(decodedJson.Length + (4 - decodedJson.Length % 4) % 4, Convert.ToChar("=")));
            string json = encoding.GetString(base64JsonArray);

            //Get json list of params
            json = json.Replace("{", "").Replace("}", "").Replace("\"", "");
            List<string> sjObjectList = new List<string>(json.Split(new char[] { Convert.ToChar(",") }));

            //Seperate into Dictionary List
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            foreach (string sObjectItem in sjObjectList)
            {
                string[] _sObjectDetails = sObjectItem.Split(new string[] { ":" }, StringSplitOptions.None);
                parameters.Add(_sObjectDetails[0], _sObjectDetails[1]);
            }
            return parameters;
        }
        #endregion
    }
}//end of namespace

