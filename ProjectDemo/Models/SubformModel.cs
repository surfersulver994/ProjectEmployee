
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDemo.Models
{
    public class SubformModel
    {
        public int SubformID { get; set; }
        public string OrderID { get; set; }
        public int ProductCode { get; set; }
        public int ProductImage { get; set; }
        public int Unit { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}