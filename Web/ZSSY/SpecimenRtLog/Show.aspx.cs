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
namespace RuRo.Web.ZSSY.SpecimenRtLog
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
		RuRo.BLL.ZSSY.SpecimenRtLog bll=new RuRo.BLL.ZSSY.SpecimenRtLog();
		RuRo.Model.ZSSY.SpecimenRtLog model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.lblusername.Text=model.username;
		this.lblPatiendId.Text=model.PatiendId;
		this.lblSampleId.Text=model.SampleId;
		this.lblPostBackStatus.Text=model.PostBackStatus;
		this.lblPostBackDate.Text=model.PostBackDate.ToString();

	}


    }
}
