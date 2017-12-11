using Demo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Demo.Infrastructure.Models
{
    public class MyPageViewModel
    {
        public MyPageViewModel()
        {
        }
        public MyPageViewModel(IMember m)
        {
            Id = m.Id;
            Name = m.Name;
            Email = m.Email;
            Login = m.Name;

            var memberRoles = Roles.GetRolesForUser(m.Username);
            MemberGroup = string.Join(",", memberRoles.Select(item => item));

            MemberType = m.ContentType.Name;
            FirstName = m.GetValue<string>("firstname");
            LastName = m.GetValue<string>("lastname");
            Address = m.GetValue<string>("Address");
            ContactPerson = m.GetValue<string>("ContactPerson");
            IsAdmin = new MemberRepository().IsCurrentMemberAdmin();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string MemberType { get; set; }
        public string MemberGroup { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
    }
}