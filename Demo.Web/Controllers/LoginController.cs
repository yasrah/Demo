using Demo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;
using System.Web.Security;

namespace Demo.Web.Controllers
{
    public class LoginController : SurfaceController
    {

        public ActionResult ShowLoginForm()
        {
            var model = new LoginViewModel();
            return PartialView("~/Views/Partials/Demo/LoginPartial.cshtml", model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (Membership.ValidateUser(model.Email, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                return Redirect("/");
            }

            TempData["Status"] = "Invalid Log-in Credentials";
            return RedirectToCurrentUmbracoPage();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        public ActionResult ShowMyPage()
        {
            //var loggedIn = User.Identity.IsAuthenticated;
            //if (!loggedIn)
            //{
            //    return PartialView("~/Views/Partials/Demo/NoAccess.cshtml");
            //}
            return PartialView("~/Views/Partials/Demo/MyPagePartial.cshtml", new MyPageViewModel());
        }
    }
}