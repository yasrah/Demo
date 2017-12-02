app.factory("ComplaintReportShowFactory", ["$http", function ($http) {
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
        },
        GetUnprocessedCompalintReportsCount: function () {
            return $http.get("/umbraco/api/dealer/GetUnprocessedCompalintReportsCount").then(function (response) {
                return response;
            });
        },
        GetUnderProcessCompalintReportsCount: function () {
            return $http.get("/umbraco/api/dealer/GetUnderProcessCompalintReportsCount").then(function (response) {
                return response;
            });
        },
        GetProcessedCompalintReportsCount: function () {
            return $http.get("/umbraco/api/dealer/GetProcessedCompalintReportsCount").then(function (response) {
                return response;
            });
        },
        NewComplaintReport: function (data) {
            return $http.post("/umbraco/api/dealer/newcomplaintreport", data);
        },
        GetMyPageData: function () {
            return $http.get("/umbraco/api/dealer/getmypagedata").then(function (response) {
                return response;
            });
        },
        GetProducts: function () {
            return $http.get("/umbraco/api/dealer/getproducts").then(function (response) {
                return response;
            });
        },
        GetProductModels: function (productId) {
            return $http.get("/umbraco/api/dealer/getproductmodels?productId=" + productId).then(function (response) {
                return response;
            });
        },
        GetComplaintReport: function (id) {
            return $http.get("/umbraco/api/dealer/GetComplaintReport?id=" + id).then(function (response) {
                return response;
            });
        }
    }
}
]);