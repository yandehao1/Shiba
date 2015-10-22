using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using RuRo.Common;
//using LTP.Accounts.Bus;
namespace RuRo.Web.ZSSY.ImportSampleSourceLog
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtsampleSourceName.Text.Trim().Length==0)
			{
				strErr+="样本源Name不能为空！\\n";	
			}
			if(this.txtsampleSourceType.Text.Trim().Length==0)
			{
				strErr+="样本源类型不能为空！\\n";	
			}
			if(this.txtsampleSourceDescription.Text.Trim().Length==0)
			{
				strErr+="样本源描述不能为空！\\n";	
			}
			if(this.txtpatientId.Text.Trim().Length==0)
			{
				strErr+="患者唯一标识不能为空！\\n";	
			}
			if(this.txtpatientName.Text.Trim().Length==0)
			{
				strErr+="患者姓名不能为空！\\n";	
			}
			if(this.txtpatientSex.Text.Trim().Length==0)
			{
				strErr+="患者性别不能为空！\\n";	
			}
			if(this.txtimportStatus.Text.Trim().Length==0)
			{
				strErr+="导入数据之前的状态不能为空！\\n";	
			}
			if(this.txthidden.Text.Trim().Length==0)
			{
				strErr+="隐藏域数据不能为空！\\n";	
			}
			if(this.txtResultStatus.Text.Trim().Length==0)
			{
				strErr+="导入数据之后的状态不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtImportDate.Text))
			{
				strErr+="执行导入的时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string sampleSourceName=this.txtsampleSourceName.Text;
			string sampleSourceType=this.txtsampleSourceType.Text;
			string sampleSourceDescription=this.txtsampleSourceDescription.Text;
			string patientId=this.txtpatientId.Text;
			string patientName=this.txtpatientName.Text;
			string patientSex=this.txtpatientSex.Text;
			string importStatus=this.txtimportStatus.Text;
			string hidden=this.txthidden.Text;
			string ResultStatus=this.txtResultStatus.Text;
			DateTime ImportDate=DateTime.Parse(this.txtImportDate.Text);

			RuRo.Model.ZSSY.ImportSampleSourceLog model=new RuRo.Model.ZSSY.ImportSampleSourceLog();
			model.sampleSourceName=sampleSourceName;
			model.sampleSourceType=sampleSourceType;
			model.sampleSourceDescription=sampleSourceDescription;
			model.patientId=patientId;
			model.patientName=patientName;
			model.patientSex=patientSex;
			model.importStatus=importStatus;
			model.hidden=hidden;
			model.ResultStatus=ResultStatus;
			model.ImportDate=ImportDate;

			RuRo.BLL.ZSSY.ImportSampleSourceLog bll=new RuRo.BLL.ZSSY.ImportSampleSourceLog();
			bll.Add(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
