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
    public class GymClassRepository : IGymClassRepository
    {
        private readonly ApplicationDbContext db;

        public GymClassRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public void Add(GymClass gymClass)
        {
            db.GymClasses.Add(gymClass);
        }


        public void Remove(GymClass gymClass)
        {
            db.GymClasses.Remove(gymClass);
        }
        public async Task<GymClass> FindAsync(int id)
        {
            return await db.GymClasses.FindAsync(id);
        }
        public async Task<List<GymClass>> GetAsync()
        {
            //var model = await _context.GymClasses.IgnoreQueryFilters().ToListAsync();
            return await db.GymClasses.ToListAsync();
        }

        public async Task<GymClass> GetAsync(int id)
        {
           return await db.GymClasses
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public bool GymClassExists(int id)
        {
            return (db.GymClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<GymClass>> GetWithAttendingAsync()
        {
            return await db.GymClasses.Include(g => g.AttendingMembers).ToListAsync();
        }

        public async Task<IEnumerable<GymClass>> GetHistoryAsync()
        {
            return await db.GymClasses
                .Include(g => g.AttendingMembers)
                .IgnoreQueryFilters()
                .Where(g => g.StartTime < DateTime.Now).ToListAsync();
        }
    }
}
