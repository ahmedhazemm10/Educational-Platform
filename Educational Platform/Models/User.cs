using Microsoft.AspNetCore.Identity;

namespace Educational_Platform.Models
{
    public class User : IdentityUser
    {
        public Student Student { get; set; }
    }
}
