using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DAL;
using Model;

namespace BLL
{
    public class RespondHis
    {
        //01.创建相应对象
        WebService.ForCenterLabService CenterLab = new WebService.ForCenterLabService();
        WebService.SpecimenRt specimenRt = new WebService.SpecimenRt();
        WebService.Specimen specimen = new WebService.Specimen();

        Samples sample = new Samples();
        SampleSocrce samplesource = new SampleSocrce();

        DAL.FpExtendDatabaseHelper fpExtendDatabase = new DAL.FpExtendDatabaseHelper();//数据库操作对象——数据层
        public void ss()
        {
            //创建specimen:
            specimen.Id = "";//样本id
            specimen.Name = "";//样本name
            specimen.Status = "";//样本状态（无）
            specimen.DateTime = "";//样本存储/出库时间（无）
            specimen.OtherInfo = "";//其他信息（scouts、in_vials、out_vials、created_at、updated_at）要求是使用^分割

            //创建specimenRt
            specimenRt.PatientId = "";//患者PatientId（样本源信息——唯一标识号）
            specimenRt.VisitId = "";//患者就诊id（样本源信息——就诊号）
            specimenRt.PatientName = "";//患者姓名（样本源信息——姓名）
            //specimenRt.Specimens.Add(specimen);

            //将specimen添加到specimenRt中
            specimenRt.Specimens = new WebService.Specimen[] { specimen };

            //调用方法回传
            CenterLab.StoreSpecimenInfo(specimenRt);
        }

        //03.回发所有数据
        #region 此方法用于向His回发数据 + public void ResponsrHis()
        /// <summary>
        /// 此方法用于向His回发数据
        /// </summary>
        public void ResponsrHis()
        {
            //检查数据库中当前用户最后一次更新的时间
            //获取当前用户
            string username = GetUserName();
            DateTime date = fpExtendDatabase.GetSpecimenRtLogLastPostBackDate(username);

            if (date.CompareTo(DateTime.Now.AddDays(-1)) <= 0)//查询的日期小于当前日期的前一天
            {
                //获取要回发的数据
                List<WebService.SpecimenRt> SpecimenRtList = GetSpecimenRtList();
                if (SpecimenRtList.Count > 0)
                {
                    foreach (WebService.SpecimenRt item in SpecimenRtList)
                    {
                        Thread.Sleep(1000);//休眠1秒钟
                        //检查当前数据是否需要回发——数据库中不存在当前样本id的数据或者数据库中的数据和当前样本id的样本数据不一样
                        //a、数据库中存在数据——更新
                        //b、数据库中不存在数据——添加
                        bool exist = false;
                        bool checkSpecimenRtResult = CheckSpecimenRt(item, ref exist);
                        if (!checkSpecimenRtResult)
                        {
                            //数据库中不存在当前样本Id的数据
                            string result = CenterLab.StoreSpecimenInfo(item);//回发数据
                            //保存日志：a、直接保存SpecimenRtLog；b、成功之后保存详细的SpecimenRt
                            bool SaveSpecimenRtLogResult = AddToSpecimenRtLog(item, result);
                            if (result == "0^成功")//此处需要判断回发数据之后保存是否成功——判断回发之后返回的状态。
                            {
                                //保存当前记录到数据库
                                bool SaveSpecimenRtResult = AddToSpecimenRt(item);
                            }
                            //检查当前的数据是否和数据库中的数据一直
                        }
                        else//数据库中存在当前样本id的数据
                        {
                            if (exist)//不一样
                            {
                                string result = "";
                                try
                                {
                                    // result = CenterLab.StoreSpecimenInfo(item);//回发数据
                                }
                                catch (Exception ex)
                                {
                                    result = ex.Message;
                                }
                                //保存日志：a、直接保存SpecimenRtLog；b、成功之后保存详细的SpecimenRt
                                bool SaveSpecimenRtLogResult = AddToSpecimenRtLog(item, result);
                                if (result == "0^成功")//此处需要判断回发数据之后保存是否成功——判断回发之后返回的状态。
                                {
                                    //保存当前记录到数据库
                                    bool SaveSpecimenRtResult = UpdateSpecimenRt(item);
                                }
                                
                            }
                        }

                    }
                }
            }
        }
        #endregion



