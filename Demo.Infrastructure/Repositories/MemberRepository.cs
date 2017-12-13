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
    public class MemberRepository
    {
        readonly MembershipHelper memberHelper = new MembershipHelper(UmbracoContext.Current);
        readonly IMemberService memberService = ApplicationContext.Current.Services.MemberService;

        public string GetCurrentMemberName()
        {
            return memberHelper.GetCurrentMember().Name;
        }


        public IEnumerable<IMember> GetAllMembers()
        {
            return ApplicationContext.Current.Services.MemberService.GetAllMembers();
        }
        public int GetCurrentMemberId()
        {
            return memberHelper.GetCurrentMember().Id;
        }

        public string[] GetCurrentMembersGroup()
        {
            var memberRoles = System.Web.Security.Roles.GetRolesForUser(GetCurrentMemberName());
            return memberRoles;
        }

        public bool IsCurrentMemberAdmin()
        {
            var memberRoles = System.Web.Security.Roles.GetRolesForUser(GetCurrentMemberName());
            return memberRoles.Any(r => r.Equals("Forhandlernett Admin"));
        }
    }
}


