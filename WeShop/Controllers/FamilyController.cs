using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace WeShop.Controllers
{
    public class FamilyController : Controller
    {
        // GET: Family
        //网站首页中，获取客户端获取用户的信息
        public ActionResult Index()
        {
            var userinfo = Session["userinfo"] as OAuthUserInfo;
            var openid = Session["oid"] as OAuthUserInfo;//得到openid
            return View();
        }
    }
}