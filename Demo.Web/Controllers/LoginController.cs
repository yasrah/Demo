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
        public ActionResult ShowNewPasswordRequestForm()
        {
            var model = new ForgotenPasswordViewModel();
            return PartialView("~/Views/Partials/Demo/NewPasswordPagePartial.cshtml", model);
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
        [HttpPost]
        public ActionResult Email(ForgotenPasswordViewModel model)
        {
            //TODO: følgende er nødvedig for å validere model og evt vise melding.
            //    Akkurat nå feiler Send nytt pasord hvis epost ikke utfylt.
            //if (model sin Email property IKKE er utfylt)
            //{
            //    return samme side som bruekren er på og vis en melding met TempData["msg"] osv.
            //}
            String username =  Membership.GetUserNameByEmail(model.Email);
                MembershipUser user = Membership.GetUser(username);

            if (user != null){
                string oldpassword=user.ResetPassword();
                string newPassword= Membership.GeneratePassword(12,2);
                 
                bool password = user.ChangePassword(oldpassword,newPassword);
           
                umbraco.library.SendMail("m.y.rahmati@gmail.com",model.Email,"newPassword","hei "+ user + " passord endred: "+newPassword+"",false);
               
            }
              if (user==null){
             
                umbraco.library.SendMail("m.y.rahmati@gmail.com",model.Email,"newPassword","Ingen bruker med "+ model.Email+" er registrert i dette systemet",false);
               
            }
            TempData["Status"] = "Sjekk din inbox for nytt passord!";
            return Redirect("/");
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        
    }
}
