using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace Demo.Infrastructure.Repositories
{
    public class MyPageRepository
    {
        readonly MembershipHelper membershipHelper = new MembershipHelper(UmbracoContext.Current);
        readonly IMemberService memberService = ApplicationContext.Current.Services.MemberService;

        public IMember GetCurrentMember()
        {
            var memberId = membershipHelper.GetCurrentMemberId();
            var memberService = ApplicationContext.Current.Services.MemberService;
            var m = memberService.GetById(memberId);
            return m;
        }

        public MyPageViewModel UpdateMyPageData(MyPageViewModel model)
        {
            var m = GetCurrentMember() as Member ;
            var member = memberService.GetById(m.Id);

            if (member == null)
            {
                // TODO something wrong!
            }
            member.Name = model.Name;
            member.SetValue("firstname", model.FirstName);
            member.SetValue("lastname", model.LastName);
            memberService.Save(member);

            return model;
        }
    }
}
