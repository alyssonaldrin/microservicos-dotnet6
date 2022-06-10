using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.ProductAPI.Config;
using MyEcommerce.ProductAPI.Model.Context;
using MyEcommerce.ProductAPI.Repository;
using MyEcommerce.ProductAPI.Repository.Implementations;
using MyEcommerce.ProductAPI.Services;
using MyEcommerce.ProductAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

// Add services to the container.

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection,
                                                                        new MySqlServerVersion(new Version(8, 0, 29))));
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
