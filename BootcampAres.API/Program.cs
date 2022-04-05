using BootcampAres.DataAccess;
using BootcampAres.DataAccess.Contracts;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using BootcampAres.Application.Services;
using BootcampAres.Application.Contracts.Services;
using BootcampAresCrossCutting.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IoC.Register(builder.Services, builder.Configuration);

string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BootcampAresContext>(
item => item.UseMySql(
mySqlConnectionStr,
ServerVersion.AutoDetect(mySqlConnectionStr)
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
