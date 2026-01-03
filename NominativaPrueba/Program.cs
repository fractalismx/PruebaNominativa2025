using Microsoft.EntityFrameworkCore;
using Domain;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Configuration["Persistence:Provider"] ?? "SqlServer";

if (provider == "SqlServer")
{
    builder.Services.AddDbContext<RelationalDbContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

    builder.Services.AddScoped<IClienteRepository, ClienteRepositoryRelational>();
}
else if (provider == "Postgres")
{
    builder.Services.AddDbContext<RelationalDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

    builder.Services.AddScoped<IClienteRepository, ClienteRepositoryRelational>();
}
else
{
    throw new Exception("Proveedor de persistencia no soportado");
}

builder.Services.AddScoped<Bussiness.ClienteService>();

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
