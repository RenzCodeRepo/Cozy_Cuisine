using Cozy_Cuisine.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cozy_Cuisine.Data.IRepositories;
using Cozy_Cuisine.Data.Repositories;
using Cozy_Cuisine.Data.IServices;
using Cozy_Cuisine.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Load appsettings.json + environment-specific appsettings
var environment = builder.Environment.EnvironmentName;

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the repository for Dependency Injection
builder.Services.AddScoped<IPatchRepository, PatchRepository>();
builder.Services.AddScoped<IWikiRepository, WikiRepository>();
builder.Services.AddScoped<IManageRepository, ManageRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();



// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Ensure database is created and seed users
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Apply pending migrations
    DbInitializer.SeedUsers(services).Wait(); // Call the seeding method
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
