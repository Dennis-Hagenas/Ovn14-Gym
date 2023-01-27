namespace Ovn14_Gym.Models
{
    public class ApplicationUserGymClass
    {
        public string ApllicationUserId { get; set; }
        public string GymClassId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public GymClass GymClass { get; set; }
    }
}
