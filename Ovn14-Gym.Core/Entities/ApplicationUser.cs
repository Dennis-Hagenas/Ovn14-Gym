using Microsoft.AspNetCore.Identity;

namespace Ovn14_Gym.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserGymClass> AttendingClasses { get; set; } = new List<ApplicationUserGymClass>();
    }
}
