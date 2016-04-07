﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class FpJsonHelper
    {

        #region 取API返回的数据中的文本对象,比如Total + public static string stringToobject(string str, string json)
        /// <summary>
        /// 取API返回的数据中的文本对象,比如Total
        /// </summary>
        /// <param name="str">要取的什么对象比如："Total"</param>
        /// <param name="jsonData">传入API返回的JSON格式的字符串</param>
        /// <returns>返回该字符穿的值</returns>
        public static string GetStrFromJsonStr(string str, string jsonData)//获取用户自定义字段返回条数
        {
            string resultStr = "";
            try
            {
                JObject jObject = JObject.Parse(jsonData);
                resultStr = (string)jObject[str];
            }
            catch (Exception)
            {
                resultStr = "";
            }
            return resultStr;
        }
        #endregion
        public static string SerializationStr(string str)
        {
            return JsonConvert.SerializeObject(str);
        }


        #region 将API返回的json格式的字符串中对象转换成list集合 + public static List<T> JObjectToList<T>(string str, string json)
        /// <summary>
        /// 将API返回的json格式的字符串中对象转换成list集合
        /// </summary>
        /// <typeparam name="T">要转换成的对象集合如：UserFields对象</typeparam>
        /// <param name="str">该对象在api字符串中的标识如：UserFields[{"obj_id":86,"id":86,"display_name":"中心编码".....}]</param>
        /// <param name="json">传入api返回的字符串</param>
        /// <returns>转换成的对象的list集合</returns>
        public static List<T> JObjectToList<T>(string str, string json)
        {
            List<T> list = new List<T>();
            try
            {
                JObject jObject = JObject.Parse(json);
                JArray jArray = (JArray)jObject[str];
                for (int i = 0; i < jArray.Count; i++)
                {
                    T t = JsonConvert.DeserializeObject<T>(jArray[i].ToString());
                    list.Add(t);
                }
            }
            catch (Exception)
            {
                list.Clear();
            }

            return list;
        }
        #endregion

        #region 将键值对格式的字符串转换成Dictionary<T,K> + public static Dictionary<T, K> JsonToDictionary<T, K>(string json)
        /// <summary>
        /// 将键值对格式的字符串转换成Dictionary
        /// </summary>
        /// <typeparam name="T">key的类型</typeparam>
        /// <typeparam name="K">value的类型</typeparam>
        /// <param name="json">传入的json格式的字符串</param>
        /// <returns>返回Dictionary</returns>
        public static Dictionary<T, K> JsonStrToDictionary<T, K>(string json)
        {

            Dictionary<T, K> dictionary = new Dictionary<T, K>();
            try
            {
                dictionary = JsonConvert.DeserializeObject<Dictionary<T, K>>(json);
            }
            catch (Exception)
            {
                dictionary.Clear();
            }
            return dictionary;
        }
        #endregion

        #region 将Dictionary转换长JSON格式的字符串,便于将数据post到FP + public static string DictionaryToJsonString<T, K>(Dictionary<T, K> dic)
        /// <summary>
        /// 将Dictionary转换长JSON格式的字符串,便于将数据post到FP
        /// </summary>
        /// <typeparam name="T">Dictionary 键的类型</typeparam>
        /// <typeparam name="K">Dictionary 值的类型</typeparam>
        /// <param name="dic">Dictionary</param>
        /// <returns>JSON格式的字符串</returns>
        public static string DictionaryToJsonString<T, K>(Dictionary<T, K> dic)
        {
            string result = "";
            try
            {
                result = JsonConvert.SerializeObject(dic);
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }
        #endregion

        #region 将Dictionary转换长JSON格式的字符串 + public static string DictionaryToJsonString(Dictionary<string, string> dic)
        /// <summary>
        /// 将Dictionary转换长JSON格式的字符串
        /// </summary>
        /// <param name="dic">字典</param>
        /// <returns>Json字符串</returns>
        public static string DictionaryToJsonString(Dictionary<string, string> dic)
        {
            return JsonConvert.SerializeObject(dic);
        }
        #endregion

        public static string DictionaryListToJsonString(List<Dictionary<string, string>> listDic)
        {
            StringBuilder result = new StringBuilder();
            //if (listDic.Count == 0)
            //{
            //    result.Append("{}");
            //}
            //if (listDic.Count == 1)
            //{
            //    result.Append(DictionaryToJsonString(listDic[0]));
            //}
            //if (listDic.Count > 1)
            //{
            result.Append("[");
            foreach (Dictionary<string, string> item in listDic)
            {
                result.Append(DictionaryToJsonString(item));
                if (!result.ToString().Trim().EndsWith(","))//判断结尾是不是“，”号
                {
                    result.Append(",");
                }
            }
            result.Remove(result.Length - 1, 1).Append("]");

            //}
            return result.ToString();
        }
        /// <summary>
        /// 将返回的JSON格式的字符串对象转换成对象
        /// </summary>
        /// <typeparam name="T">待转换的对象类型</typeparam>
        /// <param name="jsonStr">字符串</param>
        /// <returns>对象</returns>
        public static T JsonStrToObject<T>(string jsonStr) where T:class
        {
         T obj = JsonConvert.DeserializeObject(jsonStr, typeof(T)) as T;
            return obj;
        }
    }
}