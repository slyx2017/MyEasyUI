<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuChild.aspx.cs" Inherits="MyEasyUI.Menu.MenuChild" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>菜单列表</title>
    <link href="../themes/default/easyui.css" rel="stylesheet" />
    <link href="../themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../js/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/commjs.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#dg').datagrid({
                url: '../Ashx/mainmenu.ashx?action=getlist',
                method: 'get',
                title:"菜单列表",
                iconCls: 'icon-save',
                height: "auto",
                fit:true,
                fitColumns: true,
                singleSelect: true,
                collapsible: true,
                toolbar: toolbar,
                pagination: true,
                pageNumber: 1,
                pageSize: 10,
                pageList: [10, 15, 20, 30, 40, 50],
                rownumbers: true,
                loadMsg: '数据正在加载，请稍等..........',
                columns: [[
                    { field: 'ck', checkbox: true },
					{ field: 'ID', title: 'ID', width: 100 },
					{ field: 'MenuCode', title: 'MenuCode', width: 120 },
                    { field: 'MenuName', title: 'MenuName', width: 120 },
					{ field: 'ParentID', title: 'ParentID', width: 120, align: 'right' },
					{ field: 'Description', title: 'Description', width: 120, align: 'right' },
					{ field: 'MenuUrl', title: 'MenuUrl', width: 250 },
					{ field: 'Sequence', title: 'Sequence', width: 100, align: 'center' },
                    { field: 'IsInUse', title: 'IsInUse', width: 250 },
                    { field: 'AddTime', title: 'AddTime', width: 250 },
                    { field: 'AddUser', title: 'AddUser', width: 250 }
                ]],
                onHeaderContextMenu: function (e, field) {
                    e.preventDefault();
                    if (!cmenu) {
                        createColumnMenu();
                    }
                    cmenu.menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
        });
        var toolbar = [{
            text: 'Add',
            iconCls: 'icon-add',
            handler: function () {
                globalShade();
                $('#dd').dialog({
                    title: '添加',
                    width: 450,
                    height: 350,
                    closed: false,
                    cache: false
                });
                $("#dd a").click(function () {
                    deleteGlobalShade();
                })
            }
        }, {
            text: 'Cut',
            iconCls: 'icon-cut',
            handler: function () { alert('cut') }
        }, '-', {
            text: 'Save',
            iconCls: 'icon-save',
            handler: function () { alert('save') }
        }];

        var cmenu;
        function createColumnMenu() {
            cmenu = $('<div/>').appendTo('body');
            cmenu.menu({
                onClick: function (item) {
                    if (item.iconCls == 'icon-ok') {
                        $('#dg').datagrid('hideColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-empty'
                        });
                    } else {
                        $('#dg').datagrid('showColumn', item.name);
                        cmenu.menu('setIcon', {
                            target: item.target,
                            iconCls: 'icon-ok'
                        });
                    }
                }
            });
            var fields = $('#dg').datagrid('getColumnFields');
            for (var i = 0; i < fields.length; i++) {
                var field = fields[i];
                var col = $('#dg').datagrid('getColumnOption', field);
                cmenu.menu('appendItem', {
                    text: col.title,
                    name: field,
                    iconCls: 'icon-ok'
                });
            }
        }
        function submitForm() {
            var username = $("#name").val();
            var email = $("#email").val();
            var subject = $("#subject").val();
            var message = $("#message").val();
            var language = $("#language option:selected").val();
            $('#ff').form('submit');
        }
        function clearForm() {
            $('#ff').form('clear');
        }

    </script>
</head>
<body>
    <div id="dg" style="width: 100%; height: 780px;">
    </div>
    <div id="dd" class="easyui-dialog" closed="true" style="width: 500px; height: 350px;">
        <form id="ff" method="post">
            <table cellpadding="5">
                <tr>
                    <td>Name:</td>
                    <td>
                        <input class="easyui-textbox" type="text" id="name" name="name" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <input class="easyui-textbox" type="text" id="email" name="email" data-options="required:true,validType:'email'" /></td>
                </tr>
                <tr>
                    <td>Subject:</td>
                    <td>
                        <input class="easyui-textbox" type="text" id="subject" name="subject" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>Message:</td>
                    <td>
                        <input class="easyui-textbox" id="message" name="message" data-options="multiline:true" style="height: 60px" /></td>
                </tr>
                <tr>
                    <td>Language:</td>
                    <td>
                        <select class="easyui-combobox" id="language" name="language">
                            <option value="请选择" selected="selected">---请选择---</option>
                            <option value="ar">Arabic</option>
                            <option value="bg">Bulgarian</option>
                            <option value="ca">Catalan</option>
                            <option value="zh-cht">Chinese Traditional</option>
                            <option value="cs">Czech</option>
                            <option value="da">Danish</option>
                            <option value="nl">Dutch</option>
                            <option value="en">English</option>
                            <option value="et">Estonian</option>
                            <option value="fi">Finnish</option>
                            <option value="fr">French</option>
                            <option value="de">German</option>
                            <option value="el">Greek</option>
                            <option value="ht">Haitian Creole</option>
                            <option value="he">Hebrew</option>
                            <option value="hi">Hindi</option>
                            <option value="mww">Hmong Daw</option>
                            <option value="hu">Hungarian</option>
                            <option value="id">Indonesian</option>
                            <option value="it">Italian</option>
                            <option value="ja">Japanese</option>
                            <option value="ko">Korean</option>
                            <option value="lv">Latvian</option>
                            <option value="lt">Lithuanian</option>
                            <option value="no">Norwegian</option>
                            <option value="fa">Persian</option>
                            <option value="pl">Polish</option>
                            <option value="pt">Portuguese</option>
                            <option value="ro">Romanian</option>
                            <option value="ru">Russian</option>
                            <option value="sk">Slovak</option>
                            <option value="sl">Slovenian</option>
                            <option value="es">Spanish</option>
                            <option value="sv">Swedish</option>
                            <option value="th">Thai</option>
                            <option value="tr">Turkish</option>
                            <option value="uk">Ukrainian</option>
                            <option value="vi">Vietnamese</option>
                        </select>
                    </td>
                </tr>
            </table>
        </form>
        <div style="text-align: center; padding: 5px">
            <a href="javascript:void(0)" class="easyui-linkbutton" onclick="submitForm()">Submit</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" onclick="clearForm()">Clear</a>
        </div>
    </div>
</body>
</html>
