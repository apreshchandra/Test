using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web;

/// <summary>
/// Summary description for BaseClass
/// </summary>


namespace DigiMa
{
    public class BaseClass : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            CheckSession();
        }


        private void CheckSession()
        {

        }

        //public Hashtable GetUserData()
        //{
        //    return (Hashtable)Session["UserData"];
        //}

        public BaseClass()
        {
        }
    }
}