using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreezerProPlugin
{
    public partial class BaseFp : System.Web.UI.MasterPage
    {
        public string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                url = Common.XmlHelper.Read("configXML\\UriConfigXml.xml", "Uri");
                FreezerPro.Attributes.Add("src", url);
            }

        }
    }
}