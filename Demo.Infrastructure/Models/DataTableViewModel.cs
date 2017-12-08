using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Infrastructure.Models
{
    public class DataTableViewModel
    {
        public int length { get; set; }
        public int start { get; set; }
        //[JsonProperty(PropertyName = "search[value]")]
        //public string [] search { get; set; }

        public Search search { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
    }
}