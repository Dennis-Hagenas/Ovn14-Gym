using Ovn14_Gym.Core.Repositories;
using Ovn14_Gym.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn14_Gym.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;

        public IGymClassRepository GymClassRepository { get; }
        public IApplicationUserGymClassRepository ApplicationUserGymClassRepository { get; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this.db = db;
            GymClassRepository = new GymClassRepository(db);
            ApplicationUserGymClassRepository = new ApplicationUserGymClassRepository(db);
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
