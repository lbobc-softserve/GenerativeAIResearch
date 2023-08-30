using GenerativeAIResearch.Application.Client;
using GenerativeAIResearch.Application.Config;
using GenerativeAIResearch.Application.Handlers;
using GenerativeAIResearch.Application.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<CountriesApiClient>();
builder.Services.AddScoped<IRequestHandler<GetCountriesRequest,
                           IEnumerable<GetCountryResponse>>,
                           GetCountriesRequestHandler>();

builder.Services.Configure<CountriesApiOptions>(
    builder.Configuration.GetSection(
        key: nameof(CountriesApiOptions)));
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