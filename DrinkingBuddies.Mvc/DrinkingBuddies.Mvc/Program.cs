using DrinkingBuddies.Domain;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using DrinkingBuddies.Mvc.Services.Members;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository<Member>, MemberRepository>();  // Внедрение зависимости (где используется это интерфейс, будет подтягиваться эта реализация)
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddDbContext<DrinkingBuddiesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof (Program));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Статичные файлы из wwwroot
app.UseStaticFiles();

app.Run();
