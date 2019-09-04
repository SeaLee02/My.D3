var util = {
    ajax: function (userOptions) {
        var $ = layui.$;
        userOptions = userOptions || {};
        if (!userOptions.type) {
            userOptions.type = "POST"
        }
        return $.Deferred(function ($dfd) {
            $.ajax(userOptions)
                .done(function (data, textStatus, jqXHR) {
                    if (userOptions.loadingIndex) {
                        layer.close(userOptions.loadingIndex);
                    }
                    $dfd.resolve(data);
                    userOptions.success && userOptions.success(data);
                }).fail(function (data) {
                    if (userOptions.loadingIndex) {
                        layer.close(userOptions.loadingIndex);
                    }
                    if (data.responseJSON) {
                        console.log(data.responseJSON.msg);
                    } else {
                        console.log(data.statusText);
                    }
                });
        });
    }
}

//var loading = layer.load();
//var options = {
//    url: '/api/fi/zd/Zdqz',
//    contentType: "application/json",
//    data: JSON.stringify(data),
//    loadingIndex: loading
//};
//var success = function (data) {
//    layer.msg(data.msg);
//    layer.close(index);
//    var index2 = parent.layer.getFrameIndex(window.name);
//    parent.layui.table.reload('table_ys_zd');//更新表格数据
//    parent.layer.close(index2);
//};
//util.ajax(options).done(success);