using Microsoft.AspNetCore.Identity;

namespace MambaTemplate.Models
{
    public class AppUser:IdentityUser
    {
        public string Country { get; set; }
    }
}
