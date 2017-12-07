﻿using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string Address { get; set; }
        public int? CustomerType { get; set; }
    }
}
