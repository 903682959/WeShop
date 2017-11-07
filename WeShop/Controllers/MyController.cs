using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;

namespace WeShop.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        //查询客户
        public ICustomerService customer { get; set; }
        public ActionResult Index()
        {
            //
            //var c=customer.GetEntities(x=>true)
            var user = Session["oid"] as OAuthUserInfo;//得到openid
            var c = customer.GetEntities(x => x.cid == user.openid).ToList();
            if (c == null)
            {
                Customer cus = new Customer();
                cus.cid = user.openid;
                cus.image = user.headimgurl;
                cus.nickname = user.nickname;
                cus.openid = user.openid;
                cus.address = user.country + user.province + user.city;
                customer.Add(cus);
            }
            return View();
        }
    }
}