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
namespace RuRo.Web.ZSSY.LabTestMaster
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
			
	private void ShowInfo()
	{
		RuRo.BLL.ZSSY.LabTestMaster bll=new RuRo.BLL.ZSSY.LabTestMaster();
		RuRo.Model.ZSSY.LabTestMaster model=bll.GetModel();
		this.txtId.Text=model.Id.ToString();
		this.txtTestNo.Text=model.TestNo;
		this.txtpriorityIndicator.Text=model.priorityIndicator;
		this.txtWorkingId.Text=model.WorkingId;
		this.txtTestCause.Text=model.TestCause;
		this.txtRelevantClinicDiag.Text=model.RelevantClinicDiag;
		this.txtSpecimen.Text=model.Specimen;
		this.txtSpcmReceivedDateTime.Text=model.SpcmReceivedDateTime;
		this.txtOrderingDept.Text=model.OrderingDept;
		this.txtorderingProvider.Text=model.orderingProvider;
		this.txtPerformedBy.Text=model.PerformedBy;
		this.txtResultStatus.Text=model.ResultStatus;
		this.txtResultsRptDateTime.Text=model.ResultsRptDateTime;
		this.txttranscriptionist.Text=model.transcriptionist;
		this.txtVerifiedBy.Text=model.VerifiedBy;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtId.Text))
			{
				strErr+="Id格式错误！\\n";	
			}
			if(this.txtTestNo.Text.Trim().Length==0)
			{
				strErr+="检验申请单号不能为空！\\n";	
			}
			if(this.txtpriorityIndicator.Text.Trim().Length==0)
			{
				strErr+="优先标志不能为空！\\n";	
			}
			if(this.txtWorkingId.Text.Trim().Length==0)
			{
				strErr+="工作单号不能为空！\\n";	
			}
			if(this.txtTestCause.Text.Trim().Length==0)
			{
				strErr+="检验目的不能为空！\\n";	
			}
			if(this.txtRelevantClinicDiag.Text.Trim().Length==0)
			{
				strErr+="临床诊断不能为空！\\n";	
			}
			if(this.txtSpecimen.Text.Trim().Length==0)
			{
				strErr+="标本不能为空！\\n";	
			}
			if(this.txtSpcmReceivedDateTime.Text.Trim().Length==0)
			{
				strErr+="采样时间不能为空！\\n";	
			}
			if(this.txtOrderingDept.Text.Trim().Length==0)
			{
				strErr+="开医嘱科室不能为空！\\n";	
			}
			if(this.txtorderingProvider.Text.Trim().Length==0)
			{
				strErr+="医生工号不能为空！\\n";	
			}
			if(this.txtPerformedBy.Text.Trim().Length==0)
			{
				strErr+="执行科室不能为空！\\n";	
			}
			if(this.txtResultStatus.Text.Trim().Length==0)
			{
				strErr+="执行情况不能为空！\\n";	
			}
			if(this.txtResultsRptDateTime.Text.Trim().Length==0)
			{
				strErr+="报告完成时间不能为空！\\n";	
			}
			if(this.txttranscriptionist.Text.Trim().Length==0)
			{
				strErr+="报告者工号不能为空！\\n";	
			}
			if(this.txtVerifiedBy.Text.Trim().Length==0)
			{
				strErr+="审核者工号不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.txtId.Text);
			string TestNo=this.txtTestNo.Text;
			string priorityIndicator=this.txtpriorityIndicator.Text;
			string WorkingId=this.txtWorkingId.Text;
			string TestCause=this.txtTestCause.Text;
			string RelevantClinicDiag=this.txtRelevantClinicDiag.Text;
			string Specimen=this.txtSpecimen.Text;
			string SpcmReceivedDateTime=this.txtSpcmReceivedDateTime.Text;
			string OrderingDept=this.txtOrderingDept.Text;
			string orderingProvider=this.txtorderingProvider.Text;
			string PerformedBy=this.txtPerformedBy.Text;
			string ResultStatus=this.txtResultStatus.Text;
			string ResultsRptDateTime=this.txtResultsRptDateTime.Text;
			string transcriptionist=this.txttranscriptionist.Text;
			string VerifiedBy=this.txtVerifiedBy.Text;


			RuRo.Model.ZSSY.LabTestMaster model=new RuRo.Model.ZSSY.LabTestMaster();
			model.Id=Id;
			model.TestNo=TestNo;
			model.priorityIndicator=priorityIndicator;
			model.WorkingId=WorkingId;
			model.TestCause=TestCause;
			model.RelevantClinicDiag=RelevantClinicDiag;
			model.Specimen=Specimen;
			model.SpcmReceivedDateTime=SpcmReceivedDateTime;
			model.OrderingDept=OrderingDept;
			model.orderingProvider=orderingProvider;
			model.PerformedBy=PerformedBy;
			model.ResultStatus=ResultStatus;
			model.ResultsRptDateTime=ResultsRptDateTime;
			model.transcriptionist=transcriptionist;
			model.VerifiedBy=VerifiedBy;

			RuRo.BLL.ZSSY.LabTestMaster bll=new RuRo.BLL.ZSSY.LabTestMaster();
			bll.Update(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
