using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core.Models
{
   public class DealerProductInventory
    {
        public DealerProductInventory()
        {

        }

        [Key, Column(Order = 0)]
        public int DealerId { get; set; }
        [Key, Column(Order = 1)]
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
