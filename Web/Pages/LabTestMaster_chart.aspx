<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--统计图页面-->
<!--chart页面:LabTestMaster_chart.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestMaster_chart.aspx.cs" Inherits="RuRo.LabTestMaster_chart" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>LabTestMaster</title>
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/default/easyui.css" />
	<link rel="stylesheet" type="text/css" href="/js/easyui/themes/icon.css" />
	<script type="text/javascript" src="/js/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="/js/easyui/jquery.easyui.min.js"></script>
	<script type="text/javascript" src="/js/easyui/locale/easyui-lang-zh_CN.js"></script>
	<script type="text/javascript" src="/js/gridPrint.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/kfmis.css"/>
    <script type="text/javascript"  src="/js/FusionCharts/FusionCharts.js"></script>
</head>
<body>
<!--按钮固定在底部--> 
<div class="easyui-layout" data-options="fit:true">
<div data-options="region:'center',split:true" style="width:100px;padding:10px">
<div id="printBody"> 
<div class="ftitle">LabTestMaster--统计图
    <select id="chartType" onchange="showChart(this.value)">
        <option value="Column3D">柱状图3D</option>
        <option value="Column2D" selected="selected">柱状图2D</option>
        <option value="Pie3D">饼状图3D</option>
        <option value="Pie2D">饼状图2D</option>
        <option value="Line">曲线图</option>
    </select> 
</div>
<div id="chart"></div>
</div>
</div>
</div>
<script type="text/javascript">
    function showChart(v) {
        $.post('users_handler.ashx?mode=chr',{swf:v}, function (result) {
            if (result.success) {
                $("#chart").html(result.msg);
            } else {
                $.messager.alert('错误', result.msg, 'warning');
            }
        }, 'json');
    }
    showChart("Column2D");
</script>
</body>
</html>

