using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Shop.IService;
using WeShop.Filters;
using Shop.Model;

namespace WeShop.Controllers
{
    [AuthorizeFiltere]
    public class FamilyController : Controller
    {
        // GET: Family
        //网站首页中，获取客户端获取用户的信息
        public ICustomerService customer { get; set; }
        public ActionResult Index()

        {
            //var userinfo = Session["userinfo"] as OAuthUserInfo;
            //var openid = Session["oid"] as OAuthUserInfo;

            var userinfo = Session["userInfo"] as OAuthUserInfo;
            var c = customer.GetEntities(x => x.openid == userinfo.openid).ToList();
            if (c.Count==0)
            {
                Customer cus = new Customer();
                cus.openid = userinfo.openid;
                cus.cid = userinfo.openid;
                cus.image = userinfo.headimgurl;
                cus.nickname = userinfo.nickname;
                cus.tel = "";
                cus.address = userinfo.country + userinfo.province + userinfo.city;
                customer.Add(cus);
            }

            //return View(userinfo);

            string cusid =  customer.GetEntity(x=>x.openid==userinfo.openid).openid;
            Session["cuid"] = cusid;
            return View(userinfo);
        }
    }
}