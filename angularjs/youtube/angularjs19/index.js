var app = angular.module("myApp", []).controller("myController", function ($scope, stringService) {
    $scope.processString = function (input) {
        $scope.output = stringService.processString(input);
    };
});
