app.controller("ShowComplaintReportController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportFactory", function ($scope, $http, $window, $timeout, ComplaintReportFactory) {

    // Debug
    $scope.error = null;
    $scope.success = false;
    $scope.editing = false;

    $scope.wizard = {
        currentStep: 1,
    };

    $scope.onSelect = function (part) {
        $scope.complaintReportFormatted.Parts.push(part);
    }
    $scope.removePart = function (part) {
        var partIndex = $scope.complaintReportFormatted.Parts.indexOf(part);
        $scope.complaintReportFormatted.Parts.splice(partIndex, 1);
    }

    $scope.getTotalSum = function () {
        var sum = 0;
        angular.forEach($scope.complaintReportFormatted.Parts, function (part) {
            sum = sum + part.Price * part.Amount;
        });
        return sum;
    }

    $scope.changeEditMode = function () {
        if ($scope.currentDealerData.IsAdmin) {
            $scope.editing = !$scope.editing;

        } else {
            if ($scope.complaintReportFormatted.Status == 0) {
                $scope.editing = !$scope.editing;
            }
        }
    }

    //$scope.canEdit = function () {
    //    if ($scope.currentDealerData.IsAdmin) {
    //        return true;

    //    } else {
    //        if ($scope.complaintReportFormatted.Status != 0) {
    //            return false;
    //        }
    //    }
    //}

    $scope.canEdit = function () {

        return $scope.currentDealerData.IsAdmin || ($scope.complaintReportFormatted.Status == 0);
    }

    $scope.discardChanges = function () {
        $scope.changeEditMode();
        $scope.init($scope.complaintReportFormatted.ComplaintReportId);
    }

    $scope.sendToApproval = function () {
        if (window.confirm('Are you sure you want to send to approval this Id = ' + $scope.complaintReportFormatted.ComplaintReportId + '?')) {
            $scope.changeEditMode();
            ComplaintReportFactory.SendToApproval($scope.complaintReportFormatted.ComplaintReportId).then(
                function success(response) {
                    $scope.complaintReport.Status = 'Sendt til godkjenning';
                    updateModel();
                },
                function error(response) {
                    alert("Error in SendToApproval");
                }
            );
        }
    }

    $scope.approve = function () {
        if (window.confirm('Are you sure you want to send to approval this Id = ' + $scope.complaintReportFormatted.ComplaintReportId + '?')) {
            $scope.changeEditMode();
            ComplaintReportFactory.Approve($scope.complaintReportFormatted.ComplaintReportId).then(
                function success(response) {
                    $scope.complaintReport.Status = 'Godkjent';
                    updateModel();
                },
                function error(response) {
                    alert("Error in SendToApproval");
                }
            );
        }
    }

    $scope.deny = function () {
        if (window.confirm('Are you sure you want to send to deny this Id = ' + $scope.complaintReportFormatted.ComplaintReportId + '?')) {
            $scope.changeEditMode();
            ComplaintReportFactory.Deny($scope.complaintReportFormatted.ComplaintReportId).then(
                function success(response) {
                    $scope.complaintReport.Status = 'Avslått';
                    updateModel();
                },
                function error(response) {
                    alert("Error in SendToApproval");
                }
            );
        }
    }

    $scope.sendToDraft = function () {
        if (window.confirm('Are you sure you want to send to deny this Id = ' + $scope.complaintReportFormatted.ComplaintReportId + '?')) {
            $scope.changeEditMode();
            ComplaintReportFactory.SendToDraft($scope.complaintReportFormatted.ComplaintReportId).then(
                function success(response) {
                    $scope.complaintReport.Status = 0;
                    updateModel();
                },
                function error(response) {
                    alert("Error in SendToApproval");
                }
            );
        }
    }

    $scope.delete = function () {
        if (window.confirm('Are you sure you want to delete this Id = ' + $scope.complaintReportFormatted.ComplaintReportId + '?')) {
            alert("TODO: delete this");
        }
    }


    $scope.selectedCustomer = null;
    $scope.isCustomerFieldsChanged = false;
    $scope.existingCustomerSelected = false;

    $scope.customerFieldsChanged = function () {
        $scope.isCustomerFieldsChanged = true;
    }
    $scope.asyncSelected = null;
    $scope.customers = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 'New Jersey', 'New Mexico', 'New York', 'North Dakota', 'North Carolina', 'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'];

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

    $scope.existingComplaintReportId = null;

    $scope.complaintReport = {
        ComplaintReportId: null,
        Customer: {
            Customer: null,
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
        PartsMarked: 'Nei',
        PartsReturned: 'Nei',
        CreateEmail: 'Nei',
        Status: null,
        Closed: false,
        ProductModels: null,
        Products: null,
        Parts: null,
        SentToApproval: false
    }
    $scope.ProductChanged = function (id) {
        ComplaintReportFactory.GetProductModels(id).then(
            function success(response) {
                $scope.complaintReportFormatted.ProductModels = response.data;
            },
            function error(response) {
                $scope.complaintReportFormatted.ProductModel = null;
            }
        );
        //updateModel();
    };
    function updateModel() {

        $scope.complaintReportFormatted = {
            ComplaintReportId: $scope.complaintReport.ComplaintReportId,
            Product: $scope.complaintReport.SelectedProduct,
            ProductModel: $scope.complaintReport.SelectedProductModel,
            Customer: {
                CustomerId: $scope.complaintReport.Customer.CustomerId,
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
            SelectedProductModel: $scope.complaintReport.SelectedProductModel,
            SelectedProduct: $scope.complaintReport.SelectedProduct,
            Products: $scope.complaintReport.Products,
            Parts: $scope.complaintReport.Parts,
            SentToApproval: $scope.complaintReport.SentToApproval,
        }
    }


    ComplaintReportFactory.GetMyPageData().then(function (data) {
        $scope.currentDealerData = data.data;
    });

    //$scope.ProductChanged = function (id) {
    //    ComplaintReportFactory.GetProductModels(id).then(
    //        function success(response) {
    //            $scope.complaintReportFormatted.productModels = response.data;
    //        },
    //        function error(response) {
    //            $scope.complaintReportFormatted.SelectedProductModel = null;
    //        }
    //    );
    //};

    $scope.error = null;
    $scope.success = false;

    var ti = function () {
        timer = $timeout(function () {
            //$window.location.href = "/reklamasjonsrapporter/vis?id=" + $scope.existingComplaintReportId;
            $scope.success = false;
        }, 3000);
    };

    $scope.submit = function () {
        $scope.changeEditMode();
        ComplaintReportFactory.UpdateComplaintReport($scope.complaintReportFormatted).then(function success(response) {
            $scope.existingComplaintReportId = response.data;
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

    $scope.init = function (reportId) {
        ComplaintReportFactory.GetComplaintReportById(reportId).then(function (data) {

            if (data.data == null || data.data == undefined) {
                $window.location.href = "/NoAccess";
            }
            $scope.complaintReport = data.data;
            updateModel();
        });
    };

}]);