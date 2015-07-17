using FreezerProUtility.Fp_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreezerProUtility.Fp_BLL
{
    public class Subdivisions
    {

        //{"Total":4,"Subdivisions":[{"id":2,"obj_id":2,"name":"层 1","access":0,"description":"层 1 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000002","rfid_tag":"355AB1CBC000007000000002"},{"id":51,"obj_id":51,"name":"层 2","access":0,"description":"层 2 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000051","rfid_tag":"355AB1CBC000007000000033"},{"id":100,"obj_id":100,"name":"层 3","access":0,"description":"层 3 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000100","rfid_tag":"355AB1CBC000007000000064"},{"id":149,"obj_id":149,"name":"层 4","access":0,"description":"层 4 Description","subdivisions":6,"boxes":0,"barcode_tag":"7000000149","rfid_tag":"355AB1CBC000007000000095"}]}

        public static List<Fp_Model.Subdivision> GetAll(Fp_Common.UnameAndPwd up,string id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", up.UserName);
            dic.Add("password", up.PassWord);
            dic.Add("method", Fp_Common.FpMethod.subdivisions.ToString());
            dic.Add("id", id);
            FreezerProUtility.Fp_DAL.CallApi call = new FreezerProUtility.Fp_DAL.CallApi(dic);
            List<Fp_Model.Subdivision> List = call.getdata<Fp_Model.Subdivision>("Subdivisions");
            return List;
        }
        //public static List<Subdivision> GetAll(string url, string id)
        //{
        //    List<Subdivision> subdivisionList = Fp_DAL.DataWithFP.getdata<Subdivision>(url, Fp_Common.FpMethod.subdivisions, "&id=" + id, "Subdivision");
        //    return subdivisionList;
        //}

        //传入位置（返回名称id???）
        //tem→admin→06月→02日--直接生成
        public static Fp_Model.Subdivision CheckBy(Fp_Common.UnameAndPwd up,string freezerId, string location)
        {
            List<Fp_Model.Subdivision> subdivisionList = GetAll(up, freezerId);
             Fp_Model.Subdivision subdivision = new Subdivision();
            string[] l = location.Split('→');
            for (int i = 1; i < l.Length; i++)
            {
                subdivision = subdivisionList.Where(a => a.name == l[i]).FirstOrDefault();//冰箱结构重名取第一个结构
                if (subdivision == null || subdivision.name.Contains("日"))
                {
                    //找不到对应的节点就跳出
                    break;
                }
                else
                {
                    subdivisionList = GetAll(up, subdivision.id);
                }
            }
            return subdivision;
        }
    }
}
