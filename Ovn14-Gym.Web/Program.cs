using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Ovn14_Gym.Core.Entities;
using Ovn14_Gym.Data.Data;
using Ovn14_Gym.Data.Repositories;
using Ovn14_Gym.Web.Data;
using Ovn14_Gym.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric= false;
    options.Password.RequireUppercase= false;
    options.Password.RequireLowercase= false;
    options.Password.RequireDigit= false;
    options.Password.RequiredLength = 3;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
//    .RequireRole("Member")
    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required");

});

//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("Test", policy =>
//    {
//        policy.RequireRole("Admin");
//        policy.RequireClaim("Test");
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/GymClasses/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.SeedDataAsync();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=GymClasses}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
