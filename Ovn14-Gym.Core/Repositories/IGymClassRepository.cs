using Ovn14_Gym.Core.Entities;

namespace Ovn14_Gym.Data.Repositories
{
    public interface IGymClassRepository
    {
        void Add(GymClass gymClass);
        Task<GymClass> FindAsync(int id);
        Task<List<GymClass>> GetAsync();
        Task<GymClass> GetAsync(int id);
        bool GymClassExists(int id);
        void Remove(GymClass gymClass);
    }
}