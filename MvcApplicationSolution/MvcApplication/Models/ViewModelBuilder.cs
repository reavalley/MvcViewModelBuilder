namespace MvcApplication.Models
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly IViewModelFactory _viewModelFactory;

        public ViewModelBuilder(IViewModelFactory viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public T Build<T>() where T : IViewModel
        {
            var viewModel = _viewModelFactory.CreateViewModel<T>();
            viewModel.Build();
            return viewModel;
        }
    }
}