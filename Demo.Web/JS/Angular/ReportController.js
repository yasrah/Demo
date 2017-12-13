app.controller("ReportController", ["$scope", "$http", "$window", "$timeout", "$filter", "ReportFactory", function ($scope, $http, $window, $timeout, $filter, ReportFactory) {

    // Debug
    $scope.error = null;
    $scope.success = false;
    $scope.reports = null;
    $scope.reportsCount = 0;

    //DealerFactory.GetAllDealers().then(function (data) {
    //    $scope.allDealers = data.data;
    //});

    // ReportFactory.GetMyComplaintReports().then(function (response) {
    //$scope.reports = response.data;
    //$scope.reportsCount = $scope.reports.length;
    //$('#dataTables-example').dataTable({
    //    "ajax": GetMyComplaintReports()
    //    //"ajax": function (data, callback, settings) {
    //    //    callback(
    //    //        response.data
    //    //    );
    //    //}
    //});
    // });

    $(document).ready(function () {
        //var table = $('#dataTables-example').DataTable({
        //    responsive: true,
        //    serverSide: true,
        //    ajax: "http://dev.smarthus.no/umbraco/api/dealer/getmycomplaintreport"
        //});
        //table.ajax.url("http://dev.smarthus.no/umbraco/api/dealer/getmycomplaintreport").load();
    });

    $(document).ready(function () {
        $('#dataTables-example').dataTable({
            ajax: {
                url: '/umbraco/api/complaintreportapi/getmycomplaintreport',
                type: 'POST'

            },
            serverSide: true,
            processing: true,
            columns: [
                {
                    "data": "ComplaintReportId", render: function (data, type, full, meta) {
                        return '<a href="/complaintreports/showcomplaintreport?reportId=' + data + '" >' + data + '</a>'
                    }
                },
                {
                    "data": "Dealer.Name"
                },
                {
                    "data": "Customer.Name"
                },
                {
                    "data": "Customer.CustomerType"
                },
                {
                    "data": "Product.Name"
                },
                {
                    "data": "ProductModel.Name"
                },
                {
                    "data": "EngineNo"
                },
                {
                    "data": "TimeAmount"
                },
                {
                    "data": "SaleDate",
                    render: function (d) { return $filter('date')(d, "dd.MM.yyyy");; }
                },
                {
                    "data": "DamageDate",
                    render: function (d) { return $filter('date')(d, "dd.MM.yyyy");; }
                },
                {
                    "data": "RepairDate",
                    render: function (d) { return $filter('date')(d, "dd.MM.yyyy");; }
                },
                {
                    "data": "Error"
                },
                {
                    "data": "ReasonForError"
                },
                {
                    "data": "PartsMarked"
                },
                {
                    "data": "PartsReturned"
                },
                {
                    "data": "CreateEmail"
                },
                {
                    "data": "Status"
                },
                {
                    "data": "Closed"
                }


            ],
            dom: 'Bfrtip',
            lengthMenu: [
                [10, 25, 50, -1],
                ['10 rows', '25 rows', '50 rows', 'Show all']
            ],
            buttons: [
                {
                    extend: 'copyHtml5',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'excelHtml5',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'pdfHtml5',
                    exportOptions: {
                        columns: ':visible'
                    },
                    orientation: 'landscape'
                },
                {
                    extend: 'csv',
                    exportOptions: {
                        columns: ':visible'
                    },
                    orientation: 'landscape'

                },
                {
                    extend: 'print',
                    orientation: 'landscape',
                    pageSize: 'LEGAL'
                },
                'colvis',
                'pageLength'
            ]
        });
        $('#dataTables-example').on('click', 'tbody tr', function () {
            //window.location.href = $(this).attr('href');
            alert($('#dataTables-example').row(this).data());
        });

    });

    //$scope.submit = function () {
    //    MyPageFactory.UpdateMyPageData($scope.myPageData).then(function success(response) {
    //        $scope.myPageData = response.data;
    //        $scope.success = true;
    //        $timeout(function () {
    //            $scope.success = false;
    //        }, 8000);

    //    }, function error(response) {
    //        if (response.status == 401) {
    //            $scope.error = "Din sesjon er utgått. Logg inn på nytt!"
    //        }
    //        else {
    //            $scope.error = "Noe gikk galt. Prøv igjen senere!"
    //        }
    //    });
    //};
}]);