using FilmlisteApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Razor Components (Blazor Server)
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

// DbContext + SQLite
builder.Services.AddDbContext<FilmDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("FilmDb")
    ));

// (valgfritt, men nyttig)
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Razor Components endepunkt
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
