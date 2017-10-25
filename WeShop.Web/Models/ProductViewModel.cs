using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }        //商品
        public IEnumerable<ProReview> ProReviews { get; set; }    //评价
        public  IEnumerable<ProPhoto> ProPhotos { get; set; }     //商品图片
        public IEnumerable<Tag> Tags { get; set; }                //标签
        public IEnumerable<Stock> Stocks { get; set; }            //进货
        public IEnumerable<Sort> TwoSorts { get; set; }           //二级分类
    }
}