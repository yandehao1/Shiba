using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class TestData
    {
        /// <summary>
        /// 导入临床数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="test_data_type"></param>
        /// <param name="dataDic">需指定Sample Source</param>
        /// <returns></returns>
        public static string ImportTestData(Fp_Common.UnameAndPwd up, string test_data_type, Dictionary<string, string> dataDic)
        {
            string result = string.Empty;
            string jsonDic = Fp_Common.FpJsonHelper.DictionaryToJsonString(dataDic); ;
            if (!string.IsNullOrEmpty(jsonDic))
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("test_data_type", test_data_type);
                dic.Add("json", jsonDic);
                result = ImportTestDataToFp(up, dic);
            }
            return result;
        }
        /// <summary>
        /// 导入多条临床数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="test_data_type"></param>
        /// <param name="dataDicList">需指定Sample Source</param>
        /// <returns></returns>
        public static string ImportTestData(Fp_Common.UnameAndPwd up, string test_data_type, List<Dictionary<string, string>> dataDicList)
        {
            string result = string.Empty;
            string jsonDicList = Fp_Common.FpJsonHelper.DictionaryListToJsonString(dataDicList);
            if (!string.IsNullOrEmpty(jsonDicList))
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("test_data_type", test_data_type);
                dic.Add("json", jsonDicList);
                result = ImportTestDataToFp(up, dic);
            }
            return result;
        }
        private static string ImportTestDataToFp(Fp_Common.UnameAndPwd up, Dictionary<string, string> jsonDic)
        {
            string result = string.Empty;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.import_tests.ToString());
            if (jsonDic != null && jsonDic.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in jsonDic)
                {
                    dic.Add(item.Key, item.Value);
                }
            }
            FreezerProUtility.Fp_DAL.CallApi call = new FreezerProUtility.Fp_DAL.CallApi(dic);
            result = call.PostData();
            return result;
        }

        public static List<Fp_Model.Subdivision> GetAll(Fp_Common.UnameAndPwd up, string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.subdivisions.ToString());
            dic.Add("id", id);
            FreezerProUtility.Fp_DAL.CallApi call = new FreezerProUtility.Fp_DAL.CallApi(dic);
            List<Fp_Model.Subdivision> List = call.getdata<Fp_Model.Subdivision>("Subdivision");
            return List;
        }
        private static string CheckRes(string jsonResStr)
        {
            return "";
        }
    }
}
