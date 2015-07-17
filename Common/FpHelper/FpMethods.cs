using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Threading;

namespace Common
{
    
    /// <summary>
    /// Fp_Api中的所有方法的枚举集合
    /// </summary>
    public enum FpMethod
    {
        /// <summary>
        /// 高级搜索
        /// </summary>
        advanced_search,

        /// <summary>
        /// 警告信息
        /// </summary>
        alerts,

        /// <summary>
        /// 编辑信息
        /// </summary>
        audit,

        /// <summary>
        /// 样本盒信息
        /// </summary>
        box_info,

        /// <summary>
        /// 样本盒类型信息
        /// </summary>
        box_types,

        /// <summary>
        /// 样本盒
        /// </summary>
        boxes,

        /// <summary>
        /// 删除的小瓶
        /// </summary>
        delete_vials,

        /// <summary>
        /// 冰箱中的样本
        /// </summary>
        freezer_samples,

        /// <summary>
        /// 冰箱
        /// </summary>
        freezers,

        /// <summary>
        /// 获取状态——用于提交数据
        /// </summary>
        gen_token,

        get_job_status,

        /// <summary>
        /// 完整路径
        /// </summary>
        get_perfect_box,

        hh_tag_data,

        /// <summary>
        /// 导入样本组
        /// </summary>
        import_sample_groups,

        /// <summary>
        /// 导入样本组
        /// </summary>
        import_sample_groups_bulk,

        /// <summary>
        /// 导入样本
        /// </summary>
        import_samples,

        /// <summary>
        /// 导入样本
        /// </summary>
        import_samples_bulk,

        /// <summary>
        /// 导入样本源
        /// </summary>
        import_sources,

        /// <summary>
        /// 导入样本源
        /// </summary>
        import_sources_bulk,

        /// <summary>
        /// 导入测试数据
        /// </summary>
        import_tests,

        /// <summary>
        /// 最后打开的盒子
        /// </summary>
        last_open_box,

        /// <summary>
        /// 位置信息
        /// </summary>
        location_info,

        /// <summary>
        /// 
        /// </summary>
        prescan_box,

        /// <summary>
        /// 
        /// </summary>
        put_samples_in,

        /// <summary>
        /// 权限
        /// </summary>
        roles,

        /// <summary>
        /// 
        /// </summary>
        sample_archive,

        /// <summary>
        /// 样本组
        /// </summary>
        sample_groups,

        /// <summary>
        /// 样本信息
        /// </summary>
        sample_info,

        /// <summary>
        /// 样本源信息？未定义的方法
        /// </summary>
        //sample_source_info,

        /// <summary>
        /// 样本源类型
        /// </summary>
        sample_source_types,

        /// <summary>
        /// 样本源的自定义字段
        /// </summary>
        sample_source_userfields,

        /// <summary>
        /// 样本源
        /// </summary>
        sample_sources,
        /// <summary>
        /// 样本源信息
        /// </summary>
        sample_source_info,


        /// <summary>
        /// 样本类型
        /// </summary>
        sample_types,

        /// <summary>
        /// 样本的字段信息
        /// </summary>
        sample_userfields,

        /// <summary>
        /// 样本组信息
        /// </summary>
        samplegroup_info,

        /// <summary>
        /// 样本组的样品
        /// </summary>
        samplegroup_samples,

        /// <summary>
        /// 未定义的方法samples
        /// </summary>
        //samples,

        /// <summary>
        /// 查询样本信息withDate
        /// </summary>
        samples_by_date,

        /// <summary>
        /// 
        /// </summary>
        samples_out,

        /// <summary>
        /// 出库样本
        /// </summary>
        samples_trashbin,

        /// <summary>
        /// 样本源下的样本
        /// </summary>
        samplesource_samples,

        /// <summary>
        /// 样本类型下的样本
        /// </summary>
        sampletype_samples,

        /// <summary>
        /// 通过barcode找位置
        /// </summary>
        search_locations_barcode,

        /// <summary>
        /// 查找样本
        /// </summary>
        search_samples,

        /// <summary>
        /// 传感器
        /// </summary>
        sensors,

        /// <summary>
        /// 存储结构细分
        /// </summary>
        subdivisions,

        /// <summary>
        /// 出库样本？？？
        /// </summary>
        take_samples_out,

        /// <summary>
        /// 
        /// </summary>
        update_box_view,

        /// <summary>
        /// 更新样本组
        /// </summary>
        update_sample_groups,

        /// <summary>
        /// 更新样本组
        /// </summary>
        update_sample_groups_bulk,

        /// <summary>
        /// 更新样本
        /// </summary>
        update_samples,

        /// <summary>
        /// 更新样本
        /// </summary>
        update_samples_bulk,

        /// <summary>
        /// 更新样本源
        /// </summary>
        update_sources,

        /// <summary>
        /// 更新样本源
        /// </summary>
        update_sources_bulk,

        /// <summary>
        /// 用户样本
        /// </summary>
        user_samples,

        /// <summary>
        /// 自定义字段
        /// </summary>
        userfields,

        /// <summary>
        /// 用户
        /// </summary>
        users,

        /// <summary>
        /// 
        /// </summary>
        vials_box,

        /// <summary>
        /// 
        /// </summary>
        vials_import,


        /// <summary>
        /// 
        /// </summary>
        vials_sample
    }

    //public  class GetDateFromFp
    //{
    //    Config config = new Config();//配置对象
    //    WebClient webclient = new WebClient();//创建浏览器对象
    //    private string  Method(Common method,string uriExtend,string postDate)//和Fp数据交换的方法
    //    {
    //        string result = "";
    //        result = webclient.Post(config.URI, string.Format("username={0}&password={1}&method={2}&{3}",config.UserName,config.PassWord,method,uriExtend) + postDate);
    //        return result;
    //    }

    //    //单独写方法获取数据和提交数据
    //    //01.user
    //    //02.userfields
    //    private string Getuserfields()
    //    {
    //        return FpUnicodeHelper.ConvertUnicodeStringToChinese(Method(Common.userfields, "", ""));
    //    }
    //    public List<Model.UserFields> UserFields()
    //    {
    //        return FpJsonHelper.JObjectToList<Model.UserFields>("UserFields", Getuserfields());
    //    }

    //    //03.samplesourcetype
    //    private string GetSampleSourceType()
    //    {
    //        return FpUnicodeHelper.ConvertUnicodeStringToChinese(Method(Common.sample_source_types,"",""));
    //    }
    //    //04.roles
    //    //05.import_source
    //    //06.updte_source

    //    //生成界面的方法：获取类型、字段
    //    //根据字段类型生成不同的文本框类型并绑定数据



    //}

}
