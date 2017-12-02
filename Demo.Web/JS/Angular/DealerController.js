app.controller("DealerController", ["$scope", "$http", "$window", "$timeout", "DealerFactory", function ($scope, $http, $window, $timeout, DealerFactory) {

    // Debug
    $scope.debug = "tata";
    $scope.error = null;
    $scope.success = false;
    $scope.dealersCount = 0;
    $scope.reportsCount = 0;

    //DealerFactory.GetAllDealers().then(function (data) {
    //    $scope.allDealers = data.data;
    //});

    DealerFactory.GetDealersCount().then(function (data) {
        $scope.dealersCount = data.data;
    });
    DealerFactory.GetReportsCount().then(function (data) {
        $scope.reportsCount = data.data;
    });
    
    //$scope.submit = function () {
    //    MyPageFactory.UpdateMyPageData($scope.myPageData).then(function success(response) {
    //        $scope.myPageData = response.data;
    //        $scope.success = true;
    //        $timeout(function () {
    //            $scope.success = false;
    //        }, 8000);

    //    }, function error(response) {
    //        if (response.status == 401) {
    //            $scope.error = "Din sesjon er utgått. Logg inn på nytt!"
    //        }
    //        else {
    //            $scope.error = "Noe gikk galt. Prøv igjen senere!"
    //        }
    //    });
    //};
}]);