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
    }
}