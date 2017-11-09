using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeShop.Filters
{
    public class AuthorizeFiltereAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["authonAccessToken"] == null)
            {
                //1:获取当前请求的页面
                string returnUrl = filterContext.HttpContext.Request.RawUrl;
                UrlHelper url = new UrlHelper(filterContext.RequestContext);

                filterContext.Result = new RedirectResult(url.Action("Index", "OAutho", new { returnUrl }));
            }
        }
    }
}