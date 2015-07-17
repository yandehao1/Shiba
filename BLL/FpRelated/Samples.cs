using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{
    public class Samples
    {
        //创建数据层对象
        DataWithFP dataWithFP = new DataWithFP();
        /// <summary>
        /// 泛型方法处理从Fp中获取到的数据
        /// </summary>
        /// <typeparam name="T">返回集合参数的类型</typeparam>
        /// <param name="fpMethod">调用的api方法</param>
        /// <param name="param">调用方法的参数</param>
        /// <param name="datawith">从fp返回值中取什么数据</param>
        /// <returns>返回集合</returns>
        private List<T> getdata<T>(FpMethod fpMethod,Dictionary<string,string> param,string datawith)
        {
            List<T> list = new List<T>();
            string str_Json = dataWithFP.getDateFromFp(fpMethod, param);
            //默认取出来的数据只有100条
            if (ValidationData.checkTotal(str_Json))
            {
                list = FpJsonHelper.JObjectToList<T>(datawith, str_Json);
            }
            return list;
        }
        private List<T> getdata<T>(FpMethod fpMethod, string datawith)
        {
            List<T> list = new List<T>();
            string str_Json = dataWithFP.getDateFromFp(fpMethod);
            //默认取出来的数据只有100条
            if (ValidationData.checkTotal(str_Json))
            {
                list = FpJsonHelper.JObjectToList<T>(datawith, str_Json);
            }
            return list;
        }
        //样本类型 sample_types
        public List<Model.SampleTypes> GetSample_Types()
        {
            List<Model.SampleTypes> sample_TypesList = getdata<Model.SampleTypes>(FpMethod.sample_types, "SampleTypes");
            return sample_TypesList;
        }
        //样本自定义字段sample_userfields
        public Dictionary<string, string> GetSample_UserFields(string sample_id)
        {
            return new Dictionary<string, string>();
        }
        //根据日期查询样本samples_by_date  lists samples by date:# today, yesterday, week, month, 1/1/2008
        public List<Model.Sample> GetSamples_By_Date(string date, string param)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("date", date);
            dic.Add("limit", param);
            List<Model.Sample> sample_By_DateList = getdata<Model.Sample>(FpMethod.samples_by_date, dic, "Samples");
            return sample_By_DateList;
        }
        //获取出库的样本retrieves a list of samples that are taken out of the freezer:
        public List<Model.Sample_Out> GetSamples_Out(string param)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("limit", param);
            List<Model.Sample_Out> sampleOutList = getdata<Model.Sample_Out>(FpMethod.samples_out, dic, "Samples");
            return sampleOutList;
        }
        //获取删除的样本samples in the trashbin
        public List<Model.Samples_Trashbin> GetSamples_Trashbin(string param)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("limit", param);
            List<Model.Samples_Trashbin> sampleLocationsList = getdata<Model.Samples_Trashbin>(FpMethod.samples_trashbin, dic, "Locations");

            return sampleLocationsList;
        }
        //根据样本源id获取样本
        public List<Model.Sample> GetSampleSource_Samples(string samplesource_id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", samplesource_id);
            List<Model.Sample> sampleSource_Sampleslist = getdata<Model.Sample>(FpMethod.samplesource_samples, dic, "Samples");
            return sampleSource_Sampleslist;
        }
        //根据样本id获取样本的信息
        public Model.Sample_Info GetSample_Info(string sample_id)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", sample_id);
            Model.Sample_Info sample_info = new Model.Sample_Info();
            string strJson= dataWithFP.getDateFromFp(FpMethod.sample_info, dic);
            sample_info = FpJsonHelper.JsonStrToObject<Model.Sample_Info>(strJson);
            return sample_info;
        }
        
    }
}
