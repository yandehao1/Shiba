using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Web;
using System.Web.UI.HtmlControls;


namespace Common
{
   public  class CssHelper
    {

        /// <summary>
        /// 添加JS脚本链接
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="url">路径</param>
        public void AddJS(System.Web.UI.Page page, string url)
        {
            HtmlGenericControl jsControl = new HtmlGenericControl("script");
            jsControl.Attributes.Add("type", "text/javascript");
            jsControl.Attributes.Add("src", url);
            page.Header.Controls.Add(jsControl);
        }

        /// <summary>
        /// 添加JS脚本内容
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="content">脚本内容</param>
        public void AddScript(System.Web.UI.Page page, string content)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.InnerHtml = content;
            page.Header.Controls.Add(scriptControl);
        }

        /// <summary>
        /// 添加CSS样式链接
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="url">路径</param>
        public void AddCss(System.Web.UI.Page page, string url)
        {
            HtmlLink link = new HtmlLink();
            link.Href = url;
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            page.Header.Controls.Add(link);
        }

        /// <summary>
        /// 添加CSS样式内容
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="content">样式内容</param>
        public void AddStyle(System.Web.UI.Page page, string content)
        {
            HtmlGenericControl styleControl = new HtmlGenericControl("style");
            styleControl.Attributes.Add("type", "text/css");
            styleControl.InnerHtml = content;
            page.Header.Controls.Add(styleControl);
        }

        /// <summary>
        /// 添加Meta标签
        /// </summary>
        /// <param name="page">页面</param>
        /// <param name="name">Meta名字</param>
        /// <param name="content">Meta内容</param>
        public void AddMeta(System.Web.UI.Page page, string name, string content)
        {
            HtmlMeta meta = new HtmlMeta();
            meta.Name = name;
            meta.Content = content;
            page.Header.Controls.Add(meta);
        } 
    }
}
