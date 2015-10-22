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
namespace RuRo.Web.ZSSY.SpecimenRt
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
					int Id=(Convert.ToInt32(strid));
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(int Id)
	{
		RuRo.BLL.ZSSY.SpecimenRt bll=new RuRo.BLL.ZSSY.SpecimenRt();
		RuRo.Model.ZSSY.SpecimenRt model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblPatientId.Text=model.PatientId;
		this.lblPatientName.Text=model.PatientName;
		this.lblVisitId.Text=model.VisitId;
		this.lblSampleId.Text=model.SampleId;
		this.lblSampleName.Text=model.SampleName;
		this.lblOtherInfo.Text=model.OtherInfo;

	}


    }
}
