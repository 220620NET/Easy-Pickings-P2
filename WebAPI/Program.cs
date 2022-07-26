using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<InsuranceDBContext>();
builder.Services.AddDbContext<InsuranceDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P2DB")));
/*// Will need the names changed to have repository and be public
builder.Services.AddSingleton(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("P2DB")));
builder.Services.AddScoped<IClaims, Claims>();
builder.Services.AddScoped<IContact, Contact>();
builder.Services.AddScoped<IInsurance, Insurance>();
builder.Services.AddScoped<IPolicy, Policy>();*/
app.MapGet("/", () => "Hello World!");

app.Run();
