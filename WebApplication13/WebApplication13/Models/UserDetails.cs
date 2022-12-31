using Microsoft.AspNetCore.Identity;
namespace WebApplication13.Models
{
    public class UserDetails :IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
