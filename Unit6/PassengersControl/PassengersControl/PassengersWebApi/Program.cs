using Business.ServiceContracts;
using Business.ServiceImplementations;
using Domain.RepositoryContracts;
using Infrastructure.Data.RepositoryImplementations;

var builder = WebApplication.CreateBuilder(args);

// Configure app settings
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddTransient<IPassengersService, PassengersService>();
builder.Services.AddTransient<IPassengersRepository, PassengersRepository>();
builder.Services.AddTransient<IBaggageRepository, BaggageRepository>();
builder.Services.AddTransient<IFlightRepository, FlightRepository>();


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
