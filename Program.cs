using Microsoft.EntityFrameworkCore;
using SirvalApi.Models.SirvalApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios

// Agrega el contexto de base de datos con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), // Cadena de conexión
        new MySqlServerVersion(new Version(8, 0, 21)), // Versión de MySQL
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

// Agrega controladores y configura el comportamiento de JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantener nombres exactos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; // Ignorar referencias circulares
    });

// Configura Swagger para documentación API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Sirval API", Version = "v1" });
});

var app = builder.Build();

// Configuración del pipeline de middleware

// Si estamos en desarrollo, usa Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sirval API v1.0");
    });
}

// Redirección HTTPS para seguridad
app.UseHttpsRedirection();

// Autorización (aunque no está implementada aún)
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

// Ejecuta la aplicación
app.Run();