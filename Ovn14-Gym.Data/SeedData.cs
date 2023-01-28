using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ovn14_Gym.Core.Entities;
using Ovn14_Gym.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovn14_Gym.Data
{
    public class SeedData
    {

        private static ApplicationDbContext db = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager = default!;
        public static async Task InitAsync(ApplicationDbContext context, IServiceProvider services, string adminPW)
        {
            if(context is null) throw new ArgumentNullException(nameof(context));
            db = context;

            ArgumentNullException.ThrowIfNull(nameof(services));
            ArgumentNullException.ThrowIfNull(adminPW ,nameof(adminPW));
       
        roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            ArgumentNullException.ThrowIfNull(roleManager);

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            ArgumentNullException.ThrowIfNull(userManager);

        var roleNames = new[] {"Member", "Admin"};
            var adminEmail = "admin@gym.se";

        
        
        
        
        }
    }
}
