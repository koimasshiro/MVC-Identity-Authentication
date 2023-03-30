using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Auth_Mvc_App.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddAuthentication()
//    .AddGoogle(googleOptions =>
//    {
//        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//    })
//    .AddFacebook(facebookOptions =>
//    {
//        facebookOptions.AppId = builder.Configuration["Authentication:Facebook:ClientId"];
//        facebookOptions.ClientSecret = builder.Configuration["Authentication:Facebook:ClientSecret"];
//    });


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
