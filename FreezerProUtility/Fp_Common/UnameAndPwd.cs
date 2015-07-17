using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_Common
{
    public class UnameAndPwd
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public UnameAndPwd(string username,string password)
        {
            this.UserName = username;
            this.PassWord = password;
        }
    }
}
