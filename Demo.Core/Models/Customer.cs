using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class Customer
    {
        public Customer()
        {}
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public CustomerType CustomerType { get; set; }
        public virtual ICollection<ComplaintReport> ComplaintReports { get; set; }
    }

    public enum CustomerType
    {
        Private = 1,
        Industry = 2
    }
}
    