using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectDemo.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.ProductImageA = new List<SelectListItem>();
            this.UnitA = new List<SelectListItem>();
            this.RateA = new List<SelectListItem>();
        }
        public List<SelectListItem> ProductImageA { get; set; }
        public List<SelectListItem> UnitA { get; set; }
        public List<SelectListItem> RateA { get; set; }
        public int ProductCodeA { get; set; }
    }
}