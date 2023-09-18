using Microsoft.EntityFrameworkCore;
using nh.qhatu.common.application.core.interfaces;
using nh.qhatu.common.application.core.mappings;
using nh.qhatu.common.application.core.services;
using nh.qhatu.common.domain.core.interfaces;
using nh.qhatu.common.infrastructure.data.context;
using nh.qhatu.common.infrastructure.data.repositories;
using nh.qhatu.infra.bus.settings;
using nh.qhatu.infra.ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile));

//SQL Server
builder.Services.AddDbContext<QhatuContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("QhatuConnection"));
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
builder.Services.AddTransient<QhatuContext>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
