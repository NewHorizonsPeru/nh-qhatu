using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.application.interfaces;
using nh.qhatu.homedelivery.application.mappings;
using nh.qhatu.homedelivery.application.services;
using nh.qhatu.homedelivery.domain.interfaces;
using nh.qhatu.homedelivery.infrastructure.context;
using nh.qhatu.homedelivery.infrastructure.repositories;
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
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<HomeDeliveryContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IHomeDeliveryService, HomeDeliveryrService>();

//Repositories
builder.Services.AddTransient<IHomeDeliveryRepository, HomeDeliveryRepository>();


//Context
builder.Services.AddTransient<HomeDeliveryContext>();

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
