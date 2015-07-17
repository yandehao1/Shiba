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
            if (context.Request.Params["action"] == "respondhis")
            {
                StarRespond();
                context.Response.Write("回发结束");
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