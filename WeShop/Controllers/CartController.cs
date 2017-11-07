using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;


namespace WeShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //查询出购物车中对应的商品信息
        public IShopCartService shopcart { get; set; }
        public ActionResult Index()
        {
            //获取用户的openid
          string openid=  Session["oid"].ToString();
            //var cart=shopcart.GetEntities(x=>x.Cusid==openid && )
            return View();
        }
    }
    public class scar
    {
        public int MyProperty { get; set; }
    }
}