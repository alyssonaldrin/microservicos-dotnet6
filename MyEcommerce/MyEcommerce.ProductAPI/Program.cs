using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.ProductAPI.Application.Config;
using MyEcommerce.ProductAPI.Application.RepositoryAbstractions;
using MyEcommerce.ProductAPI.Application.Services;
using MyEcommerce.ProductAPI.Application.ServicesAbstractions;
using MyEcommerce.ProductAPI.Infra.Context;
using MyEcommerce.ProductAPI.Infra.Repository;

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
