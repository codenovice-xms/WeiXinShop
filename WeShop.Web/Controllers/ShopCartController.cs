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
            if (Session["userinfo"]==null)
            {
                return Redirect(@Url.Action("Index", "User"));
            }
            var cusid = CustomerService.GetEntity(c => c.OpenId == Session["openid"].ToString()).Id;
            var shoppingCart = ShopCarService.GetEntities(s => s.CusId == cusid);
            return View(shoppingCart);
        }

        public string AddCar()
        {
            if (Session["userinfo"]==null)
            {
                return "400";
            }

            ShoppingCart shoppingCart = new ShoppingCart();

            shoppingCart.ProCode = Request["procode"];
            var cusid = CustomerService.GetEntity(c => c.OpenId == Session["openid"].ToString()).Id;
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

        public string DeleteCar()
        {

            return "200";
        }
    }
}