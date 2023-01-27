using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;

namespace Ovn14_Gym.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GymClass> GymClasses => Set<GymClass>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserGymClass>().HasKey(a => new { a.ApllicationUserId, a.GymClassId });

            builder.Entity<GymClass>().HasQueryFilter(g => g.StartTime > DateTime.UtcNow);

        }
    }
}