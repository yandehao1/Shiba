<!--基础代码由科发EasyUi代码生成器v3.5(build 20140519)代码生成器生成,免费版自动增加版权注释,请保留版权信息，尊重作者劳动成果，如您有更好的建议请发至邮箱：843330160@qq.com-->
<!--编辑表单form与datagrid列表数据分别放在两个独立的aspx页面中-->
<!--form页面:OPListForSpecimen_info.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OPListForSpecimen_info.aspx.cs" Inherits="RuRo.OPListForSpecimen_info" %>
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
<!--存储参数属性input控件，判断是新增还是修改--> 
<input value=""  id="mode" type="text" style="display:none"  runat="server"  />
<input value=""  id="pk" type="text"   style="display:none" runat="server"  />
<!--编辑数据--> 
<!--编辑容器，按钮固定在底部--> 
<div class="easyui-layout" data-options="fit:true">
<div data-options="region:'center',split:true" style="width:100px;padding:10px">
<div id="printBody"> 
<div class="ftitle">OPListForSpecimen</div>
    <form id="frmAjax" method="post" novalidate>
        <!--如需控制表单控件为必填项，请增加class="easyui-validatebox" required="true" -->
        <div class="fitem">
            <div class="label">id:</div>
            <div class="control"><input id="id"  name="id"  disabled="disabled" /></div>
        </div>
        <div class="fitem">
            <div class="label">病人唯一标识号:</div>
            <div class="control"><input  id="patientid"  name="patientid"   /></div>
        </div>
        <div class="fitem">
            <div class="label">住院号:</div>
            <div class="control"><input  id="inpno"  name="inpno"   /></div>
        </div>
        <div class="fitem">
            <div class="label">就诊号:</div>
            <div class="control"><input  id="visitid"  name="visitid"   /></div>
        </div>
        <div class="fitem">
            <div class="label">姓名:</div>
            <div class="control"><input  id="name"  name="name"   /></div>
        </div>
        <div class="fitem">
            <div class="label">姓名拼音:</div>
            <div class="control"><input  id="namephonetic"  name="namephonetic"   /></div>
        </div>
        <div class="fitem">
            <div class="label">性别:</div>
            <div class="control"><input  id="sex"  name="sex"   /></div>
        </div>
        <div class="fitem">
            <div class="label">出生日期:</div>
            <div class="control"><input  id="dateofbirth"  name="dateofbirth"   /></div>
        </div>
        <div class="fitem">
            <div class="label">行政区名称:</div>
            <div class="control"><input  id="birthplace"  name="birthplace"   /></div>
        </div>
        <div class="fitem">
            <div class="label">国家简称:</div>
            <div class="control"><input  id="citizenship"  name="citizenship"   /></div>
        </div>
        <div class="fitem">
            <div class="label">民族:</div>
            <div class="control"><input  id="nation"  name="nation"   /></div>
        </div>
        <div class="fitem">
            <div class="label">身份证号:</div>
            <div class="control"><input  id="idno"  name="idno"   /></div>
        </div>
        <div class="fitem">
            <div class="label">患者工作身份:</div>
            <div class="control"><input  id="identity"  name="identity"   /></div>
        </div>
        <div class="fitem">
            <div class="label">病人收费类别:</div>
            <div class="control"><input  id="chargetype"  name="chargetype"   /></div>
        </div>
        <div class="fitem">
            <div class="label">永久通信地址:</div>
            <div class="control"><textarea  id="mailingaddress"  name="mailingaddress"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">邮政编码:</div>
            <div class="control"><input  id="zipcode"  name="zipcode"   /></div>
        </div>
        <div class="fitem">
            <div class="label">家庭电话号码:</div>
            <div class="control"><input  id="phonenumberhome"  name="phonenumberhome"   /></div>
        </div>
        <div class="fitem">
            <div class="label">单位电话号码:</div>
            <div class="control"><input  id="phonenumbebusiness"  name="phonenumbebusiness"   /></div>
        </div>
        <div class="fitem">
            <div class="label">亲属姓名:</div>
            <div class="control"><input  id="nextofkin"  name="nextofkin"   /></div>
        </div>
        <div class="fitem">
            <div class="label">亲属关系:</div>
            <div class="control"><input  id="relationship"  name="relationship"   /></div>
        </div>
        <div class="fitem">
            <div class="label">联系人地址:</div>
            <div class="control"><textarea  id="nextofkinaddr"  name="nextofkinaddr"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">联系人邮政编码:</div>
            <div class="control"><input  id="nextofkinzipcode"  name="nextofkinzipcode"   /></div>
        </div>
        <div class="fitem">
            <div class="label">联系人电话号码:</div>
            <div class="control"><input  id="nextofkinphome"  name="nextofkinphome"   /></div>
        </div>
        <div class="fitem">
            <div class="label">当前科室代码@名称:</div>
            <div class="control"><input  id="deptcode"  name="deptcode"   /></div>
        </div>
        <div class="fitem">
            <div class="label">病人所住床号:</div>
            <div class="control"><input  id="bedno"  name="bedno"   /></div>
        </div>
        <div class="fitem">
            <div class="label">入院日期及时间:</div>
            <div class="control"><input  id="admissiondatetime"  name="admissiondatetime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">主治医生工号@姓名:</div>
            <div class="control"><input  id="doctorincharge"  name="doctorincharge"   /></div>
        </div>
        <div class="fitem">
            <div class="label">手术id号:</div>
            <div class="control"><input  id="scheduleid"  name="scheduleid"   /></div>
        </div>
        <div class="fitem">
            <div class="label">主要诊断:</div>
            <div class="control"><textarea  id="diagbeforeoperation"  name="diagbeforeoperation"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">预约进行该次手术的日期及时间:</div>
            <div class="control"><input  id="scheduleddatetime"  name="scheduleddatetime"   /></div>
        </div>
        <div class="fitem">
            <div class="label">是否留标本:</div>
            <div class="control"><input  id="keepspecimensign"  name="keepspecimensign"   /></div>
        </div>
        <div class="fitem">
            <div class="label">手术室代码@名称:</div>
            <div class="control"><input  id="operatingroom"  name="operatingroom"   /></div>
        </div>
        <div class="fitem">
            <div class="label">手术医师工号@姓名:</div>
            <div class="control"><input  id="surgeon"  name="surgeon"   /></div>
        </div>
        <div class="fitem">
            <div class="label">现病史:</div>
            <div class="control"><textarea  id="inpatpreillness"  name="inpatpreillness"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">既往史:</div>
            <div class="control"><textarea  id="inpatpastillness"  name="inpatpastillness"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">家族史:</div>
            <div class="control"><textarea  id="inpatfamillness"  name="inpatfamillness"  ></textarea></div>
        </div>
        <div class="fitem">
            <div class="label">乙肝梅毒等阳性结果:</div>
            <div class="control"><textarea  id="labinfo"  name="labinfo"  ></textarea></div>
        </div>
    </form>
