using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using System.Configuration;
using Senparc.Weixin.MP;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;

namespace WeShop.Controllers
{
    public class OAuthoController : Controller
    {
        // GET: OAutho
        //定义需要使用到的数据
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://zha.zhanghaotop.xin";
        public ActionResult Index(string returnUrl)
        {
            //需要自己构造一个url:https://open.weixin.qq.com/connect/oauth2/authorize?appid=CORPID&redirect_uri=REDIRECT_URI&response_type=code&scope=SCOPE&state=STATE#wechat_redirect
            //开发者可以任意填写参数值，其实就先当于验证码

            //注意：回调的地址，不能简单就是一个字符串，而应该是域名下面的一个页面，必须是一个完整的链接地址
            string callBackUrl = $"http://zha.zhanghaotop.xin{Url.Action("CallBack", new { returnUrl })}";
            // string callBackUrl = $"http://wx.minwebsite.xin{returnUrl}";
            string state = "wx" + DateTime.Now.Millisecond;
            //保存状态参数
            Session["state"] = state;
            string oauthorurl = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
            //跳转到授权页面
            return Redirect(oauthorurl);
        }
        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //注意:前提是先要判断用户输入进来的数据state是否满足
            if (Session["state"]?.ToString() != state)
            {
                Session["State"] = null;
                return Content("非安全方式登陆，登陆失败，请重新进入");

            }
            //把session中的数据清理
            Session["state"] = null;

            //判断用户返回的code
            if (string.IsNullOrEmpty(code))
            {
                return Content("未点击商城网址");
            }
            //以token换取accesstoken
            var accessToken = OAuthApi.GetAccessToken(appID, appsecret, code);

            if (accessToken.errcode != ReturnCode.请求成功)
            {
                //需要重新定位到授权页面
                return Content($"错误消息:{accessToken.errmsg}");
            }
            Session["authonAccessToken"] = accessToken;
            //以token 和oppenid来换取用户消息
            try
            {
                OAuthUserInfo usrinfo = OAuthApi.GetUserInfo(accessToken.access_token, accessToken.openid);
                Session["userInfo"] = usrinfo;
                return Redirect(returnUrl);
            }
            catch (Exception)
            {
                //如果是没有获取到用户的信息,则需要进入到授权页面
                var callBackUrl = $"http://zha.zhanghaotop.xin{Url.Action("Callback", new { returnUrl })}";
                // 随机数，用于加强回调请求的安全，避免被恶意请求，类似验证码
                state = "wx" + DateTime.Now.Millisecond;
                Session["State"] = state;


                var url = OAuthApi.GetAuthorizeUrl(appID, callBackUrl, state, OAuthScope.snsapi_userinfo);
                return Redirect(url);

            }
        }
        public ActionResult JsSdkConfig()
        {
            //构造url地址，注意是包含域名的
            string url = $"{Domin}{Request.RawUrl}";
            JsSdkUiPackage jssdkuipackage = JSSDKHelper.GetJsSdkUiPackage(appID, appsecret, url);
            return PartialView(jssdkuipackage);
        }
    }
}