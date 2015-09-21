using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace FreezerProPlugin
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {
        string username = "", password = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request.Params["type"] == "checklogin")
            {
                context.Response.Write(checklogin(context));
            }
            if (context.Request.Params["type"] == "logout")
            {
                RuRo.Common.CookieHelper.ClearCookie("loginCookie");
                RuRo.Common.CookieHelper.ClearCookie("username");
                RuRo.Common.CookieHelper.ClearCookie("password");
                context.Response.Write("<button style=\"width:50px;\" onclick=\"dologin()\">登录</button>使用FreezerPro协同助手");
            }
            else if (context.Request.Params["type"] == "login")
            {
                username = context.Request.Params["username"];
                password = context.Request.Params["password"];
                bool checkresult = checkToken(context);
                if (checkresult)
                {
                    HttpCookie loginCookie = new HttpCookie("loginCookie");
                    loginCookie.Values.Add("Username", username);
                    loginCookie.Values.Add("Password", password);
                    loginCookie.Expires = DateTime.Now.AddDays(1);
                    context.Response.Cookies.Add(loginCookie);
                    RuRo.Common.CookieHelper.SetCookie("username", username);
                    RuRo.Common.CookieHelper.SetCookie("password", password);
                    context.Response.Write("恭喜你,登录成功,欢迎使用FreezerPro协同助手！");
                }
                else
                {
                    context.Response.Write("对不起,用户名或密码错误,请重新输入！");
                }
            }
        }
        public string checklogin(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request.Cookies["loginCookie"] == null)
            {
                return ("<button id='dologin' style=\"width:40px;\" onclick=\"dologin()\">登录</button>FreezerPro协同助手");
            }
            else
            {
                return ("<button style=\"width:40px;\" onclick=\"doimport()\">导入</button><button style=\"width:40px;\" onclick=\"logout()\">注销</button>");
            }
        }

        /// <summary>
        /// 根据账号密码检查token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool checkToken(HttpContext context)
        {
            //获取用户输入的账号密码验证数据是否正确
            username = context.Request.Params["username"];
            password = context.Request.Params["password"];
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                BLL.Token token = new BLL.Token(username, password);
                return token.CkeckRes;
            }
            return false;
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