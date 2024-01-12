using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace MambaTemplate.Areas.MambaAdmin.Controllers
{
    [Area("MambaAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
