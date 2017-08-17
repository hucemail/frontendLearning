var app = angular.module("myApp", []).controller("myController", function ($scope) {
    $scope.step = "register_step_1.html";
    $scope.next = function (i) {
        $scope.step = "register_step_" + i + ".html";
        $scope.setStepsTitle(i);
    }
    $scope.pre = function (i) {
        $scope.step = "register_step_" + i + ".html";
        $scope.setStepsTitle(i);
    }
    $scope.user = {  };
    $scope.submit = function (i) {
        console.log($scope.user);
        if ($scope.user.email == undefined) {
            return false;
        }
        $scope.step = "register_step_" + i + ".html";
        $scope.setStepsTitle(i);
        
    }
    $scope.setStepsTitle = function (index) {
        var lis = document.getElementById("steps").getElementsByTagName("li");
        for (var i = 1; i <= lis.length; i++) {
            lis[i-1].className =(i>index)?"":"active";
        }
    }
});