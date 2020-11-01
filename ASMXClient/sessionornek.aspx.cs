using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASMXClient
{
    public partial class sessionornek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        ServiceReference1.GeriSayimServiceSoapClient client = new ServiceReference1.GeriSayimServiceSoapClient();
        string SessionID = "";
        protected void btngetir_Click(object sender, EventArgs e)
        {
            SessionID= client.LoginForSession("berk", "123");
            var json = client.GetGeriSayimlarJSONSession(SessionID);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiData>(json);
            gvliste.DataSource = data;
            gvliste.DataBind();

        }
    }
}