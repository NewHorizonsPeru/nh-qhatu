using Microsoft.EntityFrameworkCore;
using nh.qhatu.infrasctructure.crosscutting.Jwt;
using nh.qhatu.security.api.Middleware;
using nh.qhatu.security.application.core.interfaces;
using nh.qhatu.security.application.core.mappgins;
using nh.qhatu.security.application.core.services;
using nh.qhatu.security.domain.core.Interfaces;
using nh.qhatu.security.infrastructure.data.Context;
using nh.qhatu.security.infrastructure.data.Repositories;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);

//Steeltoe Config Server
builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddAutoMapper(typeof(EntityToDtoProfile), typeof(DtoToEntityProfile));

builder.Services.AddDbContext<SecurityContext>(opt =>
{
    opt.UseCosmos(
        builder.Configuration["cosmosDbSettings:endpoint"],
        builder.Configuration["cosmosDbSettings:primaryKey"],
        databaseName: builder.Configuration["cosmosDbSettings:database"]);
});

//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Cross-Cutting
builder.Services.AddTransient<IJwtManager, JwtManager>();

//Context
builder.Services.AddTransient<SecurityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
