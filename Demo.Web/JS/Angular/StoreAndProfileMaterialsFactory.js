app.factory("StoreAndProfileMaterialsFactory", ["$http", function ($http) {
    return {
        GetStoreAndProfileMaterials: function () {
            return $http.get("/umbraco/api/StoreAndProfileMaterialsApi/GetStoreAndProfileMaterials").then(function (response) {
                return response;
            });
        },
        GetMyComplaintReports: function () {
            return $http.get("/umbraco/api/complaintreportapi/getmycomplaintreport").then(function (response) {
                return response;
            });
        },
        GetMyComplaintReportsUrl: function () {
            return "/umbraco/api/ComplaintReportApi/getmycomplaintreport";
        }

    }
}
]);