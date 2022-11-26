using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Validaciones.Data;
using Validaciones.Data.Context;
using Validaciones.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
#region Configuracion de la base de datos SQLite
builder.Services.AddSqlite<MyDbContext>("Data Source=.//Data//Context//ValidacionDB.sqlite");
builder.Services.AddScoped<IMyDbContext,MyDbContext>();
#endregion
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IContactoService,ContactoService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
    MyDbContextSeeder.Inicializar(db);
}

app.Run();
