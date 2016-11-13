using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication.MvcExtensions
{
    public class CustomHelper
    {
        public CustomHelper(ViewContext viewContext, IViewDataContainer viewDataContainer) : this(viewContext, viewDataContainer, RouteTable.Routes) {
        }

        public CustomHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
        {
            ViewContext = viewContext;
            ViewData = new ViewDataDictionary(viewDataContainer.ViewData);
        }

        public ViewDataDictionary ViewData
        {
            get;
            private set;
        }

        public ViewContext ViewContext
        {
            get;
            private set;
        }
    }
}