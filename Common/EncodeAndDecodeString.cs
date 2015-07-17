using System;
using System.IO;
using System.Security.Cryptography;
namespace Common
{
    public static class EncodeAndDecodeString
    {
        const string KEY_64 = "ZssyFree";//注意了，是8个字符，64位（中山三院+freezerpro）

        const string IV_64 = "ZssyFree";
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>

        public static string Decode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(byEnc);
                CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cst);
                return sr.ReadToEnd();
            }
            catch
            {
                return "";
            }
            
        }


        #region 方式2
        ////默认密钥向量
        //private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        ///**//**//**//// <summary>
        ///// DES加密字符串
        ///// </summary>
        ///// <param name="encryptString">待加密的字符串</param>
        ///// <param name="encryptKey">加密密钥,要求为8位</param>
        ///// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        //public static string EncryptDES(string encryptString, string encryptKey)
        // {
        //    try
        //     {
        //        byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
        //        byte[] rgbIV = Keys;
        //        byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
        //        DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        //        cStream.Write(inputByteArray, 0, inputByteArray.Length);
        //        cStream.FlushFinalBlock();
        //        return Convert.ToBase64String(mStream.ToArray());
        //    }
        //    catch
        //     {
        //        return encryptString;
        //    }
        //}

        ///**//**//**//// <summary>
        ///// DES解密字符串
        ///// </summary>
        ///// <param name="decryptString">待解密的字符串</param>
        ///// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        ///// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        //public static string DecryptDES(string decryptString, string decryptKey)
        // {
        //    try
        //     {
        //        byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
        //        byte[] rgbIV = Keys;
        //        byte[] inputByteArray = Convert.FromBase64String(decryptString);
        //        DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
        //        MemoryStream mStream = new MemoryStream();
        //        CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
        //        cStream.Write(inputByteArray, 0, inputByteArray.Length);
        //        cStream.FlushFinalBlock();
        //        return Encoding.UTF8.GetString(mStream.ToArray());
        //    }
        //    catch
        //     {
        //        return decryptString;
        //    }
        //} 
        #endregion
    }
}
