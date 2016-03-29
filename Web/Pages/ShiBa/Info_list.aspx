<!--���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com-->
<!--�༭��form��datagrid�б����ݷֱ��������������aspxҳ����-->
<!--datagridҳ��:Info_list.aspx-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info_list.aspx.cs" Inherits="RURO.Info_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head">
<title>Info</title>
    <link rel="stylesheet" type="text/css" href="/js/easyui/themes/default/easyui.css" />
	<link rel="stylesheet" type="text/css" href="/js/easyui/themes/icon.css" />
	<script type="text/javascript" src="/js/easyui/jquery.min.js"></script>
	<script type="text/javascript" src="/js/easyui/jquery.easyui.min.js"></script>
	<script type="text/javascript" src="/js/easyui/locale/easyui-lang-zh_CN.js"></script>
	<script type="text/javascript" src="/js/gridPrint.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/kfmis.css"/>

</head>
<body>
<!--datagrid��--> 
<table id="datagrid" title="��ѯ�б�" class="easyui-datagrid" style="width:auto;height:460px"
             url="Info_handler.ashx?mode=qry" fit='false'
             pagination="true" idField="id" rownumbers="true" 
             fitColumns="true"  singleSelect="true" toolbar="#toolbar"
             striped="false" pagelist="[10,30,50]"
             SelectOnCheck="true" CheckOnSelect="true" remoteSort="true" multiSort="true">
    <thead>    
			<tr>
			    <th field="ck" checkbox="true"></th>
                <th field="id" width="100" sortable="true">id</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="�Ա�" width="100" sortable="true">�Ա�</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="ҽ��" width="100" sortable="true">ҽ��</th>
                <th field="��ˮ��" width="100" sortable="true">��ˮ��</th>
                <th field="����" width="100" sortable="true">����</th>
                <th field="סԺ��" width="100" sortable="true">סԺ��</th>
                <th field="������" width="100" sortable="true">������</th>
                <th field="���" width="100" sortable="true">���</th>
                <th field="����" width="100" sortable="true">����</th>
            </tr>
    </thead>
</table>

<!--toolbar��������datagrid��toolbar�Զ�������--> 
<div id="toolbar">
        <table style="width: 100%;">
            <tr>
                <!--button��ť������-->
                <td style="text-align: right;"></td>
            </tr>
        </table>
</div>

<!--diaglog���ڣ����ڱ༭����--> 
<div id="dlg"  class="easyui-dialog" closed="true"></div>
<div id="dd"></div>
<script type="text/javascript">
	var url;
	/*������*/
	function newForm(){
		$('#dlg').dialog({    
            title: 'Info-�������',    
            width: 650, 
            height: 450,    
            closed: false,  
            cache: false,    
            href: 'Info_info.aspx?mode=ins'
        });     
	}

	/*�鿴����*/
	function infoForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: 'Info-�鿴����',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'Info_info.aspx?mode=inf&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('����', '�鿴����ֻ��ѡ��һ������', 'warning'); 
			}  
	    }else{
	         $.messager.alert('����', '��ѡ������', 'warning');
	    }
	}

	/*�޸�����*/
	function editForm(){
		var rows = $('#datagrid').datagrid('getSelections');
	    if(rows.length>0){
	       if(rows.length==1){
				var row = $('#datagrid').datagrid('getSelected');
				$('#dlg').dialog({    
                    title: 'Info-�޸�����',    
                    width: 650,    
                    height: 450,    
                    closed: false,    
                    cache: true,    
                    href: 'Info_info.aspx?mode=upd&pk='+ row.id
                });     
			}else{ 
				$.messager.alert('����', '�޸Ĳ���ֻ��ѡ��һ������', 'warning'); 
			}  
	    }else{
	         $.messager.alert('����', '��ѡ������', 'warning');
	    }
	}

	/*ɾ��ѡ������,������¼PK���������ö���,�ֿ�*/
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
				$.messager.confirm('��ʾ','�Ƿ�ȷ��ɾ�����ݣ�',function(r){
				if (r){
						$.post('Info_handler.ashx?mode=del&pk='+pkSelect,function(result){
							if (result.success){
								$.messager.alert('��ʾ', result.msg, 'info',function(){
									$('#datagrid').datagrid('reload');    //���¼���������
								}); 
							} else {
								$.messager.alert('����', result.msg, 'warning');
							}
						},'json');
					}
				}); 
		}else{
			 $.messager.alert('����', '��ѡ������', 'warning');
		}
	}

	/*��ѯ������������*/
	function getSearchParm(){
		//������������׷�Ӳ�������
		/*comboboxֵ��ȡ����,��������������ѯ�������*/
		//var v_so_�ֶ����� = $('#so_�ֶ�����').combobox('getValue');
		var v_parm
		var v_so_keywords = $('#so_keywords').searchbox('getValue');
		v_parm = 'so_keywords='+escape(v_so_keywords);
		return v_parm;
	}

	/*��ѯ����*/
	function searchData(){
		/*��˵���Excel����������������datagrid����load�������ز�����ֱ����URL���ݲ���*/
		var Parm = getSearchParm();//��ò�ѯ����������������URL���ݲ�ѯ����
		var QryUrl='Info_handler.ashx?mode=qry&'+Parm; 
		$('#datagrid').datagrid({url:QryUrl});
	}

	/*��������*/
	function exportData(){
		var Parm = getSearchParm();//��ò�ѯ����������������URL���ݲ�ѯ����
		var QryUrl='Info_handler.ashx?mode=exp&'+Parm; 
		$.post(QryUrl,function(result){
			if (result.success){
				window.location.href = result.msg;
			} else {
				$.messager.alert('����', result.msg, 'warning');
			}
		},'json');
	}

    /*�ر�dialog���¼���datagrid����*/
    $('#dlg').dialog({onClose:function(){ 
        $('#datagrid').datagrid('reload'); //���¼���������
    }});

</script>

</body>
</html>
