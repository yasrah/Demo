using Demo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Demo.Web.Controllers
{
    public class LoginController : SurfaceController
    {

        public ActionResult ShowLoginForm()
        {
            var model = new LoginViewModel();
            return PartialView("~/Views/Partials/Demo/LoginPartial.cshtml", model);
        }
    }
}