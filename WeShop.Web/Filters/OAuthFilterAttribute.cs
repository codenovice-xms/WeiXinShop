using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeShop.Web.Filters
{
    public class OAuthFilterAttribute:FilterAttribute,IAuthorizationFilter
    {
       
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //判断是否登陆授权，AccessToken标识代表着用户已登陆，这里面存放着用户的令牌
            if (filterContext.HttpContext.Session["AccessToken"] != null) return;


            //requestUrl代表用户访问请求地址，需要保存 以便于授权完成后 跳转到这个地址来
            var requestUrl = filterContext.HttpContext.Request.RawUrl;
            //未登录 所以跳转到登陆页
            var urlHelper=new UrlHelper(filterContext.RequestContext);
            filterContext.Result=new RedirectResult(urlHelper.Action("Login","OAuth",new {requestUrl}));
        }
    }
}