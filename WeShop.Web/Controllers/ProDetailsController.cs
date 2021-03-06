﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeShop.IService;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    public class ProDetailsController : Controller
    {
        public  IProductService ProductService { get; set; }
        public IPhotosService PhotosService { get; set; }
        public  IReviewService ReviewService { get; set; }

        public ActionResult Index(string code)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = ProductService.GetEntities(p => p.Code == code);
            productViewModel.ProPhotos = PhotosService.GetEntities(p => p.ProCode == code);
            productViewModel.ProReviews = ReviewService.GetEntities(r => r.ProCode == code);
            return View(productViewModel);
        }
    }
}