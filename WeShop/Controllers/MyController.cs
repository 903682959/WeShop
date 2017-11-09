using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

using WeShop.Filters;

namespace WeShop.Controllers
{
    [AuthorizeFiltere]
    public class MyController : Controller
    {
        // GET: My
        //查询客户
       
        public ICustomerService customer { get; set; }
        public ActionResult Index()
        {
            var userinfo = Session["userInfo"] as OAuthUserInfo;
            var c = customer.GetEntities(x => x.openid == userinfo.openid).ToList();
            if (c.Count==0)
            {
                Customer cus = new Customer();
                cus.cid = userinfo.openid;
                cus.openid = userinfo.openid;
             cus.nickname = userinfo.nickname;
                cus.tel = "";
                cus.address = userinfo.country + userinfo.province + userinfo.city;
                cus.image = userinfo.headimgurl;
                customer.Add(cus);
                

            }

            return View(userinfo);
            
        }
    }
}