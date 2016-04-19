using MvcApplication.Models;
using MvcApplication.Services;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelBuilder<DataViewModel, int> _viewModelBuilder;

        public HomeController(IViewModelBuilder<DataViewModel, int> viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;
        }

        public ActionResult Index()
        {
            var parameters = new DataViewModelParameters { Top = 2};
            var viewModel = _viewModelBuilder.Build(2);
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}