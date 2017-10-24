using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;


namespace WeShop.Controllers
{
    public class HomeController : Controller
    {
        //UI层，不能直接实例化BLL,应该利用IBLL
        public IBannerService BannerService { get; set; }
        //查询产品的
        public IProductService ProductService { get; set; }
        // GET: Home
        /// <summary>
        /// 商城首页
        /// </summary>
        /// <returns></returns>
        /// 
 
        public ActionResult Index()
        {
            //1:查询Banner，从数据库中查询
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();

            
            //最新  可以根据时间的排序来查询出前几条
            var Productresult = ProductService.GetEntities(x => true).OrderByDescending(x => x.Time).Take(3);
            ViewBag.Product = Productresult.ToList();
            return View();
        }
        public ActionResult hot()
        {
            //1:查询Banner，从数据库中查询
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();
            //查询最热  根据产品中的销量
            var Productresult = ProductService.GetEntities(x => true).OrderByDescending(x=>x.sales).Take(3);
            ViewBag.Product = Productresult.ToList();
            return View();
        }
        public ActionResult Latest()
        {
              return View();
        }
    }
}