using System;
using System.Data;
using Model;
using DAL;

namespace RuRo.BLL
{
    /// <summary>
    /// ҵ���߼���Info_BLL
    /// </summary>
    public class Info_BLL
    {
        public Info_BLL()
        {
        }
        private RuRo.DAL.Info_DAL g_DAL = new RuRo.DAL.Info_DAL();

        /// <summary>
        /// ����סԺ��Ϣ
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
        /// ����������ѯסԺ��Ϣ
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
        /// ����������Ϣ
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
        /// ����������ѯ������Ϣ
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
        /// ���ز���סԺ��Ϣ
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
        /// ���ز���������Ϣ
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
