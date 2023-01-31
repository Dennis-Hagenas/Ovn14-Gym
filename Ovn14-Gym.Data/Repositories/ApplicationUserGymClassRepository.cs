using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;
using Ovn14_Gym.Core.Repositories;
using Ovn14_Gym.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn14_Gym.Data.Repositories
{
    public class ApplicationUserGymClassRepository : IApplicationUserGymClassRepository
    {
        private readonly ApplicationDbContext db;

        public ApplicationUserGymClassRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(ApplicationUserGymClass augc)
        {
            db.AppUserGymClass.Add(augc);
        }
        public async Task<ApplicationUserGymClass> FindAsync(int id, string? userId)
        {
            //var currentGymClass = await _context.GymClasses.Include(g => g.AttendingMembers )
            //     .FirstOrDefaultAsync(g => g.Id == id);

            //var attending = currentGymClass?.AttendingMembers.FirstOrDefault(a => a.ApllicationUserId == userId);

            return await db.AppUserGymClass.FindAsync(userId, id);
        }

        public void Remove(ApplicationUserGymClass attending)
        {
            db.AppUserGymClass.Remove(attending);
        }
    }
}
