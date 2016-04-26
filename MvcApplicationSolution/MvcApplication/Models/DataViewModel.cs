using System.Collections.Generic;

namespace MvcApplication.Models
{
    public class DataViewModel : IViewModel
    {
        public DataViewModel()
        {
            ViewModelType = ViewModelType.Data;
        }

        public IEnumerable<string> Data { get; set; }
        public ViewModelType ViewModelType { get; set; }
    }
}
