using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreezerProPlugin
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void Login()
        {
            Login l = new Login();
            bool ckeckresult = l.checkToken(Context);
            //成功
            if (ckeckresult)
            {
                Response.Redirect("FpExtendPage.aspx");
            }
            else
            {
               // loginhiddendate.Attributes.Remove("hidden");
             //   loginhiddendate.InnerText = "登陆失败，请检查账号密码";
              //  password.Value = "";
            }
        }
    }
}