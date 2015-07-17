using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{

    public class Boxes
    {
        //判断指定名称的盒子是否存在
        public static bool CheckBoxesByGetAll(Fp_Common.UnameAndPwd up, string id, string boxName)
        {
            List<Box> boxes = GetAll(up, id);
            if (boxes == null)
            {
                return false;
            }
            else
            {
                Box box = boxes.Where(a => a.name == boxName).FirstOrDefault();
                if (box == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static List<Box> GetAll(Fp_Common.UnameAndPwd up, string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.boxes.ToString());
            dic.Add("id", id);
            dic.Add("show_empty", "true");
            FreezerProUtility.Fp_DAL.CallApi call = new FreezerProUtility.Fp_DAL.CallApi(dic);
            List<Box> boxes = call.getdata<Box>("Boxes");
            return boxes;
        }
    }
}
