namespace MambaTemplate.Models
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Worker>? Workers { get; set; }


    }
}
