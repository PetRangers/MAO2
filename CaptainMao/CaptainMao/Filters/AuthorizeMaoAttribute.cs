using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaptainMao.Filters
{
    //自製AuthorizeMao，加入Email是否被驗證的條件。
    //參考MVC書中第12-26頁。
    public class AuthorizeMaoAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userId = filterContext.HttpContext.User.Identity.GetUserId();
                ApplicationUserManager userManager = filterContext.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = userManager.FindById(userId);
                var urlHelper = new UrlHelper(filterContext.RequestContext);

                var currentControllerAndActionName = string.Concat(filterContext.RouteData.Values["controller"], "_", filterContext.RouteData.Values["action"]);
                //以下名單中的Action不需Email驗證也可以進入
                var allowAction = new[]{"Account_Login", "Account_LogOff", "Account_VerifyEmail", "Account_ConfirmEmail"};

                

                //如果Email還沒驗證過，有些頁面就需要被重新導向。
                if (currentUser.EmailConfirmed == false)
                {
                    //不在特別名單的Action都重新導向Account_VerifyEmail
                    if (allowAction.Contains(currentControllerAndActionName) == false)
                    {
                        filterContext.Result = new RedirectResult(urlHelper.Action("VerifyEmail", "Account"));
                    }
                }
                //原本想加入被停權者的篩選機制，但這樣寫會造成無盡的redirection，暫時無法解決，只好寫在Login動作中。
                //else
                //{
                //    if (userManager.IsInRole(userId, "Inactivated"))
                //    {
                //        filterContext.Result = new RedirectResult(urlHelper.Action("Inactivated", "Account"));
                //    }
                //}
            }
        }
    }
}