using Domain.RepositoryContracts;
using Domain.ServiceContracts;
using Domain.ServiceImplementations;
using Infrastructure.RepositoryImplementations;
using Microsoft.Extensions.Caching.Memory;
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
builder.Services.AddMemoryCache(memoryCacheOptions =>
{
    memoryCacheOptions.ExpirationScanFrequency = TimeSpan.FromMinutes(3);
    MemoryCacheEntryOptions cacheOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(6),
        SlidingExpiration = TimeSpan.FromMinutes(1.5)
    };
});

// Add services to the container.
builder.Services.AddTransient<IControlService, ControlService>();
builder.Services.AddTransient<IPassengersRepository, PassengersRepository>();
builder.Services.AddTransient<IBaggageRepository, BaggageRepository>();
builder.Services.AddTransient<IFlightsRepository, FlightsRepository>();
builder.Services.AddTransient<ICacheRepository, CacheRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
