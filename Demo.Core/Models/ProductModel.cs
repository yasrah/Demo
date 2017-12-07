using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class ProductModel
    {
        public ProductModel()
        {}
        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product{ get; set; }
        public virtual ICollection<ComplaintReport> ComplaintReports { get; set; }

    }
}
