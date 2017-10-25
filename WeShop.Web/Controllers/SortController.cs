using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.EFModel;
using WeShop.IService;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    public class SortController : Controller
    {
        public ISortService SortService { get; set; }
        
        // GET: Sort
        public ActionResult Index(int code=1)
        {
            SortViewModel sortViewModel = new SortViewModel();
            sortViewModel.Sorts = SortService.GetEntities(s => s.UpCode==null);
            sortViewModel.TwoSorts = SortService.GetEntities(s => s.UpCode == code);
            return View(sortViewModel);
        }
    }
}