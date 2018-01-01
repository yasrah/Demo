using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Models
{
    public class StoreAndProfileMaterialsVM
    {
        public StoreAndProfileMaterialsVM()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price{ get; set; }
        public string Description { get; set; }
        public int? Amount{ get; set; }
        public IEnumerable<string> Size { get; set; }
    }
}
