using System.ComponentModel.DataAnnotations;

namespace MambaTemplate.Areas.MambaAdmin.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsRemembered { get; set; }
    }
}
