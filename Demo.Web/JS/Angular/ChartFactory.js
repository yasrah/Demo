app.factory("ChartFactory", ["$http", function ($http) {
    return {
        GetChart1: function () {
            return $http.get("/umbraco/api/dealer/getchart1").then(function (response) {
                return response;
            });
        }
        //,
        //GetDealersCount: function () {
        //    return $http.get("/umbraco/api/dealer/getdealerscount").then(function (response) {
        //        return response;
        //    });
        //}
    }
}
]);