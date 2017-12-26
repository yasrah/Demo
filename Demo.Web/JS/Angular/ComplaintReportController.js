app.controller("ComplaintReportController", ["$scope", "$http", "$window", "$timeout", "ComplaintReportFactory", function ($scope, $http, $window, $timeout, ComplaintReportFactory) {

    function loadCharData() {
        Morris.Bar({
            element: 'morris-area-chart',
            data: $scope.complaintReportsDashboardChart,
            xkey: 'Period',
            ykeys: ['Count'],
            labels: ['Antall'],
            pointSize: 1,
            hideHover: 'auto',
            resize: true,
            xLabels: 'Day'
        });
    }

    function loadDonutChart() {
        Morris.Donut({
            element: 'morris-donut-chart',
            //data: $scope.complaintReportsDashboardDataForDonutChart,
            data: [
                {
                    label: "Til godkjenning",
                    value: $scope.complaintReportsDashboardData.SentToApprovalTotal
                }, {
                    label: "Godkjent",
                    value: $scope.complaintReportsDashboardData.ApprovedReportsTotal
                }, {
                    label: "Avslått",
                    value: $scope.complaintReportsDashboardData.DeclinedReportsTotal
                }
                , {
                    label: "Totalt",
                    value: $scope.complaintReportsDashboardData.TotalReports
                }
            ],
            colors: ['#f0ad4e', '#5cb85c', '#d9534f', '#337ab7'],
            resize: true
        });
    }

    ComplaintReportFactory.GetComplaintReportsDashboardData().then(function (data) {
        $scope.complaintReportsDashboardData = data.data;
        loadDonutChart();
    });

    ComplaintReportFactory.GetComplaintReportsDashboardChart().then(function (data) {
        $scope.complaintReportsDashboardChart = data.data;
        loadCharData();
    });
    //ComplaintReportFactory.GetComplaintReportsDashboardDataForDonutChart().then(function (data) {
    //    $scope.complaintReportsDashboardDataForDonutChart = data.data;
    //    loadDonutChart();
    //});
}]);