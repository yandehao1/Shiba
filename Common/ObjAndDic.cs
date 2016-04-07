using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuRo.Common
{
    public class ObjAndDic
    {
        public static Dictionary<string, string> ObjectToDic(object obj)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Type t = obj.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in pi)
            {
                try
                {
                    //添加数据到字典
                    string value=  Common.ReflectHelper.GetValue(obj, p.Name);
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (dic.ContainsKey(p.Name))
                        {
                            if (string.IsNullOrEmpty(dic[p.Name]))
                            {
                                dic[p.Name] = value;
                            }
                        }
                        else
                        {
                            dic.Add(p.Name, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(ex);
                    continue;
                }
            }
            return dic;
        }
        public static object DicToObject(Dictionary<string, string> dic,object model)
        {
            Type t = model.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (KeyValuePair<string,string> item in dic)
            {
                foreach (var p in pi)
                {
                    if (item.Key ==p.Name)
                    {
                        Common.ReflectHelper.SetValue(model, p.Name, item.Value);
                    }
                }
            }
            return model;
        }
    }
}
