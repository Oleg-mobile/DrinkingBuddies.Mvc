using DrinkingBuddies.Domain;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository<Member>, MemberRepository>();  // Нужно?
builder.Services.AddDbContext<DrinkingBuddiesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof (Program));

var app = builder.Build();

app.UseRouting();
// Статичные файлы из wwwroot
app.UseStaticFiles();

//app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
