using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    public class SortController : Controller
    {
        public ISortService SortService { get; set; }
        
        public ActionResult Index()
        {
            var sorts = SortService.GetEntities(s => true);
            return View(sorts);
        }
    }
}