using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RuRo.Web.Sever
{
    /// <summary>
    /// LabTest 的摘要说明
    /// </summary>
    public class LabTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string mod = context.Request.Params["mod"];
            switch (mod)
            {
                case "getPLM":
                    GetLabTestMasterInfo(context);
                    break;
                case "getLTR":
                    GetLabTestResult(context);
                    break;
                default:
                    break;
            }
        }

        public void GetLabTestMasterInfo(HttpContext context)
        {
            string patientId = context.Request.Params["PatientId"];
            string visitId = context.Request.Params["VisitId"];
            BLL.LabTestMaster lab = new BLL.LabTestMaster();
            string res = lab.GetData(patientId, visitId);
            context.Response.Write(res);

        }
        private void GetLabTestResult(HttpContext context)
        {
            string data = string.Empty;
            string workingId = context.Request.Params["WorkingId"];
            string testNo = context.Request.Params["TestNo"];
            BLL.LabTestResult ltr = new BLL.LabTestResult();
            context.Response.Write(ltr.GetData(workingId, testNo));
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}