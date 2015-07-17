using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuRo.Common
{
    public class ReflectHelper
    {
        /// <summary>
        /// 设置相应属性的值
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="fieldName">属性名</param>
        /// <param name="fieldValue">属性值</param>
        public static void SetValue(object entity, string fieldName, string fieldValue)
        {
            Type entityType = entity.GetType();

            PropertyInfo propertyInfo = entityType.GetProperty(fieldName);

            if (IsType(propertyInfo.PropertyType, "System.String"))
            {
                propertyInfo.SetValue(entity, fieldValue.Trim(), null);

            }

            if (IsType(propertyInfo.PropertyType, "System.Boolean"))
            {
                propertyInfo.SetValue(entity, Boolean.Parse(fieldValue), null);

            }

            if (IsType(propertyInfo.PropertyType, "System.Int32"))
            {
                if (fieldValue != "")
                    propertyInfo.SetValue(entity,Convert.ToInt32(fieldValue), null);
                else
                    propertyInfo.SetValue(entity, 0, null);

            }

            if (IsType(propertyInfo.PropertyType, "System.Decimal"))
            {
                if (fieldValue != "")
                    propertyInfo.SetValue(entity, Decimal.Parse(fieldValue), null);
                else
                    propertyInfo.SetValue(entity, new Decimal(0), null);

            }

            if (IsType(propertyInfo.PropertyType, "System.Nullable`1[System.DateTime]"))
            {
                if (fieldValue != "")
                {
                    try
                    {
                        propertyInfo.SetValue(
                            entity,
                            (DateTime?)DateTime.ParseExact(fieldValue, "yyyy-MM-dd", null), null);
                    }
                    catch
                    {
                        propertyInfo.SetValue(entity, (DateTime?)DateTime.ParseExact(fieldValue, "yyyy-MM-dd", null), null);
                    }
                }
                else
                    propertyInfo.SetValue(entity, null, null);

            }

        }


        /// <summary>
        /// 类型匹配
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static bool IsType(Type type, string typeName)
        {
            if (type.ToString() == typeName)
                return true;
            if (type.ToString() == "System.Object")
                return false;

            return IsType(type.BaseType, typeName);
        }


        public static string GetValue(object entity, string fieldName)
        {
            Type entityType = entity.GetType();
            PropertyInfo propertyInfo = entityType.GetProperty(fieldName);
            string value = string.Empty;
            if (IsType(propertyInfo.PropertyType, "System.String"))
            {
                value = propertyInfo.GetValue(entity, null).ToString();

            }

            if (IsType(propertyInfo.PropertyType, "System.Boolean"))
            {
                value = propertyInfo.GetValue(entity, null).ToString();

            }

            if (IsType(propertyInfo.PropertyType, "System.Int32"))
            {
                value = propertyInfo.GetValue(entity, null).ToString();

            }

            if (IsType(propertyInfo.PropertyType, "System.Decimal"))
            {
                value = propertyInfo.GetValue(entity, null).ToString();

            }

            if (IsType(propertyInfo.PropertyType, "System.Nullable`1[System.DateTime]"))
            {
                value = propertyInfo.GetValue(entity, null).ToString();
            }
            return value;

        }

    }
}
