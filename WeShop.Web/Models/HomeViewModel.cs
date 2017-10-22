using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class HomeViewModel
    {
        public  int NoticeNum { get; set; }
        public  IEnumerable<Banner> Banners { get; set; }
        public  IEnumerable<Notice> Notices { get; set; } 
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProPhoto> ProPhotos { get; set; } 
    }
}