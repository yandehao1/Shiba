<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--form页面:LabTestMaster_info.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestMaster_info.aspx.cs" Inherits="RuRo.LabTestMaster_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>LabTestMaster</title>
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
<!--存储参数属性input控件，判断是新增还是修改--> 
<input value=""  id="mode" type="text" style="display:none"  runat="server"  />
<input value=""  id="pk" type="text"   style="display:none" runat="server"  />
<!--编辑数据--> 
<!--编辑容器，按钮固定在底部--> 
<div class="easyui-layout" data-options="fit:true">
<div data-options="region:'center',split:true" style="width:100px;padding:10px">
<div id="printBody"> 
<div class="ftitle"></div>
    <form id="frmAjax" method="post" novalidate>
        <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
        <div class="fitem" style="display:none">
            <div class="label">id:</div>
            <div class="control"><input id="id"  name="id"  disabled="disabled" /></div>
        </div>
        <div class="fitem">
            <div class="label">检验申请单号:</div>
            <div class="control"><input  id="TestNo"  name="TestNo"   /></div>
        </div>
        <div class="fitem">
            <div class="label">优先标志:</div>
            <div class="control"><input  id="priorityIndicator"  name="priorityIndicator"   /></div>
        </div>
        <div class="fitem">
            <div class="label">工作单号:</div>
            <div class="control"><input  id="WorkingId"  name="WorkingId"   /></div>
        </div>
        <div class="fitem">
            <div class="label">检验目的:</div>
            <div class="control"><input  id="TestCause"  name="TestCause"   /></div>
        </div>
        <div class="fitem">
            <div class="label">标本:</div>
            <div class="control"><input  id="Specimen"  name="Specimen"   /></div>
        </div>
        <div class="fitem">
            <div class="label">采样时间:</div>
            <div class="control"><input  id="SpcmReceivedDateTime"  name="SpcmReceivedDateTime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">开医嘱科室:</div>
            <div class="control"><input  id="OrderingDept"  name="OrderingDept"   /></div>
        </div>
        <div class="fitem">
            <div class="label">医生工号:</div>
            <div class="control"><input  id="orderingProvider"  name="orderingProvider"   /></div>
        </div>
        <div class="fitem">
            <div class="label">执行科室:</div>
            <div class="control"><input  id="PerformedBy"  name="PerformedBy"   /></div>
        </div>
        <div class="fitem">
            <div class="label">执行情况:</div>
            <div class="control"><input  id="ResultStatus"  name="ResultStatus"   /></div>
        </div>
        <div class="fitem">
            <div class="label">报告完成时间:</div>
            <div class="control"><input  id="ResultsRptDateTime"  name="ResultsRptDateTime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">报告者工号:</div>
            <div class="control"><input  id="transcriptionist"  name="transcriptionist"   /></div>
        </div>
        <div class="fitem">
            <div class="label">审核者工号:</div>
            <div class="control"><input  id="VerifiedBy"  name="VerifiedBy"   /></div>
        </div>
        <div class="fitem">
            <div class="label">临床诊断:</div>
            <div class="control"><textarea  id="RelevantClinicDiag"  name="RelevantClinicDiag"  ></textarea></div>
        </div>
    </form>
<div class="ftitle"></div>
</div>
</div>

<div data-options="region:'south'" style="height:40px; background:#f2f2f2;">
<!--按钮-->
<%--<div class="fsubmit">
	<a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconCls="icon-cancel" onclick="$('#dlg').dialog('close');">关闭</a>
</div>--%>
</div>
</div>

<script type="text/javascript">
var mode = $('#mode').val();
var pk =  $('#pk').val();

/*编辑或查看状态下控件赋值*/
if(mode=='upd'|| mode=='inf'){ 
    url = 'LabTestMaster_handler.ashx?mode=inf&pk='+pk; 
    $.post(url,function(data){ 
         $('#frmAjax').form('load',data);
    },'json');
    $('#linkbuttonClear').linkbutton({disabled:true});
}
/*查看状态下disabled控件*/
if(mode=='inf'){ 
    $('#linkbuttonSave').linkbutton({disabled:true});
    $('input').attr('disabled','disabled');
    $('textarea').attr('disabled','disabled');
}
if(mode=='ins') url = 'LabTestMaster_handler.ashx?mode=ins';
if(mode=='upd') url = 'LabTestMaster_handler.ashx?mode=upd&pk='+pk;

/*清空充填*/
function clearForm(){
    $('#frmAjax').form('clear');
}

	/*保存表单数据*/
	function saveForm() {
	    var validate = true;
	    /*验证validatebox必填项*/
        try{
	        if($('#frmAjax').find('.easyui-validatebox').val() == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必填项是否正确填写！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

        /*验证datebox日期*/
        try{
	        if($('#frmAjax').find('.easyui-datebox').datebox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查日期是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

        /*验证datetimebox日期*/
        try{
	        if($('#frmAjax').find('.easyui-datetimebox').datetimebox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查日期是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证numberbox数字*/
	    try{
	        if($('#frmAjax').find('.easyui-numberbox').numberbox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必填数字项是否正确填写！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证combobox必选项*/ 
	    try{
	        if($('#frmAjax').find('.easyui-combobox').combobox('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必选项是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}

	    /*验证combogrid必选项*/ 
	    try{
	        if($('#frmAjax').find('.easyui-combogrid').combogrid('getValue') == ''){
	            validate = false;
	            $.messager.alert('警告', '请检查必选项是否正确选择！', 'warning');   //错误消息
	            return ;
	        }
	    }catch(exption){}
        /*URL支持参数受限制，小字段表使用
		if (validate==true){
			var Parm = $('#frmAjax').serialize();
			var saveUrl = url + '&' + Parm; 
			$.post(saveUrl, function (result) {
				if (result.success) {
					$('#dlg').dialog('close');
					$.messager.alert('提示',result.msg, 'info',function(){
						$('#datagrid').datagrid('reload'); // 重新加载数据
					});
				} else {
					$.messager.alert('警告', result.msg, 'warning');   //错误消息
				}
			}, 'json');
		}
		*/

		/*URL支持参数受限制，可采用submit,post提交Ajax表单*/
		if (validate==true){
		    $('#frmAjax').form('submit',{  
		        url:url,
                success: function(result){
                        resultJSON = $.parseJSON(result); 
                        if (resultJSON.success) {
					        $('#dlg').dialog('close');
					        $.messager.alert('提示',resultJSON.msg, 'info',function(){
						        $('#datagrid').datagrid('reload'); // 重新加载数据
					        });
				        } else {
					        $.messager.alert('警告', resultJSON.msg, 'warning');   //错误消息
				        }
                }  
            });
        }
	}

</script>

</body>
</html>
