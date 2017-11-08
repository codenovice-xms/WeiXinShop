using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    public class ProductListController : Controller
    {
        public IProductService ProductService { get; set; }

        public ActionResult Index(int code)
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.Products = ProductService.GetEntities(p =>p.Sorts.First().Code==code);
            return View(productViewModel);
        }

        public ActionResult Search(string Key)
        {
            Key = Request["key"];
           
            var Products = ProductService.GetEntities(p => p.Name.Contains(Key)  ||p.Intro.Contains(Key));
            ViewBag.Product = "Products";
            if (Products.LongCount()<1)                                             //如果没有搜索到相应商品
            {
                var TuiProducts = ProductService.GetEntities(p => p.Type==2);       //查找推荐商品
                ViewBag.Product = "TuiProducts";
                return View(TuiProducts);                                   
            }
            return View(Products);
        }
    }
}