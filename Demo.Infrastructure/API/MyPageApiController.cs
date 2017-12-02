using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using Demo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace Demo.API
{
    [MemberAuthorize]
    public class MyPageApiController : UmbracoApiController // UmbracoAuthorizedApiController
    {
        readonly DealerNetworkContext ctx = new DealerNetworkContext();
        readonly MyPageRepository myPageRepo = new MyPageRepository();

        public MyPageViewModel GetMyPageData()
        {
            System.Threading.Thread.Sleep(1000);
            var currentMember = myPageRepo.GetCurrentMember();
            return new MyPageViewModel(currentMember);
        }
        public MyPageViewModel UpdateMyPageData(MyPageViewModel model)
        {
            var myPageData = myPageRepo.UpdateMyPageData(model);
            return myPageData;
        }
    }
}
