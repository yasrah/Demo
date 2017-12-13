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
        public string CustomerType { get; set; }
        public virtual ICollection<ComplaintReport> ComplaintReports { get; set; }
    }

    public static class CustomerType
    {
        public const string Private = "Privat";
        public const string Industry = "Næring";
    }
}
    