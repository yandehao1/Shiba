using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RuRo.Web.Test
{
    enum stateTest { ok,err}
    public partial class TestEnum : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void test1_Click(object sender, EventArgs e)
        {
            ResLab.Text = Newtonsoft.Json.JsonConvert.SerializeObject(stateTest.err);
        }
    }
}