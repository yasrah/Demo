using Demo.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Demo.Web.Models
{
    public class LeftMenuViewModel
    {
        readonly List<string> iconList = new List<string>() { "fa-edit", "fa-bar-chart-o" };
        public LeftMenuViewModel(IPublishedContent home, string[] memberGroups)
        {
            contentItem = home;
            Hidden = home.GetPropertyValue<bool>("hideInNavigation");
            Name = home.Name;
            Url = home.Url;
            if (home.DocumentTypeAlias == "purchase" && !memberGroups.Contains("Forhandlernett Admin"))
            {
                Show = false;
            }
            else
            {
                Show = true;
            }
            SubPages = new List<LeftMenuViewModel>();
            foreach (var child in home.Children())
            {
                SubPages.Add(new LeftMenuViewModel(child, memberGroups));
            }

            Icon = getIconForPage(home.DocumentTypeAlias);
        }
        public string Icon { get; set; }

        public IPublishedContent contentItem { get; set; }

        public bool Show { get; set; }

        public bool Hidden { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<LeftMenuViewModel> SubPages { get; set; }

        private string getIconForPage(string pageName)
        {
            switch (pageName)
            {
                case PageNames.ComplaintReport:
                    return iconList.ElementAt(0);
                case PageNames.Purchase:
                    return iconList.ElementAt(1); 
                default:
                    return "";
            }
        }


    }
}