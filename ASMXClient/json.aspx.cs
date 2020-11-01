using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASMXClient
{
    public partial class json : System.Web.UI.Page
    {
        ASMXClient.ServiceReference1.GeriSayimServiceSoapClient client = new ServiceReference1.GeriSayimServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var json=client.GetGeriSayimlarJSON();
            var data= Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApiData>>(json);
            gvlist.DataSource = data;
            gvlist.DataBind();

        }
    }
}