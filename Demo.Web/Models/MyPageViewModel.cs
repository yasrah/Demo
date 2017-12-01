using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace Demo.Web.Models
{
    public class MyPageViewModel
    {
        public MyPageViewModel()
        {
            var memberShipHelper = new Umbraco.Web.Security.MembershipHelper(UmbracoContext.Current);
            var memberId = memberShipHelper.GetCurrentMemberId();
            var memberService = ApplicationContext.Current.Services.MemberService;
            var m = memberService.GetById(memberId);

            Id = m.Id;
            Name = m.Name;
            Email = m.Email;
            Login = m.Name;

            var memberRoles = System.Web.Security.Roles.GetRolesForUser(m.Username);
            MemberGroup = string.Join(",", memberRoles.Select(item => item));

            MemberType = m.ContentType.Name;
            //FirstName = m.GetValue<string>("firstname");
            //LastName = m.GetValue<string>("lastname");
            //Address = m.GetValue<string>("Address");
            //ContactPerson = m.GetValue<string>("ContactPerson");
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string MemberType { get; set; }
        public string MemberGroup { get; set; }
        public string Name { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        //public string ContactPerson { get; set; }
    }
}