using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASMXClient
{
    public partial class connect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected async System.Threading.Tasks.Task btngetir_ClickAsync(object sender, EventArgs e)
        {
            ServiceReference1.GeriSayimServiceSoapClient client = new ServiceReference1.GeriSayimServiceSoapClient();
             gvliste.DataSource = await client.GetGeriSayimlarXMLAsync();
            //gvliste.DataSource= client.GetGeriSayimlar(Auth: new ServiceReference1.Auth { Username = "berk", Password = "123" });
            gvliste.DataBind();
        }
    }
}