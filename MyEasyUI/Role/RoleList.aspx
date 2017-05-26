<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="MyEasyUI.Role.RoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>角色列表</title>
    <link href="../themes/default/easyui.css" rel="stylesheet" />
    <link href="../themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../js/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/commjs.js"></script>
    <script type="text/javascript" src="../js/easyui3combox.js"></script>
    <script type="text/javascript">
        $(function () {
            autoAddClear();
            loadGridData();
        });
        function loadGridData() {
            $('#dg').datagrid({
                url: '../Ashx/role.ashx?action=getlist',
                method: 'get',
                title: "角色列表",
                loadMsg: '数据正在加载，请稍等......',
                iconCls: 'icon-save',
                height: "auto",
                fit: true,
                fitColumns: true,
                singleSelect: true,
                collapsible: true,
                toolbar: '#tb',
                pagination: true,
                pageNumber: 1,
                pageSize: 15,
                pageList: [10, 15, 20, 25, 30, 35, 40, 45, 50],
                rownumbers: true,
                queryParams: {
                },
                rowStyler: function (index, row) {

                },
                columns: [[
                    { field: 'ck', checkbox: true },
					{ field: 'RoleID', title: 'ID', width: 70 },
					{ field: 'RoleName', title: '角色名称', width: 90 },
                    { field: 'RoleDesc', title: '描述', width: 250 },
					{
					    field: 'WriteRight', title: '权限', width: 70
					},
                    {
                        field: 'AddTime', title: '创建时间', width: 150, formatter: formatterDate
                    },
                    { field: 'AddUser', title: '创建人', width: 100 }

                ]],
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        //添加一个新数据行，第一列的值为你需要的提示信息，然后将其他列合并到第一列来，注意修改colspan参数为你columns配置的总列数
                        $(this).datagrid('appendRow', { uId: '<div style="text-align:center;color:red">没有相关记录！</div>' }).datagrid('mergeCells', { index: 0, field: 'RoleID', colspan: 6 })
                        //隐藏分页导航条，这个需要熟悉datagrid的html结构，直接用jquery操作DOM对象，easyui datagrid没有提供相关方法隐藏导航条
                        $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').hide();
                    }
                        //如果通过调用reload方法重新加载数据有数据时显示出分页导航容器
                    else $(this).closest('div.datagrid-wrap').find('div.datagrid-pager').show();
                }
            });
        }
        function formatterDate(value, row, index) {
            var date = new Date(value);
            var year = date.getFullYear();
            var month = date.getMonth() + 1;
            var day = date.getDate();
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();
            return year + "-" + month + "-" + day + "" + " " + hours + ":" + minutes + ":" + seconds;
        }
        function formatterLevel(value, row, index) {
            switch (value) {
                case "1":
                    return "总裁";
                    break;
                case "2":
                    return "副总裁";
                    break;
                case "3":
                    return "总经理";
                    break;
                case "4":
                    return "组长";
                    break;
                case "5":
                    return "员工";
                    break;
                default:
                    break;
            }
        }
        //查询
        function doSearch() {
            $('#dg').datagrid('load', {
                UserName: $("#UserName").val(),
                DateFrom: $("#DateFrom").val(),
                DateTo: $("#DateTo").val(),
                Level: $("#PowerLevel").val()
            });
        }
        //添加
        function addCustomer() {
            //$("#cus_name").val("");
            //$("#cus_addr").val("");
            $("#addUsers").window('open');
        }
        //添加用户信息
        function addUserInfo() {
            var name = $.trim($("#cus_name").val());
            var addr = $.trim($("#cus_addr").val());
            if (name == "") {
                return;
            } if (addr == "") {
                return;
            } else {
                $.post("../json/customerAction_addCustomer", { 'customer.cus_name': name, 'customer.cus_addr': addr }, function (data) {
                    data = parseInt($.trim(data));
                    if (data >= 1) {
                        $.messager.show({
                            title: '成功提示',
                            msg: '用户信息添加成功...',
                            timeout: 2000,
                            showType: 'slide'
                        });
                        //关闭添加信息窗口
                        $("#addUsers").dialog('close');
                        //刷新数据
                        $("#userInfo").datagrid('load', {});
                    } else {
                        $.messager.alert('失败提示', '用户信息添加失败...', 'error');
                        $("#userInfo").datagrid('load', {});
                    }
                });
            }
        }
        //显示修改对话框
        function updateCustomer() {
            //选取要修改的数据
            var rows = $("#userInfo").datagrid('getChecked');
            //判断有没有选择要修改的数据
            if (rows.length <= 0) { //说明用户没有选择数据
                $.messager.show({
                    title: '错误提示',
                    msg: '请选择您要修改的数据...',
                    timeout: 2000,
                    showType: 'slide'
                });
                return;
            }
            //如果用户有选择数据，则选取用户选定的第一条要修改的数据，并将其原值显示在对话框中
            var cid = rows[0].cus_id;
            var cname = rows[0].cus_name;
            var caddr = rows[0].cus_addr;
            $("#cid").val(cid);
            $("#cname").val(cname);
            $("#caddr").val(caddr);
            $("#updateUsers").dialog('open');
        }
        //修改
        function updateCustomerInfo() {
            var cname = $.trim($("#cname").val());
            var caddr = $.trim($("#caddr").val());
            var cid = $.trim($("#cid").val());
            if (cname == "") {
                return;
            } else if (caddr == "") {
                return;
            } else {
                $.post("../json/customerAction_updateCustomer", { 'customer.cus_name': cname, 'customer.cus_id': cid, 'customer.cus_addr': caddr }, function (data) {
                    data = parseInt($.trim(data));
                    if (data >= 1) {
                        $.messager.show({
                            title: '成功提示',
                            msg: '用户信息修改成功....',
                            timeout: 2000,
                            showType: 'slide'
                        });
                        //关闭添加信息窗口
                        $("#updateUsers").dialog('close');
                        //刷新数据
                        $("#userInfo").datagrid('load', {});
                    } else {
                        $.messager.alert('失败提示', '用户信息修改失败...', 'error');
                        $("#userInfo").datagrid('load', {});
                    }
                });
            }
        }
        function delCustomer() {
            var rows = $("#userInfo").datagrid('getChecked'); //选取要删除的数据
            //判断有没有选择要删除的数据
            if (rows.length <= 0) { //说明用户没有选择数据
                $.messager.show({
                    title: '错误提示',
                    msg: '请选择您要删除的数据...',
                    timeout: 2000,
                    showType: 'slide'
                });
                return;
            }
            //如果用户有选择数据，警告用户小心操作
            $.messager.confirm("确认提示", "数据一旦删除，将不能恢复，您确定要删除选定数据吗?", function (rt) {
                if (rt) {
                    //获取用户选中的所有数据的id in(1001,1002)
                    var cid = "";
                    for (var i = 0; i < rows.length - 1; i++) {
                        cid += rows[i].cus_id + ",";
                    }
                    cid += rows[i].cus_id;
                    $.post("../json/customerAction_delCustomer", { ids: cid }, function (data) {
                        data = parseInt($.trim(data));
                        if (data >= 1) {
                            $.messager.show({
                                title: '成功提示',
                                msg: '用户信息删除成功...',
                                timeout: 2000,
                                showType: 'slide'
                            });
                            //刷新数据
                            $("#userInfo").datagrid('load', {});
                        } else {
                            $.messager.alert('失败提示', '用户信息删除失败...', 'error');
                            $("#userInfo").datagrid('load', {});
                        }
                    });
                } else {
                    return;
                }
            });
        }
    </script>
