using Ovn14_Gym.Data;
using Ovn14_Gym.Data.Data;

namespace Ovn14_Gym.Web.Extensions
{
    public static class ApplicationBuilderExetensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

                var config = serviceProvider.GetRequiredService<IConfiguration>();
                var adminPW = config["AdminPW"];

                ArgumentNullException.ThrowIfNull(adminPW, nameof(adminPW));

                try
                {
                    await SeedData.InitAsync(db, serviceProvider, adminPW);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
