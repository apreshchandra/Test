using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class TwitterData
    {
        private string AccessToken;

        public string AccessToken1
        {
            get { return AccessToken; }
            set { AccessToken = value; }
        }
        private string CachedUserId;

        public string CachedUserId1
        {
            get { return CachedUserId; }
            set { CachedUserId = value; }
        }

        private string _sToken;

        public string TokenKey
        {
            get { return _sToken; }
            set { _sToken = value; }
        }

        private string _sTokenSecret;

        public string TokenSecretKey
        {
            get { return _sTokenSecret; }
            set { _sTokenSecret = value; }
        }
    }
}
