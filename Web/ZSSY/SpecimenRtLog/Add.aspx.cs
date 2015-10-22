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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string username=this.txtusername.Text;
			string PatiendId=this.txtPatiendId.Text;
			string SampleId=this.txtSampleId.Text;
			string PostBackStatus=this.txtPostBackStatus.Text;
			DateTime PostBackDate=DateTime.Parse(this.txtPostBackDate.Text);

			RuRo.Model.ZSSY.SpecimenRtLog model=new RuRo.Model.ZSSY.SpecimenRtLog();
			model.username=username;
			model.PatiendId=PatiendId;
			model.SampleId=SampleId;
			model.PostBackStatus=PostBackStatus;
			model.PostBackDate=PostBackDate;

			RuRo.BLL.ZSSY.SpecimenRtLog bll=new RuRo.BLL.ZSSY.SpecimenRtLog();
			bll.Add(model);
			RuRo.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
