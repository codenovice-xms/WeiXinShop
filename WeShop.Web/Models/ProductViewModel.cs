using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProReview> ProReviews { get; set; }
        public  IEnumerable<ProPhoto> ProPhotos { get; set; }
        public IEnumerable<Tag> Tags { get; set; } 
    }
}