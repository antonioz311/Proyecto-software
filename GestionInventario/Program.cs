// Program.cs
using GestionInventario.Repositories;
using GestionInventario.Services;


var builder = WebApplication.CreateBuilder(args);

// Añadir DbContext con conexión MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
    new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();



var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar repositorios
builder.Services.AddSingleton<UsuarioRepositorio>();
builder.Services.AddSingleton<ProveedorRepositorio>();
builder.Services.AddSingleton<ProductoRepositorio>();
builder.Services.AddSingleton<MovimientoRepositorio>();

// Registrar servicios
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<ProveedorServicio>();
builder.Services.AddScoped<ProductoServicio>();
builder.Services.AddScoped<MovimientoServicio>();
builder.Services.AddScoped<InventarioServicio>();

var app = builder.Build();

// Configurar el pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Gestión de Inventarios v1");
        c.RoutePrefix = string.Empty; // Swagger como página de inicio
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
