using Microsoft.EntityFrameworkCore;
using SistemaElecciones.Extensions;
using SistemaElecciones.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EleccionesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

}, ServiceLifetime.Scoped);


builder.Host.ConfigureServices(services =>
{
    services.AddRazorPages();
    services.AddRazorPages().AddRazorRuntimeCompilation();
});
builder.Services.WebInjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
