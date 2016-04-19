using System.Collections.Generic;

namespace MvcApplication.Models
{
    public class DataViewModel : IViewModel
    {
        public IEnumerable<string> Data { get; set; }
    }
}
