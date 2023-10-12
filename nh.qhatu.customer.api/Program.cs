using Microsoft.EntityFrameworkCore;
using nh.qhatu.customer.application.interfaces;
using nh.qhatu.customer.application.mappings;
using nh.qhatu.customer.application.services;
using nh.qhatu.customer.domain.interfaces;
using nh.qhatu.customer.infrastructure.context;
using nh.qhatu.customer.infrastructure.repositories;
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
builder.Services.AddDbContext<CustomerContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<ICustomerService, CustomerService>();

//Repositories
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();


//Context
builder.Services.AddTransient<CustomerContext>();

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
