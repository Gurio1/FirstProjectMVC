using AnimeWebSite.Infrastructure;
using AnimeWebSite.Services.Abstractions;
using AnimeWebSite.Services;
using Microsoft.EntityFrameworkCore;
using AnimeWebSite.Infrastructure.Repository;
using AnimeWebSite.Contracts.Profiles;
using AnimeWebSite.Identity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AnimeProfile).Assembly);

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContext<AnimeWebSiteDbContext>(config =>
{
    config.UseInMemoryDatabase("Memory");
})
   .AddIdentity<ApplicationUser,ApplicationRole>(options =>
   {
       options.Password.RequireDigit = true;
       options.Password.RequireLowercase = false;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequireUppercase = false;
       options.Password.RequiredLength = 6;
   })
   .AddEntityFrameworkStores<AnimeWebSiteDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Authentication/SignIn";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    InitializeDb.Init(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
