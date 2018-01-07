app.controller("MaterialsCartController", ["$scope", "SharedVarFactory", function ($scope, SharedVarFactory) {

    $scope.order = SharedVarFactory.getOrder,

        $scope.remove = function ($event, item) {
            var partIndex = $scope.order.list.indexOf(item);
            $scope.order.list.splice(partIndex, 1);
            $event.preventDefault();
            return false;
        }

    //$('#remove-item').click(function (e) {
    //    // Coding
    //    alert();
    //    var partIndex = $scope.value.indexOf(item);
    //    $scope.value.splice(partIndex, 1);
    //});

    $scope.$on('increment-value-event', function () {
        $scope.order = SharedVarFactory.getOrder();
    });

}]);
