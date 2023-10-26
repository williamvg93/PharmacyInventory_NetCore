using System.Reflection;
using Api.Extensions;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

/* Add AutoMApper */
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

/* Add Db Conection */
builder.Services.AddDbContext<PharmaInventContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConnec");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});

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
