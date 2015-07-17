using System;
using System.Collections.Generic;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class UserFields
    {        //创建数据层对象
        DataWithFP dataWithFP = new DataWithFP();

        #region 获取自定义字段集合 + public List<Model.UserFields> UserFields()
        /// <summary>
        /// 获取自定义字段集合
        /// </summary>
        /// <returns> List<Model.UserFields> </returns>
        public List<Model.UserFields> UserFieldList()
        {
            List<Model.UserFields> list_UserFields = new List<Model.UserFields>() { };
            string str_Json = dataWithFP.getDateFromFp(FpMethod.userfields);
            try
            {
                string total = FpJsonHelper.GetStrFromJsonStr("Total", str_Json);
                if (Convert.ToInt32(total) > 0)
                {
                    list_UserFields = FpJsonHelper.JObjectToList<Model.UserFields>("UserFields", str_Json);
                }
            }
            catch (Exception e)
            {
            }
            return list_UserFields;
        }
        #endregion

    }
}
