using Demo.Core.Models;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class ComplaintReportRepository
    {
        readonly DealerNetworkContext ctx = new DealerNetworkContext();
        public List<Customer> GetAllCustomersName(string query)
        {
            return ctx.Customers.Where(c => c.Name.Contains(query)).ToList();
        }

        public List<PartViewModel> GetPartsByQuery(string query)
        {
            return ctx.Parts.Where(c => c.Description.Contains(query) || c.PartNo.ToString().Contains(query))
                .Select(p => new PartViewModel
                {
                    PartId = p.PartId,
                    PartNo = p.PartNo,
                    Description = p.Description,
                    Price = p.Price,
                    Shipping = p.Shipping,
                    Amount = 1,
                }).ToList();
        }
    }
}
