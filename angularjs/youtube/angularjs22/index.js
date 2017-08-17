var myApp= angular.module("myApp", []).controller("myController", function ($scope,$anchorScroll,$location) {
    $scope.scrollTo = function (scrollLocation) {
        if($location.hash(scrollLocation))
        {
            console.log($location);
            $anchorScroll.yOffset = 20;
            $anchorScroll();
        }
    }
});