using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using WeShop.EFModel;

namespace WeShop.Web.Models
{
    public class UserInfoViewModel
    {
        public OAuthUserInfo OAuthUserInfo { get; set; }
        public  Customer Customer { get; set; }
    }
}