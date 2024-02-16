using Microsoft.EntityFrameworkCore;
using Mission6_Mosarsaa.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MovieContext>();
    context.Database.EnsureCreated();

    if (!context.Movies.Any())
    {
        context.Movies.AddRange(
            new Movie { Title = "Farha", Year = 2020, Director = "Darin J. Sallam", Rating = "PG-13" },
            new Movie { Title = "Born in Gaza", Year = 2014, Director = "Hernan Zin", Rating = "R" },
            new Movie { Title = "Don't Look Up", Year = 2021, Director = "Adam Mckay", Rating = "R" }
        );
        context.SaveChanges();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
