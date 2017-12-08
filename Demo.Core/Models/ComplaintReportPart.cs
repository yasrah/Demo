using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class ComplaintReportPart
    {
        [Key, Column(Order = 0)]
        public int ComplaintReportId { get; set; }
        [Key, Column(Order = 1)]
        public int PartId { get; set; }

        public virtual ComplaintReport ComplaintReport { get; set; }
        public virtual Part Part { get; set; }

        public int Amount { get; set; }
    }
}
