using Demo.Core.Models;
using Demo.Infrastructure.Context;
using Demo.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Umbraco.Core.Logging;

namespace Demo.Infrastructure.Repositories
{
    public class StoreAndProfileMaterialsRepository
    {
        //readonly SiteRepository siteRepo = new SiteRepository();
        //readonly DealerNetworkContext ctx = new DealerNetworkContext();
        //public List<StoreAndProfileMaterialsVM> GetStoreAndProfileMaterials()
        //{
        //    return SiteRepository.StoreAndProfileMaterials;
        //}

        //public List<PartViewModel> GetPartsByQuery(string query)
        //{
        //    return ctx.Parts.Where(c => c.Description.Contains(query) || c.PartNo.ToString().Contains(query))
        //        .Select(p => new PartViewModel
        //        {
        //            PartId = p.PartId,
        //            PartNo = p.PartNo,
        //            Description = p.Description,
        //            Price = p.Price,
        //            Shipping = p.Shipping,
        //            Amount = 1,
        //        }).ToList();
        //}

    }
}
