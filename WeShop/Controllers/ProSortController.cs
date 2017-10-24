using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

namespace WeShop.Controllers
{
    public class ProSortController : Controller
    {
        /// <summary>
        /// 查询出产品的类别
        /// </summary>
        /// <returns></returns>
        // GET: ProSort
        public ISortService SortService { get; set; }
        //查询产品的
        public IProductService ProductService { get; set; }
        public ActionResult Index()
        {
            var Sort = SortService.GetEntities(x => true);
            ViewBag.Sorts = Sort.ToList();

            var Productresult = ProductService.GetEntities(x => true);
            ViewBag.Product = Productresult.ToList();
            return View();
        }
    }
}