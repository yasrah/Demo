using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace Demo.Infrastructure.Repositories
{
    public class MemberRepository
    {
        readonly MembershipHelper memberHelper = new MembershipHelper(UmbracoContext.Current);

        public string GetCurrentMemberName()
        {
            return memberHelper.GetCurrentMember().Name;
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
    }

}


