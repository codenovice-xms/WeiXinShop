using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeShop.EFModel;
using WeShop.IService;
using WeShop.Web.Filters;
using WeShop.Web.Models;

namespace WeShop.Web.Controllers
{
    public class UserController : Controller
    {
        public IProductService ProductService { get; set; }
        public ICustomerService CustomerService { get; set; }
        //[OAuthFilter]
        public ActionResult Index()
        {
            UserInfoViewModel userInfoViewModel = new UserInfoViewModel();
            userInfoViewModel.OAuthUserInfo = Session["userinfo"] as OAuthUserInfo;
            Customer customer = new Customer();
            Session["openid"]= customer.OpenId = userInfoViewModel.OAuthUserInfo.openid;
            Session["cusid"] = CustomerService.GetEntity(c => c.OpenId == Session["openid"].ToString()).Id;
            customer.CreateTime=DateTime.Now;
            if (CustomerService.GetEntity(c => c.OpenId == userInfoViewModel.OAuthUserInfo.openid)==null)
            {
                CustomerService.Add(customer);
            }
            return View(userInfoViewModel);
        }
    }
}