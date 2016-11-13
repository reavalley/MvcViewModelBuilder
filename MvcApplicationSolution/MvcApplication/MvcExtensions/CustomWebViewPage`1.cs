using System.Web.Mvc;

namespace MvcApplication.MvcExtensions
{
    public abstract class CustomWebViewPage<TModel> : WebViewPage<TModel>
    {
        public CustomHelper<TModel> ReaValley { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
            ReaValley = new CustomHelper<TModel>(ViewContext, this);
        }
    }
}