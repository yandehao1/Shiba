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
namespace RuRo.Web.ZSSY.OPListForSpecimen
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
		RuRo.BLL.ZSSY.OPListForSpecimen bll=new RuRo.BLL.ZSSY.OPListForSpecimen();
		RuRo.Model.ZSSY.OPListForSpecimen model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtPatientId.Text=model.PatientId;
		this.txtInpNO.Text=model.InpNO;
		this.txtVisitId.Text=model.VisitId;
		this.txtName.Text=model.Name;
		this.txtNamePhonetic.Text=model.NamePhonetic;
		this.txtSex.Text=model.Sex;
		this.txtDateOfBirth.Text=model.DateOfBirth;
		this.txtBirthPlace.Text=model.BirthPlace;
		this.txtCitizenship.Text=model.Citizenship;
		this.txtNation.Text=model.Nation;
		this.txtIDNO.Text=model.IDNO;
		this.txtIdentity.Text=model.Identity;
		this.txtChargeType.Text=model.ChargeType;
		this.txtMailingAddress.Text=model.MailingAddress;
		this.txtZipCode.Text=model.ZipCode;
		this.txtPhoneNumberHome.Text=model.PhoneNumberHome;
		this.txtPhoneNumbeBusiness.Text=model.PhoneNumbeBusiness;
		this.txtNextOfKin.Text=model.NextOfKin;
		this.txtRelationShip.Text=model.RelationShip;
		this.txtNextOfKinAddr.Text=model.NextOfKinAddr;
		this.txtNextOfKinZipCode.Text=model.NextOfKinZipCode;
		this.txtNextOfKinPhome.Text=model.NextOfKinPhome;
		this.txtDeptCode.Text=model.DeptCode;
		this.txtBedNO.Text=model.BedNO;
		this.txtAdmissionDateTime.Text=model.AdmissionDateTime;
		this.txtDoctorInCharge.Text=model.DoctorInCharge;
		this.txtScheduleId.Text=model.ScheduleId;
		this.txtDiagBeforeOperation.Text=model.DiagBeforeOperation;
		this.txtScheduledDateTime.Text=model.ScheduledDateTime;
		this.txtKeepSpecimenSign.Text=model.KeepSpecimenSign;
		this.txtOperatingRoom.Text=model.OperatingRoom;
		this.txtSurgeon.Text=model.Surgeon;
		this.txtInPatPreillness.Text=model.InPatPreillness;
		this.txtInPatPastillness.Text=model.InPatPastillness;
		this.txtInPatFamillness.Text=model.InPatFamillness;
		this.txtLabInfo.Text=model.LabInfo;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPatientId.Text.Trim().Length==0)
			{
				strErr+="病人唯一标识号不能为空！\\n";	
			}
			if(this.txtInpNO.Text.Trim().Length==0)
			{
				strErr+="住院号不能为空！\\n";	
			}
			if(this.txtVisitId.Text.Trim().Length==0)
			{
				strErr+="就诊号不能为空！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="姓名不能为空！\\n";	
			}
			if(this.txtNamePhonetic.Text.Trim().Length==0)
			{
				strErr+="姓名拼音不能为空！\\n";	
			}
			if(this.txtSex.Text.Trim().Length==0)
			{
				strErr+="性别不能为空！\\n";	
			}
			if(this.txtDateOfBirth.Text.Trim().Length==0)
			{
				strErr+="出生日期不能为空！\\n";	
			}
			if(this.txtBirthPlace.Text.Trim().Length==0)
			{
				strErr+="行政区名称不能为空！\\n";	
			}
			if(this.txtCitizenship.Text.Trim().Length==0)
			{
				strErr+="国家简称不能为空！\\n";	
			}
			if(this.txtNation.Text.Trim().Length==0)
			{
				strErr+="民族不能为空！\\n";	
			}
			if(this.txtIDNO.Text.Trim().Length==0)
			{
				strErr+="身份证号不能为空！\\n";	
			}
			if(this.txtIdentity.Text.Trim().Length==0)
			{
				strErr+="患者工作身份不能为空！\\n";	
			}
			if(this.txtChargeType.Text.Trim().Length==0)
			{
				strErr+="病人收费类别不能为空！\\n";	
			}
			if(this.txtMailingAddress.Text.Trim().Length==0)
			{
				strErr+="永久通信地址不能为空！\\n";	
			}
			if(this.txtZipCode.Text.Trim().Length==0)
			{
				strErr+="邮政编码不能为空！\\n";	
			}
			if(this.txtPhoneNumberHome.Text.Trim().Length==0)
			{
				strErr+="家庭电话号码不能为空！\\n";	
			}
			if(this.txtPhoneNumbeBusiness.Text.Trim().Length==0)
			{
				strErr+="单位电话号码不能为空！\\n";	
			}
			if(this.txtNextOfKin.Text.Trim().Length==0)
			{
				strErr+="亲属姓名不能为空！\\n";	
			}
			if(this.txtRelationShip.Text.Trim().Length==0)
			{
				strErr+="亲属关系不能为空！\\n";	
			}
			if(this.txtNextOfKinAddr.Text.Trim().Length==0)
			{
				strErr+="联系人地址不能为空！\\n";	
			}
			if(this.txtNextOfKinZipCode.Text.Trim().Length==0)
			{
				strErr+="联系人邮政编码不能为空！\\n";	
			}
			if(this.txtNextOfKinPhome.Text.Trim().Length==0)
			{
				strErr+="联系人电话号码不能为空！\\n";	
			}
			if(this.txtDeptCode.Text.Trim().Length==0)
			{
				strErr+="当前科室代码@名称不能为空！\\n";	
			}
			if(this.txtBedNO.Text.Trim().Length==0)
			{
				strErr+="病人所住床号不能为空！\\n";	
			}
			if(this.txtAdmissionDateTime.Text.Trim().Length==0)
			{
				strErr+="入院日期及时间不能为空！\\n";	
			}
			if(this.txtDoctorInCharge.Text.Trim().Length==0)
			{
				strErr+="主治医生工号@姓名不能为空！\\n";	
			}
			if(this.txtScheduleId.Text.Trim().Length==0)
			{
				strErr+="手术id号不能为空！\\n";	
			}
			if(this.txtDiagBeforeOperation.Text.Trim().Length==0)
			{
				strErr+="主要诊断不能为空！\\n";	
			}
			if(this.txtScheduledDateTime.Text.Trim().Length==0)
			{
				strErr+="预约进行该次手术的日期及时间不能为空！\\n";	
			}
			if(this.txtKeepSpecimenSign.Text.Trim().Length==0)
			{
				strErr+="是否留标本不能为空！\\n";	
			}
			if(this.txtOperatingRoom.Text.Trim().Length==0)
			{
				strErr+="手术室代码@名称不能为空！\\n";	
			}
			if(this.txtSurgeon.Text.Trim().Length==0)
			{
				strErr+="手术医师工号@姓名不能为空！\\n";	
			}
			if(this.txtInPatPreillness.Text.Trim().Length==0)
			{
				strErr+="现病史不能为空！\\n";	
			}
			if(this.txtInPatPastillness.Text.Trim().Length==0)
			{
				strErr+="既往史不能为空！\\n";	
			}
			if(this.txtInPatFamillness.Text.Trim().Length==0)
			{
				strErr+="家族史不能为空！\\n";	
			}
			if(this.txtLabInfo.Text.Trim().Length==0)
			{
				strErr+="乙肝梅毒等阳性结果不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string PatientId=this.txtPatientId.Text;
			string InpNO=this.txtInpNO.Text;
			string VisitId=this.txtVisitId.Text;
			string Name=this.txtName.Text;
			string NamePhonetic=this.txtNamePhonetic.Text;
			string Sex=this.txtSex.Text;
			string DateOfBirth=this.txtDateOfBirth.Text;
			string BirthPlace=this.txtBirthPlace.Text;
			string Citizenship=this.txtCitizenship.Text;
			string Nation=this.txtNation.Text;
			string IDNO=this.txtIDNO.Text;
			string Identity=this.txtIdentity.Text;
			string ChargeType=this.txtChargeType.Text;
			string MailingAddress=this.txtMailingAddress.Text;
			string ZipCode=this.txtZipCode.Text;
			string PhoneNumberHome=this.txtPhoneNumberHome.Text;
			string PhoneNumbeBusiness=this.txtPhoneNumbeBusiness.Text;
			string NextOfKin=this.txtNextOfKin.Text;
			string RelationShip=this.txtRelationShip.Text;
			string NextOfKinAddr=this.txtNextOfKinAddr.Text;
			string NextOfKinZipCode=this.txtNextOfKinZipCode.Text;
			string NextOfKinPhome=this.txtNextOfKinPhome.Text;
			string DeptCode=this.txtDeptCode.Text;
			string BedNO=this.txtBedNO.Text;
			string AdmissionDateTime=this.txtAdmissionDateTime.Text;
			string DoctorInCharge=this.txtDoctorInCharge.Text;
			string ScheduleId=this.txtScheduleId.Text;
			string DiagBeforeOperation=this.txtDiagBeforeOperation.Text;
			string ScheduledDateTime=this.txtScheduledDateTime.Text;
			string KeepSpecimenSign=this.txtKeepSpecimenSign.Text;
			string OperatingRoom=this.txtOperatingRoom.Text;
			string Surgeon=this.txtSurgeon.Text;
			string InPatPreillness=this.txtInPatPreillness.Text;
			string InPatPastillness=this.txtInPatPastillness.Text;
			string InPatFamillness=this.txtInPatFamillness.Text;
			string LabInfo=this.txtLabInfo.Text;


			RuRo.Model.ZSSY.OPListForSpecimen model=new RuRo.Model.ZSSY.OPListForSpecimen();
			model.Id=Id;
			model.PatientId=PatientId;
			model.InpNO=InpNO;
			model.VisitId=VisitId;
			model.Name=Name;
			model.NamePhonetic=NamePhonetic;
			model.Sex=Sex;
			model.DateOfBirth=DateOfBirth;
			model.BirthPlace=BirthPlace;
			model.Citizenship=Citizenship;
			model.Nation=Nation;
			model.IDNO=IDNO;
			model.Identity=Identity;
			model.ChargeType=ChargeType;
			model.MailingAddress=MailingAddress;
			model.ZipCode=ZipCode;
			model.PhoneNumberHome=PhoneNumberHome;
			model.PhoneNumbeBusiness=PhoneNumbeBusiness;
			model.NextOfKin=NextOfKin;
			model.RelationShip=RelationShip;
			model.NextOfKinAddr=NextOfKinAddr;
			model.NextOfKinZipCode=NextOfKinZipCode;
			model.NextOfKinPhome=NextOfKinPhome;
			model.DeptCode=DeptCode;
			model.BedNO=BedNO;
			model.AdmissionDateTime=AdmissionDateTime;
			model.DoctorInCharge=DoctorInCharge;
			model.ScheduleId=ScheduleId;
			model.DiagBeforeOperation=DiagBeforeOperation;
			model.ScheduledDateTime=ScheduledDateTime;
			model.KeepSpecimenSign=KeepSpecimenSign;
			model.OperatingRoom=OperatingRoom;
			model.Surgeon=Surgeon;
			model.InPatPreillness=InPatPreillness;
			model.InPatPastillness=InPatPastillness;
			model.InPatFamillness=InPatFamillness;
			model.LabInfo=LabInfo;

			RuRo.BLL.ZSSY.OPListForSpecimen bll=new RuRo.BLL.ZSSY.OPListForSpecimen();
			bll.Update(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
