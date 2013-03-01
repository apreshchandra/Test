using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DigiMa.Common;
using System.Web.UI.WebControls;

namespace DigiMa
{
    public partial class PreviewLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string imagetoLoad = string.Empty;
                if (!string.IsNullOrEmpty(Request["IDID"].ToString()))
                {
                    imagetoLoad = Request["IDID"].ToString();
                }

                if (!(imagetoLoad.Equals(string.Empty)))
                {
                    prevImage.Src = imagetoLoad;
                }
            }
            catch (Exception ex)
            {
                CommonUtility objCommon = new CommonUtility();
                objCommon.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(),"");
            }
        }
    }
}