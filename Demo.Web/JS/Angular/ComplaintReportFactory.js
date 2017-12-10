app.factory("ComplaintReportFactory", ["$http", function ($http) {
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
            return $http.post("/umbraco/api/complaintreportapi/newcomplaintreport", data);
        },
        GetMyPageData: function () {
            return $http.get("/umbraco/api/mypageapi/getmypagedata").then(function (response) {
                return response;
            });
        },
        GetProducts: function () {
            return $http.get("/umbraco/api/complaintreportapi/getproducts").then(function (response) {
                return response;
            });
        },
        GetProductModels: function (productId) {
            return $http.get("/umbraco/api/complaintreportapi/getproductmodels?productId=" + productId).then(function (response) {
                return response;
            });
        },
        GetComplaintReportById: function (reportId) {
            return $http.get("/umbraco/api/complaintreportapi/getcomplaintreportbyid?reportId=" + reportId).then(function (response) {
                return response;
            });
        },
        UpdateComplaintReport: function (data) {
            return $http.post("/umbraco/api/complaintreportapi/updatecomplaintreport", data);
        },
        SendToApproval: function (reportId) {
            return $http.get("/umbraco/api/complaintreportapi/SendToApproval?reportId=" + reportId).then(function (response) {
                return response;
            });
        },
        Approve: function (reportId) {
            return $http.get("/umbraco/api/complaintreportapi/approve?reportId=" + reportId).then(function (response) {
                return response;
            });
        },
        Deny: function (reportId) {
            return $http.get("/umbraco/api/complaintreportapi/deny?reportId=" + reportId).then(function (response) {
                return response;
            });
        },
    }
}
]);