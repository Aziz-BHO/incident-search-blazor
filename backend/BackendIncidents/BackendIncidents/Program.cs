using BackendIncidents.Data;
using BackendIncidents.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Connexion PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Incidents API", Version = "v1" });
});

builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();

var app = builder.Build();

// Enable Swagger UI (only in Development if you prefer)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incidents API v1");
        c.RoutePrefix = "swagger"; // UI served at /swagger
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();