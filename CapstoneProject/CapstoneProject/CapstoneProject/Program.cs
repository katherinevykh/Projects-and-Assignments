using CapstoneProject.Areas.Identity.Data;
using CapstoneProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<CapstoneProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity with roles
builder.Services.AddDefaultIdentity<CapstoneProjectUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Matches working login
})
.AddRoles<IdentityRole>()
.AddRoleManager<RoleManager<IdentityRole>>()
.AddEntityFrameworkStores<CapstoneProjectDbContext>();

// Configure cookie authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "CapstoneProjectCookie";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.LoginPath = "/Identity/Account/Login"; // Path to redirect for login
    options.AccessDeniedPath = "/Home/AccessDenied"; // Path to redirect for access denied
    options.SlidingExpiration = false;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.Cookie.MaxAge = TimeSpan.FromMinutes(60);
});

// Add Razor Pages services (needed for Identity UI)
builder.Services.AddRazorPages();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapStaticAssets();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map Razor Pages (including Identity pages)
app.MapRazorPages();

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map area routes (if you have other areas besides Identity)
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Redirect root to login page
app.MapGet("/", context =>
{
    context.Response.Redirect("/Home/Index"); // or another authenticated page
    return Task.CompletedTask;
});

// Seed roles
await RoleSeeder.SeedRolesAsync(app);

app.Run();