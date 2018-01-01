app.controller("StoreAndProfileMaterialsController", ["$scope", "$http", "$window", "$timeout", "StoreAndProfileMaterialsFactory", "$rootScope", "SharedVarFactory", "Notification", function ($scope, $http, $window, $timeout, StoreAndProfileMaterialsFactory, $rootScope, SharedVarFactory, Notification) {

    $scope.order = {
        list: [],
        contactPerson: '',
        comment: '',
        total: function () {
            var totalPrice = 0;
            this.list.forEach(function (obj) {
                totalPrice += parseFloat(obj.price) * obj.amount;
            });
            return totalPrice.toFixed(2);
        },
        sum:0
    };
    $scope.isNumber = function (number) {
        return angular.isNumber(number);
    }
    $scope.submit = function () {
        $('#myModal').modal('toggle'); //or  $('#IDModal').modal('hide');
        $scope.order.list = [];
        SharedVarFactory.setOrder($scope.order);
        $rootScope.$broadcast('increment-value-event');
        Notification.success({ message: "Din bestilling er sendt inn!", positionY: 'top', positionX: 'center' });

    }

    $scope.materials = [];

    $scope.addToList = function (item) {
        var itemIndex = $scope.order.list.indexOf(item);
        if (itemIndex > 0) {
            // increment
            $scope.order.list[itemIndex].amount += item.Amount;
            //$scope.list.push({ id: item.Id, name: item.Name, price: item.Price, amount: item.Amount, size: item.SelectedSize });

        }
        else {
            // add
            $scope.order.list.push({ id: item.Id, name: item.Name, price: item.Price, amount: item.Amount, size: item.SelectedSize, totalPrice: (item.Amount * item.Price).toFixed(2) });

        }
        $scope.order.sum = $scope.order.total();
        SharedVarFactory.setOrder($scope.order);
        $rootScope.$broadcast('increment-value-event');
        Notification.success({ message: item.Name + " er lag til i handlevogna!", positionY: 'top', positionX: 'center' });
    }

    $scope.removeProduct = function (product) {
        var partIndex = $scope.order.list.indexOf(product);
        $scope.order.list.splice(partIndex, 1);
        $scope.order.sum = $scope.order.total();
    }

    //$scope.update = function () {
    //    MyService.setValue($scope.value);
    //    $rootScope.$broadcast('increment-value-event');
    //};
    //function loadCharData() {
    //    Morris.Bar({
    //        element: 'morris-area-chart',
    //        data: $scope.complaintReportsDashboardChart,
    //        xkey: 'Period',
    //        ykeys: ['Count'],
    //        labels: ['Antall'],
    //        pointSize: 1,
    //        hideHover: 'auto',
    //        resize: true,
    //        xLabels: 'Day'
    //    });
    //}

    //function loadDonutChart() {
    //    Morris.Donut({
    //        element: 'morris-donut-chart',
    //        //data: $scope.complaintReportsDashboardDataForDonutChart,
    //        data: [
    //            {
    //                label: "Til godkjenning",
    //                value: $scope.complaintReportsDashboardData.SentToApprovalTotal
    //            }, {
    //                label: "Godkjent",
    //                value: $scope.complaintReportsDashboardData.ApprovedReportsTotal
    //            }, {
    //                label: "Avslått",
    //                value: $scope.complaintReportsDashboardData.DeclinedReportsTotal
    //            }
    //            , {
    //                label: "Kladd",
    //                value: $scope.complaintReportsDashboardData.DraftReportsTotal
    //            }
    //        ],
    //        colors: ['#f0ad4e', '#5cb85c', '#d9534f', '#337ab7'],
    //        resize: true
    //    });
    //}

    StoreAndProfileMaterialsFactory.GetStoreAndProfileMaterials().then(function success(data) {
        $scope.getStoreAndProfileMaterialsError = false;
        $scope.materials = data.data;
    }, function error(response) {
        $scope.getStoreAndProfileMaterials = true;
    });

    //ComplaintReportFactory.GetComplaintReportsDashboardChart().then(function (data) {
    //    $scope.complaintReportsDashboardChart = data.data;
    //    loadCharData();
    //});

}]);