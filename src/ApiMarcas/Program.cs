using ApiMarcas.Data;
using ApiMarcas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL connection from environment variables
var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "marcas_autos";
var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres";

var connectionString = $"Host={host};Database={database};Username={username};Password={password}";

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<MarcasContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MarcasContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        logger.LogInformation("Applying database migrations...");
        context.Database.Migrate();
        
        logger.LogInformation("Seeding initial data...");
        SeedData.Initialize(context);
        logger.LogInformation("Database initialized successfully");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while initializing the database");
    }
}

app.Run();

