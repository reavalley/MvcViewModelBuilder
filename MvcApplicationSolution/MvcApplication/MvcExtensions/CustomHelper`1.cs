using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication.MvcExtensions
{
    public class CustomHelper<TModel> : CustomHelper
    {
        public new ViewDataDictionary<TModel> ViewData { get; }

        public CustomHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
            : this(viewContext, viewDataContainer, RouteTable.Routes)
        {
        }
        
        public CustomHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
            : base(viewContext, viewDataContainer, routeCollection)
        {
                ViewData = new ViewDataDictionary<TModel>(viewDataContainer.ViewData);
            }
        }
}