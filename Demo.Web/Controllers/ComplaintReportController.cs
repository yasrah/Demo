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
        readonly ComplaintReportRepository complaintReportRepo = new ComplaintReportRepository();

        public ActionResult ShowNewComplaintReport()
        {
            return PartialView("~/Views/Partials/Demo/NewComplaintReportPartial.cshtml");
        }

        public ActionResult ShowComplaintReport(int repotId)
        {
            //var id = Request.QueryString["id"];
            //var isLoggedIn = membershipRepo.IsCurrentMemberAuthenticated();
            //if (!isLoggedIn)
            //{
            //    //return Redirect("/login");
            //    //return RedirectToUmbracoPage(Constants.Node.LoginPageId);
            //    return PartialView("~/Views/Partials/SmartHus/NoAccess.cshtml");
            //    //return RedirectToUmbracoPage(Constants.Node.LoginPageId);
            //}
            //var dealers = dealerRepo.GetAll();
            var report = complaintReportRepo.GetComplaintReportById(repotId);
            return PartialView("~/Views/Partials/Demo/ComplaintReportShowPartial.cshtml", report);

        }

        public ActionResult ShowComplaintReportDashboard()
        {
            return PartialView("~/Views/Partials/Demo/ComplaintReportDashboardPartial.cshtml");
        }


    }
}