        public void HF()
        {
            //1、回发根据日期查询到的样本
            //2、回发被删除的样本
            //3、回发出库的样本
            //都要使用到：回发、从数据库查询数据、从Fp中查询数据
            //单条回发
        }
        //02.获取FP中的数据
        #region 根据日期、删除的样本、出库的样本生成SpecimenRt集合 + private List<WebService.SpecimenRt> GetSpecimenRtList()
        /// <summary>
        /// 根据日期、删除的样本、出库的样本生成SpecimenRt集合
        /// </summary>
        /// <returns>SpecimenRt集合</returns>
        private List<WebService.SpecimenRt> GetSpecimenRtList()
        {
            //创建回发数据对象
            List<WebService.SpecimenRt> SpecimenRtList = new List<WebService.SpecimenRt>();
            //创建查询日期（2015.02.12,2015.03.13）
            string date = string.Format("{0},{1}", fpExtendDatabase.GetSpecimenRtLogLastPostBackDate(GetUserName()).ToString("yyyy.MM.dd"), DateTime.Now.AddDays(-1).ToString("yyyy.MM.dd"));
            if (CreateSpecimenRtWithSamples_By_Date(date).Count > 0)
            {
                SpecimenRtList.AddRange(CreateSpecimenRtWithSamples_By_Date(date));
            }
            if (CreateSpecimenRtWithSamples_Out().Count > 0)
            {
                SpecimenRtList.AddRange(CreateSpecimenRtWithSamples_Out());
            }
            if (CreateSpecimenRtWithSamples_Trashbin().Count > 0)
            {
                SpecimenRtList.AddRange(CreateSpecimenRtWithSamples_Trashbin());
            }
            return SpecimenRtList;
        }
        #endregion
        #region 根据日期创建回发信息集合 + private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_By_Date()
        /// <summary>
        /// 根据日期创建回发信息集合，返回是specimenRtList
        /// </summary>
        /// <param name="date">日期"tadoy","yesterday","2015.02.18,2015.02.19"</param>
        /// <returns>WebService.SpecimenRt回发信息集合</returns>
        private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_By_Date(string date)
        {
            List<WebService.SpecimenRt> specimenRtList = new List<WebService.SpecimenRt>();
            //sample_by_date，根据日期获取“前一天（yesterday）”的样本,如果是调用当天的样本数据就是“today"或者是"2015.02.18,2015.02.19"
            //***此处应该是根据保存的日志文件中的日期然后根据保存的日期取数据
            //http://192.168.1.104/api?username=admin;password=admin;method=samples_by_date&date=2014.03.15,2015.03.16
            List<Model.Sample> sample_by_dateList = sample.GetSamples_By_Date(date,"5000");
            if (sample_by_dateList.Count > 0)
            {
                foreach (Model.Sample item in sample_by_dateList)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    //根据日期获取样本再根据id获取样本详细信息
                    Model.Sample_Info sampleinfo = sample.GetSample_Info(item.id);
                    dic = CreatOtherInfoBySampleInfo(sampleinfo);//根据Sample_Info获取：样本类型、总管数、样本更新时间、样本源id字典
                    dic.Add("created_at", item.created_at);//添加创建时间
                    dic.Add("in_vials", "");
                    dic.Add("out_vials", "");
                    string source_id = sampleinfo.source_id;//获取样本源id
                    specimen.Id = item.id.ToString();//添加样本id
                    specimen.Name = item.name;//添加样本名称
                    specimen.OtherInfo = Common.FpJsonHelper.DictionaryToJsonString(dic);//添加其他信息（样本类型、总管数、样本创建时间、样本保存时间、样本可用管数、样本出库在外的管数）
                    specimenRt = Get_SpecimenRt(source_id);//创建specimenRt
                    specimenRt.Specimens = new WebService.Specimen[] { specimen };//将specimen添加到specimenRt中
                    specimenRtList.Add(specimenRt);
                }
            }
            return specimenRtList;
        }
        #endregion
        #region 根据出库的样本创建回发信息集合 + private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_Out()
        /// <summary>
        /// 根据出库的样本创建回发信息集合
        /// </summary>
        /// <returns>WebService.SpecimenRt回发信息集合</returns>
        private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_Out()
        {
            List<WebService.SpecimenRt> specimenRtList = new List<WebService.SpecimenRt>();
            List<Model.Sample_Out> sample_by_dateList = sample.GetSamples_Out("5000");//获取出库的样本
            if (sample_by_dateList.Count > 0)
            {
                foreach (Model.Sample_Out item in sample_by_dateList)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    Model.Sample_Info sampleinfo = sample.GetSample_Info(item.id);
                    dic = CreatOtherInfoBySampleInfo(sampleinfo);
                    dic.Add("created_at", item.created_at);
                    dic.Add("in_vials", item.in_vials);
                    dic.Add("out_vials", item.out_vials);
                    string source_id = sampleinfo.source_id;
                    specimen.Id = item.id.ToString();//添加样本id
                    specimen.Name = item.name;//添加样本名称
                    specimen.OtherInfo = Common.FpJsonHelper.DictionaryToJsonString(dic);//添加其他信息（样本类型、总管数、样本创建时间、样本保存时间、样本可用管数、样本出库在外的管数）
                    specimenRt = Get_SpecimenRt(source_id);//创建specimenRt
                    specimenRt.Specimens = new WebService.Specimen[] { specimen };
                    specimenRtList.Add(specimenRt);
                }
            }
            return specimenRtList;
        }
        #endregion
        #region 根据删除的样本创建回发对象集合 + private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_Trashbin()
        /// <summary>
        /// 根据删除的样本创建回发对象集合 
        /// </summary>
        /// <returns>WebService.SpecimenRt 集合</returns>
        private List<WebService.SpecimenRt> CreateSpecimenRtWithSamples_Trashbin()
        {
            List<WebService.SpecimenRt> specimenRtList = new List<WebService.SpecimenRt>();
            List<Model.Samples_Trashbin> sample_by_dateList = sample.GetSamples_Trashbin("5000");//所有删除的样本
            if (sample_by_dateList.Count > 0)
            {
                foreach (Model.Samples_Trashbin item in sample_by_dateList)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    Model.Sample_Info sampleinfo = sample.GetSample_Info(item.obj_id);
                    dic = CreatOtherInfoBySampleInfo(sampleinfo);
                    dic.Add("created_at", item.created_at);
                    dic.Add("in_vials", "");
                    dic.Add("out_vials", "");
                    string source_id = sampleinfo.source_id;
                    specimen.Id = item.id.ToString();//添加样本id
                    specimen.Name = item.name;//添加样本名称
                    specimen.OtherInfo = Common.FpJsonHelper.DictionaryToJsonString(dic);//添加其他信息（样本类型、总管数、样本创建时间、样本保存时间、样本可用管数、样本出库在外的管数）
                    specimenRt = Get_SpecimenRt(source_id);//创建specimenRt
                    specimenRt.Specimens = new WebService.Specimen[] { specimen };
                    specimenRtList.Add(specimenRt);
                }
            }
            return specimenRtList;
        }
        #endregion
        #region 根据样本信息创建回发信息中包含的其他样本信息字典 + private Dictionary<string, string> CreatOtherInfoBySampleInfo
        /// <summary>
        /// 根据样本信息创建回发信息中包含的其他样本信息字典（sample_type、scount、updated_at、source_id）
        /// </summary>
        /// <param name="sampleinfo">样本信息对象</param>
        /// <returns>字典</returns>
        private Dictionary<string, string> CreatOtherInfoBySampleInfo(Model.Sample_Info sampleinfo)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("sample_type", sampleinfo.sample_type);//样本类型
            dic.Add("scount", sampleinfo.scount);//总管数
            dic.Add("updated_at", sampleinfo.updated_at);//更新时间
            dic.Add("source_id", sampleinfo.source_id);//样本源id
            return dic;
        }
        #endregion
        #region 创建回发数据中患者信息部分 + private WebService.SpecimenRt Get_SpecimenRt(string source_id)
        /// <summary>
        /// 创建回发数据中患者信息部分
        /// </summary>
        /// <param name="source_id">样本源id</param>
        /// <returns>WebService.SpecimenRt 对象</returns>
        private WebService.SpecimenRt Get_SpecimenRt(string source_id)
        {
            WebService.SpecimenRt SpecimenRt = new WebService.SpecimenRt();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic = samplesource.Get_Sample_Source_Userfields(source_id);//根据id获取样本源信息
            if (dic.Count > 0)
            {
                if (dic.Keys.Contains("唯一标识号"))
                {
                    specimenRt.PatientId = dic["唯一标识号"];
                }
                if (dic.Keys.Contains("姓名"))
                {
                    specimenRt.PatientName = dic["姓名"];
                }
                if (dic.Keys.Contains("就诊号"))
                {
                    specimenRt.VisitId = dic["就诊号"];
                }
            }
            return SpecimenRt;
        }
        #endregion
        #region 判断当前的样本数据是否在数据库中存在，并判断数据是否是一样的 + private bool CheckSpecimenRt(WebService.SpecimenRt item, ref bool exist)
        /// <summary>
        /// 判断当前的样本数据是否在数据库中存在，并判断数据是否是一样的
        /// </summary>
        /// <param name="item">当前的样本数据（从Fp中获取的数据）</param>
        /// <param name="exist">数据库中存在的数据是否和当前数据一样（true不一样）</param>
        /// <returns>数据库中是否存在数据</returns>
        private bool CheckSpecimenRt(WebService.SpecimenRt item, ref bool exist)
        {
            //检查当前的数据(WebService.SpecimenRt)在数据库中是否存在
            SpecimenRt specimenRt = fpExtendDatabase.SelectSpecimenRtBySampleId(item.Specimens[0].Id);
            if (specimenRt != null)//根据样本ID查询到了数据
            {
                //判断当前传入的item是否和数据中保存的数据一样
                if (item.PatientId != specimenRt.PatientId || item.PatientName != specimenRt.PatientName || item.VisitId != specimenRt.VisitId ||
                    item.Specimens[0].Name != specimenRt.SampleName || item.Specimens[0].OtherInfo != specimenRt.OtherInfo
                    )//只要有一项不同就是不一样
                {
                    exist = true;//数据不一样
                }
                return true;
            }
            return false;
        }
        #endregion
        #region 添加当前样本回发日志到数据库 + private bool AddToSpecimenRtLog(WebService.SpecimenRt item, string result)
        /// <summary>
        /// 添加当前样本回发日志到数据库
        /// </summary>
        /// <param name="item">当前的样本数据</param>
        /// <param name="result">回发后的状态</param>
        /// <returns>保存是否成功</returns>
        private bool AddToSpecimenRtLog(WebService.SpecimenRt item, string result)
        {
            //保存日志：a、直接保存SpecimenRtLog
            SpecimenRtLog specimenRtLog = new SpecimenRtLog();
            specimenRtLog.PatiendId = item.PatientId;//提交的患者唯一标识
            specimenRtLog.PostBackDate = DateTime.Now;//提交日期
            specimenRtLog.PostBackStatus = result;//保存提交的结果
            specimenRtLog.SampleId = item.Specimens[0].Id;//样本id
            if (string.IsNullOrEmpty(GetUserName()))
            {
                return false;
            }
            else
            {
                specimenRtLog.username = GetUserName();//当前用户
            }
            return fpExtendDatabase.AddToSpecimenRtLog(specimenRtLog);//保存到数据库__返回保存是否成功的状态

        }
        #endregion
        #region 将当前的样本数据添加到数据库保存 + private bool AddToSpecimenRt(WebService.SpecimenRt item)
        /// <summary>
        /// 将当前的样本数据添加到数据库保存
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool AddToSpecimenRt(WebService.SpecimenRt item)
        {
            //保存当前记录到数据库——b、成功之后保存详细的SpecimenRt
            SpecimenRt specimenRt = WebSpecimenRtToDataBaseSpecimenRt(item);
            return fpExtendDatabase.AddToSpecimenRt(specimenRt);
        }
        #endregion
        #region 将当前的样本数据更新到数据库 + private bool UpdateSpecimenRt(WebService.SpecimenRt item)
        /// <summary>
        /// 将当前的样本数据更新到数据库
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool UpdateSpecimenRt(WebService.SpecimenRt item)
        {
            //更新SpecimenRt
            SpecimenRt specimenRt = WebSpecimenRtToDataBaseSpecimenRt(item);
            if (specimenRt != null)
            {
                return fpExtendDatabase.UpdateToSpecimenRt(specimenRt);
            }
            return false;
        }
        #endregion
  #region 将WebService.SpecimenRt 对象转换成数据库SpecimenRt中保存的对象  private SpecimenRt WebSpecimenRtToDataBaseSpecimenRt(WebService.SpecimenRt item)
        /// <summary>
        /// 将WebService.SpecimenRt 对象转换成数据库SpecimenRt中保存的对象
        /// </summary>
        /// <param name="item">WebService.SpecimenRt</param>
        /// <returns>SpecimenRt</returns>
        private Model.SpecimenRt WebSpecimenRtToDataBaseSpecimenRt(WebService.SpecimenRt item)
        {
            //将当前需要回传的样本数据转换成数据库里保存的格式
            Model.SpecimenRt specimenRt = new Model.SpecimenRt();
            specimenRt.PatientId = item.PatientId;
            specimenRt.PatientName = item.PatientName;
            specimenRt.SampleId = item.Specimens[0].Id;
            specimenRt.SampleName = item.Specimens[0].Name;
            specimenRt.OtherInfo = item.Specimens[0].OtherInfo;
            return specimenRt;
        }
        #endregion
        #region 获取当前的用户名 +  private string GetUserName()
        /// <summary>
        /// 获取当前的用户名
        /// </summary>
        /// <returns></returns>
        private string GetUserName()
        {
            string Username = "";
            Username = AccountHelper.GetActiveAccountUesrName()[0];
            return Username;
        }
        #endregion
        /// <summary>
        /// 根据当前用户名获取最后一次回发的时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetRespondDateByUserName()
        {
            string username = GetUserName();
            DateTime datetime = fpExtendDatabase.GetSpecimenRtLogLastPostBackDate(username);
            return datetime;
        }
    }
}
