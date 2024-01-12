using MambaTemplate.DAL;
using MambaTemplate.Models;
using MambaTemplate.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        { 
            List<Profession> professions=await _context.Professions.ToListAsync();
            List<Worker> workers=await _context.Workers.ToListAsync();
            HomeVM homeVM = new HomeVM
            {
                Professions = professions,
                Workers = workers
            };   
            return View(homeVM);
        }
    }
}