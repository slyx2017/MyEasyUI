<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MyEasyUI.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link id="easyuiTheme" href="themes/default/easyui.css" rel="stylesheet" />
    <link href="themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/commjs.js"></script>
    <link href="css/menuaccrodion.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            // TreeMenu();
           AccrodionMenu();
        });

        //Tree
        function TreeMenu() {
            $("#MenuTree").css("display", "block");
            $("#menu").css("display", "none");
            $('#MenuTree').tree({
                method: 'get',
                url: 'Ashx/mainmenu.ashx?action=init',
                animate: true,
                lines: true,
                onClick: function (node) {
                    $(this).tree(node.state === 'closed' ? 'expand' : 'collapse', node.target);
                    node.state = node.state === 'closed' ? 'open' : 'closed';
                    if (node.attributes) {
                        Open(node.text, createFrame(node.attributes.url));
                    }
                }
            });
        }
        //Accrodion
        function AccrodionMenu() {
            $("#MenuTree").css("display", "none");
            $("#menu").css("display", "block");
            $.ajax({
                type: 'get',
                url: 'Ashx/mainmenu.ashx?action=init',
                success: function (data) {
                    createAccrodion(data);
                }
            });
        }

    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',border:false" style="height: 40px; padding: 0px">
        <a href="javascript:void(0);" onclick="TreeMenu()" class="easyui-linkbutton">Tree</a>
        <a href="javascript:void(0);" onclick="AccrodionMenu()" class="easyui-linkbutton">Accrodion</a>
        <div style="position: absolute; right: 14px; top: 5px; height: 29px;">
            <div class="easyui-panel" style="padding: 0px; font-size: 16px; font-weight: 900; height: 25px;border:0px;width: 120px;overflow: hidden;">
                <a href="javascript:void(0);" class="easyui-menubutton" data-options="menu:'#layout_north_pfMenu',iconCls:'icon-ok'">更换皮肤</a>
            </div>
        </div>
        <div id="layout_north_pfMenu" style="display: none;">
            <div onclick="changeTheme('default');">default</div>
            <div onclick="changeTheme('black');">black</div>
            <div onclick="changeTheme('bootstrap');">bootstrap</div>
            <div onclick="changeTheme('gray');">gray</div>
            <div onclick="changeTheme('metro');">metro</div>
        </div>
    </div>
    <div data-options="region:'west',split:true,title:'导航菜单'" style="width: 200px; padding: 0px;">
        <ul id="MenuTree" class="easyui-tree"></ul>
        <div id="menu" class="easyui-accordion" fit="true" border="false" style="display: none;">
        </div>
    </div>
    <div data-options="region:'south',border:false" style="height: 25px; padding: 10px; text-align: center">south region</div>
    <div data-options="region:'center'">
        <div id="tabs" class="easyui-tabs" data-options="fit:true,border:false">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden;">
                    <h1>Welcome to using The jQuery EasyUI!</h1>
                </div>
        </div>
    </div>

    <div id="tabsMenu" class="easyui-menu" style="width: 150px;">
        <div id="m-refresh">刷新</div>
        <div class="menu-sep"></div>
        <div id="m-close">关闭当前</div>
        <div id="m-closeother">除此之外全部关闭</div>
        <div id="m-tabcloseright">当前页右侧全部关闭</div>
        <div id="m-tabcloseleft">当前页左侧全部关闭</div>
        <div id="m-closeall">全部关闭</div>
        <div class="menu-sep"></div>
        <div id="m-exit">退出</div>
    </div>
        </form>
</body>
</html>
