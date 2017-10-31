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
        public IProReviewService proreview { get; set; }
        //用户
        public ICustomerService customer { get; set; }
        //库存
        public IStockService stock { get; set; }
        public ActionResult Index()
        {
            //接受传过来的产品id
            string pcode = Request["id"];
            //查询出客户的信息
            List<Customer> cus = customer.GetEntities(x => true).ToList();
            //产品
            var pro = productresult.GetEntities(x =>x.Code==pcode).ToList();
            ViewBag.product = pro;
            //连接产品与库存
            var ps = stock.GetEntities(x =>x.pcode == pcode).ToList();
            ViewBag.ck = ps;
            //连接评价
            var all = proreview.GetEntities(x => x.Procode == pcode && x.Procode== cus[0].cid).ToList();
            ViewBag.AllInfo = all;
            return View();
        }
    }
}