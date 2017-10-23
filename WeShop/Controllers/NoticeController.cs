using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.IService;

namespace WeShop.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice
        public InoticeService notice { get; set; }
        public ActionResult Index()
        {
            var n = notice.GetEntities(x => true);
            ViewBag.notices = n.ToList();
            return View();
        }
        public ActionResult xq()
        {

            return View();
        }
    }
}