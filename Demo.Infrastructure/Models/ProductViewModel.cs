using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
        }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}
