namespace MambaTemplate.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProfessionId { get; set; }
        public Profession Profession { get; set; }
        public string Image { get; set; }
    }
}
