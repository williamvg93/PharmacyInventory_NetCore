using Api.Extensions;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Add AddAPlicationServices */
builder.Services.AddAplicationServices();

/* Add Cors */
builder.Services.ConfigureCors();

/* Add Config RAte Limiting */
builder.Services.ConfigureRatelimiting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/* Use Cors */
app.UseCors("CorsPolicy");

/* Use RateLimiting */
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