</head>

<body>
    <div id="dg" style="width: 100%; height: 780px;">
    </div>
    <div id="addUsers" class="easyui-window" title="添加用户信息" style="width: 400px; height: 200px; text-align: center;"
        data-options="iconCls:'icon-add',resizable:true,modal:true,closed:true,inline:true,footer:'#footer'">
        <a href="#" class="easyui-linkbutton" onclick="getChecked()">GetChecked</a>
        <div class="easyui-panel" style="padding: 5px; border: 0px;">
            <ul id="tt" class="easyui-tree" data-options="url:'../Ashx/mainmenu.ashx?action=init',method:'get',animate:true,checkbox:true"></ul>
        </div>
        <script type="text/javascript">
            function getChecked() {
                var nodes = $('#tt').tree('getChecked');
                var s = '';
                for (var i = 0; i < nodes.length; i++) {
                    if (s != '') s += ',';
                    s += nodes[i].id;
                }
                alert(s);
            }
        </script>
        <div id="footer" style="text-align: center; padding: 5px">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="addUserInfo()">添 加</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="$('#addUsers').window('close')">取 消</a>
        </div>
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <div style="margin-bottom: 5px">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="addCustomer()">添 加</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true">修 改</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true">删 除</a>
            省：<input id="loc_rprovince" class="easyui-combobox" name="loc_rprovince" />
            市：<input id="loc_rcity" class="easyui-combobox" name="loc_rcity" />
            县：<input id="loc_rtown" class="easyui-combobox" name="loc_rtown" />
        </div>
    </div>
</body>
</html>
