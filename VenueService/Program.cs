﻿using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VenueService.Dependencyinj;
using VenueService.Infraestructure.GlobalExceptionHandler;  
using Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new() { Title = "VenueService API", Version = "v1" });

    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

builder.Services.AddProblemDetails(); 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>(); 


builder.Services.AddMediatR(typeof(AssemblyMarker).Assembly);


builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

app.UseExceptionHandler(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Opcional según tu necesidad:
// app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
