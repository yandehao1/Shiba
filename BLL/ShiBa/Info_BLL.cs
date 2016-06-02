using System;
using System.Data;
using Model;
using DAL;

namespace RuRo.BLL
{
    /// <summary>
    /// 业务逻辑层Info_BLL
    /// </summary>
    public class Info_BLL
    {
        public Info_BLL()
        {
        }
        private RuRo.DAL.Info_DAL g_DAL = new RuRo.DAL.Info_DAL();

        /// <summary>
        /// 返回住院信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public  string GetZhuYuanData(string code)
        {
            DataSet ds = new DataSet();
            ds=g_DAL.GetZhuYuanDataForCode(code);
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
        /// <summary>
        /// 返回姓名查询住院信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetZhuYuanDataForName(string name)
        {
            DataSet ds = new DataSet();
            ds = g_DAL.GetZhuYuanDataForName(name);
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }

        /// <summary>
        /// 返回门诊信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMenZhenData(string code) 
        {
            DataSet ds = new DataSet();
            ds = g_DAL.GetMenZhenDataForCode(code);
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }

        /// <summary>
        /// 返回姓名查询门诊信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetMenZhenDataForName(string name,string ksrq,string jsrq)
        {
            DataSet ds = new DataSet();
            ds = g_DAL.GetMenZhenDataForName(name, ksrq, jsrq);
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
        /// <summary>
        /// 返回测试住院信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetZhuYuanTest(string code)
        {
            DataSet ds = new DataSet();
            ds = g_DAL.GetTestzhuyuan();
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }

        /// <summary>
        /// 返回测试门诊信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetmenzhenTest(string code)
        {
            DataSet ds = new DataSet();
            ds = g_DAL.GetTestmenzhen();
            return FpUtility.Fp_Common.FpJsonHelper.ObjectToJsonStr(ds);
        }
    }
}
