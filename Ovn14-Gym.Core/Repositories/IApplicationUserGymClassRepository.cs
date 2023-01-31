using Ovn14_Gym.Core.Entities;

namespace Ovn14_Gym.Core.Repositories
{
    public interface IApplicationUserGymClassRepository
    {
        void Add(ApplicationUserGymClass augc);
        Task<ApplicationUserGymClass> FindAsync(int id, string? userId);
        void Remove(ApplicationUserGymClass attending);
    }
}