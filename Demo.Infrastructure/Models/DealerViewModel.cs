using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace Demo.Infrastructure.Models
{
    public class DealerViewModel
    {
        public DealerViewModel(IMember member)
        {
            DealerId = member.Id;
            Name = member.Name;
            Address = member.GetValue<string>("Address");
        }
        public int DealerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
