$(function () {
    loadProData();
})
function loadProData() {
    // 省级 
    $('#loc_rprovince').combobox({
        method: 'get',
        url: 'combox_province_data.json',
        valueField: 'ProID', //值字段
        textField: 'name', //显示的字段
        panelHeight: '200',
        editable: true, //不可编辑，只能选择
        value: '--省份--',
        onChange: function (newId, oldId) {
            var p1 = newId;
            var p2 = oldId;
            $('#loc_rcity').combobox('clear');
            $('#loc_rcity').combobox({
                method: 'get',
                valueField: 'CityID', //值字段
                textField: 'name', //显示的字段
                url: 'combox_city_data.json',
                panelHeight: '200',
                editable: true, //不可编辑，只能选择
                value: '--市--',
                onLoadSuccess: function (data) {
                    var json = "[";
                    var id = data[0]["ProID"];
                    if (p1 == id) {
                        $.each(data, function (i, n) {
                            //获取对象中属性为username,content的值 
                            var id = n["ProID"];
                            var cityID = n["CityID"];
                            var name = n["name"];
                            if (p1 == id) {
                                json += "{\"CityID\":" + cityID + ",\"name\":\"" + name + "\"},";
                            }
                        });
                        if (json.endsWith(",")) {
                            json = json.substring(0, json.length - 1);
                        }
                        json = json + "]";
                        $('#loc_rcity').combobox('loadData', json);\}
                }
               
            });
        }
    });
    //$('#loc_rcity').combobox({
    //    valueField: 'CityID', //值字段
    //    textField: 'name', //显示的字段
    //    url: 'combox_city_data.json',
    //    panelHeight: '200',
    //    editable: true, //不可编辑，只能选择
    //    value: '--市--'
    //});
}