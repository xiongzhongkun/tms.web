/*****************************************************************
                  jQuery Ajax封装通用类  (linjq)       
*****************************************************************/
$(function () {
    /**
     * ajax封装
     * url 发送请求的地址
     * data 发送到服务器的数据，数组存储，如：{"date": new Date().getTime(), "state": 1}
     * async 默认值: true。默认设置下，所有请求均为异步请求。如果需要发送同步请求，请将此选项设置为 false。
     *       注意，同步请求将锁住浏览器，用户其它操作必须等待请求完成才可以执行。
     * type 请求方式("POST" 或 "GET")， 默认为 "GET"
     * dataType 预期服务器返回的数据类型，常用的如：xml、html、json、text
     * successfn 成功回调函数
     * errorfn 失败回调函数
     */
    jQuery.ax = function (url, data, async, type, dataType, successfn, errorfn) {
        async = (async == null || async == "" || typeof (async) == "undefined") ? "true" : async;
        type = (type == null || type == "" || typeof (type) == "undefined") ? "post" : type;
        dataType = (dataType == null || dataType == "" || typeof (dataType) == "undefined") ? "json" : dataType;
        data = (data == null || data == "" || typeof (data) == "undefined") ? { "date": new Date().getTime() } : data;
        $.ajax({
            type: type,
            async: async,
            data: data,
            url: url,
            dataType: dataType,
            success: function (d) {
                successfn(d);
            },
            error: function (e) {
                errorfn(e);
            }
        });
    };

    /**
     * ajax封装
     * url 发送请求的地址
     * data 发送到服务器的数据，数组存储，如：{"date": new Date().getTime(), "state": 1}
     * successfn 成功回调函数
     */
    jQuery.axs = function (url, data, successfn) {
        data = (data == null || data == "" || typeof (data) == "undefined") ? { "date": new Date().getTime() } : data;
        $.ajax({
            type: "post",
            data: data,
            url: url,
            dataType: "json",
            beforeSend: function (d)
            {
                $("#loadingToast").show();
            },
            complete: function (d,e) {
                $("#loadingToast").hide();
            },
            error: function(xhr,status,error)
            {
                $("#loadingToast").hide();
            },
            success: function (d) {
                $("#loadingToast").hide();
                successfn(d);
            }
        });
    };

    /**
     * ajax封装
     * url 发送请求的地址
     * data 发送到服务器的数据，数组存储，如：{"date": new Date().getTime(), "state": 1}
     * dataType 预期服务器返回的数据类型，常用的如：xml、html、json、text
     * successfn 成功回调函数
     * errorfn 失败回调函数
     */
    jQuery.axse = function (url, data, successfn, errorfn) {
        data = (data == null || data == "" || typeof (data) == "undefined") ? { "date": new Date().getTime() } : data;
        $.ajax({
            type: "post",
            data: data,
            url: url,
            dataType: "json",
            success: function (d) {
                successfn(d);
            },
            error: function (e) {
                errorfn(e);
            }
        });
    };


    /*
    时间转换
    */
    jQuery.formatDateTime=function(cellvalue){
        var date = new Date(parseInt(cellvalue.replace("/Date(", "").replace(")/", ""), 10));
        //月份为0-11，所以+1，月份小于10时补个0
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        return date.getFullYear() + "-" + month + "-" + currentDate + " " + date.getHours() + ":" + minutes;
    };
});


function handle_resp(e) {
    if (e.flag) {
        if (e.other == "跳转") {
            window.location.href = e.data;
        }
        else if (e.other == "列表") {
            bootbox.alert({
                message: e.msg,
                callback: function () {
                    setTimeout(function () {
                        $("#html_body").attr("style", "overflow-x:hidden");
                    }, 500);
                },
            });
            $(".fade").modal('hide');
            $("#loadingToast").hide();
            $("#" + e.data).DataTable().ajax.reload();
        }
        else {
            bootbox.dialog({
                message: e.msg,
                buttons: {
                    "success": {
                        "label": "确定",
                        "className": "btn-sm btn-primary"
                    }
                }
            });
        }
    } else {
        $("#loadingToast").hide();
        bootbox.dialog({
            message: e.msg,
            buttons: {
                "success": {
                    "label": "确定",
                    "className": "btn-sm btn-primary"
                }
            }
        });
    }
}

function failed_resp(e) {
    $("#loadingToast").hide();
    bootbox.dialog({
        message: "发起请求失败！",
        buttons: {
            "success": {
                "label": "确定",
                "className": "btn-sm btn-primary"
            }
        }
    });
}

function ajax_OnBegin() {
    $("#loadingToast").show();
}

function ajax_OnComplete() {
    $("#loadingToast").hide();
}
