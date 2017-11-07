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
            string pcode = Request["id"];//从地址栏接受的值
            var product = Productresult.GetEntities(x => x.ProductSortid == pcode).ToList();
            //List<Product> product= Productresult.GetEntities(x => x.Code == pcode).ToList();
            ViewBag.product = product;
            ViewBag.id = pcode;

            return View();
        }
        public ActionResult Price()
        {
           
            //var  product = Productresult.GetEntities(x =>true).OrderByDescending(x=>x.price).ToList();
            //ViewBag.price = product;
           // int id = Convert.ToInt32(Request["cid"]);//从前台页面接受的值
                                       //List<Product> p = Productresult.GetEntities(x => true).OrderByDescending(x => x.price).ToList();
                                       //string html = "";
                                       //foreach (Product item in p)
                                       //{
                                       //    html +=@"<li>
                                       //        <a href = '/Detail/index/?id=@item.Code' >
                                       //              <img src = '/images/"+item.images+@"'>
                                       //            <div class='search_item'>
                                       //                <p>"+item.Name+@"</p>
                                       //                <h2><i>￥</i><b>"+ item.price + @"</b></h2>
                                       //            </div>
                                       //        </a>
                                       //    </li>";
                                       //}

            
            //测试
            string pcode = Request["id"];
            int id = Convert.ToInt32(Request["cid"]);
            if (id == 0)
            {
                var product = Productresult.GetEntities(x => x.ProductSortid == pcode).ToList();
                string zhtml = "";
                foreach (var item in product)
                {
                    zhtml += @"<li>
                    <a href = '/Detail/index/?id=@item.Code'>
                          <img src = '/images/" + item.images + @"'>
                        <div class='search_item'>
                            <p>" + item.Name + @"</p>
                            <h2><i>￥</i><b>" + item.price + @"</b></h2>
                        </div>
                    </a>
                </li>";
                }
                return Content(zhtml);
            }
            else
            {
                string phtml = "";
                //找出相对应的的价格
                List<Product> p = Productresult.GetEntities(x => x.ProductSortid == pcode).OrderByDescending(x => x.price).ToList();
                foreach (Product item in p)
                {
                    phtml += @"<li>
                    <a href = '/Detail/index/?id=@item.Code'>
                          <img src = '/images/" + item.images + @"'>
                        <div class='search_item'>
                            <p>" + item.Name + @"</p>
                            <h2><i>￥</i><b>" + item.price + @"</b></h2>
                        </div>
                    </a>
                </li>";
                }
                return Content(phtml);
            }
            //return Content(Request["cid"]);
            //return View();
        }
    }
}