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
namespace RuRo.Web.ZSSY.OPListForSpecimen
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
		RuRo.BLL.ZSSY.OPListForSpecimen bll=new RuRo.BLL.ZSSY.OPListForSpecimen();
		RuRo.Model.ZSSY.OPListForSpecimen model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblPatientId.Text=model.PatientId;
		this.lblInpNO.Text=model.InpNO;
		this.lblVisitId.Text=model.VisitId;
		this.lblName.Text=model.Name;
		this.lblNamePhonetic.Text=model.NamePhonetic;
		this.lblSex.Text=model.Sex;
		this.lblDateOfBirth.Text=model.DateOfBirth;
		this.lblBirthPlace.Text=model.BirthPlace;
		this.lblCitizenship.Text=model.Citizenship;
		this.lblNation.Text=model.Nation;
		this.lblIDNO.Text=model.IDNO;
		this.lblIdentity.Text=model.Identity;
		this.lblChargeType.Text=model.ChargeType;
		this.lblMailingAddress.Text=model.MailingAddress;
		this.lblZipCode.Text=model.ZipCode;
		this.lblPhoneNumberHome.Text=model.PhoneNumberHome;
		this.lblPhoneNumbeBusiness.Text=model.PhoneNumbeBusiness;
		this.lblNextOfKin.Text=model.NextOfKin;
		this.lblRelationShip.Text=model.RelationShip;
		this.lblNextOfKinAddr.Text=model.NextOfKinAddr;
		this.lblNextOfKinZipCode.Text=model.NextOfKinZipCode;
		this.lblNextOfKinPhome.Text=model.NextOfKinPhome;
		this.lblDeptCode.Text=model.DeptCode;
		this.lblBedNO.Text=model.BedNO;
		this.lblAdmissionDateTime.Text=model.AdmissionDateTime;
		this.lblDoctorInCharge.Text=model.DoctorInCharge;
		this.lblScheduleId.Text=model.ScheduleId;
		this.lblDiagBeforeOperation.Text=model.DiagBeforeOperation;
		this.lblScheduledDateTime.Text=model.ScheduledDateTime;
		this.lblKeepSpecimenSign.Text=model.KeepSpecimenSign;
		this.lblOperatingRoom.Text=model.OperatingRoom;
		this.lblSurgeon.Text=model.Surgeon;
		this.lblInPatPreillness.Text=model.InPatPreillness;
		this.lblInPatPastillness.Text=model.InPatPastillness;
		this.lblInPatFamillness.Text=model.InPatFamillness;
		this.lblLabInfo.Text=model.LabInfo;

	}


    }
}
