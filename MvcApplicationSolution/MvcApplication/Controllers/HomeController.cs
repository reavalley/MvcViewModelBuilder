using MvcApplication.Models;
using MvcApplication.Services;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IViewModelBuilder _viewModelBuilder;

        public HomeController(IViewModelBuilder viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;
        }

        public ActionResult Index()
        {
            var viewModel = _viewModelBuilder.Build<DataViewModel>();
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