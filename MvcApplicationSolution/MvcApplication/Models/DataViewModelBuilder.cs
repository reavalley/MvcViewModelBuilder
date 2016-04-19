using System.Linq;
using MvcApplication.Services;

namespace MvcApplication.Models
{
    public class DataViewModelBuilder : IViewModelBuilder<DataViewModel, int>
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ITestService _testService;

        public DataViewModelBuilder(IViewModelFactory viewModelFactory, ITestService testService)
        {
            _viewModelFactory = viewModelFactory;
            _testService = testService;
        }

        public DataViewModel Build(int parameters)
        {
            var viewModel = _viewModelFactory.CreateViewModel<DataViewModel>();
            viewModel.Data = _testService.GetData().Take(parameters);
            return viewModel;
        }
    }
}