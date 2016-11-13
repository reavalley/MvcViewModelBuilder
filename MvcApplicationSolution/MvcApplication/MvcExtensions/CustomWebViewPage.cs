namespace MvcApplication.MvcExtensions
{
    public abstract class CustomWebViewPage : CustomWebViewPage<object>
    {
        public override void InitHelpers()
        {
            base.InitHelpers();
            ReaValley = new CustomHelper<object>(ViewContext, this);
        }
    }
}