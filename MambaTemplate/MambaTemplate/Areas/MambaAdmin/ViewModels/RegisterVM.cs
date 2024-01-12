using System.ComponentModel.DataAnnotations;

namespace MambaTemplate.Areas.MambaAdmin.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Password { get; set; }



    }
}
