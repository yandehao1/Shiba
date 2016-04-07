//基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com
using System;
using System.Collections.Generic;

namespace RuRo.Model
{
   /// <summary>
   /// 实体类Info
   /// </summary>
   public class Info
   {
       private int __id = 0;
       private string __部门 = "";
       private string __姓名 = "";
       private string __性别 = "";
       private string __年龄 = "";
       private string __医生 = "";
       private string __流水号 = "";
       private string __卡号 = "";
       private string __住院号 = "";
       private string __病历号 = "";
       private string __诊断 = "";
       private string __日期 = "";

       private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


       public Info()
       {
           this.__Changed.Add("id", false);
           this.__Changed.Add("部门", false);
           this.__Changed.Add("姓名", false);
           this.__Changed.Add("性别", false);
           this.__Changed.Add("年龄", false);
           this.__Changed.Add("医生", false);
           this.__Changed.Add("流水号", false);
           this.__Changed.Add("卡号", false);
           this.__Changed.Add("住院号", false);
           this.__Changed.Add("病历号", false);
           this.__Changed.Add("诊断", false);
           this.__Changed.Add("日期", false);
       }

       /// <summary>
       /// 将类重置到初始化状态
       /// </summary>
       public void Reset()
       {
           this.__id = 0;
           this.__部门 = "";
           this.__姓名 = "";
           this.__性别 = "";
           this.__年龄 = "";
           this.__医生 = "";
           this.__流水号 = "";
           this.__卡号 = "";
           this.__住院号 = "";
           this.__病历号 = "";
           this.__诊断 = "";
           this.__日期 = "";

           this.__Changed["id"] = false;
           this.__Changed["部门"] = false;
           this.__Changed["姓名"] = false;
           this.__Changed["性别"] = false;
           this.__Changed["年龄"] = false;
           this.__Changed["医生"] = false;
           this.__Changed["流水号"] = false;
           this.__Changed["卡号"] = false;
           this.__Changed["住院号"] = false;
           this.__Changed["病历号"] = false;
           this.__Changed["诊断"] = false;
           this.__Changed["日期"] = false;
       }

       /// <summary>
       /// 获取类中成员的改变状态
       /// </summary>
       public bool Changed(string strKey)
       {
           return __Changed[strKey];
       }



       /// <summary>
       /// 设置或获取类中的[id]的数据
       /// </summary>
       public int id
       {
           set{ __id = value; __Changed["id"] = true;}
           get{return __id;}
       }

       /// <summary>
       /// 设置或获取类中的[部门]的数据
       /// </summary>
       public string 部门
       {
           set{ __部门 = value; __Changed["部门"] = true;}
           get{return __部门;}
       }

       /// <summary>
       /// 设置或获取类中的[姓名]的数据
       /// </summary>
       public string 姓名
       {
           set{ __姓名 = value; __Changed["姓名"] = true;}
           get{return __姓名;}
       }

       /// <summary>
       /// 设置或获取类中的[性别]的数据
       /// </summary>
       public string 性别
       {
           set{ __性别 = value; __Changed["性别"] = true;}
           get{return __性别;}
       }

       /// <summary>
       /// 设置或获取类中的[年龄]的数据
       /// </summary>
       public string 年龄
       {
           set{ __年龄 = value; __Changed["年龄"] = true;}
           get{return __年龄;}
       }

       /// <summary>
       /// 设置或获取类中的[医生]的数据
       /// </summary>
       public string 医生
       {
           set{ __医生 = value; __Changed["医生"] = true;}
           get{return __医生;}
       }

       /// <summary>
       /// 设置或获取类中的[流水号]的数据
       /// </summary>
       public string 流水号
       {
           set{ __流水号 = value; __Changed["流水号"] = true;}
           get{return __流水号;}
       }

       /// <summary>
       /// 设置或获取类中的[卡号]的数据
       /// </summary>
       public string 卡号
       {
           set{ __卡号 = value; __Changed["卡号"] = true;}
           get{return __卡号;}
       }

       /// <summary>
       /// 设置或获取类中的[住院号]的数据
       /// </summary>
       public string 住院号
       {
           set{ __住院号 = value; __Changed["住院号"] = true;}
           get{return __住院号;}
       }

       /// <summary>
       /// 设置或获取类中的[病历号]的数据
       /// </summary>
       public string 病历号
       {
           set{ __病历号 = value; __Changed["病历号"] = true;}
           get{return __病历号;}
       }

       /// <summary>
       /// 设置或获取类中的[诊断]的数据
       /// </summary>
       public string 诊断
       {
           set{ __诊断 = value; __Changed["诊断"] = true;}
           get{return __诊断;}
       }

       /// <summary>
       /// 设置或获取类中的[日期]的数据
       /// </summary>
       public string 日期
       {
           set{ __日期 = value; __Changed["日期"] = true;}
           get{return __日期;}
       }

   }
}
