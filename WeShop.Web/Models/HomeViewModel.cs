using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class HomeViewModel
    {
        public  int NoticeNum { get; set; }                     //公告数量
        public  IEnumerable<Banner> Banners { get; set; }       //banner
        public  IEnumerable<Notice> Notices { get; set; }       //公告
        public IEnumerable<Product> Products { get; set; }      //商品
        public IEnumerable<ProPhoto> ProPhotos { get; set; }    //商品图片
    }
}