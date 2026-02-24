using Comercializadora.Repository;
using Comercializadora.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IProductoRepository, ProductoRepository>();
builder.Services.AddSingleton<IDetalleFacturaRepository, DetalleFacturaRepository>();
builder.Services.AddSingleton<IFacturaRepository, FacturaRepository>();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
