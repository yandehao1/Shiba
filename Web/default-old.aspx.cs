using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Data;
using System.Text;

namespace FreezerProPlugin
{
    public partial class index : System.Web.UI.Page
    {
        public string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //第一次加载时
                //01.添加嵌套页。
                AddUrlToiframe();
                //02.检查登陆
                CheckLogin();
            }
        }

        void resHis_Click(object sender, EventArgs e)
        {
            BLL.Respond respond = new BLL.Respond();
            respond.RespondHis();
        }
        public void HF()
        {
            BLL.Respond respond = new BLL.Respond();
            respond.RespondHis();
        }
        private void AddUrlToiframe()
        {
            url = XmlHelper.Read("configXML\\UriConfigXml.xml", "Uri");
            FreezerPro.Attributes.Add("src", url);
        }
        private void CheckLogin()
        {
            MenuBar.InnerHtml = "";
            Login checkLogin = new Login();
          //  MenuBar.InnerHtml = checkLogin.checklogin(Context);
        }
    }
}