using Microsoft.EntityFrameworkCore;
using nh.qhatu.infrastructure.bus.settings;
using nh.qhatu.infrastructure.ioc;
using nh.qhatu.payment.application.interfaces;
using nh.qhatu.payment.application.mappings;
using nh.qhatu.payment.application.services;
using nh.qhatu.payment.domain.interfaces;
using nh.qhatu.payment.infrastructure.context;
using nh.qhatu.payment.infrastructure.repositories;
using Steeltoe.Common.Contexts;
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
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<PaymentContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IPaymentService, PaymentService>();

//Repositories
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

//Context
builder.Services.AddTransient<PaymentContext>();

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

app.MapControllers();

app.Run();
