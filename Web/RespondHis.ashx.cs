using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreezerProPlugin
{
    /// <summary>
    /// RespondHis 的摘要说明
    /// </summary>
    public class RespondHis : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //页面关闭时调用方法回发数据
            //获取用户输入的账号密码验证数据是否正确
            //string username = "";
            //string password = "";
            //try
            //{
            //    if (context.Session["Username"] != null)
            //    {
            //        username = context.Session["Username"].ToString();
            //        password = context.Session["Password"].ToString();
            //    }
            //    else
            //    {
            //        username = context.Request.Cookies["loginCookie"].Values["Username"].ToString();
            //        password = context.Request.Cookies["loginCookie"].Values["Password"].ToString();
            //    }
            //    if (!string.IsNullOrEmpty(username)&&!string.IsNullOrEmpty(password))
            //    {
            //        BLL.Token token = new BLL.Token(username, password);
            //        if (token.checkAuth_Token())
            //        {
            //            StarRespond();
            //        }
            //    }
            //}
            //catch (Exception e)
            //{

            //}
            if (context.Request.Params["action"] == "respondhis")
            {
                StarRespond();
            }
        }

        public void StarRespond()
        {
            BLL.Respond respond = new BLL.Respond();
            respond.RespondHis();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}