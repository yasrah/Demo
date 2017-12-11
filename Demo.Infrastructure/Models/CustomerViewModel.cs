using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {

        }
        public int CustomerId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Range(1, 2, ErrorMessage = "CustomerType må velges.")]
        public int CustomerType { get; set; }
    }
}
