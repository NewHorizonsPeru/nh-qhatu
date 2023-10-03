using Microsoft.EntityFrameworkCore;
using nh.qhatu.security.application.core.interfaces;
using nh.qhatu.security.application.core.mappgins;
using nh.qhatu.security.application.core.services;
using nh.qhatu.security.domain.core.Interfaces;
using nh.qhatu.security.infrastructure.data.Context;
using nh.qhatu.security.infrastructure.data.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
        builder.Configuration["CosmosDbSettings:Endpoint"],
        builder.Configuration["CosmosDbSettings:PrimaryKey"],
        databaseName: builder.Configuration["CosmosDbSettings:Database"]);
});

//Services
builder.Services.AddTransient<ISecurityService, SecurityService>();

//Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

//Context
builder.Services.AddTransient<SecurityContext>();

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
