using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.BLL
{
    public class UnameAndPwd
    {
        private string UserName { get; set; }
        private string PassWord { get; set; }

        public  FpUtility.Fp_Common.UnameAndPwd GetUp()
        {
            this.UserName = Common.CookieHelper.GetCookieValue("username");
            string pwd = Common.CookieHelper.GetCookieValue("password");
            if (!string.IsNullOrEmpty(pwd))
            {
                try
                {
                   //加密方式 Common.DEncrypt.DESEncrypt.Encrypt(password);
                    this.PassWord = Common.DEncrypt.DESEncrypt.Decrypt(pwd);
                }
                catch (Exception ex)
                {
                    Common.LogHelper.WriteError(ex);
                }
            }
            return new FpUtility.Fp_Common.UnameAndPwd(this.UserName, this.PassWord);
        }
    }
}
