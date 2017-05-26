<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="MyEasyUI.Role.AddRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../themes/default/easyui.css" rel="stylesheet" />
    <link href="../themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../js/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="../js/commjs.js"></script>
</head>
<body>
    <a href="#" class="easyui-linkbutton" onclick="getChecked()">GetChecked</a>
    <div class="easyui-panel" style="padding: 5px">
        <ul id="tt" class="easyui-tree" data-options="url:'../Menu/tree_data1.json',method:'get',animate:true,checkbox:true"></ul>
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
</body>
</html>
