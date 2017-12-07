using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
    public class Product
    {
        public Product()
        {}
        public int ProductId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}
