var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Servicio de la cache
builder.Services.AddMemoryCache(x => 
{
    x.SizeLimit = 1024;
    x.ExpirationScanFrequency = TimeSpan.FromMinutes(1);
});
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
