using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigiMa.Data
{
    public class AppWallPost
    {
        //Default Constructor
		public AppWallPost() : base()
		{
		}

	#region "Variables"
        private string _sMessage; //The message
        private string _sPicture; //If available, a link to the picture included with this post
        private string _sLink; //The link attached to this post
        private string _sName; //The name of the link
        private string _sCaption; //The caption of the link (appears beneath the link name)
        private string _sDescription; //A description of the link (appears beneath the link caption)
        private string _sSource; //If available, the source link attached to this post (for example, a flash or video file)
        private string _sFrom; //An object containing the ID and name of the user who posted the message
        private string _sTo; //A list of the profiles mentioned or targeted in this post
    #endregion

	#region "Properties"

		public string Message {
			get { return _sMessage; }
			set { _sMessage = value; }
		}

		public string Picture {
			get { return _sPicture; }
			set { _sPicture = value; }
		}

		public string Link {
			get { return _sLink; }
			set { _sLink = value; }
		}

		public string Name {
			get { return _sName; }
			set { _sName = value; }
		}

		public string Caption {
			get { return _sCaption; }
			set { _sCaption = value; }
		}

		public string Description {
			get { return _sDescription; }
			set { _sDescription = value; }
		}

		public string Source {
			get { return _sSource; }
			set { _sSource = value; }
		}

		public string ToUserID {
			get { return _sTo; }
			set { _sTo = value; }
		}

        public string FromUserID
        {
            get { return _sFrom; }
            set { _sFrom = value; }
        }
    #endregion
    }
}
