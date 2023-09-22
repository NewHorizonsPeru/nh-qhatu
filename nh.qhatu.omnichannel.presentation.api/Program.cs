using Microsoft.EntityFrameworkCore;
using nh.qhatu.infra.bus.settings;
using nh.qhatu.infra.ioc;
using nh.qhatu.omnichannel.application.core.interfaces;
using nh.qhatu.omnichannel.application.core.mappings;
using nh.qhatu.omnichannel.application.core.services;
using nh.qhatu.omnichannel.domain.core.interfaces;
using nh.qhatu.omnichannel.infrastructure.data.context;
using nh.qhatu.omnichannel.infrastructure.data.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//AutoMapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

//SQL Server
builder.Services.AddDbContext<QhatuContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetConnectionString("QhatuConnection"));
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IOrderService, OrderrService>();

//Repositories
builder.Services.AddTransient<IOrderRepository, OrderRepository>();


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

app.MapControllers();

app.Run();