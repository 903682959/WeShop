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
        /// 查询类别作为一级栏目
        /// </summary>
        /// <returns></returns>
        // GET: 
        public ISortService SortService { get; set; }
        //查询产品的
        //public IProductService ProductService { get; set; }
        //查询产品类别可以做二级栏目
        public IProSortService ProSortService { get; set; }
        public ActionResult Index()
        {
            List<Sort> Sorts= SortService.GetEntities(x => true).ToList();
            ViewBag.Sortresult = Sorts;

            var s = ProSortService.GetEntities(a => a.SortCode==Sorts[0].Code);
            ViewBag.s = s;
            return View();
        }
        public ActionResult ProSortdata()
        {
            string id = Request["id"];
            List<ProSort> s = ProSortService.GetEntities(a => a.SortCode == id).ToList();
            string shtml = "";
            foreach (ProSort item in s)
            {
                shtml += @"<li>

                            <a class='imga' href='/Product/Index'><img src='/images/" + item.Pimg+ @"'></a>
                              <a class='txta' href='/Product/Index'>
                                <span>" + item.Pname + @"</span>
                                <i>" + item.Pdesc + @"</i>
                            </a>
                        </li>";
            }
            return Content(shtml);
         }
    }
}