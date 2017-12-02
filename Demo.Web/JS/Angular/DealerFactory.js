app.factory("DealerFactory", ["$http", function ($http) {
    return {
        GetReportsCount: function () {
            return $http.get("/umbraco/api/dealer/getreportscount").then(function (response) {
                return response;
            });
        },
        GetDealersCount: function () {
            return $http.get("/umbraco/api/dealer/getdealerscount").then(function (response) {
                return response;
            });
        }
    }
}
]);