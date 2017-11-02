using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

namespace WeShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        //查询出购物车中对应的商品信息
        public IShopCartService shopcart { get; set; }
        public ActionResult Index()
        {

            return View();
        }
    }
}