<div class="ftitle"></div>
</div>
</div>

<div data-options="region:'south'" style="height:40px; background:#f2f2f2;">
<!--按钮-->
<div class="fsubmit">
	<a href="javascript:void(0)" id="linkbuttonSave" class="easyui-linkbutton" iconCls="icon-ok" onclick="saveForm()">保存</a>
	<a href="javascript:void(0)" id="linkbuttonClear" class="easyui-linkbutton" iconCls="icon-back" onclick="clearForm();">清空</a>
	<a href="javascript:void(0)" id="linkbuttonPrint" class="easyui-linkbutton" iconCls="icon-print" onclick="printPage('printBody');">打印</a>
	<a href="javascript:void(0)" id="linkbuttonColse" class="easyui-linkbutton" iconCls="icon-cancel" onclick="$('#dlg').dialog('close');">关闭</a>
</div>
</div>
</div>

<script type="text/javascript">
var mode = $('#mode').val();
var pk =  $('#pk').val();

/*编辑或查看状态下控件赋值*/
if(mode=='upd'|| mode=='inf'){ 
    url = 'OPListForSpecimen_handler.ashx?mode=inf&pk='+pk; 
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

if(mode=='ins') url = 'OPListForSpecimen_handler.ashx?mode=ins';
if(mode=='upd') url = 'OPListForSpecimen_handler.ashx?mode=upd&pk='+pk;

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
