using System.Collections.Generic;
using MvcApplication.Services;

namespace MvcApplication.Models
{
    public class DataViewModel : IViewModel
    {
        private readonly ITestService _testService;

        public DataViewModel(ITestService testService)
        {
            _testService = testService;
        }

        public IEnumerable<string> Data { get; set; }
        public void Build()
        {
            Data = _testService.GetData();
        }
    }
}
