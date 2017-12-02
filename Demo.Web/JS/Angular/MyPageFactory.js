app.factory("MyPageFactory", ["$http", function ($http) {
    return {
        PostForm: function (form) {
            console.log("Posting Form: " + form);
            return $http.post("/umbraco/api/raskwebapi/postform", form);

        },
        VerifyCaptcha: function (payload) {
            return $http.post("https://www.google.com/recaptcha/api/siteverify", payload);
        },
        ValidateReCaptchaToken: function (payload) {
            return $http.post("/umbraco/api/raskwebapi/verifycaptcha", payload);
        },
        GetMyPageData: function () {
            return $http.get("/umbraco/api/mypageapi/getmypagedata").then(function (response) {
                return response; 
            });
        },
        GetCurrentMemberId: function () {
            return $http.get("/umbraco/api/dealer/getcurrentuserid").then(function (response) {
                return response;
            });
        },
        GetId: function () {
            return $http.get("/umbraco/api/dealer/GetAllDealers");
        },
        UpdateMyPageData: function (data) {
            return $http.post("/umbraco/api/mypageapi/updatemypagedata", data);
        }
    }
}
]);