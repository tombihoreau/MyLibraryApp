using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure la connexion à la base de données
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyLibraryDB")));

// Ajoute les services au conteneur
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure le pipeline de requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
