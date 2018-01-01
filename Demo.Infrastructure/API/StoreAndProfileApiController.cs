using Demo.Core.Models;
using Demo.Core.Models.ModelsBuilder;
using Demo.Infrastructure;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using Demo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;

namespace Demo.API
{
    [MemberAuthorize]
    public class StoreAndProfileMaterialsApiController : UmbracoApiController // UmbracoAuthorizedApiController
    {
        //readonly DealerNetworkContext ctx = new DealerNetworkContext();
        //readonly MyPageRepository myPageRepo = new MyPageRepository();
        //readonly MemberRepository memberRepo = new MemberRepository();
        //readonly ComplaintReportRepository complaintReportRepo = new ComplaintReportRepository();

        public List<StoreAndProfileMaterialsVM> GetStoreAndProfileMaterials()
        {
            var res = SiteRepository.StoreAndProfileMaterials;
            return res;
        }
    }
}
