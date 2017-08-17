/// <reference path="angular.js" />
var app=angular.module("myApp", []).controller("myController", function ($scope) {
    $scope.menus = [
           {
               name: "用户管理", status: 1, url: "http://www.baidu.com"
           },
           {
               name: "菜单管理", status: 2, url: "http://www.baidu.com"
           },
           {
               name: "部门管理", status: 0, url: "http://www.baidu.com"
           },
           {
               name: "角色管理", status: 1, url: "http://www.baidu.com"
           },
           {
               name: "权限管理", status: 2, url: "http://www.baidu.com"
           }
    ];
});