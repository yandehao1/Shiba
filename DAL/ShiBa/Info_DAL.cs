using System;
using System.Data;
using System.Text;
using System.Web;
using Model;
using Maticsoft.DBUtility;

namespace RuRo.DAL
{
  /// <summary>
  /// ���ݷ��ʲ�Info_DAL
  /// </summary>
    public class Info_DAL
    {
        public Info_DAL()
        {
        }
        /// <summary>
        /// ��ѯסԺ
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataSet GetZhuYuanDataForCode(string code) 
        {
            string sqlstr = "select distinct a.bedNO ��λ,a.patient_no,a.name as ����,"
                +"(case when a.sex='1' then '��' when a.sex='2' then 'Ů' else a.sex end) as �Ա�,"
                +"to_char(sysdate,'yyyy')-to_char(a.csrq,'yyyy') as ����,a.PatientNO as ��ˮ��,"
                + "a.dept_name ���� from  bydata.view_BBK_inpatientinfo  a  where a.patient_no='"+code+"'";
            return DbHelperOra.Query(sqlstr);
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataSet GetMenZhenDataForCode(string code) 
        {
            string sqlstr = "select distinct c.seedept as ����,c.name as ����,sex as �Ա�, age as ����,"
                + "c.docname as ҽ��,c.ysdm as ҽ������,c.mzlsh as ��ˮ��,c.usercard as ����,"
                + "c.fphm as ��Ʊ��,c.patientno as ������,c.sqrq as ����,c.diagnose as ��� "
                + "from bydata.view_lis_outpatient c where  usercard='"+code+"'";
            return DbHelperOra.Query(sqlstr);
        }
    }
}
