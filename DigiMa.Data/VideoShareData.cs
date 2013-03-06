using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
   public class VideoShareData : AppBase
    {
        private string _sVideoShareConfigDID;

        public string SVideoShareConfigDID
        {
            get { return _sVideoShareConfigDID; }
            set { _sVideoShareConfigDID = value; }
        }
        private string _sVideoShareURL;

        public string SVideoShareURL
        {
            get { return _sVideoShareURL; }
            set { _sVideoShareURL = value; }
        }
        private string _sVideoShareURLConverted;

        public string SVideoShareURLConverted
        {
            get { return _sVideoShareURLConverted; }
            set { _sVideoShareURLConverted = value; }
        }
        private string _sVideoShareDesc;

        public string SVideoShareDesc
        {
            get { return _sVideoShareDesc; }
            set { _sVideoShareDesc = value; }
        }

    }
}
