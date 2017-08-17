/// <reference path="index.js" />
/// <reference path="angular.js" />
app.filter("status", function ($sce) {
    return function (status) {
        switch (status) {
            case 1:
                return $sce.trustAsHtml("<span style='color:green;'>启用<span>");
            case 2:
                return $sce.trustAsHtml("<span style='color:red;'>禁用<span>");
            case 0:
                return $sce.trustAsHtml("删除");
            default:
                return $sce.trustAsHtml("未知状态");
        }
    }
})
.filter("url", function ($sce) {
    return function (url)
    {
        return $sce.trustAsHtml("<a href='javascript:;'>查看详情</a>")
    }
});