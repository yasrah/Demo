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
    public class NavigationController : SurfaceController
    {
        //readonly MyPageRepository myPageRepo = new MyPageRepository();
        readonly MemberRepository memberRepo = new MemberRepository();

        public ActionResult ShowLeftMenu()
        {
            var dealerHome = SiteRepository.DealerHome;
            var memberRoles = memberRepo.GetCurrentMembersGroup();
            var leftMenuViewModel = new LeftMenuViewModel(dealerHome, memberRoles);

            return PartialView("~/Views/Partials/Demo/LeftMenuPartial.cshtml", leftMenuViewModel);
        }
    }
}