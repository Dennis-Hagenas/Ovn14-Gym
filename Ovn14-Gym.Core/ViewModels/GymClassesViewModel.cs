using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn14_Gym.Data.ViewModels
{
    public class GymClassesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime? StartTime { get; set; }

        [Required]
        public TimeSpan? Duration { get; set; }
        public DateTime? EndTime { get { return StartTime + Duration; } }
        public string Description { get; set; } = string.Empty;
    }
}
