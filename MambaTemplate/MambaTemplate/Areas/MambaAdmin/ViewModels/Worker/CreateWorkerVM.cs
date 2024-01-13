using MambaTemplate.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MambaTemplate.Areas.MambaAdmin.ViewModels.Worker
{
    public class CreateWorkerVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProfessionId { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
    }
}
