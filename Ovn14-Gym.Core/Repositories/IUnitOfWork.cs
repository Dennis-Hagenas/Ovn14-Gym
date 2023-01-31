namespace Ovn14_Gym.Data.Repositories
{
    public interface IUnitOfWork
    {
        IGymClassRepository GymClassRepository { get; }
        IApplicationUserGymClassRepository ApplicationUserGymClassRepository { get; }

        Task CompleteAsync();
    }
}