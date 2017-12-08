using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Infrastructure.Models
{
    public class ComplaintReportWrapper
    {
        public IEnumerable<ExistingComplaintReportViewModel> data { get; set; }
        public int recordsTotal { get; set; }

        public int recordsFiltered { get; set; }

    }
}