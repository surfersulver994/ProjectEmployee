using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class ProductModel
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public int Rate { get; set; }
        public int Description { get; set; }
        public int ProductImage { get; set; }
    }
}