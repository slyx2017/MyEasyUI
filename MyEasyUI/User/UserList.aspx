<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="MyEasyUI.User.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户列表</title>
    <link href="../themes/default/easyui.css" rel="stylesheet" />
    <link href="../themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../js/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/commjs.js"></script>
    <script type="text/javascript">
        $(function () {
            autoAddClear();
            loadGridData();
        });
        function loadGridData() {
            $('#dg').datagrid({
                url: '../Ashx/user.ashx?action=getlist',
                method: 'get',
                title: "用户列表",
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
                    UserName: $("#UserName").val(),
                    DateFrom: $("#DateFrom").val(),
                    DateTo: $("#DateTo").val(),
                    Level: $("#PowerLevel").val()
                },
                rowStyler: function (index, row) {
                    if (row.AccountState == 2) {
                        return 'background-color:#D6DBE9;color:red';
                    }
                },
                columns: [[
                    { field: 'ck', checkbox: true },
					{ field: 'uId', title: 'ID', width: 100 },
					{ field: 'uName', title: '用户名', width: 120 },
                    { field: 'uLoginName', title: '登录名', width: 120 },
					{
					    field: 'Sex', title: '性别', width: 250, formatter:
                                            function (value, row, index) {
                                                if (value == "True")
                                                    return "男";
                                                else
                                                    return "女";
                                            }
					},
					{ field: 'Telephone', title: '电话', width: 100 },
                    { field: 'Email', title: '邮箱', width: 250 },
                    {
                        field: 'Birthday', title: '生日', width: 250, formatter:
                                            function (value, row, index) {
                                                var date = new Date(value);
                                                var year = date.getFullYear();
                                                var month = date.getMonth() + 1;
                                                var day = date.getDate();
                                                return year + "-" + month + "-" + day;
                                            }
                    },
                    {
                        field: 'AccountState', title: '账号状态', width: 250, formatter:
                                              function (value, row, index) {
                                                  if (value == 1)
                                                      return "正常";
                                                  else
                                                      return "冻结";
                                              }
                    },
                    {
                        field: 'uAddtime', title: '添加时间', width: 150, formatter: formatterDate
                    },
                    { field: 'PowerLevelID', title: '级别', width: 250, formatter: formatterLevel }

                ]],
                onLoadSuccess: function (data) {
                    if (data.total == 0) {
                        //添加一个新数据行，第一列的值为你需要的提示信息，然后将其他列合并到第一列来，注意修改colspan参数为你columns配置的总列数
                        $(this).datagrid('appendRow', { uId: '<div style="text-align:center;color:red">没有相关记录！</div>' }).datagrid('mergeCells', { index: 0, field: 'uId', colspan: 10 })
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
            $("#cus_name").val("");
            $("#cus_addr").val("");
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
        data-options="iconCls:'icon-add',resizable:true,modal:true,closed:true,inline:true">
        <br />
        用户名称：<input type="text" class="easyui-textbox" id="cus_name" /><br />
        <br />
        联系地址：<input type="text" class="easyui-textbox" id="cus_addr" /><br />
        <br />
        <div style="text-align: center; padding: 5px">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="addUserInfo()">添 加</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="$('#addUsers').window('close')">取 消</a>
        </div>
    </div>

    <div id="updateUsers" class="easyui-dialog" title="修改用户信息" style="width: 400px; height: 200px; text-align: center"
        data-options="iconCls:'icon-add',resizable:true,modal:true,closed:true">
        <br />
        <input type="hidden" id="cid" />
        用户名称：<input type="text" id="cname" /><br />
        <br />
        联系地址：<input type="text" id="caddr" /><br />
        <br />
        <input type="button" value="修改" onclick="updateCustomerInfo()" />
    </div>
    <div id="tb" style="padding: 5px; height: auto">
        <div style="margin-bottom: 5px">
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-add',plain:true" onclick="addCustomer()">添 加</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-edit',plain:true">修 改</a>
            <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-remove',plain:true">删 除</a>
        </div>
        <div>
            用户名:
            <input id="UserName" name="UserName" addClear class="easyui-textbox" style="width: 120px" />
            生日:
            <input id="DateFrom" name="DateFrom" addClear class="easyui-datebox" data-options="buttons:buttons" style="width: 120px" />
            -
            <input id="DateTo" name="DateTo" addClear class="easyui-datebox" data-options="buttons:buttons" style="width: 120px" />
            职位: 
			<input id="PowerLevel" name="PowerLevel" addClear class="easyui-combobox" data-options="url:'../Ashx/user.ashx?action=getPosition',method:'get',valueField:'PowerLevelID',textField:'PowerName',panelHeight:'auto'" />
            <a href="#" class="easyui-linkbutton" iconcls="icon-search" onclick="doSearch()">搜索</a>
        </div>
        <script>
            var buttons = $.extend([], $.fn.datebox.defaults.buttons);
            buttons.splice(1, 0, {
                text: '清空',
                handler: function (target) {
                    if (target.id == "DateFrom") {
                        $("#DateFrom").datebox("setValue", "");
                        $("#DateFrom").datebox("hidePanel", "");
                    }
                    if (target.id == "DateTo") {
                        $("#DateTo").datebox("setValue", "");
                        $("#DateTo").datebox("hidePanel", "");
                    }
                }
            });
        </script>
    </div>
</body>
</html>
