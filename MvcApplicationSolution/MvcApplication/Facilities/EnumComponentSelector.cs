using Castle.Facilities.TypedFactory;

namespace MvcApplication.Facilities
{
    public class EnumComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(System.Reflection.MethodInfo method, object[] arguments)
        {
            return arguments[0].ToString();
        }
    }
}