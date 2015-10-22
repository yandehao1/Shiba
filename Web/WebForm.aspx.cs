using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreezerProPlugin
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("");
        }

        public void fp_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            bool loginResult = login.checkToken(Context);
            if (loginResult)//登陆成功
            {
                //打开扩展系统
                Response.Write("<script>window.open('FpExtendPage.aspx','_blank')</script>");
            }
            else
            {
                //打开登陆窗
                Response.Write("<script>window.open('Login.aspx','_blank')</script>");
            }

        }
    }
}