﻿namespace Ovn14_Gym.Core.Entities
{
#nullable disable
    public class ApplicationUserGymClass
    {
        public string ApllicationUserId { get; set; }
        public int GymClassId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public GymClass GymClass { get; set; }
    }
}