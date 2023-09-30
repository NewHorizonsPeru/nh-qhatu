using Microsoft.EntityFrameworkCore;
using nh.qhatu.customer.application.core.interfaces;
using nh.qhatu.customer.application.core.mappings;
using nh.qhatu.customer.application.core.services;
using nh.qhatu.customer.domain.core.interfaces;
using nh.qhatu.customer.infrastructure.data.context;
using nh.qhatu.customer.infrastructure.data.repositories;
using nh.qhatu.infra.bus.settings;
using nh.qhatu.infra.ioc;
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
builder.Services.AddDbContext<QhatuContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<ICustomerService, CustomerService>();

//Repositories
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();


//Context
builder.Services.AddTransient<QhatuContext>();

//CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

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
