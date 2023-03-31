using Microsoft.AspNetCore.Identity;

namespace BookStore_CoreAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
