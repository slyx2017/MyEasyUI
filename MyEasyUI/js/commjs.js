﻿$(function () {
    TabsMenuRight();
});
/** 
 * 更换EasyUI主题的方法 
 * @param themeName 
 * 主题名称 
 */
changeTheme = function (themeName) {
    var $easyuiTheme = $('#easyuiTheme');
    var url = $easyuiTheme.attr('href');
    var href = url.substring(0, url.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
    $easyuiTheme.attr('href', href);
    var $iframe = $('iframe');
    if ($iframe.length > 0) {
        for (var i = 0; i < $iframe.length; i++) {
            var ifr = $iframe[i];
            $(ifr).contents().find('#easyuiTheme').attr('href', href);
        }
    }
    $.cookie('easyuiThemeName', themeName, {
        expires: 7
    });
};
//创建iframe
//function CreateFrame(url) {
//    var content = "<iframe src='" + url + "' width='100%' height='99%' frameborder='0' scrolling='auto' ></iframe>";
//    return content;
//}
function createFrame(url) {
    var s = '<iframe frameborder="0" scrolling="auto" src="' + url + '" style="width:100%;height:100%;"></iframe>';
    return s;
}
//在右边center区域打开菜单，新增tab  
function Open(text, url) {
    if ($("#tabs").tabs('exists', text)) {
        $('#tabs').tabs('select', text);
    } else {
        $('#tabs').tabs('add', {
            title: text,
            iconCls: "icon-ok",
            closable: true,
            content: url
        });
    }
}
//创建Accrodion菜单
function createAccrodion(data) {
    var menuhtml = $("#menu").html().trim().length;
    if (menuhtml <= 0) {
        $.each(data, function (i, n) {
            $(".easyui-accordion").accordion('add',
              {
                  iconCls: "icon-search",
                  title: n.text,
                  content: moduleIndex(n.children)
              });
        });
        $(".easyui-accordion").accordion();
        $('.easyui-accordion li a').click(function () {
            var tabTitle = $(this).text();
            var url = $(this).attr("way");
            addTab(tabTitle, url);
            $('.easyui-accordion li').removeClass("tree-node-selected");
            $(this).parent().parent().addClass("tree-node-selected");
        }).hover(function () {
            $(this).parent().addClass("hover");
        }, function () {
            $(this).parent().removeClass("hover");
        });
       
    }
}

function addTab(subtitle, url) {
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content:createFrame(url),
            iconCls: "icon-ok",
            closable: true,
        });
        //$('#tabs div').removeClass("panel-body");
    } else {
        $('#tabs').tabs('select', subtitle);
    }
    tabClose();
}

