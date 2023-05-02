using Microsoft.EntityFrameworkCore;
using CaseStudy.Models.DataAccess;
using CaseStudy.Models;
using Microsoft.AspNetCore.Identity;
using CaseStudy.Models.DataAccess.Configuration;

var builder = WebApplication.CreateBuilder(args);

// must be called before AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.AppendTrailingSlash = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core DI
builder.Services.AddDbContext<SportsProContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SportsProContext")));

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<SportsProContext>().AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
	await ConfigureIdentity.CreateAdminUserAsync(scope.ServiceProvider);
}

// must be called before routes are mapped
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
