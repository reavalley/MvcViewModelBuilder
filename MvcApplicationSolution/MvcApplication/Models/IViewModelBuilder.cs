namespace MvcApplication.Models
{
    public interface IViewModelBuilder
    {
        T Build<T>() where T : IViewModel;
    }
}