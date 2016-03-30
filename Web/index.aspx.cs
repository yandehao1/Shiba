using System;

namespace RuRo.Web
{ 
    public partial class index : System.Web.UI.Page
    {

        public string hospitalName = System.Configuration.ConfigurationManager.AppSettings["hospitalName"];
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Common.CookieHelper.GetCookieValue("username");
            //string keshi = Common.CookieHelper.GetCookieValue(username + "department");
            //try
            //{
            //    keshi = Common.DEncrypt.DESEncrypt.Decrypt(keshi);
            //}
            //catch (Exception ex)
            //{
            //    Common.LogHelper.WriteError(ex);
            //    keshi = "";
            //}
            //if (keshi == "")
            //{
            laName.Text = username;
            //}
            //else
            //{
            //    laName.Text = keshi + "/" + username;
            //}
        }
    }
}