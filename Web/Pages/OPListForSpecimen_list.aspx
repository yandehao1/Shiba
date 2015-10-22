<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--datagrid页面:OPListForSpecimen_list.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OPListForSpecimen_list.aspx.cs" Inherits="RuRo.OPListForSpecimen_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>OPListForSpecimen</title>
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
<table id="datagrid" title="OPListForSpecimen" class="easyui-datagrid" style="width:auto;height:460px"
             url="OPListForSpecimen_handler.ashx?mode=qry" fit='false'
             pagination="true" idField="id" rownumbers="true" 
             fitColumns="true"  singleSelect="true" toolbar="#toolbar"
             striped="false" pageList="[15,30,50,100,500]"
             SelectOnCheck="true" CheckOnSelect="true" remoteSort="true">
    <thead>    
			<tr>
			    <th field="ck" checkbox="true"></th>
                <th field="id" width="100" sortable="true">id</th>
                <th field="patientid" width="100" sortable="true">病人唯一标识号</th>
                <th field="inpno" width="100" sortable="true">住院号</th>
                <th field="visitid" width="100" sortable="true">就诊号</th>
                <th field="name" width="100" sortable="true">姓名</th>
                <th field="namephonetic" width="100" sortable="true">姓名拼音</th>
                <th field="sex" width="100" sortable="true">性别</th>
                <th field="dateofbirth" width="100" sortable="true">出生日期</th>
                <th field="birthplace" width="100" sortable="true">行政区名称</th>
                <th field="citizenship" width="100" sortable="true">国家简称</th>
                <th field="nation" width="100" sortable="true">民族</th>
                <th field="idno" width="100" sortable="true">身份证号</th>
                <th field="identity" width="100" sortable="true">患者工作身份</th>
                <th field="chargetype" width="100" sortable="true">病人收费类别</th>
                <th field="mailingaddress" width="100" sortable="true">永久通信地址</th>
                <th field="zipcode" width="100" sortable="true">邮政编码</th>
                <th field="phonenumberhome" width="100" sortable="true">家庭电话号码</th>
                <th field="phonenumbebusiness" width="100" sortable="true">单位电话号码</th>
                <th field="nextofkin" width="100" sortable="true">亲属姓名</th>
                <th field="relationship" width="100" sortable="true">亲属关系</th>
                <th field="nextofkinaddr" width="100" sortable="true">联系人地址</th>
                <th field="nextofkinzipcode" width="100" sortable="true">联系人邮政编码</th>
                <th field="nextofkinphome" width="100" sortable="true">联系人电话号码</th>
                <th field="deptcode" width="100" sortable="true">当前科室代码@名称</th>
                <th field="bedno" width="100" sortable="true">病人所住床号</th>
                <th field="admissiondatetime" width="100" sortable="true">入院日期及时间</th>
                <th field="doctorincharge" width="100" sortable="true">主治医生工号@姓名</th>
                <th field="scheduleid" width="100" sortable="true">手术id号</th>
                <th field="diagbeforeoperation" width="100" sortable="true">主要诊断</th>
                <th field="scheduleddatetime" width="100" sortable="true">预约进行该次手术的日期及时间</th>
                <th field="keepspecimensign" width="100" sortable="true">是否留标本</th>
                <th field="operatingroom" width="100" sortable="true">手术室代码@名称</th>
                <th field="surgeon" width="100" sortable="true">手术医师工号@姓名</th>
                <th field="inpatpreillness" width="100" sortable="true">现病史</th>
                <th field="inpatpastillness" width="100" sortable="true">既往史</th>
                <th field="inpatfamillness" width="100" sortable="true">家族史</th>
                <th field="labinfo" width="100" sortable="true">乙肝梅毒等阳性结果</th>
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
            title: 'OPListForSpecimen-添加数据',    
            width: 650, 
            height: 450,    
            closed: false,  
            cache: false,    
            href: 'OPListForSpecimen_info.aspx?mode=ins'
        });     
	}

	/*查看数据*/
	function infoForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: 'OPListForSpecimen-查看数据',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'OPListForSpecimen_info.aspx?mode=inf&pk='+ row.id
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
                    title: 'OPListForSpecimen-修改数据',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'OPListForSpecimen_info.aspx?mode=upd&pk='+ row.id
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
						$.post('OPListForSpecimen_handler.ashx?mode=del&pk='+pkSelect,function(result){
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
		var QryUrl='OPListForSpecimen_handler.ashx?mode=qry&'+Parm; 
		$('#datagrid').datagrid({url:QryUrl});
	}

    /*关闭dialog重新加载datagrid数据*/
    $('#dlg').dialog({onClose:function(){ 
        $('#datagrid').datagrid('reload'); //重新加载载数据
    }});

</script>

</body>
</html>
