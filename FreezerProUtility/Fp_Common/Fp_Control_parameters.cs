using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FpUtility.Fp_Common
{
    /// <summary>
    /// 调用Fp 方法时参数方法
    /// </summary>
    public class Fp_Control_parameters
    {
        private string required_parameters="";
        public string Required_parameters
        {
            set{required_parameters =value;}
            get{return CreatRequired_parameters(required_parameters);}
        }
        private string optional_query_parameters = "";
        public string Optional_query_parameters
        {
            set { optional_query_parameters = value; }
            get { return CreatRequired_parameters(optional_query_parameters); }
        }

        #region 必须参数 Required parameters + private string CreatRequired_parameters(string required_parameters = "")
        /// <summary>
        /// 必须参数 Required parameters
        /// </summary>
        /// <param name="required_parameters">传入的参数</param>
        /// <returns>参数返回值</returns>
        private string CreatRequired_parameters(string required_parameters = "")
        {
            return string.IsNullOrEmpty(required_parameters) ? "" : "&Required parameters=" + required_parameters;
        } 
        #endregion

        #region  调用Fp方法可选参数  private string CreatOptional_query_parameters(string required_parameters = "")
        /// <summary>
        ///  可选参数
        /// </summary>
        /// <param name="required_parameters"></param>
        /// <returns></returns>
        private string CreatOptional_query_parameters(string required_parameters = "")
        {
            return string.IsNullOrEmpty(required_parameters) ? "" : "&Optional query parameters=" + required_parameters;
        } 
        #endregion
        public string start { get; set; }
        public string limit { get; set; }
        public string sort { get; set; }
        public Dir dir { get; set; }
        public string Optional_control_parameters
        {
            get { return CreatOptional_control_parameters(this.dir, this.start, this.limit, this.sort); }
        }
        #region 调用Fp方法返回值控制参数 private  string CreatOptional_control_parameters(string start = "", string limit = "", string sort = "", Dir dir = Dir.ASC)
        /// <summary>
        ///  可选控制参数 用于控制返回数据的
        /// </summary>
        /// <param name="start">开始</param>
        /// <param name="limit">条数限制</param>
        /// <param name="sort">排序字段</param>
        /// <param name="dir">排序方法</param>
        /// <returns></returns>
        private   string CreatOptional_control_parameters(Dir dir,string start = "", string limit = "", string sort = "")
        {
            string Optional_control_parameters = "";
            if (!string.IsNullOrEmpty(start))
            {
                Optional_control_parameters += "&start=" + start;
            }
            if (!string.IsNullOrEmpty(limit))
            {
                Optional_control_parameters += "&limit=" + limit;
            }
            if (!string.IsNullOrEmpty(sort))
            {
                Optional_control_parameters += "&sort=" + sort;
            }
            if (!string.IsNullOrEmpty(dir.ToString()))
            {
                Optional_control_parameters += "&dir=" + dir;
            }
            return Optional_control_parameters;
        } 
        #endregion
    }
}
