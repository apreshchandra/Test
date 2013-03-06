using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SiteDetails
/// </summary>
public class SiteDetails
{
    public int SiteID { get; set; }
    public string SiteName { get; set; }
    public List<string> Pages { get; set; }
    public string DefaultPage { get; set; }
    public string CurrentPage { get; set; }
    public string FolderPath { get; set; }
    public string FolderPathTool { get; set; }
    public string FolderPathFinal { get; set; }

    public string[] PageTags { get; set; } //For saving the HTML, Head,Bady tags before binding the template
    public string CustomerName { get; set; } //One Site is ment for only one customer
    //public string ToolCodePath { get; set; }
    //public string FinalCodePath { get; set; }

    public SiteDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}