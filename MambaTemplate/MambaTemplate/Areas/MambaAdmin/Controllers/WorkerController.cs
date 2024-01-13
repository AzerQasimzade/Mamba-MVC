using MambaTemplate.Areas.MambaAdmin.ViewModels.Worker;
using MambaTemplate.DAL;
using MambaTemplate.Models;
using MambaTemplate.Utilities.Enums;
using MambaTemplate.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaTemplate.Areas.MambaAdmin.Controllers
{
    [Area("MambaAdmin")]
    public class WorkerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public WorkerController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
           List<Worker> workers=await _context.Workers.Include(c=>c.Profession).ToListAsync();
           return View(workers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkerVM workerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!workerVM.Photo.ValidateFileType(FileHelper.Image))
            {
                ModelState.AddModelError("Photo", "File Type uygun deyil!");
                return View();
            }
            if (!workerVM.Photo.ValidateSize(SizeHelper.mb))
            {
                ModelState.AddModelError("Photo", "File olcusu uygun deil!");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + workerVM.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "admin", "images", "faces",filename);
            FileStream file = new FileStream(path, FileMode.Create);
            await workerVM.Photo.CopyToAsync(file);
         
            Worker worker = new Worker
            {
                Image=filename,
                Name = workerVM.Name,
                Surname = workerVM.Surname,
                ProfessionId= workerVM.ProfessionId
            }; 
            await _context.Workers.AddAsync(worker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            Worker existed = await _context.Workers.FirstOrDefaultAsync(x => x.Id == id);
            if (existed is null)
            {
                return NotFound();
            }
            UpdateWorkerVM workerVM = new UpdateWorkerVM
            {
                Name = existed.Name,
                Surname = existed.Surname,
                Photo = existed.Photo,
                ProfessionId = existed.ProfessionId
            };
            return View(workerVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,UpdateWorkerVM updateWorkerVM)
        {
            Worker existed=await _context.Workers.FirstOrDefaultAsync(w=>w.Id == id);
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (updateWorkerVM.Photo is not null)
            {
                if (!updateWorkerVM.Photo.ValidateFileType(FileHelper.Image))
                {
                    ModelState.AddModelError("Photo", "File Type uygun deyil!");
                    return View();
                }
                if (!updateWorkerVM.Photo.ValidateSize(SizeHelper.mb))
                {
                    ModelState.AddModelError("Photo", "File olcusu uygun deil!");
                    return View();
                }
                string filename = Guid.NewGuid().ToString() + updateWorkerVM.Photo.FileName;
                string path = Path.Combine(_env.WebRootPath, "admin", "images", "faces", filename);
                FileStream file = new FileStream(path, FileMode.Create);
                await updateWorkerVM.Photo.CopyToAsync(file);
                existed.Image.DeleteFile(_env.WebRootPath, "admin", "images", "faces");
                existed.Image = filename;
            }
            existed.Name= updateWorkerVM.Name;
            existed.Surname= updateWorkerVM.Surname;
            existed.ProfessionId= updateWorkerVM.ProfessionId;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

    }
}
