using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace FreezerProUtility.Fp_Common
{
    public static class FpUnicodeHelper
    {
        #region 01.UnicodeStringToChinese
        /// <summary>
        /// UnicodeStringToChinese
        /// </summary>
        /// <param name="unicodeString">UnicodeString</param>
        /// <returns>Chinese</returns>

       static Regex re = new Regex("\\\\u[0123456789abcdef]{4}", RegexOptions.IgnoreCase);


        public static string ConvertUnicodeStringToChinese(string unicodeString)
        {
            if (string.IsNullOrEmpty(unicodeString))
                return string.Empty;

            string outStr = unicodeString;
            MatchCollection mc = re.Matches(unicodeString);
            foreach (Match ma in mc)
            {
                outStr = outStr.Replace(ma.Value, ConverUnicodeStringToChar(ma.Value).ToString());
            }
            return outStr;
        }

        public static char ConverUnicodeStringToChar(string str)
        {
            char outStr = Char.MinValue;
            outStr = (char)int.Parse(str.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
            return outStr;
        }
        #region ConvertChineseToUnicodeString
        //static Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
        //public static string ConvertChineseToUnicodeString(string chinese)
        //{
        //    MatchCollection mc = re.Matches(chinese);
        //    string unicodeString = "";
        //    foreach (Match ma in mc)
        //    {
        //        char c;
        //        if (Short.TryParse(ma.Remove(0, 1), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
        //        {
        //            unicodeString += ("\\u" + c);
        //        }
        //    }
        //    return unicodeString;
        //}
        
        #endregion

        public static string uncode(string str)
        {
            string outStr = "";
            Regex reg = new Regex(@"(?i)//u([0-9a-f]{4})");
            outStr = reg.Replace(str, delegate(Match m1)
            {
                return ((char)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString();
            });
            return outStr;
        }


        #endregion

    }

}
