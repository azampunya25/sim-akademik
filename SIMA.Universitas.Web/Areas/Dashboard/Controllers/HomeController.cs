using Microsoft.AspNetCore.Mvc;
using SIMA.Universitas.Web.Abstractions;

namespace SIMA.Universitas.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : BaseController<HomeController>
    {
        public IActionResult Index()
        {
            _notify.Information("Hi There!");
            return View();
        }
    }
}