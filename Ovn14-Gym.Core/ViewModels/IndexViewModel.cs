using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn14_Gym.Core.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<GymClassViewModel> GymClass { get; set; }
        public bool ShowHistory { get; set; }
    }
}
