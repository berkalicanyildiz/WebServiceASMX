using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using WebServiceASMX.Models;

namespace WebServiceASMX
{
    /// <summary>
    /// Summary description for GeriSayimService
    /// </summary>
    [WebService(Namespace = "https://asmx.berkalicanyildiz.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GeriSayimService : System.Web.Services.WebService
    {
        GeriSayimDbContext db = new GeriSayimDbContext();
        public Auth KimlikDenetimi;


        [WebMethod(Description = "Get Geri Sayimlar JSON With Soap Header Security")]
        [SoapHeader("KimlikDenetimi", Direction = SoapHeaderDirection.In)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetGeriSayimlarJSONSoapHeader()
        {
            if (KimlikDenetimi == null)
            {
                //return json;

                return "Şifre Yok";

            }
            if (KimlikDenetimi.Username == "berk" && KimlikDenetimi.Password == "123")
            {
                var liste = db.Geri_Sayimlar.ToList();
                string json = JsonConvert.SerializeObject(liste);
                return json;

            }
            else
            {
                return "Şifre Hatası";

            }

        }

        [WebMethod(Description = "Get Geri Sayimlar JSON With Parameters Security")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetGeriSayimlarJSONParameters(string username, string password)
        {
            if (username == "berk" && password == "123")
            {
                var liste = db.Geri_Sayimlar.ToList();
                string json = JsonConvert.SerializeObject(liste);
                return json;

            }
            else
            {
                return "Şifre Hatası";

            }
        }


        [WebMethod(Description = "Get Geri Sayimlar JSON With Session Security", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetGeriSayimlarJSONSession(string logininfo)
        {

            if (logininfo == "" && Session["LoginInfo"].ToString() != logininfo)
            {
                return "Session Hatası";
            }
            else
            {
                var liste = db.Geri_Sayimlar.ToList();
                string json = JsonConvert.SerializeObject(liste);
                return json;
            }

        }

        [WebMethod(EnableSession = true, Description = "Session Değeri Alma")]
        public string LoginForSession(string username, string password)
        {
            if (username == "berk" && password == "123")
            {
                string logininfo = Guid.NewGuid().ToString();
                Session["LoginInfo"] = logininfo;
                return logininfo;
            }
            else
            {
                Session["LoginInfo"] = "";
                return "";
            }
        }



        [WebMethod(Description = "Get Geri Sayimlar JSON Public")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetGeriSayimlarJSON()
        {
            var liste = db.Geri_Sayimlar.ToList();
            string json = JsonConvert.SerializeObject(liste);
            return json;
        }

        [WebMethod(Description = "Get Geri Sayimlar XML Public")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public List<GeriSayim> GetGeriSayimlarXML()
        {
            return db.Geri_Sayimlar.ToList();
        }
    }
}
