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
        //类别
        public IProSortService prosort { get; set; }
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
            List<num> stock1 = stock.GetEntities(x => x.pcode == pcode).Join(productresult.GetEntities(x => true),
                                  a => a.pcode = pcode, b => b.Code, (a, b) => new num { pcode = a.pcode, pname = b.Name, images = b.images, details = b.contents, price = b.price, describe = b.describe, stock = a.num, time = b.Time, sale=a.sale }).ToList();
           ViewBag.ck = stock1;

            //连接评价
            //var all = proreview.GetEntities(x => x.Procode == pcode && x.Procode== cus[0].cid).ToList();
            //ViewBag.AllInfo = all;
            //List<proreview> all = proreview.GetEntities(x => x.Procode == pcode && x.Procode == cus[0].cid).Join(productresult.GetEntities(x=>true).Join(customer.GetEntities(x=>true),
            //          v=>v.Code=pcode,b=>b.cid,a=>a.Procode,(v,b,a)=>new proreview { code=v.Code}).

            return View();
        }
    }
    public class num
    {
        public string pcode { get; set; }
        public string images { get; set; }
        public string pname { get; set; }
        public string details { get; set; }
        public decimal? price { get; set; }
        public string describe { get; set; }
        public int? stock { get; set; }
        public DateTime time { get; set; }
        public int? sale { get; set; }
    }
    public class proreview
    {
        public string code { get; set; }
    }
}