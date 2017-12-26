using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class ComplaintReportsDashboardData
    {
        public ComplaintReportsDashboardData()
        {

        }
        public int DraftReportsTotal { get; set; }
        public int SentToApprovalTotal { get; set; }
        public int ApprovedReportsTotal { get; set; }
        public int DeclinedReportsTotal { get; set; }
        public int TotalReports { get; set; }
    }
}
