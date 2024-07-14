using APICodigoEFC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CodigoContext>(
options =>
{
    // cadena de conexion docker dbeaver
    options.UseSqlServer("Data Source=localhost,1435;" +
    "Initial Catalog=CodigoDB; User ID=sa; Password=p@$$w0rd022; " +
    "TrustServerCertificate=True;");

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
