/*新增表单*/
function newForm(url) {
    $('#dlg').dialog({
        title: '添加数据',
        width: 650,
        height: 450,
        closed: false,
        cache: false,
        href: url + '?mode=ins'
    });
}
/*查看数据*/
function infoForm($dg, url) {
    var rows = $dg.datagrid('getSelections');
    if (rows.length > 0) {
        if (rows.length == 1) {
            var row = $dg.datagrid('getSelected');
            $('#dlg').dialog({
                title: '查看数据',
                width: 650,
                height: 450,
                closed: false,
                cache: true,
                href: url + '?mode=inf&pk=' + row.id
            });
        } else {
            $.messager.alert('警告', '查看操作只能选择一条数据', 'warning');
        }
    } else {
        $.messager.alert('警告', '请选择数据', 'warning');
    }
}
/*修改数据*/
function editForm($dg, url) {
    var rows = $dg.datagrid('getSelections');
    if (rows.length > 0) {
        if (rows.length == 1) {
            var row = $dg.datagrid('getSelected');
            $('#dlg').dialog({
                title: '修改数据',
                width: 650,
                height: 450,
                closed: false,
                cache: true,
                href: url + '?mode=upd&pk=' + row.id
            });
        } else {
            $.messager.alert('警告', '修改操作只能选择一条数据', 'warning');
        }
    } else {
        $.messager.alert('警告', '请选择数据', 'warning');
    }
}
/*删除选择数据,多条记录PK主键参数用逗号,分开*/
function destroy($dg, url) {
    var selecRows = $dg.datagrid('getSelections');
    if (selecRows.length > 0) {
        $.messager.confirm('提示', '是否确认删除数据？', function (r) {
            if (r) {
                var copyRows = [];
                for (var j = 0; j < selecRows.length; j++) {
                    copyRows.push(selecRows[j]);
                }
                for (var i = 0; i < copyRows.length; i++) {
                    var index = $dg.datagrid('getRowIndex', copyRows[i]);
                    $dg.datagrid('deleteRow', index);
                }
            }
        });
    } else {
        $.messager.alert('警告', '请选择数据', 'warning');
    }
}

/*查询条件参数构建*/
function getSearchParm() {
    //增加条件，请追加参数名称
    /*combobox值获取方法,用于下拉条件查询条件组合*/
    //var v_so_字段名称 = $('#so_字段名称').combobox('getValue');
    var v_parm
    var v_so_keywords = $('#so_keywords').searchbox('getValue');
    v_parm = 'so_keywords=' + escape(v_so_keywords);
    return v_parm;
}

/*查询数据*/
function searchData(url) {
    /*兼顾导出Excel公用条件，在这里datagrid不用load函数加载参数，直接用URL传递参数*/
    var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
    var QryUrl = url + '?mode=qry&' + Parm;
    $dg.datagrid({ url: QryUrl });
}

/*导出数据*/
function exportData(url) {
    var Parm = getSearchParm();//获得查询条件参数构建，用URL传递查询参数
    var QryUrl = url + '?mode=exp&' + Parm;
    $.post(QryUrl, function (result) {
        if (result.success) {
            window.location.href = result.msg;
        } else {
            $.messager.alert('错误', result.msg, 'warning');
        }
    }, 'json');
}