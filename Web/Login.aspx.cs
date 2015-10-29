using System;
using System.Web;

namespace RuRo.Web
{
    /// <summary>
    /// Login 的摘要说明。
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    SetDepartment();
            //}
            if (!IsPostBack)
            {
                if (CheckLoginByCookie())
                {
                    //Response.Redirect("ExtendPage.aspx");
                    Response.Redirect("index.aspx");
                }
            }
            //登陆
            //验证登陆
            //跳转扩展页面
        }

        #region Web 窗体设计器生成的代码

        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            //base.OnInit(e);
        }

        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.btnLogin_Click);
        }

        #endregion Web 窗体设计器生成的代码

        private void SetDepartment()
        {
            //department.Width = 136;

            //ArrayList arrValue = new ArrayList();
            //arrValue.Add("--请选择--");
            //arrValue.Add("心研所");
            //arrValue.Add("肺癌所");
            ////将数组绑定到DropDownList控件的DataSource属性
            //department.DataSource = arrValue;

            //department.DataBind();
        }

        private void btnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            #region 检查登陆

            string userName = txtUsername.Text.ToString().Trim();
            string passWord = RuRo.Common.PageValidate.InputText(txtPass.Value.Trim(), 30);
            //获取当前科室存入cookie
            //string depar = department.SelectedValue;
            //DateTime datetime = DateTime.Now.AddDays(7.0);
            //Common.CookieHelper.SetCookie(userName+"department", Common.DEncrypt.DESEncrypt.Encrypt(depar), datetime);
            if (checkToken(userName, passWord))
            {
                //清除cookie
                LoginOut();
                //重写cookie
                WriteCookie(userName, passWord);
                // Response.Redirect("ExtendPage.aspx");
                Response.Redirect("index.aspx");
            }
            else
            {
                lblMsg.Text = "请检查账号密码";
                // Response.Redirect("Login.aspx");
            }

            #endregion 检查登陆
        }

        public bool CheckLoginByCookie()
        {
            string userName = Common.CookieHelper.GetCookieValue("username");
            string temPass = Common.CookieHelper.GetCookieValue("password");
            if (!string.IsNullOrEmpty(userName) && userName != "null" && !string.IsNullOrEmpty(temPass) && temPass != "null")
            {
                string passWord = string.Empty;
                try
                {
                    passWord = Common.DEncrypt.DESEncrypt.Decrypt(temPass);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                }
                return checkToken(userName, passWord);
            }
            else
            {
                return false;
            }
        }

        private void LoginOut()
        {
            Common.CookieHelper.ClearCookie("username");
            Common.CookieHelper.ClearCookie("password");
        }

        private bool checkToken(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                FreezerProUtility.Fp_Common.UnameAndPwd up = new FreezerProUtility.Fp_Common.UnameAndPwd(username, password);
                FreezerProUtility.Fp_BLL.Token token = new FreezerProUtility.Fp_BLL.Token(up);
                bool b = token.checkAuth_Token();
                return b;
            }
        }

        //写入cookie
        private void WriteCookie(string username, string password)
        {
            string DEnPassword = Common.DEncrypt.DESEncrypt.Encrypt(password);
            HttpCookie passwordcookie = new HttpCookie("password");
            passwordcookie.Value = DEnPassword;
            Response.Cookies.Add(passwordcookie);
            Common.CookieHelper.SetCookie("username", username);
            Common.CookieHelper.SetCookie("password", DEnPassword);
        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}