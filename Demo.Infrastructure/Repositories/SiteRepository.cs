using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Demo.Infrastructure.Constants;
using Umbraco.Web;

namespace Demo.Infrastructure.Repositories
{
    public class SiteRepository
    {

        public static UmbracoHelper _umbracoHelper
        {
            get
            {
                var umbracoContext = UmbracoContext.Current;
                var umbracoHelper = new Umbraco.Web.UmbracoHelper(umbracoContext);
                return umbracoHelper;
            }
        }

        public static IPublishedContent DealerHome
        {
            get
            {
                return _umbracoHelper.TypedContentAtRoot().FirstOrDefault(x => x.Id == Node.DealerHomeId);
            }
        }


        //public static Home Home
        //{
        //    get
        //    {
        //        return _umbracoHelper.TypedContentAtRoot().FirstOrDefault(x => x.Id == Constants.Nodes.homeId) as Home;
        //        //var home = _umbracoHelper.TypedContentAtRoot().FirstOrDefault(); //.Fi.Children<Home>();
        //        //return home as Home;
        //    }
        //}
        //public static Settings Settings
        //{
        //    get
        //    {
        //        return _umbracoHelper.TypedContentAtRoot().FirstOrDefault(x => x.Id == Constants.Nodes.settingsId) as Settings;
        //        //return _umbracoHelper.TypedContentAtRoot().Skip(1).Take(1) as Settings; //.Fi.Children<Home>();
        //    }
        //}

        //public static Menyfolder MenuFolder
        //{
        //    get
        //    {
        //        //return Settings.Children.FirstOrDefault(x => x.Id == Constants.Nodes.menuId);
        //        return Settings.FirstChild<Menyfolder>() as Menyfolder;
        //    }
        //}
        //public static ChefFolder ChefFolder
        //{
        //    get
        //    {
        //        //return Settings.Children.FirstOrDefault(x => x.Id == Constants.Nodes.menuId);
        //        return Settings.FirstChild<ChefFolder>() as ChefFolder;
        //    }
        //}
        //public static GalleryFolder GalleryFolder
        //{
        //    get
        //    {
        //        return Settings.FirstChild<GalleryFolder>() as GalleryFolder;
        //    }
        //}
        //public static IEnumerable<Menu> MenuItems
        //{
        //    get
        //    {
        //        return MenuFolder.Children<Menu>();
        //    }
        //}

        //public static List<Gallery> GalleryItems
        //{
        //    get
        //    {
        //        return GalleryFolder.Children<Gallery>().ToList();
        //    }
        //}

        //public static IEnumerable<Chef> Chefs
        //{
        //    get
        //    {
        //        return ChefFolder.Children<Chef>();
        //    }
        //}

        //public static IEnumerable<IPublishedContent> MainItems
        //{
        //    get
        //    {
        //        return MenuItems.Where(x => x.GetPropertyValue<string>("type").Equals(MenuType.main));
        //    }
        //}
        //public static IEnumerable<IPublishedContent> DessertItems
        //{
        //    get
        //    {
        //        return MenuItems.Where(x => x.GetPropertyValue<string>("type").Equals(MenuType.dessert));
        //    }
        //}
        //public static IEnumerable<IPublishedContent> DrinktItems
        //{
        //    get
        //    {
        //        return MenuItems.Where(x => x.GetPropertyValue<string>("type").Equals(MenuType.drink));
        //    }
        //}
        //public static IPublishedContent GetTypedMedia(int id)
        //{
        //    return _umbracoHelper.TypedMedia(id);
        //}
    }
}