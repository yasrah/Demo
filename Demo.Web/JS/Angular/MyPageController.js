app.controller("MyPageController", ["$scope", "$http", "$window", "$timeout", "MyPageFactory", function ($scope, $http, $window, $timeout, MyPageFactory) {

    // Debug
    $scope.debug = "tata";
    $scope.error = null;
    $scope.success = false;
    $scope.myPageData = null;

    MyPageFactory.GetMyPageData().then(function (response) {
        $scope.myPageData = response.data;
    });

    var ti = function () {
        timer = $timeout(function () {
            $scope.success = false;
        }, 3000);
    };
    //$scope.timer();
    $scope.submit = function () {
        $scope.success = false;
        $timeout.cancel(ti);
        MyPageFactory.UpdateMyPageData($scope.myPageData).then(function success(response) {
            $scope.myPageData = response.data;
            $scope.success = true;
            //var timer = $timeout(function () {
            //    $scope.success = false;
            //}, 8000);
           ti();

        }, function error(response) {
            if (response.status == 401) {
                $window.location.href = "/login";
            }
            else {
                $scope.error = "Noe gikk galt. Prøv igjen senere!"
            }
        });
    };
}]);

//app.directive('loading', ['$http', function ($http) {
//    return {
//        restrict: 'A',
//        link: function (scope, elm, attrs) {
//            scope.isLoading = function () {
//                return $http.pendingRequests.length > 0;
//            };
//            scope.$watch(scope.isLoading, function (v) {
//                if (v) {
//                    elm.show();
//                } else {
//                    elm.hide();
//                }
//            });
//        }
//    };
//}]);