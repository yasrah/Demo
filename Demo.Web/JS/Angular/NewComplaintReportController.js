app.controller("NewComplaintReportController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportFactory", function ($scope, $http, $window, $timeout, ComplaintReportFactory) {

    // Debug
    $scope.error = null;
    $scope.success = false;
    $scope.dealersCount = 0;
    $scope.unprocessedReportsCount = 0;
    $scope.underProcessReportsCount = 0;
    $scope.processedReportsCount = 0;

    $scope.wizard = {
        currentStep: 1,
    };

   
    $scope.onSelect = function (part) {
        $scope.newComplaintReport.Parts.push(part);
    }
    $scope.removePart = function (part) {
        var partIndex = $scope.newComplaintReport.Parts.indexOf(part);
        $scope.newComplaintReport.Parts.splice(partIndex, 1);
    }

    $scope.getTotalSum = function () {
        var sum = 0;
        angular.forEach($scope.newComplaintReport.Parts, function (part) {
            sum = sum + part.Price * part.Amount;
        });
        return sum;
    }

    $scope.selectedCustomer = null;
    $scope.isCustomerFieldsChanged = false;
    $scope.existingCustomerSelected = false;

    $scope.customerFieldsChanged = function () {
        $scope.isCustomerFieldsChanged = true;
    }
    $scope.asyncSelected = null;
    $scope.customers = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];


    //$scope.getLocation = function (val) {
    //    return $http.get('http://local.demo.no/Umbraco/Api/complaintreportapi/GetAllCustomersName', {
    //        params: {
    //            query: val,
    //            sensor: false
    //        }
    //    }).then(function (response) {
    //        return response.data.map(function (item) {
    //            return item;
    //        });
    //    });
    //};

    $scope.getParts = function (query) {
        return $http.get('http://local.demo.no/umbraco/api/complaintreportapi/getpartsbyquery', {
            params: {
                query: query
            }
        }).then(function (response) {
            return response.data.map(function (item) {
                return item;
            });
        });
    };

    //$scope.products = {};
    //$scope.productModels = {};
    $scope.newComplaintReportId = null;

    $scope.newComplaintReport = {
        Product: null,
        ProductModel: null,
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
        Parts: []
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
            alert($scope.newComplaintReportId);
            $window.location.href = "/reklamasjonsrapporter/vis?id=" + $scope.newComplaintReportId;
            $scope.success = false;
        }, 3000);
    };

    $scope.submit = function () {
        alert("Submit...");
        //$scope.success = false;
        //$timeout.cancel(ti);
        ComplaintReportFactory.NewComplaintReport($scope.newComplaintReport).then(function success(response) {
            $scope.newComplaintReportId = response.data;
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
                    url: "http://local.demo.no/Umbraco/Api/complaintreportapi/GetAllCustomersName",
                }
            },
            callback: {
                onInit: function (node) {
                    alert("oninit..");
                    console.log('Typeahead Initiated on ' + node.selector);

                },
                onClickBefore: function () {
                    alert("onClickBefore");
                    $scope.existingCustomerSelected = true;
                }
            }
        });
        // TypeAhead End
    });
}]);