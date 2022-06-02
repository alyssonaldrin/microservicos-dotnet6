using Microsoft.EntityFrameworkCore;
using MyEcommerce.ProductAPI.Model.Context;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection,
                                                                        new MySqlServerVersion(new Version(8, 0, 29))));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
