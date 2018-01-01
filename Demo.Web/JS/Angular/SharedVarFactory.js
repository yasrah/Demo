app.factory("SharedVarFactory", ["$http", function ($http) {
    // private
    var order = {};

    // public
    return {

        getOrder: function () {
            return order;
        },

        setOrder: function (obj) {
            order = obj;
        }
    }
}
]);