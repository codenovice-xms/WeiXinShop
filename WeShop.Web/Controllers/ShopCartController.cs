using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.Annotations;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeShop.EFModel;
using WeShop.IService;
using WeShop.Web.Filters;

namespace WeShop.Web.Controllers
{
    public class ShopCartController : Controller
    {
        public IProductService ProductService { get; set; }
        public IShopCarService ShopCarService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public ActionResult Index()
        {
            //if (Session["userinfo"]==null)  //如果未登陆，跳转到‘我的’页面进行登陆
            //{
            //    return Redirect(@Url.Action("Index", "User"));
            //}
            Session["cusid"] = 4;
            int cusid =Convert.ToInt32(Session["cusid"]);
            Session["Carnum"] = ShopCarService.GetCount(s => s.CusId == cusid);
            var shoppingCart = ShopCarService.GetEntities(s => s.CusId == cusid);
            return View(shoppingCart);
        }

        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <returns></returns>
        public string AddCar()
        {
            //if (Session["userinfo"]==null) //如果未登陆，跳转到‘我的’页面进行登陆
            //{
            //    return "400";
            //}

            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCart.ProCode = Request["procode"];
            int cusid = Convert.ToInt32(Session["cusid"]);
            shoppingCart.CusId = cusid;

            int num;
            var car = ShopCarService.GetCount(s => s.CusId == cusid && s.ProCode == Request["procode"]);
            if (car>0)  num= Convert.ToInt32(Request["count"])+ ShopCarService.GetEntity(s => s.CusId == cusid && s.ProCode == Request["procode"]).Qty;//如果购物车中有相同商品，原有商品数量+添加的数量
            else num = Convert.ToInt32(Request["count"]);                                                                                              //直接添加传的值
            shoppingCart.Qty = num;
            shoppingCart.CreateTime=DateTime.Now;
            ShopCarService.Add(shoppingCart);
            return "200";
        }

        /// <summary>
        /// 删除购物车商品
        /// </summary>
        /// <returns></returns>
        public string DeleteCar()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ProCode = Request["procode"];
            int cusid = Convert.ToInt32(Session["cusid"]);
            shoppingCart.CusId = cusid;

            if (ShopCarService.Remove(shoppingCart))
                return "200";
            return "400";
        }

        public string UpdateCarNum()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ProCode = Request["procode"];
            int cusid = Convert.ToInt32(Session["cusid"]);
            shoppingCart.CusId = cusid;
            int num= Convert.ToInt32(Request["count"]);
            shoppingCart.Qty = num;
            shoppingCart.CreateTime = DateTime.Now;
            ShopCarService.Add(shoppingCart);
            return "200";
        }
    }
}