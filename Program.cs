using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcStore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MvcStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcStoreContext") ?? throw new InvalidOperationException("Connection string 'MvcStoreContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
