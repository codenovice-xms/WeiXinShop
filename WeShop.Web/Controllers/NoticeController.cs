using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;

namespace WeShop.Web.Controllers
{
    public class NoticeController : Controller
    {
        public INoticeService NoticeService { get; set; }

        public ActionResult Index()
        {
            var notice = NoticeService.GetEntities(n => true);
            return View(notice);
        }

        public ActionResult Detail(int id)
        {
            var notice = NoticeService.GetEntity(n => n.Id == id);
            return View(notice);
        }
    }
}