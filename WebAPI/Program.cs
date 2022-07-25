using Models;
using DataAccess;
using Services;
using WebAPI.WebControllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
// Will need the names changed to have repository and be public
builder.Services.AddSingleton(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("P2DB")));
builder.Services.AddScoped<IClaims, Claims>();
builder.Services.AddScoped<IContact, Contact>();
builder.Services.AddScoped<IInsurance, Insurance>();
builder.Services.AddScoped<IPolicy, Policy>();
app.MapGet("/", () => "Hello World!");

app.Run();
