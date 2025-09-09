using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TourDbContext>(options =>
    options.UseInMemoryDatabase("TourDB"));

var app = builder.Build();

// Middleware
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

// DbContext scaffold
public class TourDbContext : DbContext
{
    public TourDbContext(DbContextOptions<TourDbContext> options) : base(options) { }
    public DbSet<Tour> Tours { get; set; }
}

public class Tour
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
