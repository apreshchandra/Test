using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DigiMa.DataAccess;
using DigiMa.Common;
using DigiMa.Data;
using System.Text;

namespace DigiMa.BizProcess
{
    public class BizBase
    {
        private SonetPie _osonetpie;
        public SonetPie GetSonetPie
        {
            get { return _osonetpie; }
        }

        public BizBase() { }
        public BizBase(SonetPie osonetpie)
        {
            try
            {
                if (osonetpie.QSvarsString != null)
                {
                    //Retain back qsvrs from collection
                    osonetpie.QSvars = new Hashtable();
                    string[] _sItems = osonetpie.QSvarsString.Split(new string[] { "$;$" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int iItemCounter = 0; iItemCounter < _sItems.Length; iItemCounter++)
                    {
                        string[] _sSubItems = _sItems[iItemCounter].Split(new string[] { "$:$" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int iItemSubCounter = 0; iItemSubCounter < _sSubItems.Length; iItemSubCounter++)
                        {
                            if (_sSubItems.Length == 2)
                            {
                                if (osonetpie.QSvars.ContainsKey(_sSubItems[0]))
                                    osonetpie.QSvars[_sSubItems[0]] = _sSubItems[1];
                                else
                                    osonetpie.QSvars.Add(_sSubItems[0], _sSubItems[1]);
                            }
                        }
                    }
                }

                if (osonetpie.Formvars != null)
                {
                    //Retain back formvrs from collection
                    osonetpie.Formvars = new Hashtable();
                    string[] _sItems = osonetpie.FormvarsString.Split(new string[] { "$;$" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int iItemCounter = 0; iItemCounter < _sItems.Length; iItemCounter++)
                    {
                        string[] _sSubItems = _sItems[iItemCounter].Split(new string[] { "$:$" }, StringSplitOptions.RemoveEmptyEntries);
                        for (int iItemSubCounter = 0; iItemSubCounter < _sSubItems.Length; iItemSubCounter++)
                        {
                            if (_sSubItems.Length == 2)
                            {
                                if (osonetpie.Formvars.ContainsKey(_sSubItems[0]))
                                    osonetpie.Formvars[_sSubItems[0]] = _sSubItems[1];
                                else
                                    osonetpie.Formvars.Add(_sSubItems[0], _sSubItems[1]);
                            }
                        }
                    }
                }
                _osonetpie = osonetpie;
            }
            catch (Exception ex)
            {
                //Log4NetUtility.ErrorDebug(this.GetType().FullName, "Error in BizAppConfiguration(soNetKoKo osoNetKoKo)", ex);
                throw ex;
            }
        }
    }
}
