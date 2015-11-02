<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RuRo.Web.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>RuRo样本信息管理系统插件</title>
    <script src="../include/jquery-easyui-1.4.3/jquery.min.js"></script>
    <script src="../include/jquery-easyui-1.4.3/jquery.easyui.min.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
    <link href="../include/jquery-easyui-1.4.3/themes/default/easyui.css" rel="stylesheet" />
    <link href="../include/jquery-easyui-1.4.3/themes/icon.css" rel="stylesheet" />
    <link href="include/css/index.css" rel="stylesheet" />
    <script src="include/jquery-easyui-1.4.3/outlook2.js"></script>
    <script src="include/js/jquery.cookie.js"></script>
</head>
<body class="easyui-layout" style="overflow-y: hidden" scrolling="no">
    <noscript>
        <div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
            <img src="Images/IndexImg/noscript.gif" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px; background: #fff repeat-x center 50%; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head" index="100">
            <asp:Label ID="laName" Text="" runat="server"></asp:Label>&nbsp;
            <a href="#" id="loginOut">安全退出</a>
        </span>
    </div>
    <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div class="footer">中山三院临床样本资源库</div>
    </div>
    <div region="west" split="true" title="导航菜单" style="width: 180px;" id="nav">
        <div id="nav" class="easyui-accordion" fit="false" border="false">
            <!--  导航内容 -->
            <div title="插件管理" data-options="iconCls:'icon-sys'" style="overflow: auto; padding: 0px;">
                <ul>
                    <li>
                        <div><a target="mainFrame" rel="Pages/Search.aspx"><span></span>查询信息</a></div>
                    </li>
                    <li>
                        <div><a target="mainFrame" rel="Pages/ResHis.aspx"><span></span>回发数据</a></div>
                    </li>
                    <li>
                        <div><a target="mainFrame" rel="Pages/NormalLisReport_list_F.aspx"><span></span>查看检测信息</a></div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div id="mainPanle" region="center" style="background: #eee;">
        <div id="tabs" class="easyui-tabs" fit="true" border="false">
<%--            <div title="欢迎使用" style="padding: 20px; overflow: hidden;" id="home">
                <h1>欢迎进入</h1>
            </div>--%>
        </div>
    </div>
    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="mm-tabupdate">刷新</div>
        <div class="menu-sep"></div>
        <div id="mm-tabclose">关闭</div>
        <div id="mm-tabcloseall">全部关闭</div>
        <div id="mm-tabcloseother">除此之外全部关闭</div>
        <div class="menu-sep"></div>
        <div id="mm-tabcloseright">当前页右侧全部关闭</div>
        <div id="mm-tabcloseleft">当前页左侧全部关闭</div>
        <div class="menu-sep"></div>
        <div id="mm-exit">退出</div>
    </div>
</body>
</html>
