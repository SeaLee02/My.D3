jQuery.sealee = {
    p: function (s) {
        return s < 10 ? '0' + s : s;
    },
    getNowDate: function getNowDate() {
        var myDate = new Date();
        var year = myDate.getFullYear();
        var month = myDate.getMonth() + 1;
        var date = myDate.getDate();
        var h = myDate.getHours();
        var m = myDate.getMinutes();
        var s = myDate.getSeconds();

        var nowDate = year + '-' + this.p(month) + "-" + this.p(date) + " " + this.p(h) + ':' + this.p(m) + ":" + this.p(s);
        return nowDate;
    },
    //在Jquery里格式化Date日期时间数据
    timeStamp2String: function timeStamp2String(time) {
        var datetime = new Date();
        datetime.setTime(time);
        var year = datetime.getFullYear();
        var month = datetime.getMonth() + 1 < 10 ? "0" + (datetime.getMonth() + 1) : datetime.getMonth() + 1;
        var date = datetime.getDate() < 10 ? "0" + datetime.getDate() : datetime.getDate();
        var hour = datetime.getHours() < 10 ? "0" + datetime.getHours() : datetime.getHours();
        var minute = datetime.getMinutes() < 10 ? "0" + datetime.getMinutes() : datetime.getMinutes();
        var second = datetime.getSeconds() < 10 ? "0" + datetime.getSeconds() : datetime.getSeconds();
        return year + "-" + month + "-" + date + " " + hour + ":" + minute + ":" + second;
    },
    getQueryString: function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return decodeURI(r[2]); return null;
    },
    getCookie: function (cookieName) {
        return $.cookie(cookieName);
    },
    getCookieObj: function (cookieName) {
        var cookie = this.getCookie(cookieName);
        if (cookie) {
            return JSON.parse(cookie);
        } else {
            return null;
        }
    },
    setCookie: function (cookieName, cookieValue, expiresDay) {
        if (!expiresDay) {
            expiresDay = 1;
        }
        $.cookie(cookieName, cookieValue, { expires: expiresDay, path: '/' });
    },
    deleteCookie: function myfunction(cookieName) {
        $.cookie(cookieName, '', { expires: -1, path: '/' });
    },
    setUserInfo: function (data) {
        data = JSON.stringify(data);
        this.setCookie("cookieName", data, 7);
    },
    getUserInfo: function () {
        return this.getCookieObj("cookieName");
    },

    deleteUserInfo: function () {
        this.deleteCookie("cookieName");
    },
    deepCopy: function (data) {
        return JSON.parse(JSON.stringify(data));
    },
    parseQueryString: function (paramData) {
        if (!(typeof paramData == "string")) {
            return paramData;
        }
        var obj = {};
        var keyvalue = [];
        var key = "",
            value = "";
        var paraString = paramData.split("&");
        for (var i = 0; i < paraString.length; i++) {
            keyvalue = paraString[i].split("=");
            key = keyvalue[0];
            value = keyvalue[1];
            if (/^\d+-\d+-\d+$/.test(value)) {
                value = value + " 00:00:00";
            }
            if (value != "") {
                obj[key] = decodeURIComponent(value, true).replace("+", " ");
            }

        }
        return obj;
    },
    loginOut: function () {
        location.href = "/Home/Login";
    },
    getAuthorizationCookie: function () {
        var cookie = $.cookie('Abp.AuthToken');
        if (!cookie) {
            return null;
        } else {
            cookie = "Bearer " + cookie;
            return cookie
        }
    }
}