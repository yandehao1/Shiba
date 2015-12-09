<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--datagrid页面:SpecimenRt_list.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecimenRt_list.aspx.cs" Inherits="RuRo.SpecimenRt_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>主要作用是用于判断是否需要回发给His</title>
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/default/easyui.css" />
	<link rel="stylesheet" type="text/css" href="/js/easyui/themes/icon.css" />
	<script type="text/javascript" src="/js/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="/js/easyui/jquery.easyui.min.js"></script>
	<script type="text/javascript" src="/js/easyui/locale/easyui-lang-zh_CN.js"></script>
	<script type="text/javascript" src="/js/gridPrint.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/kfmis.css"/>

</head>
<body>
<!--datagrid栏--> 
<table id="datagrid" title="回发数据" class="easyui-datagrid" style="width:auto;height:460px"
             url="SpecimenRt_handler.ashx?mode=qry" fit='false'
             pagination="true" idField="id" rownumbers="true" 
             fitColumns="true"  singleSelect="true" toolbar="#toolbar"
             striped="false" pageList="[15,30,50,100,500]"
             SelectOnCheck="true" CheckOnSelect="true" remoteSort="true">
    <thead>    
			<tr>
			    <th field="ck" checkbox="true"></th>
                <th field="id" width="100" sortable="true">序号自增列</th>
                <th field="patientid" width="100" sortable="true">患者唯一标识号</th>
                <th field="patientname" width="100" sortable="true">患者名称</th>
                <th field="visitid" width="100" sortable="true">患者就诊号</th>
                <th field="sampleid" width="100" sortable="true">样本Id</th>
                <th field="samplename" width="100" sortable="true">样本Name</th>
                <th field="otherinfo" width="100" sortable="true">其他信息（样本类型、总管数、在库管数、出库管数、创建时间、更新时间）</th>
            </tr>
    </thead>
</table>

<!--toolbar栏，用于datagrid的toolbar自定义内容--> 
<div id="toolbar">
<table style="width:100%;">
<tr>
    <td>
        <!--查询输入栏--> 
        <table>
            <tr>

                <!--查询控件-->
                <td>
                    <!--
                    编码字段<input id="so_字段名称"  class="easyui-combobox" panelHeight="auto"  data-options="valueField:'编码表对应code字段名',textField:'编码表对应name字段名', url:'/common/codeDataHandler.ashx?tabName=编码表名'"/>
                    <input id="date"     class="easyui-datebox" type="text" />
                    -->
                </td>
                <!--检索关键字-->
                <td><input id="so_keywords"  class="easyui-searchbox" data-options="prompt:'请输入查询关键字',searcher:searchData" ></input></td>
            </tr>
        </table> 
    </td>
    <!--button按钮工具栏--> 
    <td  style="text-align:right;">
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonInfo" iconCls="icon-search" plain="false" onclick="infoForm();">查看</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonAdd" iconCls="icon-add" plain="false" onclick="newForm();">添加</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonEdit" iconCls="icon-edit" plain="false" onclick="editForm();">编辑</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" id="linkbuttonDel" iconCls="icon-cancel" plain="false" onclick="destroy();">删除</a>
    </td>
</tr>
</table>  
</div>

<!--diaglog窗口，用于编辑数据--> 
<div id="dlg"  class="easyui-dialog" closed="true"></div>

<script type="text/javascript">
	var url;
	/*新增表单*/
	function newForm(){
		$('#dlg').dialog({    
            title: '添加数据',    
            width: 650, 
            height: 450,    
            closed: false,  
            cache: false,    
            href: 'SpecimenRt_info.aspx?mode=ins'
        });     
	}

	/*查看数据*/
	function infoForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: '查看数据',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'SpecimenRt_info.aspx?mode=inf&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('警告', '查看操作只能选择一条数据', 'warning'); 
			}  
	    }else{
	         $.messager.alert('警告', '请选择数据', 'warning');
	    }
	}

	/*修改数据*/
	function editForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: '主要作用是用于判断是否需要回发给His-修改数据',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'SpecimenRt_info.aspx?mode=upd&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('警告', '修改操作只能选择一条数据', 'warning'); 
			}  
	    }else{
	         $.messager.alert('警告', '请选择数据', 'warning');
	    }
	}

	/*删除选择数据,多条记录PK主键参数用逗号,分开*/
	function destroy(){
		var rows = $('#datagrid').datagrid('getSelections');
		if(rows.length>0){ 
				var pkSelect="";
				for(var i=0;i<rows.length;i++){
					row = rows[i];
					if(i==0){
						pkSelect+= row.id;
					}else{
						pkSelect+=','+row.id;
					}
				}
				$.messager.confirm('提示','是否确认删除数据？',function(r){
				if (r){
						$.post('SpecimenRt_handler.ashx?mode=del&pk='+pkSelect,function(result){
							if (result.success){
								$.messager.alert('提示', result.msg, 'info',function(){
									$('#datagrid').datagrid('reload');    //重新加载载数据
								}); 
							} else {
								$.messager.alert('错误', result.msg, 'warning');
							}
						},'json');
					}
				}); 
		}else{
			 $.messager.alert('警告', '请选择数据', 'warning');
		}
	}

	/*查询条件参数构建*/
	function getSearchParm(){
		//增加条件，请追加参数名称
		/*combobox值获取方法,用于下拉条件查询条件组合*/
		//var v_so_字段名称 = $('#so_字段名称').combobox('getValue');
		var v_parm
		var v_so_keywords = $('#so_keywords').searchbox('getValue');
		v_parm = 'so_keywords='+escape(v_so_keywords);
		return v_parm;
	}

	/*查询数据*/
	function searchData(){
		/*兼顾导出Excel公用条件，在这里datagrid不用load函数加载参数，直接用URL传递参数*/
		var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
		var QryUrl='SpecimenRt_handler.ashx?mode=qry&'+Parm; 
		$('#datagrid').datagrid({url:QryUrl});
	}

    /*关闭dialog重新加载datagrid数据*/
    $('#dlg').dialog({onClose:function(){ 
        $('#datagrid').datagrid('reload'); //重新加载载数据
    }});

</script>

</body>
</html>
