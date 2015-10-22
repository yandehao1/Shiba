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
namespace RuRo.Web.ZSSY.SpecimenRt
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		RuRo.BLL.ZSSY.SpecimenRt bll=new RuRo.BLL.ZSSY.SpecimenRt();
		RuRo.Model.ZSSY.SpecimenRt model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtPatientId.Text=model.PatientId;
		this.txtPatientName.Text=model.PatientName;
		this.txtVisitId.Text=model.VisitId;
		this.txtSampleId.Text=model.SampleId;
		this.txtSampleName.Text=model.SampleName;
		this.txtOtherInfo.Text=model.OtherInfo;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPatientId.Text.Trim().Length==0)
			{
				strErr+="患者唯一标识号不能为空！\\n";	
			}
			if(this.txtPatientName.Text.Trim().Length==0)
			{
				strErr+="患者名称不能为空！\\n";	
			}
			if(this.txtVisitId.Text.Trim().Length==0)
			{
				strErr+="患者就诊号不能为空！\\n";	
			}
			if(this.txtSampleId.Text.Trim().Length==0)
			{
				strErr+="样本Id不能为空！\\n";	
			}
			if(this.txtSampleName.Text.Trim().Length==0)
			{
				strErr+="样本Name不能为空！\\n";	
			}
			if(this.txtOtherInfo.Text.Trim().Length==0)
			{
				strErr+="其他信息（样本类型、总管数、在不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string PatientId=this.txtPatientId.Text;
			string PatientName=this.txtPatientName.Text;
			string VisitId=this.txtVisitId.Text;
			string SampleId=this.txtSampleId.Text;
			string SampleName=this.txtSampleName.Text;
			string OtherInfo=this.txtOtherInfo.Text;


			RuRo.Model.ZSSY.SpecimenRt model=new RuRo.Model.ZSSY.SpecimenRt();
			model.Id=Id;
			model.PatientId=PatientId;
			model.PatientName=PatientName;
			model.VisitId=VisitId;
			model.SampleId=SampleId;
			model.SampleName=SampleName;
			model.OtherInfo=OtherInfo;

			RuRo.BLL.ZSSY.SpecimenRt bll=new RuRo.BLL.ZSSY.SpecimenRt();
			bll.Update(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
