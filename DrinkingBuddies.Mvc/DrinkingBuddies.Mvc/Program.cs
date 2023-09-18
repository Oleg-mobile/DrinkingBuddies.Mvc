using DrinkingBuddies.Domain;
using DrinkingBuddies.Domain.Models;
using DrinkingBuddies.Domain.Repositories;
using DrinkingBuddies.Mvc.Services.Accounts;
using DrinkingBuddies.Mvc.Services.Members;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Нужно ли перебросить на страницу аутентификации
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
        options.LoginPath = "/Account/Login";
        options.SlidingExpiration = true;
    });

builder.Services.AddTransient<IRepository<Member>, MemberRepository>();  // Внедрение зависимости (где используется это интерфейс, будет подтягиваться эта реализация)
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddDbContext<DrinkingBuddiesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(typeof(Program));

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
