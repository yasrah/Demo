app.controller("ComplaintReportController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportFactory", function ($scope, $http, $window, $timeout, ComplaintReportFactory) {

    // Debug
    $scope.debug = "tata";
    $scope.error = null;
    $scope.success = false;
    $scope.dealersCount = 0;
    $scope.unprocessedReportsCount = 0;
    $scope.underProcessReportsCount = 0;
    $scope.processedReportsCount = 0;

    $scope.wizard = {
        currentStep: 1,

    };

    $scope.newComplaintReport = {
        ComplaintReportId: null,
        SelectedProduct: null,
        SelectedProductModel: null,
        Customer: {
            Name: null,
            Address: null,
            CustomerType: null,
        },
        MachineNo1: null,
        MachineNo2: null,
        EngineNo: null,
        TimeAmount: null,
        SaleDate: null,
        DamageDate: null,
        RepairDate: null,
        Error: null,
        ReasonForError: null,
        PartsMarked: false,
        PartsReturned: false,
        CreateEmail: false,
        Status: null,
        Closed: false,
        ProductModels: null,
        Products: null,
        Closed: false
    }


    //DealerFactory.GetAllDealers().then(function (data) {
    //    $scope.allDealers = data.data;
    //});

    //ComplaintReportFactory.GetDealersCount().then(function (data) {
    //    $scope.dealersCount = data.data;
    //});
    //ComplaintReportFactory.GetReportsCount().then(function (data) {
    //    $scope.reportsCount = data.data;
    //});

    //ComplaintReportFactory.GetUnprocessedCompalintReportsCount().then(function (data) {
    //    $scope.unprocessedReportsCount = data.data;
    //});

    //ComplaintReportFactory.GetUnderProcessCompalintReportsCount().then(function (data) {
    //    $scope.underProcessReportsCount = data.data;
    //});

    //ComplaintReportFactory.GetProcessedCompalintReportsCount().then(function (data) {
    //    $scope.processedReportsCount = data.data;
    //});

    ComplaintReportFactory.GetMyPageData().then(function (data) {
        $scope.currentDealerData = data.data;
    });

    ComplaintReportFactory.GetProducts().then(function (data) {
        $scope.products = data.data;
    });


    $scope.ProductChanged = function (id) {
        ComplaintReportFactory.GetProductModels(id).then(
            function success(response) {
                $scope.productModels = response.data;
            },
            function error(response) {
                $scope.newComplaintReport.SelectedProductModel = null;
            }
        );
    };

    $scope.ProductModelChanged = function (id) {
        alert("ProductModelChanged ()" + id);

    };

    $scope.ProductModelChanged = function () {
        //$scope.ProductChanged();
    }


    $scope.error = null;
    $scope.success = false;

    var ti = function () {
        timer = $timeout(function () {
            $window.location.href = "/reklamasjonsrapporter/vis?id=" + $scope.newComplaintReport.ComplaintReportId;
            $scope.success = false;
        }, 3000);
    };

    $scope.submit = function () {
        alert("Submit...");
        //$scope.success = false;
        //$timeout.cancel(ti);
        ComplaintReportFactory.NewComplaintReport($scope.newComplaintReport).then(function success(response) {
            $scope.newComplaintReport = response.data;
            $scope.success = true;
            ti();

        }, function error(response) {
            if (response.status == 401) {
                $window.location.href = "/login-gikk galt";
            }
            else {
                $scope.error = "Noe gikk galt. Prøv igjen senere!"
            }
        });
    };

    $scope.init = function (id) {
        //$scope.newComplaintReport.ComplaintReportId = id;
        ComplaintReportFactory.GetComplaintReport(id).then(function (data) {
            $scope.newComplaintReport = data.data;
            $scope.ProductChanged($scope.newComplaintReport.SelectedProduct);

        });
    };


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
    

    $(document).ready(function () {
        //TypeAhead
        
        $.typeahead({
            input: '.js-typeahead-country_v1',
            order: "desc",
            source: {
                ajax: {
                    url: "http://local.demo.no/Umbraco/Api/ComplaintReportApi/GetAllCustomersName/",
                }
            },
            callback: {
                onInit: function (node) {
                    alert("oninit");
                    console.log('Typeahead Initiated on ' + node.selector);

                },
                onClickBefore: function () {
                    alert("onClickBefore");

                }
            }
        });
        // TypeAhead End
    });
}]);