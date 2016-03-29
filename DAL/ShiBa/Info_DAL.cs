using System;
using System.Data;
using System.Text;
using System.Web;
using Model;
using Maticsoft.DBUtility;

namespace RuRo.DAL
{
  /// <summary>
  /// 数据访问层Info_DAL
  /// </summary>
    public class Info_DAL
    {
        public Info_DAL()
        {
        }
        /// <summary>
        /// 查询住院
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetZhuYuanDataForCode(string code) 
        {
            string sqlstr = "select distinct a.bedNO 床位,a.patient_no,a.name as 姓名,"
                +"(case when a.sex='1' then '男' when a.sex='2' then '女' else a.sex end) as 性别,"
                +"to_char(sysdate,'yyyy')-to_char(a.csrq,'yyyy') as 年龄,a.PatientNO as 流水号,"
                + "a.dept_name 部门 from  bydata.view_BBK_inpatientinfo  a  where a.patient_no='"+code+"'";
            return DbHelperOra.Query(sqlstr);
        }

        /// <summary>
        /// 查询门诊
        /// </summary>
        /// <returns></returns>
        public DataSet GetMenZhenDataForCode(string code) 
        {
            string sqlstr = "select distinct c.seedept as 部门,c.name as 姓名,sex as 性别, age as 年龄,"
                + "c.docname as 医生,c.ysdm as 医生代码,c.mzlsh as 流水号,c.usercard as 卡号,"
                + "c.fphm as 发票号,c.patientno as 病历号,c.sqrq as 日期,c.diagnose as 诊断 "
                + "from bydata.view_lis_outpatient c where  usercard='"+code+"'";
            return DbHelperOra.Query(sqlstr);
        }
    }
}
