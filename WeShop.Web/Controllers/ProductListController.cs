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
        private IProductService ProductService { get; set; }

        private ProductViewModel productViewModel = new ProductViewModel();
        public ActionResult Index(int Code)
        {
            productViewModel.Products = ProductService.GetEntities(p => true);
            return View(productViewModel);
        }
    }
}