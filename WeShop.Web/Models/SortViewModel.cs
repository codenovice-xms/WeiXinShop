using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class SortViewModel
    {
        public IEnumerable<Sort> Sorts { get; set; }
        
        public  IEnumerable<Sort> TwoSorts { get; set; }
    }
}