using AnimeWebSite.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AnimeWebSiteDbContext>(config =>
{
    config.UseInMemoryDatabase("Memory");
});


builder.Services.AddAuthentication("Cookie").AddCookie("Cookie",config =>
{
    config.LoginPath = "/Authentication/SignIn";
});

builder.Services.AddAuthorization();

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AnimeWebSiteDbContext>();
InitializeDb.Init(context);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
