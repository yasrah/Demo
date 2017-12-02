app.factory("ReportFactory", ["$http", function ($http) {
    return {
        GetAllDealers: function () {
            return $http.get("/umbraco/api/dealer/getall").then(function (response) {
                return response;
            });
        },
        GetMyComplaintReports: function () {
            return $http.get("/umbraco/api/dealer/getmycomplaintreport").then(function (response) {
                return response;
            });
        },
        GetMyComplaintReportsUrl: function () {
            return "/umbraco/api/dealer/getmycomplaintreport";
        }

    }
}
]);