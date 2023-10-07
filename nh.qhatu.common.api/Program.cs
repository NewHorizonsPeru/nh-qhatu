using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.application.interfaces;
using nh.qhatu.common.application.mappings;
using nh.qhatu.common.application.services;
using nh.qhatu.common.domain.interfaces;
using nh.qhatu.common.infrastructure.context;
using nh.qhatu.common.infrastructure.repositories;
using nh.qhatu.infrastructure.bus.settings;
using nh.qhatu.infrastructure.ioc;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile));

//SQL Server
builder.Services.AddDbContext<CommonContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<ICommonService, CommonService>();

//Repositories
builder.Services.AddTransient<IBrandRepository, BrandRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICreditCardTypeRepository, CreditCardTypeRepository>();

//Context
builder.Services.AddTransient<CommonContext>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//Consul
builder.Services.AddDiscoveryClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
