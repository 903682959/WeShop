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

using WeShop.Filters;

namespace WeShop.Controllers
{
    [AuthorizeFiltere]
    public class CartController : Controller
    {
       
        // GET: Cart
        //查询出购物车中对应的商品信息
        public IShopCartService shopcart { get; set; }
        //查询客户
        public ICustomerService customer { get; set; }
        //产品
        public IProductService pro { get; set; }
        public ActionResult Index()
        {
            //获取用户的openid
            var userinfo = Session["userInfo"] as OAuthUserInfo;
            var c = customer.GetEntities(x => x.openid == userinfo.openid).ToList();
            var p = pro.GetEntities(x => true).ToList();
            string  ocid = Session["cuid"].ToString();
            var cart = shopcart.GetEntities(x => x.cid ==Convert.ToInt32(ocid)).Join(pro.GetEntities(y => true), a => a.ProCode, b => b.Code, (a, b) => new scar { img = b.images,money=b.price,describe=b.describe,name=b.Name }).ToList();
            ViewBag.shopcart = cart;
            return View();
        }
    }
    public class scar
    {
        public string  img { get; set; }
        public string  pimg { get; set; }//产品的图片
        public decimal?  money { get; set; }
        public string describe { get; set; }
        public string  name { get; set; }
    }
}