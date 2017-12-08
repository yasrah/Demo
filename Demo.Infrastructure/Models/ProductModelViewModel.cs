using Demo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
   public class ProductModelViewModel
    {
        public ProductModelViewModel(ProductModel model)
        {
            ProductModelId = model.ProductModelId;
            Name = model.Name;
        }
        public int ProductModelId { get; set; }
        public string Name { get; set; }
    }
}
