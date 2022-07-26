using AnimeWebSite.Contracts;
using AnimeWebSite.Domain.Repositories;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Infrastructure;
using AnimeWebSite.Infrastructure.Repositories;
using AnimeWebSite.Services;
using AnimeWebSite.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AddAnimeViewModel).Assembly);

builder.Services.AddScoped<IAnimeRepository, AnimeRepository>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<IAnimeReviewsRepository, AnimeReviewsRepository>();


builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<IAnimeReviewsService, AnimeReviewsService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IFileSystemService, FileSystemService>();

builder.Services.AddDbContext<AnimeWebSiteDbContext>(config =>
{
    config.UseInMemoryDatabase("Memory");
})
   .AddIdentity<ApplicationUser, ApplicationRole>(options =>
   {
       options.Password.RequireDigit = true;
       options.Password.RequireLowercase = false;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequireUppercase = false;
       options.Password.RequiredLength = 6;

       options.User.RequireUniqueEmail = true;
       options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+���������������������������������������������������������������� ";
   })
   .AddEntityFrameworkStores<AnimeWebSiteDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Authentication/SignIn";
    options.AccessDeniedPath = "/Authentication/Reject";
});

var configuration = builder.Configuration;

builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = configuration["ExternalAuthentication:Facebook:AppId"];
    options.AppSecret = configuration["ExternalAuthentication:Facebook:AppSecret"];
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", builder =>
    {
        builder.RequireRole("Administrator");
    });

    options.AddPolicy("User", builder =>
    {
        builder.RequireRole("User", "Administrator");
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SeedDb.Init(scope.ServiceProvider);
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
