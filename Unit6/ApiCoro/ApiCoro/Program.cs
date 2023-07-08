using MusicianDomain.RepositoryContracts;
using MusicianRepository.RepositoryImplementations;
using MusicianService.ServiceContracts;
using MusicianService.ServiceImplementations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Configure app settings
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Servicio de la cache
builder.Services.AddMemoryCache(x =>
{
    x.SizeLimit = 2048;
    x.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
});

// Add services to the container.
builder.Services.AddTransient<ICoroService, CoroService>();
builder.Services.AddTransient<IConciertoRepository, ConciertoRepository>();
builder.Services.AddTransient<IMusicosRepository, MusicosRepository>();
builder.Services.AddTransient<IDiasOcupadosRepository, DiasOcupadosRepository>();
builder.Services.AddTransient<ICacheRepository, CacheRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Añadir documentacion a swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// To Use .json files on the wwwroot folder as https request to simulate external api
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
