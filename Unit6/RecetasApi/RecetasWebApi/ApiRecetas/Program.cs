using System.Reflection;
using RecetasDomain.RepositoryContracts;
using RecetasRepository.RepositoryImplementations;
using RecetasService.ServiceContracts;
using RecetasService.ServiceImplementations;

var builder = WebApplication.CreateBuilder(args);

// Configure app settings
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IPriceIngredientsRepository, PriceIngredientsRepository>();
builder.Services.AddTransient<IPriceForCookingRepository, PriceForCookingRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o => // Esto pal XML
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
