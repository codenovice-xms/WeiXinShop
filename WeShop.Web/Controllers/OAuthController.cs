using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;

namespace WeShop.Web.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth
        private string _appId = "wxb8b0a6922fabc1f7";
        private string _appsecret = "adead9c8f3d61b8d1493fd7213f87404";
        private string _domain = "http://wx.xumingsheng.top";
        public ActionResult Login(string requestUrl)
        {
            var redirectUrl = $"{ _domain}{Url.Action("CallBack", new { requestUrl })}";
            var state = "wx" + DateTime.Now.Millisecond;
            Session["state"] = state;

            var url = OAuthApi.GetAuthorizeUrl(_appId, redirectUrl, state, OAuthScope.snsapi_userinfo);
            return Redirect(url);
        }

        public ActionResult CallBack(string code, string state, string requestUrl)
        {
            if (state != (string)Session["state"])
            {
                return Content("非法访问！");
            }
            if (string.IsNullOrEmpty(code))
            {
                return Content("授权失败！");
            }
            var oAuthAccessToken = OAuthApi.GetAccessToken(_appId, _appsecret, code);
            if (oAuthAccessToken.errcode != ReturnCode.请求成功)
            {
                return Content("授权失败！");
            }
            //获取令牌成功，说明已登陆
            Session["AccessToken"] = oAuthAccessToken;
            //尝试获取用户信息，如果能获取到，就说明令牌有权限，如果没有获取到，说明令牌没有权限
            //但是不管令牌是否有权限，OpenId都是一样的

            OAuthUserInfo userInfo;
            try
            {
                userInfo = OAuthApi.GetUserInfo(oAuthAccessToken.access_token, oAuthAccessToken.openid);
                Session["userinfo"] = userInfo;
                return Redirect(requestUrl);
            }
            catch (Exception)
            {
                var redirectUrl = $"{ _domain}{Url.Action("CallBack", new { requestUrl })}";
                var url = OAuthApi.GetAuthorizeUrl(_appId, redirectUrl, state, OAuthScope.snsapi_userinfo);
                return Redirect(url);
            }
        }

        public ActionResult JsSdkConfig()
        {
            //生成需要注册的完整URL
            var url = _domain + Request.RawUrl;
            var config = JSSDKHelper.GetJsSdkUiPackage(_appId, _appsecret, url);
            return PartialView(config);
        }
    }
}