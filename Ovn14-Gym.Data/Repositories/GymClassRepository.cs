using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;
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

        public async Task<List<GymClass>> GetAsync()
        {
            //var model = await _context.GymClasses.IgnoreQueryFilters().ToListAsync();
            return await db.GymClasses.ToListAsync();
        }
    }
}
