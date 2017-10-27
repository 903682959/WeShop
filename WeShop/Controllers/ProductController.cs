using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

namespace WeShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //查询产品的
        public IProductService Productresult { get; set; }
        public ActionResult Index()
        {
            string pcode = Request["id"];
            var product = Productresult.GetEntities(x => x.ProductSortid == pcode).ToList();
            //List<Product> product= Productresult.GetEntities(x => x.Code == pcode).ToList();
            ViewBag.product = product;
            return View();
        }
        public ActionResult Price()
        {
            var  product = Productresult.GetEntities(x =>true).OrderByDescending(x=>x.price).ToList();
            ViewBag.price = product;
            return View();
        }
    }
}