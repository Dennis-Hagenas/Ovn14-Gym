using Ovn14_Gym.Core.Entities;

namespace Ovn14_Gym.Data.Repositories
{
    public interface IGymClassRepository
    {
        Task<List<GymClass>> GetAsync();
    }
}