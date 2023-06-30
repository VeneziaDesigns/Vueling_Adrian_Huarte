using CrudApi.DbContextFolder;
using CrudDomain.RepositoryContracts;
using CrudInfrastructure.Data.RepositoryImplementations;
using CrudServices.ServiceContracts;
using CrudServices.ServiceImplementations;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Configure database
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<ApiCrudNet6Context>(x => x.UseSqlServer(connectionString));

// Servicio de la cache
builder.Services.AddMemoryCache(x =>
{
    x.SizeLimit = 2048;
    x.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
});

// Add services to the container.
builder.Services.AddTransient<ICrudService, CrudService>();
builder.Services.AddTransient<ICrudRepository, CrudRepository>();
builder.Services.AddTransient<ICacheRepository, CacheRepository>();
builder.Services.AddTransient<IBackupRepository, BackupRepository>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
