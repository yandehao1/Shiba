$(function () {
    InitLeftMenu();
    tabClose();
    tabCloseEven();
});
//退出登录
$(function () {
    $('#loginOut').click(function () {
        $.messager.confirm('系统提示', '您确定要退出本次登录吗?', function (r) {
            if (r) {
                $.cookie('username', null);
                $.cookie('password', null);
                CloseWebPage();
            }
        });
    })
});
//初始化左侧
function InitLeftMenu() {
    $('.easyui-accordion li a').click(function () {
        var tabTitle = $(this).text();
        //var url = $(this).attr("href");
        var url = $(this).attr("rel");
        addTab(tabTitle, url);
        $('.easyui-accordion div ul li div').removeClass("selected");
        $(this).parent().addClass("selected");
    }).hover(function () { $(this).parent().addClass("hover"); }, function () { $(this).parent().removeClass("hover"); });
    $(".easyui-accordion").accordion();
}
function addTab(subtitle, url) {
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true
            //width:$('#mainPanle').width()-10, createFrame(url),
            //height:$('#mainPanle').height()-26
        });
    }
    else {
        $('#tabs').tabs('select', subtitle);
        $('#mm-tabupdate').click();
    }
    tabClose();
}
function createFrame(url) {
    var s = '<iframe scrolling="yes"  name = "mainFrame" frameborder="0"  src="' + url + '" style="width:100%;height:98%;"></iframe>';
    return s;
}
function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () { var subtitle = $(this).children("span").text(); $('#tabs').tabs('close', subtitle); });
    $(".tabs-inner").bind('contextmenu', function (e) {
        $('#mm').menu('show', { left: e.pageX, top: e.pageY });
        var subtitle = $(this).children("span").text();
        $('#mm').data("currtab", subtitle);
        return false;
    });
}
//绑定右键菜单事件
function tabCloseEven() {
    //关闭当前
    $('#mm-tabclose').click(function () { var currtab_title = $('#mm').data("currtab"); $('#tabs').tabs('close', currtab_title); })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner span').each(function (i, n) { var t = $(n).text(); $('#tabs').tabs('close', t); });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('.tabs-inner span').each(function (i, n) {
            var t = $(n).text();
            if (t != currtab_title)
                $('#tabs').tabs('close', t);
        });
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            alert('后边没有啦~~');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            alert('到头了，前边没有啦~~');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //退出
    $("#mm-exit").click(function () { $('#mm').menu('hide'); })
}

//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function msgShow(title, msgString, msgType) { $.messager.alert(title, msgString, msgType); }

//注销按钮
function loginOut() {
    $.messager.alert('提示', '确认注销？', 'error');
    $.cookie('username', null);
    $.cookie('password', null);
    CloseWebPage();
}

function CloseWebPage() {
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        if (navigator.userAgent.indexOf("MSIE 6.0") > 0) {
            window.opener = null;
            window.close();
        } else {
            window.open('', '_top');
            window.top.close();
        }
    }
    else if (navigator.userAgent.indexOf("Firefox") > 0) {
        window.location.href = 'about:blank ';
    } else {
        window.opener = null;
        window.open('', '_self', '');
        window.close();
    }
}