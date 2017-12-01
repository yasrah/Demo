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
    public class LoginRepository
    {
        readonly MembershipHelper memberHelper = new MembershipHelper(UmbracoContext.Current);

        public string GetCurrentMemberName()
        {
            return memberHelper.GetCurrentMember().Name;
        }
    }

}


