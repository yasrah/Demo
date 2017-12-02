//app.controller("ComplaintReportEditController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportEditFactory", function ($scope, $http, $window, $timeout, ComplaintReportEditFactory) {

//    $scope.error = null;
//    $scope.success = false;

//    $scope.init = function (id) {
//        ComplaintReportEditFactory.GetComplaintReport(id).then(function (data) {
//            $scope.complaintReport = data.data;
//        });
//    };

//    var ti = function () {
//        timer = $timeout(function () {
//            $scope.success = false;
//        }, 3000);
//    };

//    var tiDelete = function () {
//        timer = $timeout(function () {
//            $scope.success = false;
//            $window.location.href = "/reklamasjonsrapporter/soek";
//        }, 3000);
//    };

//    $scope.submit = function () {
//        $scope.success = false;
//        $timeout.cancel(ti);
//        ComplaintReportEditFactory.UpdateComplaintReport($scope.complaintReport).then(function success(response) {
//            $scope.complaintReport = response.data;
//            $scope.success = true;
//            ti();

//        }, function error(response) {
//            if (response.status == 401) {
//                $window.location.href = "/login-gikk galt";
//            }
//            else {
//                $scope.error = "Noe gikk galt. Prøv igjen senere!"
//            }
//        });
//    };


//    $scope.delete = function (id) {
//        $scope.success = false;
//        $timeout.cancel(ti);
//        ComplaintReportEditFactory.DeleteComplaintReport(id).then(function success(response) {
//            $scope.success = true;
//            tiDelete();
//        }, function error(response) {
//            if (response.status == 401) {
//                alert("ikke tilgang");
//                $window.location.href = "/login-gikk galt";
//            }
//            else {
//                $scope.error = "Noe gikk galt. Prøv igjen senere!"
//            }
//        });
//    };
//}]);

app.controller("ComplaintReportEditController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportFactory", function ($scope, $http, $window, $timeout, ComplaintReportFactory) {

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
    var options = {
        weekday: "long", year: "numeric", month: "short",
        day: "numeric", hour: "2-digit", minute: "2-digit"
    };
    $scope.complaintReport = null;

    function updateModel() {

        $scope.complaintReportFormated = {
            ComplaintReportId: $scope.complaintReport.ComplaintReportId,
            Product: $scope.complaintReport.Product.ProductId,
            ProductModel: $scope.complaintReport.ProductModel.ProductModelId,
            Customer: {
                Name: $scope.complaintReport.Customer.Name,
                Address: $scope.complaintReport.Customer.Address,
                CustomerType: $scope.complaintReport.Customer.CustomerType,
            },
            MachineNo1: $scope.complaintReport.MachineNo1,
            MachineNo2: $scope.complaintReport.MachineNo2,
            EngineNo: $scope.complaintReport.EngineNo,
            TimeAmount: $scope.complaintReport.TimeAmount,
            SaleDate: new Date($scope.complaintReport.SaleDate),
            DamageDate: new Date($scope.complaintReport.DamageDate),
            RepairDate: new Date($scope.complaintReport.RepairDate),
            Error: $scope.complaintReport.MachineNo1,
            ReasonForError: $scope.complaintReport.ReasonForError,
            PartsMarked: $scope.complaintReport.PartsMarked,
            PartsReturned: $scope.complaintReport.PartsReturned,
            CreateEmail: $scope.complaintReport.CreateEmail,
            Status: $scope.complaintReport.Status,
            Closed: $scope.complaintReport.Closed,

            ProductModels: $scope.complaintReport.ProductModels,
            Products: $scope.complaintReport.Products,


        };
    }


    //DealerFactory.GetAllDealers().then(function (data) {
    //    $scope.allDealers = data.data;
    //});

    //ComplaintReportShowFactory.GetDealersCount().then(function (data) {
    //    $scope.dealersCount = data.data;
    //});
    //ComplaintReportShowFactory.GetReportsCount().then(function (data) {
    //    $scope.reportsCount = data.data;
    //});

    //ComplaintReportShowFactory.GetUnprocessedCompalintReportsCount().then(function (data) {
    //    $scope.unprocessedReportsCount = data.data;
    //});

    //ComplaintReportShowFactory.GetUnderProcessCompalintReportsCount().then(function (data) {
    //    $scope.underProcessReportsCount = data.data;
    //});

    //ComplaintReportShowFactory.GetProcessedCompalintReportsCount().then(function (data) {
    //    $scope.processedReportsCount = data.data;
    //});

    ComplaintReportFactory.GetMyPageData().then(function (data) {
        $scope.currentDealerData = data.data;
    });

    //ComplaintReportShowFactory.GetProducts().then(function (data) {
    //    $scope.products = data.data;
    //});


    $scope.ProductChanged = function (id) {
        ComplaintReportFactory.GetProductModels(id).then(
            function success(response) {
                $scope.complaintReportFormated.ProductModels = response.data;
            },
            function error(response) {
                $scope.complaintReportFormated.ProductModels = null;
                //$scope.complaintReport.SelectedProductModel = null;
            }
        );
    };

    //$scope.ProductModelChanged = function (id) {
    //    alert("ProductModelChanged ()" + id);

    //};

    //$scope.ProductModelChanged = function () {
    //    //$scope.ProductChanged();
    //}


    //$scope.error = null;
    //$scope.success = false;

    //var ti = function () {
    //    timer = $timeout(function () {
    //        $window.location.href = "/reklamasjonsrapporter/vis?id=" + $scope.complaintReport.ComplaintReportId;
    //        $scope.success = false;
    //    }, 3000);
    //};

    $scope.submit = function () {
        alert("Submit hahah...");
        alert("2 Submit hahah...");

        ComplaintReportFactory.UpdateComplaintReport($scope.complaintReportFormated).then(function success(response) {
            $scope.complaintReport = response.data;
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
        //$scope.complaintReport.ComplaintReportId = id;
        ComplaintReportFactory.GetComplaintReport(id).then(function (data) {
            $scope.complaintReport = data.data;
            //$scope.ProductChanged($scope.complaintReport.SelectedProduct);
            updateModel();
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
                    url: "http://dev.smarthus.no/Umbraco/Api/dealer/GetAllCustomersName",
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

