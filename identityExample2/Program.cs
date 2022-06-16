using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using identityExample2.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("identityExample2ContextDbConnection") ?? throw new InvalidOperationException("Connection string 'identityExample2ContextDbConnection' not found.");

builder.Services.AddDbContext<identityExample2ContextDb>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<identityExample2User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<identityExample2ContextDb>();;

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
