﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeShop.IService;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }
        public IProductService ProductService { get; set; }
        public  INoticeService NoticeService { get; set; }
        public IShopCarService ShopCarService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public ActionResult Index(string type="1")
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Banners = BannerService.GetEntities(b => true);
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);
            homeViewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, false, n => true, n => n.ModiTime);
            homeViewModel.Products = ProductService.GetEntitiesByPage(3, 1, false, p => p.Type.ToString()==type, p => p.ModiTime);
            Session["cusid"] = 4; //假数据
            return View(homeViewModel);
        }
    }
}