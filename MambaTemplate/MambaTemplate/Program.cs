using MambaTemplate.DAL;
using MambaTemplate.Models;
using MambaTemplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddScoped<_LayoutService>();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Lockout.AllowedForNewUsers = true;
    opt.Lockout.AllowedForNewUsers= true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}
).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); 
var app = builder.Build();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
