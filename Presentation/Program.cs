using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.mapperConfig;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//Config ApiVersioning
builder.Services.AddConfigApiVersioning();

//dbStringConnection and jwt vars
builder.Configuration.setConnectionAndJwtVars();

//mapper config
IMapper mapper = mappConfig.registerMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//cors config
string _MyCoors = builder.Services.AddConfigCors(builder);

//jwt config
builder.Services.AddConfigAuthenticationJwt(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfigSwaggerGen();

var app = builder.Build();
app.Environment.Development();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseCustomSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(_MyCoors);

app.Run();
