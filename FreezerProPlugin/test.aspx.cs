using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreezerProPlugin
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string url = @"http://10.33.4.23/api?username=test&password=123456&method=import_sources";
            string data = "&sample_source_type=感染科&json={\"Name\":\"0000079553\",\"Description\":\"心内科病区\"}";
            BLL.bll_test test = new BLL.bll_test();
            string res1 = test.postdata(url, data);
            Response.Write("<br />");
            string res2 = test.ImportSampleSource(url, data);
            Response.Write(res1);
            Response.Write(res2);
        }
    }
}