﻿namespace Ovn14_Gym.Core.Repositories
{
    public interface IUnitOfWork
    {
        IGymClassRepository GymClassRepository { get; }
        IApplicationUserGymClassRepository ApplicationUserGymClassRepository { get; }

        Task CompleteAsync();
    }
}