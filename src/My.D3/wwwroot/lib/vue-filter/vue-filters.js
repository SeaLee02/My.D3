// 转成大写
Vue.filter('uppercase', function (value) {
    if (!value) return ''
    // 返回处理后的值
    return value.toUpperCase();
})
// 
Vue.filter('lowercase', function (value) {
    if (!value) return ''
    // 返回处理后的值
    return value.toLowerCase();
})
// 首字母大写
Vue.filter('capitalize', function (value) {
    if (!value) return ''
    value = value.toString();
    return value.charAt(0).toUpperCase() + value.slice(1);
})
// 格式化时间
Vue.filter('parseShortDate', function (value) {
    if (!value) return ''
    return moment(value).format('YYYY-MM-DD')
})
Vue.filter('parseTime', function (value) {
    if (!value) return ''
    return moment(value).format('HH:mm:ss')
})
// 货币格式化
Vue.filter('currency', function (price) {
    if (!price) return 0;
    return formatCurrency(price);
})
// 百分号格式化
Vue.filter('percent', function (price, fixPoint) {
    if (!fixPoint) {
        fixPoint = 2;
    }
    if (!price) return "0.00%";
     price = (price * 100).toFixed(fixPoint);
     var result = price.toString() + "%";
     return result;
})

/** 
 * 将数值四舍五入(保留2位小数)后格式化成金额形式 
 * 
 * @param num 数值(Number或者String) 
 * @return 金额格式的字符串,如'1,234,567.45' 
 * @type String 
 */
function formatCurrency(num) {
    num = num.toString().replace(/\$|\,/g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num + '.' + cents);
}  