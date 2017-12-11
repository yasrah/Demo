using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
   public class Part
    {
        public Part()
        {

        }

        public int PartId { get; set; }
        public int PartNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Shipping { get; set; }
        public virtual ICollection<ComplaintReportPart> ComplaintReportParts { get; set; }
        public int MyProperty2 { get; set; }
    }
}
