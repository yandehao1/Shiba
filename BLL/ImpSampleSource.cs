using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.BLL
{
   public class ImpSampleSource
    {
       public string Import(object obj, string sampleSourceTypeName, string ssName, string ssDescription)
       {
           UnameAndPwd up = new UnameAndPwd();
           //将前台传入的对象转换成字典
           Dictionary<string, string> dataDic = Common.ObjAndDic.ObjectToDic(obj);
           dataDic.Add("Name", ssName);
           dataDic.Add("Description", ssDescription);
           //匹配字段并转换成
           string result = FpUtility.Fp_BLL.SampleSocrce.ImportSampleSourceDataToFp(up.GetUp(), sampleSourceTypeName, dataDic);
           return result;
       }
    }
}
