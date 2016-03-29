using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_BLL
{
    public class SampleGroup
    {
        public static List<Fp_Model.Sample_Group> GetAll(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.sample_groups.ToString());
            FpUtility.Fp_DAL.CallApi call = new FpUtility.Fp_DAL.CallApi(dic);
            List<Fp_Model.Sample_Group> List = call.getdata<Fp_Model.Sample_Group>("SampleGroups");
            return List;
        }
        //public static List<Fp_Model.Sample_Group> GetAll(string url)
        //{
        //    List<Fp_Model.Sample_Group> List = Fp_DAL.DataWithFP.getdata<Fp_Model.Sample_Group>(url, Fp_Common.FpMethod.sample_groups, "", "SampleGroups");
        //    return List;
        //}
        public static Fp_Model.Sample_Group GetBy(Fp_Common.UnameAndPwd up, string name)
        {
            List<Fp_Model.Sample_Group> List = GetAll(up);
            Fp_Model.Sample_Group sample_Group = new Fp_Model.Sample_Group();
            if (List!=null&&List.Count>0)
            {
                sample_Group = List.Where<Fp_Model.Sample_Group>(a => a.name == name).FirstOrDefault();
            }
            return sample_Group;
        }
        public static Dictionary<string, string> GetAllIdAndNameDic(Fp_Common.UnameAndPwd up)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            List<Fp_Model.Sample_Group> sample_Group = GetAll(up);
            foreach (var item in sample_Group)
            {
                dic.Add(item.id, item.name);
            }
            return dic;
        }
    }
}
