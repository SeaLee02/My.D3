//将form表单转换为json数据
$.fn.serializeJson = function () {
    var serializeObj = {};
    var array = this.serializeArray(); //将form表单序列化数组对象 
    var str = this.serialize();  //将form表单序列化字符串
    $(array).each(function () {  //遍历表单数组拼接json串
        if (serializeObj[this.name]) {
            if ($.isArray(serializeObj[this.name])) {
                serializeObj[this.name].push(this.value);
            } else {
                serializeObj[this.name] = [serializeObj[this.name], this.value];
            }
        } else {
            serializeObj[this.name] = this.value;
        }
    });
    return serializeObj;
};

jQuery.li = {
    //拼接查询语句
    getFilters: function () {
        var advDiv = $("#searchform");
        var allInput = $("[data-op]", advDiv);
        var filters = [];
        for (var i = 0; i < allInput.length; i++) {
            var item = $(allInput[i]);
            var isRepeat = false;
            var value = item[0].value;
            if (value != "") {
                for (var j = 0; j < filters.length; j++) {

                    if (item.data("name") == filters[j].name) {
                        filters[j].value2 = value;
                        isRepeat = true;
                    }
                }
                if (!isRepeat) {

                    var op = item.data("op");
                    console.log(op);
                    if (!op) {
                        op = "like";
                    }
                    var dataType = item.data("datatype");
                    if (!dataType) {
                        dataType = "nvarchar";
                    }
                    if (/^\d+-\d+-\d+$/.test(value)) {
                        value = value + " 00:00:00";
                    }
                    // 枚举是0的话那么不加入
                    if (value == "0") {
                        continue;
                    }
                    if (value == "是") {
                        value = 1;
                    }
                    if (value == "否") {
                        value = 0;
                    }
                    filters.push({ attribute: item.data("name"), operatoer: op, value: value, datatype: dataType });
                }
            }
        }
        if (filters.length >= 1) {
            var myFilter = {
                type: "and",
                conditions: filters
            };
            return myFilter;
        }
        return null;
    }
}