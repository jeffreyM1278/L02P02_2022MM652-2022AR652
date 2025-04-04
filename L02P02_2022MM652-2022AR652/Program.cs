using L02P02_2022MM652_2022AR652.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Agregamos el DbContext con la cadena de conexión a SQL Server
builder.Services.AddDbContext<LibreriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("libreriaDBconnection")));

//  Agregamos MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

//  Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//  Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Autores}/{action=Index}/{id?}");

app.Run();