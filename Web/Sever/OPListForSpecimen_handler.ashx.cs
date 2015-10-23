using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Text;
using BLL;
namespace RuRo
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OPListForSpecimen_handler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["mode"] != null)
            {
                string mode = context.Request["mode"].ToString();
                switch (mode)
                { 
                    case "inf":/*查询实体类*/
                        InfoData(context);
                        break;
                    case "ins":/*新增*/
                        SaveData(context);
                        break;
                    case "upd":/*修改*/
                        SaveData(context);
                        break;
                    case "del":/*删除*/
                        DeleteData(context);  
                        break;
                    case "qrycode":/*按照条码查询*/
                        QueryDataCode(context, false);
                        break;
                    case "qrydate":/*按照日期查询*/
                        QueryDataDate(context, false);
                        break;
                }
            }
        }

        /// <summary>
        /// 查询info数据实体类
        /// </summary>
        /// <param name="context"></param>
        private static void InfoData(HttpContext context)
        {
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="context"></param>
        private static void SaveData(HttpContext context)
        {
            result rlt = new result();
            try
            {
                BLL.ZSSY.OPListForSpecimen bll_OPListForSpecimen = new BLL.ZSSY.OPListForSpecimen();
                Model.ZSSY.OPListForSpecimen model_OPListForSpecimen = new Model.ZSSY.OPListForSpecimen();
                #region 实体类赋值

                if (context.Request["PatientId"] != null)
                    model_OPListForSpecimen.PatientId = context.Request["PatientId"];

                if (context.Request["InpNO"] != null)
                    model_OPListForSpecimen.InpNO = context.Request["InpNO"];

                if (context.Request["VisitId"] != null)
                    model_OPListForSpecimen.VisitId = context.Request["VisitId"];

                if (context.Request["Name"] != null)
                    model_OPListForSpecimen.Name = context.Request["Name"];

                if (context.Request["NamePhonetic"] != null)
                    model_OPListForSpecimen.NamePhonetic = context.Request["NamePhonetic"];

                if (context.Request["Sex"] != null)
                    model_OPListForSpecimen.Sex = context.Request["Sex"];

                if (context.Request["DateOfBirth"] != null)
                    model_OPListForSpecimen.DateOfBirth = context.Request["DateOfBirth"];

                if (context.Request["BirthPlace"] != null)
                    model_OPListForSpecimen.BirthPlace = context.Request["BirthPlace"];

                if (context.Request["Citizenship"] != null)
                    model_OPListForSpecimen.Citizenship = context.Request["Citizenship"];

                if (context.Request["Nation"] != null)
                    model_OPListForSpecimen.Nation = context.Request["Nation"];

                if (context.Request["IDNO"] != null)
                    model_OPListForSpecimen.IDNO = context.Request["IDNO"];

                if (context.Request["Identity"] != null)
                    model_OPListForSpecimen.Identity = context.Request["Identity"];

                if (context.Request["ChargeType"] != null)
                    model_OPListForSpecimen.ChargeType = context.Request["ChargeType"];

                if (context.Request["MailingAddress"] != null)
                    model_OPListForSpecimen.MailingAddress = context.Request["MailingAddress"];

                if (context.Request["ZipCode"] != null)
                    model_OPListForSpecimen.ZipCode = context.Request["ZipCode"];

                if (context.Request["PhoneNumberHome"] != null)
                    model_OPListForSpecimen.PhoneNumberHome = context.Request["PhoneNumberHome"];

                if (context.Request["PhoneNumbeBusiness"] != null)
                    model_OPListForSpecimen.PhoneNumbeBusiness = context.Request["PhoneNumbeBusiness"];

                if (context.Request["NextOfKin"] != null)
                    model_OPListForSpecimen.NextOfKin = context.Request["NextOfKin"];

                if (context.Request["RelationShip"] != null)
                    model_OPListForSpecimen.RelationShip = context.Request["RelationShip"];

                if (context.Request["NextOfKinAddr"] != null)
                    model_OPListForSpecimen.NextOfKinAddr = context.Request["NextOfKinAddr"];

                if (context.Request["NextOfKinZipCode"] != null)
                    model_OPListForSpecimen.NextOfKinZipCode = context.Request["NextOfKinZipCode"];

                if (context.Request["NextOfKinPhome"] != null)
                    model_OPListForSpecimen.NextOfKinPhome = context.Request["NextOfKinPhome"];

                if (context.Request["DeptCode"] != null)
                    model_OPListForSpecimen.DeptCode = context.Request["DeptCode"];

                if (context.Request["BedNO"] != null)
                    model_OPListForSpecimen.BedNO = context.Request["BedNO"];

                if (context.Request["AdmissionDateTime"] != null)
                    model_OPListForSpecimen.AdmissionDateTime = context.Request["AdmissionDateTime"];

                if (context.Request["DoctorInCharge"] != null)
                    model_OPListForSpecimen.DoctorInCharge = context.Request["DoctorInCharge"];

                if (context.Request["ScheduleId"] != null)
                    model_OPListForSpecimen.ScheduleId = context.Request["ScheduleId"];

                if (context.Request["DiagBeforeOperation"] != null)
                    model_OPListForSpecimen.DiagBeforeOperation = context.Request["DiagBeforeOperation"];

                if (context.Request["ScheduledDateTime"] != null)
                    model_OPListForSpecimen.ScheduledDateTime = context.Request["ScheduledDateTime"];

                if (context.Request["KeepSpecimenSign"] != null)
                    model_OPListForSpecimen.KeepSpecimenSign = context.Request["KeepSpecimenSign"];

                if (context.Request["OperatingRoom"] != null)
                    model_OPListForSpecimen.OperatingRoom = context.Request["OperatingRoom"];

                if (context.Request["Surgeon"] != null)
                    model_OPListForSpecimen.Surgeon = context.Request["Surgeon"];

                if (context.Request["InPatPreillness"] != null)
                    model_OPListForSpecimen.InPatPreillness = context.Request["InPatPreillness"];

                if (context.Request["InPatPastillness"] != null)
                    model_OPListForSpecimen.InPatPastillness = context.Request["InPatPastillness"];

                if (context.Request["InPatFamillness"] != null)
                    model_OPListForSpecimen.InPatFamillness = context.Request["InPatFamillness"];

                if (context.Request["LabInfo"] != null)
                    model_OPListForSpecimen.LabInfo = context.Request["LabInfo"];
                #endregion
                //数据转换
                //数据匹配
                //数据提交
                //结果返回
                
            }
            catch (Exception exception)
            {
                rlt.success = false;
                rlt.msg = exception.Message;
            }
            //context.Response.Write(JSONHelper.Convert2Json(rlt)); 
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        private static void DeleteData(HttpContext context)
        {
        }

        /// <summary>
        /// 按照条码查询
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryDataCode(HttpContext context, bool export)
        {
            string barcode = context.Request["code"].ToString();
            GetDataFromHospital hospitalDataByBarcode = new GetDataFromHospital();
            ////正常调用医院webservice获取数据时取消注销下面一行
            //string jsonStrResult = hospitalDataByBarcode.GetDataByBarcode(barcode);
            //if (jsonStrResult == "")//直接无数据返回（可能是链接有问题）
            //{
            //    string result = "{\"success\":false,\"result\":\"获取数据失败，请检查条码号\"}";
            //    context.Response.Write(result);
            //    context.Response.End();
            //}
            //if (jsonStrResult.Contains("OPListForSpecimen"))
            //{
            //    string oPListForSpecimen = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("OPListForSpecimen", jsonStrResult);
            //    string result = "{\"success\":false,\"result\":" + oPListForSpecimen + "}";
            //    context.Response.Write(result);
            //    context.Response.End();
            //}
            //if (jsonStrResult.Contains("Name"))
            //{
            //    string result = "{\"success\":true,\"result\":" + jsonStrResult + "}";
            //    context.Response.Write(result);
            //    context.Response.End();
            //}
            //else
            //{
            //    string result = "";
            //    context.Response.Write(result);
            //    context.Response.End();
            //}
            #region 下面是测试数据
            //下面是测试数据
            context.Response.Write(hospitalDataByBarcode.GetOPListForSpecimenByLocalBracodeFileToJsonStr());
            //if (barcode == "多行")
            //{
            //    context.Response.Write(hospitalDataByBarcode.GetOPListForSpecimenByLocalDateFileToJsonStr());
            //}
            #region MyRegion
            //if (barcode == "9")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000129239\",\"patientId\":\"0000129239\",\"patientName\":\"何成法\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"精神(心理)科二区\",\"sampleSourceDescription\":\"精神(心理)科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "8")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001890963\",\"patientId\":\"0001890963\",\"patientName\":\"邱奕鑫\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"脊柱外科\",\"sampleSourceDescription\":\"脊柱外科病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "7")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001916085\",\"patientId\":\"0001916085\",\"patientName\":\"李聪\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"耳鼻咽喉科\",\"sampleSourceDescription\":\"耳鼻咽喉科病区\",\"importStatus\":\"待导入\",\"hidden\":\"BKuGcH2lFRjXTTv9Jc9Hi59lwc2gIcAhNZ5l++lmKcal4Z1TEN3YYoirk9go/lolH1ic3RMoctRf/5JiNSabEjhWYrHYP6iYH4tb4oYvWZ5iNJzvFleuuqRupUjgfierYqy0nPh5Q/4i7DgaaDIdiymDV+ymfZB88X7Qej9TM3OMLRe/WSbfWtItqJ+bMUjT78nnlt9+BiQeLNaYK13Vlkdzj5nbaZN6d0Gy/KKaO5ursZdUbyJ0An3eT71YMKOjR1E8XgOe2SD9SHWq1utXstjKwLtVzZ/39e8DJ36IRYXAJs1LJyb2oZ32gJ39a0vSdPZI/BknJKKWYCHBVlCTpQu3+jaoOFM4b9+2qas78OP78rKAsCk6KozVXdtzQ03Eq5JpDvn2H8s6uuU7DXKA7+LcYMjvg9uO6s1nNpcJLGovi0c93viPG3AeIzuX12YuHtLhAGJv/zpCVHhE8RbpUHmQDATqmrCgOL8ZVo/4g19OBx/98rlUTU2m4eovwPjcIr21W6qbaxV9X6z4pae+b3oRoDZjhOUt1F+jPZooY+tNjjcClg3MGnp2lyo/tjyJmw6oOrZOsM8F5iXM2NiAtVMxP4+DQxJ5ERopO6/pxH4oBkZpfGV30wuy/SPAfp85dH2mi8BMt1FQRZaBx/+RWLkCLnbMjOazzTNjcdzQJzAlcML6m8VLb56LMSTHPqngQT3LyQ1Ub8ORwC0Q8h+5YPfdHBG6hLjwv3cFtpRE0rqM7YMzip9KGEMpi2sNJl3yTJqt/hqg9uW3P1nhn/nMoN9japiZfLJBXzIsVw27jrGZEiOAqsv1t1agoT0HgLeCrGWGqO+My8P2TCQmroNqm5+awQtG7DleDkE769BUFHEgCecMhDSJCL/3aiUjElhCk5KEdqOQefZ+7G2v0yAZc9gYC3/hxhwjAQhUhXeSSXeBaALm9UuIGwDWkS6lePGLIE5+STYujxkVKz2ze5Ug5axkaVv0g6XjIq8TB9Vm8dJTLHUWfoxAkkENwtIBEV/nO654EiLAjqkn0uN/i1hFEjZBnuQy9MQefgDmv8nVffBk6nsexwNMwJ97HYZm9GHSxHjTM0TLoGABrZI8RwFuIAs1DzEQoSFZJn4KMJD+m5smq9RAgqa/hI+tpDnwRHmDnjVeRLAFXcqDED6DmZFBPwnGq/y/yLH3VTuxchZ5GZddggb+mH0t+mVG78N8fbKeHsuq530eQvZeSlguB5cminj0CZqL/VEbSaVAdJ7DZYXLcUXAQhBpGtvBB/Co9nboN9v7GsbO7wg/J8YoQ4bGgMY0+4lLlKqv3d6b5310UzJq1dQg/xBC11eqpeHLgiY/sTOZ081pyI3pAitjrWF+Kltcv1Uu7+K3cx0ny4ON4LneV/PQOMOI8ImKVDvcHARlqUWLQUFtbXPH+r8ZH9p68trRDkoGTansDfo7FJtvvUiooY1fRpJtEYaUt9ZTzyGrS8hC0OZrFpbeCO8W0TkU4di7g5xs5luWYG2M73/fP/LUsncTlWTkz316s6Pq5NMGJkCl2kHel82sT445JEBQgCU5nhQ918qyPwBYu6OU8tVHkBP1qf1JoP8Y1NgZ3tq0mTucX0cB5alN7qp5+EVf/jKIsk/N8p7/ntk/PBO5vmQqW+fNLrn5SbbgzN9JoQswf/ktBASU6mdq1+41c8hJTT696VkXT1GAyeCBCPNm+DLEQp6BKQv1eMqkSvjKd5pGgrvOBbfuWN1zmc7TOdlBal4wGeuLgV+Lh24D85TTAWMx+6dZ3Hs2MrSIUjs2LVLkEv/A4ld045kDCtdQGoyP8+6fmCKCXB8gbxvgWdRWpIpt/+fVljXTZ2eBEen04XXF7cYgFG6RcTN7AxgNq4dHpAIPTfSUicHJF8ZymCGVA5Sl3639CCoju++uQKSVcM2X1bWp2ZJhqaQMUTxfbc8Z74sVZcCQ6wCZjWcJEuHAZd/sW1lnXb4VGg==\"}}");
            //}
            //if (barcode == "6")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000185174\",\"patientId\":\"0000185174\",\"patientName\":\"叶瑞峰\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"精神(心理)科二区\",\"sampleSourceDescription\":\"精神(心理)科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "2")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001691427\",\"patientId\":\"0001691427\",\"patientName\":\"柯日春\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"泌尿外科二区\",\"sampleSourceDescription\":\"泌尿外科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"BKuGcH2lFRjXTTv9Jc9HiyhfMEuzeZDGkirfH7NVhh3semWPAzjb2CMSFDK/D38Ck7e9kuD3C47n5fcCNVPEg6MwSeSQCJfS/MUiRN2MC0X4L1hCooLt81lQk3S0JgPLJRutBHuaHPzmXgVGjBON1kxP8Nfqz8fYdwiD0rGlQpDrVFO3Al4Kp+M1vayoD2p+8FtQQva/i5Qa5Qkh2rCj8DS4qcADmKnwu4yAeZdY/EgcvcPpLEk/X49AD3rp6KihXQ/CKKthMkoPle6q2UEQ9IeL/y6RFRbE7irrFd4dtg3c/DWNCu2k8eC1ft7jWOAoR+fl58r8t5XQudezLvBVn21n9+afksAfG0BAxQTkL6fsqqg+GMCQbGQ0WiZ7Knq7xqJU1lonCKatXUHUenGA8422KnMGJbK1EOPNus701wwu2j1zgN5Xz2LAB/PH9UPdWX9ut7UWi3flEOBt9cpptzHaB9W0e7fApNHhQCH3DCSMRdmS9IVmWnfkjtJerL3P1Nj0HeorA7oaAY3OcXBro5pCMVAiqj8lY5lhbxZGwjCtUlYTuNuVeMNe/cXI2Ta3tIevg4UWTA0p9Kab6qLH8CB5HBOnE415nOr4XIPD0tN/KRSvmEds7jzmK2fskVHUtOwMnSDGp3ri9ZHufUAgfH9R7xLDkUMdC9JRFBSIP7/lzNVleCDdvicB6iw5rFof0DdD1kpanJSQTbsHZUMdh9dnQHrX7AzCZJ2mC1IFI9bs/+OszMpld5ikxUatQfv+0M5CSeDUyNzQc3Lpl3ZVBBnOU7hoEwJwEJBfiMBib+ilLV/ILtn+/81sm0drb3PlIqMtC4hF8CqT5w2wO4+GWSm9nhtIlqOecRCOTe/hUYKBz6dC5s4LEluYTN0TZI8YQjIcbO7Z6Ovtwot01esqnB2XOavixbUbIwhHpWjQchvzD1cYe4mZwpFHk6wcUE3plAA5cZ64NN3VaRUfEjMaL6UjLZf0ZxMuVnm2sQgJ7pYXA+jsrESg1F9kMfK5bhS7fwC3S+ztc7IdHyzMXiFkoZOqCyn+yXY0ilv1EbdhEw54gsyeknb+zIVG+7hAgUmgJJ2F0Ps1MZslcsmPU6bCX+GkWU4+9Xg2MF14YGe9Bc0KP/XHaAsMkL23cmrgsHmPjyRmqDiYzIdT/B8Nb+l1JFjX36DsDWSPKKQO9k1rJ2PC1pLqo5F/To+Bu6BlB9GKgo7l8hGQcyBzt/YTCAHQchXVTUhHt+eLh77GMvq5U7U55B76s6BXOjE5fG+5BUywfmDl5iP5/0vNui6tlhmdBle2B6ngQXY+0itY7nKMOJbOIzBnJp0uHPOCzF66rWKuH2yqM3s/29WpNz/B6+d5lXy+Ror+TtOAhenyj58098Yuc89sdnyXGgjj+n5VZTKCRoLYdmN8mco9SuxiBQziIaX7D4V4af/lIKhWChKr9cV9eLVsB13RDhbqVhZs5G4FqUOU0OawpcW1RTDmH8xN/ru/uvwdbZVLtO7I/vlb14DBvZgmHZr4enzWkF+ng9iTWC7yC4kL48ydd0yl7eIoSpmnJ7BIwGbklwU+eKrtmg29CHefwahD2Ea6UKdEc7nLm28Nt/YE9jvqcvoFvV5+eO7KGzS9Wgz6M2uacjcXxxt4cdgse3wHXVbGI6405Sf+OTupuw/kOjVCUC04VDwBuor1DZfXpGt7y/v3BWaGtbBe2BE2L3Fympe/skWe1bT8oI6cQhjAIajj29w33G5QqWpogDlUMVZEg0tKR975u9xDc62y3kZ6s1Jtnj3U9memXX9o2ttJ8VZgK6uu1OxhdLXndOhLuRW79Xc/mYGF3fgPADF8WpAThOXck2Q7oafqfVe8MRh+CT5JMjMvGrmJzypHSGD0Cw9OsDFY/AmFr0pgzDvoI0acWQ==\"}}");
            //}
            //if (barcode == "3")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000223145\",\"patientId\":\"0000223145\",\"patientName\":\"余日土\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"肾脏内科\",\"sampleSourceDescription\":\"肾脏内科病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "4")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000586906\",\"patientId\":\"0000586906\",\"patientName\":\"邓茂龄\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"泌尿外科一区\",\"sampleSourceDescription\":\"泌尿外科一区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            #endregion
            //context.Response.End(); 
            #endregion
        }

        /// <summary>
        /// 按照日期查询
        /// </summary>
        /// <param name="context"></param>
        /// <param name="export">是否导出Excel文件</param>
        private static void QueryDataDate(HttpContext context, bool export)
        {
            //#region 获取Jquery回传Server分页页码和每页行数
            //int page,rows;
            //if (context.Request["page"] != null)
            //   page = int.Parse(context.Request["page"]);
            //else
            //   page = 1; 
            //if (context.Request["rows"]!= null)
            //    rows = int.Parse(context.Request["rows"]);
            //else
            //    rows = 10;
            //#endregion
            string barcode = context.Request["code"].ToString();
            GetDataFromHospital hospitalDataByBarcode = new GetDataFromHospital();
            //正常调用医院webservice获取数据时取消注销下面一行
            string jsonStrResult = hospitalDataByBarcode.GetDataByBarcode(barcode);
            if (jsonStrResult == "")//直接无数据返回（可能是链接有问题）
            {
                string result = "{\"success\":false,\"result\":\"获取数据失败，请检查条码号\"}";
                context.Response.Write(result);
                context.Response.End();
            }
            if (jsonStrResult.Contains("OPListForSpecimen"))
            {
                string oPListForSpecimen = FreezerProUtility.Fp_Common.FpJsonHelper.GetStrFromJsonStr("OPListForSpecimen", jsonStrResult);
                string result = "{\"success\":false,\"result\":" + oPListForSpecimen + "}";
                context.Response.Write(result);
                context.Response.End();
            }
            if (jsonStrResult.Contains("Name"))
            {
                string result = "{\"success\":true,\"result\":" + jsonStrResult + "}";
                context.Response.Write(result);
                context.Response.End();
            }
            else
            {
                string result = "";
                context.Response.Write(result);
                context.Response.End();
            }
            #region 下面是测试数据
            //下面是测试数据
            //context.Response.Write(hospitalDataByBarcode.GetOPListForSpecimenByLocalBracodeFileToJsonStr());
            //if (barcode == "多行")
            //{
            //    context.Response.Write(hospitalDataByBarcode.GetOPListForSpecimenByLocalDateFileToJsonStr());
            //}
            #region MyRegion

            //if (barcode == "9")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000129239\",\"patientId\":\"0000129239\",\"patientName\":\"何成法\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"精神(心理)科二区\",\"sampleSourceDescription\":\"精神(心理)科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "8")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001890963\",\"patientId\":\"0001890963\",\"patientName\":\"邱奕鑫\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"脊柱外科\",\"sampleSourceDescription\":\"脊柱外科病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "7")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001916085\",\"patientId\":\"0001916085\",\"patientName\":\"李聪\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"耳鼻咽喉科\",\"sampleSourceDescription\":\"耳鼻咽喉科病区\",\"importStatus\":\"待导入\",\"hidden\":\"BKuGcH2lFRjXTTv9Jc9Hi59lwc2gIcAhNZ5l++lmKcal4Z1TEN3YYoirk9go/lolH1ic3RMoctRf/5JiNSabEjhWYrHYP6iYH4tb4oYvWZ5iNJzvFleuuqRupUjgfierYqy0nPh5Q/4i7DgaaDIdiymDV+ymfZB88X7Qej9TM3OMLRe/WSbfWtItqJ+bMUjT78nnlt9+BiQeLNaYK13Vlkdzj5nbaZN6d0Gy/KKaO5ursZdUbyJ0An3eT71YMKOjR1E8XgOe2SD9SHWq1utXstjKwLtVzZ/39e8DJ36IRYXAJs1LJyb2oZ32gJ39a0vSdPZI/BknJKKWYCHBVlCTpQu3+jaoOFM4b9+2qas78OP78rKAsCk6KozVXdtzQ03Eq5JpDvn2H8s6uuU7DXKA7+LcYMjvg9uO6s1nNpcJLGovi0c93viPG3AeIzuX12YuHtLhAGJv/zpCVHhE8RbpUHmQDATqmrCgOL8ZVo/4g19OBx/98rlUTU2m4eovwPjcIr21W6qbaxV9X6z4pae+b3oRoDZjhOUt1F+jPZooY+tNjjcClg3MGnp2lyo/tjyJmw6oOrZOsM8F5iXM2NiAtVMxP4+DQxJ5ERopO6/pxH4oBkZpfGV30wuy/SPAfp85dH2mi8BMt1FQRZaBx/+RWLkCLnbMjOazzTNjcdzQJzAlcML6m8VLb56LMSTHPqngQT3LyQ1Ub8ORwC0Q8h+5YPfdHBG6hLjwv3cFtpRE0rqM7YMzip9KGEMpi2sNJl3yTJqt/hqg9uW3P1nhn/nMoN9japiZfLJBXzIsVw27jrGZEiOAqsv1t1agoT0HgLeCrGWGqO+My8P2TCQmroNqm5+awQtG7DleDkE769BUFHEgCecMhDSJCL/3aiUjElhCk5KEdqOQefZ+7G2v0yAZc9gYC3/hxhwjAQhUhXeSSXeBaALm9UuIGwDWkS6lePGLIE5+STYujxkVKz2ze5Ug5axkaVv0g6XjIq8TB9Vm8dJTLHUWfoxAkkENwtIBEV/nO654EiLAjqkn0uN/i1hFEjZBnuQy9MQefgDmv8nVffBk6nsexwNMwJ97HYZm9GHSxHjTM0TLoGABrZI8RwFuIAs1DzEQoSFZJn4KMJD+m5smq9RAgqa/hI+tpDnwRHmDnjVeRLAFXcqDED6DmZFBPwnGq/y/yLH3VTuxchZ5GZddggb+mH0t+mVG78N8fbKeHsuq530eQvZeSlguB5cminj0CZqL/VEbSaVAdJ7DZYXLcUXAQhBpGtvBB/Co9nboN9v7GsbO7wg/J8YoQ4bGgMY0+4lLlKqv3d6b5310UzJq1dQg/xBC11eqpeHLgiY/sTOZ081pyI3pAitjrWF+Kltcv1Uu7+K3cx0ny4ON4LneV/PQOMOI8ImKVDvcHARlqUWLQUFtbXPH+r8ZH9p68trRDkoGTansDfo7FJtvvUiooY1fRpJtEYaUt9ZTzyGrS8hC0OZrFpbeCO8W0TkU4di7g5xs5luWYG2M73/fP/LUsncTlWTkz316s6Pq5NMGJkCl2kHel82sT445JEBQgCU5nhQ918qyPwBYu6OU8tVHkBP1qf1JoP8Y1NgZ3tq0mTucX0cB5alN7qp5+EVf/jKIsk/N8p7/ntk/PBO5vmQqW+fNLrn5SbbgzN9JoQswf/ktBASU6mdq1+41c8hJTT696VkXT1GAyeCBCPNm+DLEQp6BKQv1eMqkSvjKd5pGgrvOBbfuWN1zmc7TOdlBal4wGeuLgV+Lh24D85TTAWMx+6dZ3Hs2MrSIUjs2LVLkEv/A4ld045kDCtdQGoyP8+6fmCKCXB8gbxvgWdRWpIpt/+fVljXTZ2eBEen04XXF7cYgFG6RcTN7AxgNq4dHpAIPTfSUicHJF8ZymCGVA5Sl3639CCoju++uQKSVcM2X1bWp2ZJhqaQMUTxfbc8Z74sVZcCQ6wCZjWcJEuHAZd/sW1lnXb4VGg==\"}}");
            //}
            //if (barcode == "6")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000185174\",\"patientId\":\"0000185174\",\"patientName\":\"叶瑞峰\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"精神(心理)科二区\",\"sampleSourceDescription\":\"精神(心理)科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "2")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0001691427\",\"patientId\":\"0001691427\",\"patientName\":\"柯日春\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"泌尿外科二区\",\"sampleSourceDescription\":\"泌尿外科二区病区\",\"importStatus\":\"待导入\",\"hidden\":\"BKuGcH2lFRjXTTv9Jc9HiyhfMEuzeZDGkirfH7NVhh3semWPAzjb2CMSFDK/D38Ck7e9kuD3C47n5fcCNVPEg6MwSeSQCJfS/MUiRN2MC0X4L1hCooLt81lQk3S0JgPLJRutBHuaHPzmXgVGjBON1kxP8Nfqz8fYdwiD0rGlQpDrVFO3Al4Kp+M1vayoD2p+8FtQQva/i5Qa5Qkh2rCj8DS4qcADmKnwu4yAeZdY/EgcvcPpLEk/X49AD3rp6KihXQ/CKKthMkoPle6q2UEQ9IeL/y6RFRbE7irrFd4dtg3c/DWNCu2k8eC1ft7jWOAoR+fl58r8t5XQudezLvBVn21n9+afksAfG0BAxQTkL6fsqqg+GMCQbGQ0WiZ7Knq7xqJU1lonCKatXUHUenGA8422KnMGJbK1EOPNus701wwu2j1zgN5Xz2LAB/PH9UPdWX9ut7UWi3flEOBt9cpptzHaB9W0e7fApNHhQCH3DCSMRdmS9IVmWnfkjtJerL3P1Nj0HeorA7oaAY3OcXBro5pCMVAiqj8lY5lhbxZGwjCtUlYTuNuVeMNe/cXI2Ta3tIevg4UWTA0p9Kab6qLH8CB5HBOnE415nOr4XIPD0tN/KRSvmEds7jzmK2fskVHUtOwMnSDGp3ri9ZHufUAgfH9R7xLDkUMdC9JRFBSIP7/lzNVleCDdvicB6iw5rFof0DdD1kpanJSQTbsHZUMdh9dnQHrX7AzCZJ2mC1IFI9bs/+OszMpld5ikxUatQfv+0M5CSeDUyNzQc3Lpl3ZVBBnOU7hoEwJwEJBfiMBib+ilLV/ILtn+/81sm0drb3PlIqMtC4hF8CqT5w2wO4+GWSm9nhtIlqOecRCOTe/hUYKBz6dC5s4LEluYTN0TZI8YQjIcbO7Z6Ovtwot01esqnB2XOavixbUbIwhHpWjQchvzD1cYe4mZwpFHk6wcUE3plAA5cZ64NN3VaRUfEjMaL6UjLZf0ZxMuVnm2sQgJ7pYXA+jsrESg1F9kMfK5bhS7fwC3S+ztc7IdHyzMXiFkoZOqCyn+yXY0ilv1EbdhEw54gsyeknb+zIVG+7hAgUmgJJ2F0Ps1MZslcsmPU6bCX+GkWU4+9Xg2MF14YGe9Bc0KP/XHaAsMkL23cmrgsHmPjyRmqDiYzIdT/B8Nb+l1JFjX36DsDWSPKKQO9k1rJ2PC1pLqo5F/To+Bu6BlB9GKgo7l8hGQcyBzt/YTCAHQchXVTUhHt+eLh77GMvq5U7U55B76s6BXOjE5fG+5BUywfmDl5iP5/0vNui6tlhmdBle2B6ngQXY+0itY7nKMOJbOIzBnJp0uHPOCzF66rWKuH2yqM3s/29WpNz/B6+d5lXy+Ror+TtOAhenyj58098Yuc89sdnyXGgjj+n5VZTKCRoLYdmN8mco9SuxiBQziIaX7D4V4af/lIKhWChKr9cV9eLVsB13RDhbqVhZs5G4FqUOU0OawpcW1RTDmH8xN/ru/uvwdbZVLtO7I/vlb14DBvZgmHZr4enzWkF+ng9iTWC7yC4kL48ydd0yl7eIoSpmnJ7BIwGbklwU+eKrtmg29CHefwahD2Ea6UKdEc7nLm28Nt/YE9jvqcvoFvV5+eO7KGzS9Wgz6M2uacjcXxxt4cdgse3wHXVbGI6405Sf+OTupuw/kOjVCUC04VDwBuor1DZfXpGt7y/v3BWaGtbBe2BE2L3Fympe/skWe1bT8oI6cQhjAIajj29w33G5QqWpogDlUMVZEg0tKR975u9xDc62y3kZ6s1Jtnj3U9memXX9o2ttJ8VZgK6uu1OxhdLXndOhLuRW79Xc/mYGF3fgPADF8WpAThOXck2Q7oafqfVe8MRh+CT5JMjMvGrmJzypHSGD0Cw9OsDFY/AmFr0pgzDvoI0acWQ==\"}}");
            //}
            //if (barcode == "3")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000223145\",\"patientId\":\"0000223145\",\"patientName\":\"余日土\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"肾脏内科\",\"sampleSourceDescription\":\"肾脏内科病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            //if (barcode == "4")
            //{
            //    context.Response.Write("{\"success\":\"true\",\"result\":{\"sampleSourceName\":\"0000586906\",\"patientId\":\"0000586906\",\"patientName\":\"邓茂龄\",\"patientSex\":\"男\",\"sampleSourceTypeName\":\"泌尿外科一区\",\"sampleSourceDescription\":\"泌尿外科一区病区\",\"importStatus\":\"待导入\",\"hidden\":\"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\"}}");
            //}
            #endregion
            //context.Response.End(); 
            #endregion
        }


        /// <summary>
        /// FusionChart统计图格式化字符串
        /// </summary>
        /// <param name="context"></param>
        private static void ChartData(HttpContext context)
        {
            //统计图dome代码==========================Begin
            //统计图请根据实际业务情况，改造SQL统计实现真实数据显示
            //string swf = "Column3D";
            //if (context.Request["swf"] != null)
            //    swf = context.Request["swf"];
            //StringBuilder xmlData = new StringBuilder();
            //xmlData.Append("<chart caption='IT行业年均收入' subCaption='2014年' xAxisName='城市' yAxisName='收入' showValues='0' formatNumberScale='0' showBorder='1'  logoURL='/images/login_banquan.gif'  logoPosition='BR' logoAlpha='20'>");
            //xmlData.Append("<set label='成都' value='5120' />");
            //xmlData.Append("<set label='上海' value='9800' />");
            //xmlData.Append("<set label='北京' value='9800' />");
            //xmlData.Append("<set label='天津' value='6300' />");
            //xmlData.Append("<set label='广州' value='10080' />");
            //xmlData.Append("</chart>");
            //string ChartHtml = FusionCharts.RenderChartHTML("../js/FusionCharts/" + swf + ".swf","", xmlData.ToString(), "myChart", "600", "350", false);
            //result rlt = new result();
            //rlt.success = true;
            //rlt.msg = ChartHtml;
            //context.Response.Write(JSONHelper.Convert2Json(rlt));
            //统计图dome代码==========================End



//            string swf = "Column3D";
//            if (context.Request["swf"] != null)
//                swf = context.Request["swf"];
//            string strSql = @"select 字段名,count(*) records from oplistforspecimen group by 字段名";
//            DataTable dt = new DataTable();
//            DbHelper.GetTable(strSql, ref dt);

//            StringBuilder xmlData = new StringBuilder();
//            xmlData.AppendFormat(@"<chart caption='{0}' 
//                                    subCaption='{1}' 
//                                    xAxisName='{2}' 
//                                    yAxisName='{3}' 
//                                    showValues='0' 
//                                    formatNumberScale='0' 
//                                    showBorder='1'  
//                                    logoURL='/images/login_banquan.gif'  
//                                    logoPosition='BR' 
//                                    logoAlpha='20'>",
//                                    "统计图","统计图副标题","X坐标标题","数量");
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                xmlData.AppendFormat("<set label='{0}' value='{1}' />",dt.Rows[i]["字段名"],dt.Rows[i]["records"]);  
//            }
//            xmlData.Append("</chart>");
//            string ChartHtml = FusionCharts.RenderChartHTML("../js/FusionCharts/" + swf + ".swf","", xmlData.ToString(), "myChart", "600", "350", false);
//            result rlt = new result();
//            rlt.success = true;
//            rlt.msg = ChartHtml;
//            context.Response.Write(JSONHelper.Convert2Json(rlt));

        }

        #region JSON实体返回类定义
        /// <summary>
        /// 实体Ajax返回类
        /// </summary>
        public class result
        {
            bool _success = false;
            string _msg = "";
            public bool success 
            {
                set { _success = value; }
                get { return _success; }
            }
            public string msg
            {
                set { _msg = value; }
                get { return _msg; } 
            }
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}

