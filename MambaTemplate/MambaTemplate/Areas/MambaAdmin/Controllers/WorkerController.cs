using MambaTemplate.DAL;
using MambaTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace MambaTemplate.Areas.MambaAdmin.Controllers
{
    [Area("MambaAdmin")]
    public class WorkerController : Controller
    {
        private readonly AppDbContext _context;

        public WorkerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
            return View();
        }

    }
}
