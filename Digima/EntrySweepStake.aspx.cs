using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.UI;
using DigiMa.BizProcess;
using System.Collections;
using System.IO;
using System.Text;
using DigiMa.Common;
using DigiMa.Data;
using System.Web.UI.WebControls;
using System.Net;

namespace DigiMa
{
    public partial class EntrySweepStake : System.Web.UI.Page
    {
        string ADID;
        string sonetID;
        CommonUtility commonUtil = new CommonUtility();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["AppDID"] != null)
            {
                ADID = Request["AppDID"].ToString();
            }
            if (Request["SonetID"] != null)
            {
                sonetID = Request["SonetID"].ToString();
            }

            if (!IsPostBack)
            {
                Getcountrytobind();
            }
        }


        private void Getcountrytobind()
        {
            CanvasBizProcess canvBiz = new CanvasBizProcess();
            DataSet dsCountryList = canvBiz.GetCountryList();
            ddlCountry.DataSource = dsCountryList;
            ddlCountry.DataTextField = "countryname";
            ddlCountry.DataValueField = "countryid";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("Select Country", ""));
            ViewState["countrylist"] = dsCountryList;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //check if user has already entered
                FacebookBizProcess fbBiz = new FacebookBizProcess();
                if (!fbBiz.CheckIfSweepstakeAlreadyEntered(ADID, sonetID))
                {
                    //Save these details to SubmitForm table
                    SweepStakesEntryInfo sweepEntry = new SweepStakesEntryInfo();
                    sweepEntry.AppConfigDID1 = ADID;
                    sweepEntry.SoNetID1 = sonetID;
                    sweepEntry.FirstName1 = txtFirstName.Text.Trim().Replace("'", "''");
                    sweepEntry.LastName1 = txtLastName.Text.Trim().Replace("'", "''");
                    sweepEntry.Address1 = txtAddress.Text.Trim().Replace("'", "''");
                    sweepEntry.Country1 = ddlCountry.SelectedValue;
                    sweepEntry.City1 = txtCity.Text.Trim().Replace("'", "''");
                    sweepEntry.ZipCode1 = txtZip.Text.Trim().Replace("'", "''");
                    sweepEntry.Email1 = txtEmail.Text.Trim().Replace("'", "''");
                    sweepEntry.Gender1 = ddlGender.SelectedValue;
                    if (datepickerEntryForm.Value == "")
                    {
                        sweepEntry.DOB1 = System.DBNull.Value.ToString();
                    }
                    else
                    {
                        sweepEntry.DOB1 = SQLSafeDates(datepickerEntryForm.Value);
                    }
                    sweepEntry.Telephone1 = txtTelePhone.Text.Trim().Replace("'", "''");
                    sweepEntry.Mobile1 = txtMobile.Text.Trim().Replace("'", "''");
                    sweepEntry.UserType = System.DBNull.Value.ToString();
                    sweepEntry.Remarks = txtRemarks.Text.Trim().Replace("'", "''");

                    //CallBiz Method
                    using (CanvasBizProcess canvBiz = new CanvasBizProcess())
                    {
                        spanError.InnerHtml = "";
                        canvBiz.SaveSweepStakesEntryInfo(sweepEntry);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close()", true);
                    }
                }
                else
                {
                    spanError.InnerHtml = "You have already entered this Sweepstakes contest!";
                }
            }
            catch (Exception ex)
            {
                commonUtil.SendErrorMail(ex.Message, ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "");
            }
        }
        private string SQLSafeDates(string inoputDate)
        {

            string[] dates = inoputDate.Split('/');

            string month = dates[1];

            string date = dates[0];
            string year = dates[2].Substring(0, 4);
            string timePart = "00:00:00";


            return year + "-" + month + "-" + date + " " + timePart;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myCloseScript", "window.close();", true);
        }
    }
}