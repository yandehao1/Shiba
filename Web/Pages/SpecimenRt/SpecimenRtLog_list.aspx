<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecimenRtLog_list.aspx.cs" Inherits="RuRo.SpecimenRtLog_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>回发数据记录存档</title>
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="../../include/jquery-easyui-1.4.3/themes/icon.css" />
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../../include/jquery-easyui-1.4.3/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="../../include/css/kfmis.css" />
    <script type="text/javascript" src="../../include/js/page.js"></script>
    <script type="text/javascript" src="../../include/js/jquery.cookie.js"></script>
</head>
<body>
<!--datagrid栏--> 
<table id="dgSpecimenRtLog" title="回发数据记录存档" class="easyui-datagrid" style="width:auto;height:460px"
             url="SpecimenRtLog_handler.ashx?mode=qry" fit='false'
             pagination="true" idField="id" rownumbers="true" 
             fitColumns="true"  singleSelect="true" toolbar="#toolbar"
             striped="false" pageList="[10,20,50,80]"
             SelectOnCheck="true" CheckOnSelect="true" remoteSort="false">
    <thead>    
			<tr>
			    <%--<th field="ck" checkbox="true"></th>--%>
                <th field="id" width="100" sortable="true" hidden="hidden">自增列</th>
                <th field="username" width="100" sortable="true">回发用户</th>
                <th field="PatiendId" width="100" sortable="true">患者唯一标识</th>
                <th field="SampleId" width="50" sortable="true">样本id</th>
                <th field="PostBackStatus" width="100" sortable="true">状态</th>
                <th field="PostBackDate" width="100" sortable="true">回发时间</th>
            </tr>
    </thead>
</table>

<!--toolbar栏，用于datagrid的toolbar自定义内容--> 
<div id="toolbar">
<table style="width:100%;">
<tr>
    <!--button按钮工具栏--> 
    <td  style="text-align:right;">
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconCls="icon-search" plain="false" onclick="loadLogData();">查看</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="resHis();">回发</a>
    </td>
</tr>
</table>  
</div>

<!--diaglog窗口，用于编辑数据--> 
<div id="dlg"  class="easyui-dialog" closed="true"></div>
<script type="text/javascript">
	var url;
    /*回发数据*/
	function resHis() {
	    $.messager.alert('提示', '开始回发数据', 'error');
	    ajaxLoading();
	    $.ajax({
	        type: 'GET',
	        url: '../Sever/SpecimenRtLog_handler.ashx?action=respondhis',
	        onSubmit: function () { },
	        success: function (data) {
	            ajaxLoadEnd();
	            $.messager.alert('提示', '回发完成，点击查看回发信息', 'error');
	        }
	    });
	}
    /*查询数据*/
	function loadLogData() {
	    $.ajax({
	        type: 'GET',
	        url: '../Sever/SpecimenRtLog_handler.ashx?mode=qry',
	        onSubmit: function () { },
	        success: function (data) {
	            var getdata = JSON.parse(data);
	            var loaddata = getdata.ds;
	            if (!loaddata) { $.messager.alert('提示', '查询不到数据,请检查数据是否存在！', 'error'); }
	            else {
	                PagePaging(loaddata);
	            }
	        }
	    });
	}

	function PagePaging(loaddata) {
	    $("#dgSpecimenRtLog").datagrid({
	        data: loaddata.slice(0, 10)
	    });
	    var pager = $("#dgSpecimenRtLog").datagrid("getPager");
	    pager.pagination({
	        total: loaddata.length,
	        onSelectPage: function (pageNo, pageSize) {
	            var start = (pageNo - 1) * pageSize;
	            var end = start + pageSize;
	            $("#dgSpecimenRtLog").datagrid("loadData", loaddata.slice(start, end));
	            pager.pagination('refresh', {
	                total: loaddata.length,
	                pageNumber: pageNo
	            });
	        }
	    });
	}

	function searchData(){
		/*兼顾导出Excel公用条件，在这里datagrid不用load函数加载参数，直接用URL传递参数*/
		var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
		var QryUrl='SpecimenRtLog_handler.ashx?mode=qry&'+Parm; 
		$('#datagrid').datagrid({url:QryUrl});
	}
    /*关闭dialog重新加载datagrid数据*/
    $('#dlg').dialog({onClose:function(){ 
        $('#datagrid').datagrid('reload'); //重新加载载数据
    }});
</script>

</body>
</html>
