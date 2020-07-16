using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDemo.Controllers
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public int CustomerID { get; set; }
        public int TotalQty { get; set; }
        public int TotalAmount { get; set; }
    }
}
