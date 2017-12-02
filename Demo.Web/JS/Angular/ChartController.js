app.controller("ChartController", ["$scope", "$http", "$window", "$timeout", "ChartFactory", function ($scope, $http, $window, $timeout, ChartFactory) {

    // Debug
    //$scope.debug = "tata";
    //$scope.error = null;
    //$scope.success = false;
    //$scope.dealersCount = 0;
    $scope.chartData1 = null;

    //DealerFactory.GetAllDealers().then(function (data) {
    //    $scope.allDealers = data.data;
    //});
    function loadCharData() {
        Morris.Area({
            element: 'morris-area-chart',
            data: $scope.chartData1,
            xkey: 'Period',
            ykeys: ['Iphone', 'Ipad', 'Itouch'],
            labels: ['IPhone', 'IPad', 'IPod Touch'],
            pointSize: 2,
            hideHover: 'auto',
            resize: true,
            xLabels: 'Year'
        });

    }
    ChartFactory.GetChart1().then(function (data) {
        $scope.chartData1 = data.data;
        loadCharData();
    });
    //ChartFactory.GetReportsCount().then(function (data) {
    //    $scope.chartData1 = data.data;
    //});
    
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