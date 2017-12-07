using Demo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;
using System.Web.Security;
using Demo.Infrastructure.Models;
using Demo.Infrastructure.Repositories;

namespace Demo.Web.Controllers
{
    public class ComplaintReportController : SurfaceController
    {
        //readonly MyPageRepository myPageRepo = new MyPageRepository();

        public ActionResult ShowNewComplaintReport()
        {
            return PartialView("~/Views/Partials/Demo/NewComplaintReportPartial.cshtml");
        }
    }
}