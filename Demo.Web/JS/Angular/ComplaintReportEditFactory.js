//app.factory("ComplaintReportEditFactory", ["$http", function ($http) {
//    return {
//        PostForm: function (form) {
//            console.log("Posting Form: " + form);
//            return $http.post("/umbraco/api/raskwebapi/postform", form);

//        },
//        VerifyCaptcha: function (payload) {
//            return $http.post("https://www.google.com/recaptcha/api/siteverify", payload);
//        },
//        ValidateReCaptchaToken: function (payload) {
//            return $http.post("/umbraco/api/raskwebapi/verifycaptcha", payload);
//        },
//        GetComplaintReport: function (id) {
//            return $http.get("/umbraco/api/dealer/GetComplaintReport?id=" + id).then(function (response) {
//                return response;
//            });
//        },
//        GetCurrentMemberId: function () {
//            return $http.get("/umbraco/api/dealer/getcurrentuserid").then(function (response) {
//                return response;
//            });
//        },
//        GetId: function () {
//            return $http.get("/umbraco/api/dealer/GetAllDealers");
//        },
//        UpdateComplaintReport: function (data) {
//            return $http.post("/umbraco/api/dealer/updatecomplaintreport", data);
//        },
//        DeleteComplaintReport: function (id) {
//            return $http.get("/umbraco/api/dealer/deletecomplaintreport?complaintReportId=" + id).then(function (response) {
//                return response;
//            });
//        },
//        GetProducts: function () {
//            return $http.get("/umbraco/api/dealer/getproducts").then(function (response) {
//                return response;
//            });
//        },
//        GetProductModels: function (productId) {
//            return $http.get("/umbraco/api/dealer/getproductmodels?productId=" + productId).then(function (response) {
//                return response;
//            });
//        }
//    }
//}
//]);


app.factory("ComplaintReportEditFactory", ["$http", function ($http) {
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