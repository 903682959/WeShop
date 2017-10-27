using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;


namespace WeShop.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        //商品详细信息    评价    收藏
        //产品
        public IProductService productresult { get; set; }
        //评价

        public ActionResult Index()
        {
            return View();
        }
    }
}