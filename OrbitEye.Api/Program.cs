using Microsoft.EntityFrameworkCore;
using OrbitEye.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrbitEyeDbContext>(options =>
    options.UseOracle(
        builder.Configuration.GetConnectionString("OracleConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();