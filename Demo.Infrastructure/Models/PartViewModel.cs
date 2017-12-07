using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class PartViewModel
    {
        public PartViewModel()
        {

        }
        public PartViewModel(Part part)
        {
            PartId = part.PartId;
            PartNo = part.PartNo;
            Description = part.Description;
            Price = part.Price;
            Shipping = part.Shipping;
            Amount = 1;
        }
        public int PartId { get; set; }
        public int PartNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Shipping { get; set; }
        public int Amount { get; set; }
    }
}
