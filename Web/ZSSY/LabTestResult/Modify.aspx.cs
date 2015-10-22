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
namespace RuRo.Web.ZSSY.LabTestResult
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(id);
				}
			}
		}
			
	private void ShowInfo(int id)
	{
		RuRo.BLL.ZSSY.LabTestResult bll=new RuRo.BLL.ZSSY.LabTestResult();
		RuRo.Model.ZSSY.LabTestResult model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtReportItemName.Text=model.ReportItemName;
		this.txtReportItemCode.Text=model.ReportItemCode;
		this.txtAbnormalIndicator.Text=model.AbnormalIndicator;
		this.txtResult.Text=model.Result;
		this.txtUnits.Text=model.Units;
		this.txtResultDateTime.Text=model.ResultDateTime;
		this.txtReferenceResult.Text=model.ReferenceResult;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtReportItemName.Text.Trim().Length==0)
			{
				strErr+="子项名称不能为空！\\n";	
			}
			if(this.txtReportItemCode.Text.Trim().Length==0)
			{
				strErr+="子项编码不能为空！\\n";	
			}
			if(this.txtAbnormalIndicator.Text.Trim().Length==0)
			{
				strErr+="N-正常L-低H-高不能为空！\\n";	
			}
			if(this.txtResult.Text.Trim().Length==0)
			{
				strErr+="正文描述不能为空！\\n";	
			}
			if(this.txtUnits.Text.Trim().Length==0)
			{
				strErr+="检验结果为数值型不能为空！\\n";	
			}
			if(this.txtResultDateTime.Text.Trim().Length==0)
			{
				strErr+="检验日期及时间不能为空！\\n";	
			}
			if(this.txtReferenceResult.Text.Trim().Length==0)
			{
				strErr+="结果参考值不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string ReportItemName=this.txtReportItemName.Text;
			string ReportItemCode=this.txtReportItemCode.Text;
			string AbnormalIndicator=this.txtAbnormalIndicator.Text;
			string Result=this.txtResult.Text;
			string Units=this.txtUnits.Text;
			string ResultDateTime=this.txtResultDateTime.Text;
			string ReferenceResult=this.txtReferenceResult.Text;


			RuRo.Model.ZSSY.LabTestResult model=new RuRo.Model.ZSSY.LabTestResult();
			model.id=id;
			model.ReportItemName=ReportItemName;
			model.ReportItemCode=ReportItemCode;
			model.AbnormalIndicator=AbnormalIndicator;
			model.Result=Result;
			model.Units=Units;
			model.ResultDateTime=ResultDateTime;
			model.ReferenceResult=ReferenceResult;

			RuRo.BLL.ZSSY.LabTestResult bll=new RuRo.BLL.ZSSY.LabTestResult();
			bll.Update(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
