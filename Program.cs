using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Meetify.Models;
using Meetify.Data;
using Meetify.Business.IRepository;
using Meetify.Business.Repository;
using AutoMapper;
using Meetify.Mappings;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Register DbContext
builder.Services.AddDbContext<MeetifyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 Register Identity (optional, remove if unused)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MeetifyContext>()
    .AddDefaultTokenProviders();

// ✅ Add Razor Pages support
builder.Services.AddRazorPages();

// ✅ ADD THIS: Enable MVC Controllers with Views
builder.Services.AddControllersWithViews();

// 🔧 Register your custom repositories
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
// ✅ Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);



var app = builder.Build();

// 🔧 Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// ✅ Keep Razor Pages if you're using them
app.MapRazorPages();

// ✅ ADD THIS: Enable Controller Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 🔧 Run the application
app.Run();