function tabClose() {
    /*双击关闭TAB选项卡*/
    $(".tabs-inner").dblclick(function () {
        var subtitle = $(this).children(".tabs-closable").text();
        $('#tabs').tabs('close', subtitle);
    })
}
//在右边center区域打开菜单
function moduleIndex(menusData) {
    var text = "";
    text += '<ul class="tree-node" style="text-align:left;padding-left:0px;list-style:none">';
    $.each(menusData, function (j, o) {
        text += '<li style="height:25px;padding:0px 0px;"><div style="height:25px"><a target="mainFrame" way="' + o.attributes.url + '"><div style="float:left;width:90%;padding:0px 0px;"><div class="" style="float:left;"></div><div>' + o.text + '</div></div></a></div></li> ';
    });
    text += '</ul>';
    return text;
}
//tabs的右键菜单
function TabsMenuRight() {
    //绑定tabs的右键菜单  
    $("#tabs").tabs({
        onContextMenu: function (e, title) {
            e.preventDefault();
            $("#tabsMenu").menu('show', {
                left: e.pageX - 2,
                top: e.pageY - 2
            }).data("tabTitle", title);
        }
    });
    //刷新
    $("#m-refresh").click(function () {
        var currTab = $('#tabs').tabs('getSelected');    //获取选中的标签项
        var url = $(currTab.panel('options').content).attr('src');    //获取该选项卡中内容标签（iframe）的 src 属性
        /* 重新设置该标签 */
        $('#tabs').tabs('update', {
            tab: currTab,
            options: {
                content: createFrame(url)
            }
        })
    });
    //关闭所有
    $("#m-closeall").click(function () {
        $(".tabs li").each(function (i, n) {
            var title = $(n).text();
            $('#tabs').tabs('close', title);
        });
    });

    //除当前之外关闭所有
    $("#m-closeother").click(function () {
        var currTab = $('#tabs').tabs('getSelected');
        currTitle = currTab.panel('options').title;

        $(".tabs li").each(function (i, n) {
            var title = $(n).text();

            if (currTitle != title) {
                $('#tabs').tabs('close', title);
            }
        });
    });

    //关闭当前
    $("#m-close").click(function () {
        var currTab = $('#tabs').tabs('getSelected');
        currTitle = currTab.panel('options').title;
        $('#tabs').tabs('close', currTitle);
    });
    //关闭当前右侧的TAB
    $('#m-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            //msgShow('系统提示','后边没有啦~~','error');
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
    $('#m-tabcloseleft').click(function () {
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
    $("#m-exit").click(function () {
        $('#tabsMenu').menu('hide');
    })
}
//dialog遮罩层全局
function maskInit() {
    var sWidth = document.documentElement.clientWidth;
    var sHeight = document.documentElement.clientHeight;
    //获取页面的可视区域高度和宽度  
    var wHeight = document.documentElement.clientHeight;
    var oMask = document.getElementById("mask");
    var oMaskIframe = document.getElementById("maskIframe");

    oMask.style.height = sHeight + "px";
    oMask.style.width = sWidth + "px";
    oMask.style.background = "#ccc";
    oMask.style.position = "fixed";
    oMask.style.zIndex = 5;
    oMask.style.opacity = "0.3";
    oMask.style.display = "none";
}
function globalShade() {
    //获取页面的高度和宽度  

    if (window.parent.document.getElementById('mask')) {

        window.parent.document.getElementById('mask').style.display = "block";

    }
    if (document.getElementById("maskIframe")) {
        document.getElementById("maskIframe").style.display = "block";


    }


};
function deleteGlobalShade() {
    if (window.parent.document.getElementById('mask')) {
        window.parent.document.getElementById('mask').style.display = "none";

    }
    if (document.getElementById("maskIframe")) {

        document.getElementById("maskIframe").style.display = "none";

    }

};

/*
 * 为‘文本框’列表添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4TextBox(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.textbox('getIcon', 0);
        if (theObj.textbox('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.textbox({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.textbox('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //根据目前值，确定是否显示清除图标
    showIcon();
}

/*
 * 为‘下拉列表框’添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4Combobox(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.combobox('getIcon', 0);
        if (theObj.combobox('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.combobox({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.combobox('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //初始化确认图标显示
    showIcon();
}


/*
 * 为‘数据表格下拉框’添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4Combogrid(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.combogrid('getIcon', 0);
        if (theObj.combogrid('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.combogrid({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.combogrid('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //初始化确认图标显示
    showIcon();
}

/*
 * 为‘数值输入框’添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4Numberbox(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.numberbox('getIcon', 0);
        if (theObj.numberbox('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.numberbox({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.numberbox('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //初始化确认图标显示
    showIcon();
}

/*
 * 为‘日期选择框’添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4Datebox(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.datebox('getIcon', 0);
        if (theObj.datebox('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.datebox({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.datebox('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //初始化确认图标显示
    showIcon();
}


/*
 * 为‘日期时间选择框’添加‘清除’图标
 * 该实现使用了 onChange 事件，如果用户需要该事件，可传入自定义函数，会自动回调 。
 */
function addClear4Datetimebox(theId, onChangeFun) {
    var theObj = $(theId);

    //根据当前值，确定是否显示清除图标
    var showIcon = function () {
        var icon = theObj.datetimebox('getIcon', 0);
        if (theObj.datetimebox('getValue')) {
            icon.css('visibility', 'visible');
        } else {
            icon.css('visibility', 'hidden');
        }
    };

    theObj.datetimebox({
        //添加清除图标
        icons: [{
            iconCls: 'icon-clear',
            handler: function (e) {
                theObj.datetimebox('clear');
            }
        }],

        //值改变时，根据值，确定是否显示清除图标
        onChange: function () {
            if (onChangeFun) {
                onChangeFun();
            }
            showIcon();
        }

    });

    //初始化确认图标显示
    showIcon();
}
//自动填加清除功能 （组件需要增加 addClear属性 ）
function autoAddClear() {
    var arr = $("input[addClear]");
    for (var i = 0; i < arr.length; i++) {
        var oneInput = $(arr[i]);
        var theId = oneInput.attr("id");
        theId = theId.replace('.', '\\.');
        var theClass = oneInput.attr("class");

        if (theClass.indexOf("easyui-textbox") != -1) {//文本框
            addClear4TextBox("#" + theId);
        }
        else if (theClass.indexOf("easyui-combobox") != -1) {//下拉列表框
            addClear4Combobox("#" + theId);
        }
        else if (theClass.indexOf("easyui-combogrid") != -1) {//数据表格下拉框
            addClear4Combogrid("#" + theId);
        }
        else if (theClass.indexOf("easyui-numberbox") != -1) {//数值输入框
            addClear4Numberbox("#" + theId);
        }
        else if (theClass.indexOf("easyui-datebox") != -1) {//日期选择框
            addClear4Datebox("#" + theId);
        }
        else if (theClass.indexOf("easyui-datetimebox") != -1) {//日期选择框
            addClear4Datetimebox("#" + theId);
        }
    }
}
