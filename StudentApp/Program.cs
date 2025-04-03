using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using StudentApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your DbContext and read the connection string from appsettings.json
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed database with initial data (Bart & Lisa)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<StudentContext>();
    context.Database.Migrate(); // Apply any pending migrations

    if (!context.Students.Any())
    {
        context.Students.AddRange(
            new Student
            {
                FirstName = "Bart",
                LastName = "Simpson",
                DateOfBirth = new DateTime(1971, 5, 31),
                GPA = 2.7,
                MyField = "Skateboarding"
            },
            new Student
            {
                FirstName = "Lisa",
                LastName = "Simpson",
                DateOfBirth = new DateTime(1973, 8, 5),
                GPA = 4.0,
                MyField = "Saxophone"
            }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
