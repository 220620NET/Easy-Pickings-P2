using Services;
using Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<InsuranceDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("P2DB")));
app.MapGet("/", () => "Hello World!");

app.Run();
