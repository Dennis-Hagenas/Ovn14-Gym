using Microsoft.AspNetCore.Identity;

namespace Ovn14_Gym.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime TimeOfRegistration { get; set; }

        public ICollection<ApplicationUserGymClass> AttendingClasses { get; set; } = new List<ApplicationUserGymClass>();
    }
}
