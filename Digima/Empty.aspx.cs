using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Empty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool bTest = asdf(0);
        Response.Write(bTest.ToString());
    }

    private bool asdf(int ij)
    {
        try
        {
            throw new TimeoutException();
           return false;
           
        }
        catch (Exception x)
        {
            int i = 10 / ij;
        }
        finally
        {
            Response.Write("FInaly");
           /// return true;
        }
        return false;
    }
}