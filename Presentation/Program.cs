using AspNetCoreRateLimit;
using AutoMapper;
using Models.mapperConfig;
using Presentation.GraphQL.Schematics.Mutations;
using Presentation.GraphQL.Schematics.Queries;
using Presentation.GraphQL.Tools;
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

//Middleware IpRateLimit limitador de peticiones por ip
builder.SetConfigureIpRateLimit();

//GraphQL configuración
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
        .AddTypeExtensionCustom();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfigSwaggerGen();

var app = builder.Build();
app.Environment.Development(); //tipo de entorno Development / Production

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseCustomSwaggerUI();
    app.UseGraphQLAltair("/altair");
}

app.UseWebSockets();

app.UseAuthentication();

app.UseIpRateLimiting();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseMiddleware(typeof(ErrorMiddleware));

app.MapControllers();

app.MapGraphQL();

app.UseCors(_MyCoors);

app.Run();
