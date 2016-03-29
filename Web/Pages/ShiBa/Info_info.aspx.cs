using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace RuRo.Web
{
    public partial class Info_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Common.js.SetNoCache(); 
            if (Page.IsPostBack == false)
            {
                //if (Request["mode"] != null)
                //    mode.Value = Request["mode"];
                //if (Request["pk"] != null)
                //    pk.Value = Request["pk"];
            }
        }
    }
}
