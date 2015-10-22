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
namespace RuRo.Web.ZSSY.SpecimenRtLog
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
		RuRo.BLL.ZSSY.SpecimenRtLog bll=new RuRo.BLL.ZSSY.SpecimenRtLog();
		RuRo.Model.ZSSY.SpecimenRtLog model=bll.GetModel(id);
		this.lblid.Text=model.id.ToString();
		this.txtusername.Text=model.username;
		this.txtPatiendId.Text=model.PatiendId;
		this.txtSampleId.Text=model.SampleId;
		this.txtPostBackStatus.Text=model.PostBackStatus;
		this.txtPostBackDate.Text=model.PostBackDate.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtusername.Text.Trim().Length==0)
			{
				strErr+="回发此数据的用户不能为空！\\n";	
			}
			if(this.txtPatiendId.Text.Trim().Length==0)
			{
				strErr+="回发的患者唯一标识不能为空！\\n";	
			}
			if(this.txtSampleId.Text.Trim().Length==0)
			{
				strErr+="回发的样本id不能为空！\\n";	
			}
			if(this.txtPostBackStatus.Text.Trim().Length==0)
			{
				strErr+="回发后的状态不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPostBackDate.Text))
			{
				strErr+="回发时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int id=int.Parse(this.lblid.Text);
			string username=this.txtusername.Text;
			string PatiendId=this.txtPatiendId.Text;
			string SampleId=this.txtSampleId.Text;
			string PostBackStatus=this.txtPostBackStatus.Text;
			DateTime PostBackDate=DateTime.Parse(this.txtPostBackDate.Text);


			RuRo.Model.ZSSY.SpecimenRtLog model=new RuRo.Model.ZSSY.SpecimenRtLog();
			model.id=id;
			model.username=username;
			model.PatiendId=PatiendId;
			model.SampleId=SampleId;
			model.PostBackStatus=PostBackStatus;
			model.PostBackDate=PostBackDate;

			RuRo.BLL.ZSSY.SpecimenRtLog bll=new RuRo.BLL.ZSSY.SpecimenRtLog();
			bll.Update(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
