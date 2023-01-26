using Microsoft.AspNetCore.Identity;

namespace Ovn14_Gym.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<ApplicationUserGymClass> AttendedClasses { get; set; }
    }
}
