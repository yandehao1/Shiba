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
namespace RuRo.Web.ZSSY.LabTestMaster
{
    public partial class Show : Page
    {        
        		public string strid=""; 
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
		this.lblId.Text=model.Id.ToString();
		this.lblTestNo.Text=model.TestNo;
		this.lblpriorityIndicator.Text=model.priorityIndicator;
		this.lblWorkingId.Text=model.WorkingId;
		this.lblTestCause.Text=model.TestCause;
		this.lblRelevantClinicDiag.Text=model.RelevantClinicDiag;
		this.lblSpecimen.Text=model.Specimen;
		this.lblSpcmReceivedDateTime.Text=model.SpcmReceivedDateTime;
		this.lblOrderingDept.Text=model.OrderingDept;
		this.lblorderingProvider.Text=model.orderingProvider;
		this.lblPerformedBy.Text=model.PerformedBy;
		this.lblResultStatus.Text=model.ResultStatus;
		this.lblResultsRptDateTime.Text=model.ResultsRptDateTime;
		this.lbltranscriptionist.Text=model.transcriptionist;
		this.lblVerifiedBy.Text=model.VerifiedBy;

	}


    }
}
