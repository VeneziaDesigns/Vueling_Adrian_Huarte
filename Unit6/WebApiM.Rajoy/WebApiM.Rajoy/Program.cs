using M.Domain.RepositoryContracts;
using M.Infrastructure.Data.MarianicoRepositoryImplementation;
using M.Services.ServiceContracts;
using M.Services.ServiceImplementations;

var builder = WebApplication.CreateBuilder(args);

// Configure app settings
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddTransient<IMarianicoService, MarianicoService>();
builder.Services.AddTransient<IMarianicoRepository, MarianicoRepository>();

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
