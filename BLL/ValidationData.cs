using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// 检查数据类
    /// </summary>
    public static class ValidationData
    {
        #region 检查数据中是否存在Total + public static  bool checkTotal(string Json)

        /// <summary>
        /// 检查数据中是否存在Total
        /// </summary>
        /// <param name="Json">传入FP返回的字符串</param>
        /// <returns>检查结果如果存在就返回true</returns>
        public static  bool checkTotal(string Json)
        {
            bool result = false;
            try
            {
                //包含Total就进行再次判断是否有值
                if (Json.Contains("Total"))
                {
                    string total = Common.FpJsonHelper.GetStrFromJsonStr("Total", Json);
                    if (Convert.ToInt32(total) > 0)
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return result;
        } 
	#endregion

        #region 检查Json字符串中是否包含auth_token + static bool checkAuth_Token(string Json)
        /// <summary>
        /// 检查Json字符串中是否包含auth_token
        /// </summary>
        /// <param name="Json">传入从FP中获取的Json字符串</param>
        /// <returns></returns>
        public static bool checkAuth_Token(string Json)
        {
            return Json.Contains("auth_token");
        } 
        #endregion
    }
}
