namespace MambaTemplate.Areas.MambaAdmin.ViewModels.Worker
{
    public class UpdateWorkerVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProfessionId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
