using Microsoft.EntityFrameworkCore;
using Prova.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Oracle EF Core
var conn = builder.Configuration.GetValue<string>("OracleConnection");
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseOracle(conn));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
