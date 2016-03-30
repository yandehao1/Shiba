<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RuRo.Web.Pages.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>市八查询数据</title>
    <link rel="stylesheet" type="text/css" href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../include/css/kfmis.css" />
    <script type="text/javascript" src="../include/js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../include/js/default.js"></script>
    <script type="text/javascript" src="../include/js/page.js"></script>
    <style type="text/css">
        #SearchForm {
            margin: 5px;
        }

            #SearchForm div {
                margin: 5px;
            }
    </style>
</head>
<body style="width: 940px">
    <div class="easyui-panel">  
        <form id="SearchForm" runat="server">
            <div style="float: left">
                查询方式：
                    <select id="selectType" class="easyui-combobox" name="dept" style="width: 130px;" data-options="required:true,multiple:false,panelHeight: 'auto',prompt:'请选择查询方式'">
                        <option value="zhuyuan">住院号</option>
                        <option value="kahao">卡号</option>
                        <%-- <option value="3">批量扫码</option>--%>
                    </select>
            </div>
            <div id="getcode" style="float: left">
                <input id="code" class="easyui-textbox" name="code" data-options="prompt:'请输入条码',required:true" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybycodeData()">条码查询信息</a>
            </div>
            <%--  <div id="getdate" style="display: none; float: left">
                开始日期：<input id="ksrq" class="easyui-datebox" name="ksrq" data-options="required:true" style="width: 130px" />
                结束日期：<input id="jsrq" class="easyui-datebox" name="jsrq" data-options="required:true" style="width: 130px" />
                <a href="javascript:void(0)" class="easyui-linkbutton" id="btnGet" name="btnGet" plain="false" onclick="querybydate()">日期查询信息</a>
            </div>--%>
            <!--Search end-->
        </form>
    </div>
    <div class="easyui-panel" style="float: left; margin-top: 10px;" data-options="href:'ShiBa/Info_list.aspx'"></div>
    <div id="dd"></div>
    <script type="text/javascript">
        //$('#dd').window({
        //    title: '详细数据页面',
        //    width: 800,
        //    height: 500,
        //    modal: true,
        //    href: 'ShiBa/Info_info.aspx',
        //    onLoad: function () {
               
        //    }
        //});
        ////给日期框设置值
        //function SetDate() {
        //    var begindate = new Date();
        //    $('#ksrq').textbox('setValue', myformatter(begindate))
        //    $('#jsrq').textbox('setValue', myformatter(begindate))
        //}
        //var getdatageid;
        ////样品数据绑定
        //$(function () {
        //    $('#ss').combobox({
        //        onChange: function (newValue) {
        //            if (newValue == 2) {
        //                //日期
        //                $("#getdate").show();
        //                $("#getcode").hide();
        //                SetDate();
        //            }
        //            else {
        //                $("#getdate").hide();
        //                $("#getcode").show();
        //            }
        //        }
        //    });
        //})

        function querybycodeData()
        {
            var code = $('#code').textbox('getValue');//获取数据源
            var Type = $('#selectType').textbox('getValue');//获取查询方式
            if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#code').textbox('clear'); return; }
            if (code == "") { $.messager.alert('提示', '条码不能为空', 'error'); return; }
            else
            {
                ajaxLoading();
                $.ajax({
                    type: 'GET',
                    url: '../Fp_Ajax/getData.ashx?mode=qrycode',
                    data: { "type": Type, "getcode": code },
                    success: function (data)
                    {
                        ajaxLoadEnd();
                        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); return; }
                        else
                        {

                            var dsData = JSON.parse(data);
                            if (dsData.ds.length>0) {
                                var loadData = dsData.ds;
                                PagePaging(loadData);
                            }
                            else {
                                $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error');
                            }
                            
                        }
                    }
                })
            }
        }

        //绑定数据 条码
        //function querybycode() {
        //    var code = $('#code').textbox('getValue');//获取数据源
        //    var selectType = $('#selectType').textbox('getValue');//获取查询方式
        //    if (/.*[\u4e00-\u9fa5]+.*$/.test(code)) { $.messager.alert('错误', '不能输入中文', 'error'); $('#code').textbox('clear'); return; }
        //    if (code == "") { $.messager.alert('提示', '条码不能为空', 'error'); }
        //    else {
        //        ajaxLoading();
        //        $.ajax({
        //            type: 'GET',
        //            url: '/ShiBa/Info_handler.ashx?mode=qrycode&code=' + code,
        //            onSubmit: function () { },
        //            success: function (data) {
        //                ajaxLoadEnd();
        //                $('#code').textbox('setValue', '');
        //                if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
        //                else {
        //                    //$('#dd').window({
        //                    //    title: '详细数据页面',
        //                    //    width: 800,
        //                    //    height: 500,
        //                    //    modal: true,
        //                    //    href: 'ShiBa/Info_info.aspx',
        //                    //    onLoad: function () {
        //                    //        var basedata = $.parseJSON(data);
        //                    //        if (!data) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
        //                    //        else {
        //                    //            var loaddata = $.parseJSON(data);
        //                    //            if (loaddata.success) {
        //                    //                PagePaging(loaddata.result);
        //                    //            } else {
        //                    //                ShowMsg(loaddata.result)
        //                    //            }
        //                    //            PagePaging(loaddata);
        //                    //        }
        //                    //    }
        //                    //});
        //                }
        //            }
        //        });
        //        ajaxLoadEnd();
        //    }
        //}
        function CheckDate(checkdate) {
            var result = checkdate.match(/((^((1[8-9]\d{2})|([2-9]\d{3}))(-)(10|12|0?[13578])(-)(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(11|0?[469])(-)(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))(-)(0?2)(-)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)(-)(0?2)(-)(29)$)|(^([3579][26]00)(-)(0?2)(-)(29)$)|(^([1][89][0][48])(-)(0?2)(-)(29)$)|(^([2-9][0-9][0][48])(-)(0?2)(-)(29)$)|(^([1][89][2468][048])(-)(0?2)(-)(29)$)|(^([2-9][0-9][2468][048])(-)(0?2)(-)(29)$)|(^([1][89][13579][26])(-)(0?2)(-)(29)$)|(^([2-9][0-9][13579][26])(-)(0?2)(-)(29)$))/);
            if (result == null) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</body>
</html>
