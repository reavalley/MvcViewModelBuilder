using System;
using System.Collections.Generic;

namespace MvcApplication.Services
{
    public interface ITestService
    {
        IEnumerable<string> GetData();
    }

    public class TestService : ITestService
    {
        public IEnumerable<string> GetData()
        {
            return new[] { "This", "Is", "Some", "Data" };
        }
    }
}
