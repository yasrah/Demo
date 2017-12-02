app.controller("ComplaintReportShowController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportShowFactory", function ($scope, $http, $window, $timeout, ComplaintReportShowFactory) {

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
    $scope.complaintReport = {
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
    }
    function updateModel() {

        $scope.complaintReportFormated = {
            ComplaintReportId: $scope.complaintReport.ComplaintReportId,
            SelectedProduct: $scope.complaintReport.SelectedProduct,
            SelectedProductModel: $scope.complaintReport.SelectedProductModel,
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


        }
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

    ComplaintReportShowFactory.GetMyPageData().then(function (data) {
        $scope.currentDealerData = data.data;
    });

    //ComplaintReportShowFactory.GetProducts().then(function (data) {
    //    $scope.products = data.data;
    //});


    $scope.ProductChanged = function (id) {
        ComplaintReportShowFactory.GetProductModels(id).then(
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

    //$scope.submit = function () {
    //    alert("Submit...");
    //    //$scope.success = false;
    //    //$timeout.cancel(ti);
    //    ComplaintReportShowFactory.NewComplaintReport($scope.complaintReport).then(function success(response) {
    //        $scope.complaintReport = response.data;
    //        $scope.success = true;
    //        ti();

    //    }, function error(response) {
    //        if (response.status == 401) {
    //            $window.location.href = "/login-gikk galt";
    //        }
    //        else {
    //            $scope.error = "Noe gikk galt. Prøv igjen senere!"
    //        }
    //    });
    //};

    $scope.init = function (id) {
        //$scope.complaintReport.ComplaintReportId = id;
        ComplaintReportShowFactory.GetComplaintReport(id).then(function (data) {
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
}]);