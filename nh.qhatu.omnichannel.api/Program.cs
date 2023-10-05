using Microsoft.EntityFrameworkCore;
using nh.qhatu.infra.bus.settings;
using nh.qhatu.infra.ioc;
using nh.qhatu.omnichannel.application.interfaces;
using nh.qhatu.omnichannel.application.mappings;
using nh.qhatu.omnichannel.application.services;
using nh.qhatu.omnichannel.domain.interfaces;
using nh.qhatu.omnichannel.infrastructure.http.repositories;
using nh.qhatu.omnichannel.infrastructure.sqlServer.context;
using nh.qhatu.omnichannel.infrastructure.sqlServer.repositories;
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
builder.Services.AddDbContext<OmnichannelContext>(config =>
{
    config.UseMySQL(builder.Configuration.GetValue<string>("connectionStrings:qhatuConnection"));
});

//HTTP Clients
builder.Services.AddHttpClient("CommonService", cf =>
{
    cf.BaseAddress = new Uri(builder.Configuration["qhatuServices:commonService"]);
});

//RabbitMQ Settings
builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("rabbitMqSettings"));

//IoC
builder.Services.RegisterServices(builder.Configuration);

//Services
builder.Services.AddTransient<IOrderService, OrderService>();

//Repositories
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();


//Context
builder.Services.AddTransient<OmnichannelContext>();

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

app.MapControllers();

app.Run();