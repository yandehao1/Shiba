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
namespace RuRo.Web.ZSSY.ImportSampleSourceLog
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int id=(Convert.ToInt32(strid));
					ShowInfo(id);
				}
			}
		}
		
	private void ShowInfo(int id)
	{
		RuRo.BLL.ZSSY.ImportSampleSourceLog bll=new RuRo.BLL.ZSSY.ImportSampleSourceLog();
		RuRo.Model.ZSSY.ImportSampleSourceLog model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblsampleSourceName.Text=model.sampleSourceName;
		this.lblsampleSourceType.Text=model.sampleSourceType;
		this.lblsampleSourceDescription.Text=model.sampleSourceDescription;
		this.lblpatientId.Text=model.patientId;
		this.lblpatientName.Text=model.patientName;
		this.lblpatientSex.Text=model.patientSex;
		this.lblimportStatus.Text=model.importStatus;
		this.lblhidden.Text=model.hidden;
		this.lblResultStatus.Text=model.ResultStatus;
		this.lblImportDate.Text=model.ImportDate.ToString();

	}


    }
}
