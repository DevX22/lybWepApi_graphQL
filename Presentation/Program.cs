using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.mapperConfig;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string _MyCoors = "SysLyb";

// Add services to the container.

builder.Services.AddControllers();

//dbconfig and jwt
globalVar.Go(builder.Configuration);

//mapper config
IMapper mapper = mappConfig.registerMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//coors
builder.Services.AddCors(options =>
{
    string Cliente = builder.Configuration["ClienteHost"];
    options.AddPolicy(name: _MyCoors,
                      builder =>
                      {
                          builder.AllowAnyOrigin(); //<= permitir todas las rutas
                          builder.WithOrigins(Cliente); //<= esto es para host real
                          //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});
//jwt
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});
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

app.UseCors(_MyCoors);

app.Run();
