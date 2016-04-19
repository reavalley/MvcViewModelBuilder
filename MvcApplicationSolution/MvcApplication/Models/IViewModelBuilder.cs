namespace MvcApplication.Models
{
    public interface IViewModelBuilder<out TViewModel, in TInput> where TViewModel : IViewModel
    {
        TViewModel Build(TInput parameters);
    }
}