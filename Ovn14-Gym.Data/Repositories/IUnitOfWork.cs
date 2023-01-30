namespace Ovn14_Gym.Data.Repositories
{
    public interface IUnitOfWork
    {
        GymClassRepository GymClassRepository { get; }

        Task CompleteAsync();
    }
}